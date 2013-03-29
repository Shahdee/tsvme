using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;


namespace vme
{
    enum Marker 
    {
        FrameHeader = 0,
        ScanHeader = 1,
        ImageStart =3,
        ImageEnd = 4,
        Dummy = 5,
        HuffmanTables =6,
        Comment =7,
        DNLSegment =8,
        Restart=9,
        RestartInterval=10,

    };

    class JpegDecode
    {
        public JpgParameters property;
        private int  pos;
        private Marker type;

        public JpegDecode() 
        {
            property = new JpgParameters();
            type = new Marker();
            pos = 0;
        }

        private Marker RetrieveMarkerType(byte b0, byte b1)
        {
            string h0 = b0.ToString("X");
            string h1 = b1.ToString("X");
            string hh = h0 + h1;
            if (property.jdic.jdict.ContainsKey(h0 + h1))
            {
                switch (h0 + h1) 
                {
                    case "FFFE": return Marker.Comment;
                    case "FFC4": return Marker.HuffmanTables;
                    case "FFC0":
                    case "FFC1":
                    case "FFC2":
                    case "FFC3":
                    case "FFC5":
                    case "FFC6":
                    case "FFC7":
                        return Marker.FrameHeader;
                    case "FFDA":
                        return Marker.ScanHeader;
                    case "FFDC":
                        return Marker.DNLSegment;
                    case "FFD0":
                    case "FFD1":
                    case "FFD2":
                    case "FFD3":
                    case "FFD4":
                    case "FFD5":
                    case "FFD6":
                    case "FFD7":
                        return Marker.Restart;
                    case "FFD9":
                        return Marker.ImageEnd;
                    case "FFDD":
                        return Marker.RestartInterval;

                    default: return Marker.Dummy;
                }
            }

            return Marker.Dummy;
        
        }

        /* Извлекает заголовок кадра изображения */
        private void RetrieveFrameHeader(byte[] frag, ref int i)
        {
            byte k=0;
            byte b0 = frag[i];
            i++;
            byte b1 = frag[i];
            property.frameLength = Convert.ToUInt16((b0 << 8 )+ b1);
            i++;
            property.P = frag[i];
            i++;
            b0 = frag[i];
            i++;
            b1 = frag[i];
            property.Y = Convert.ToUInt16((b0 << 8 ) + b1);
            i++;
            b0 = frag[i];
            i++;
            b1 = frag[i];
            property.X = Convert.ToUInt16((b0 << 8 ) + b1);
            i++;
            b0 = frag[i];
            property.Nf = b0;
            i++;
            property.chvtq = new byte[property.Nf*4];

            for (byte j = 0; j < property.Nf; j++) 
            {
                property.chvtq[k] = frag[i];
                i++;
                k++;
                b0 = (byte) (frag[i] >> 4);
                property.chvtq[k] = b0;
                k++;
                b1 = (byte)(frag[i] << 4);
                property.chvtq[k] = (byte) (b1 >> 4);
                k++;
                i++;
                property.chvtq[k] = frag[i];

            
            }
        
        }

        /* Retrieve entropy codede segment*/
        private void RetrieveECS(byte[] frag, ref int i, int elementLength)
         {
             property.esc = new List<byte>();
             byte b0;
             byte b1;

             while ((i < elementLength - 1) && (type == Marker.ScanHeader))  // пока мы не дошли до конца Jpeg файла
             {
                 b0 = frag[i];
                 b1 = frag[i + 1];
                 // согласно ISO 10918-1 маркер может быть только "FF + 1..254"
                 if (b0 == 255 && b1 != 0 && b1 != 255)
                 {
                     type = RetrieveMarkerType(b0, b1);
                     i += 2; // установили указатель на элементе данных сразу после маркера
                 }
                 else
                 {
                     property.esc.Add(b0);
                     i++;
                 }
             }
         
         }

        /* Извлекает заголовок скана изображения */
         private void RetrieveScanHeader(byte[] frag, ref int i, int elementLength) 
        {
            byte k = 0;
            byte b0 = frag[i];
            i++;
            byte b1 = frag[i];
            property.scanLength = Convert.ToUInt16((b0 << 8) + b1);
            i++;
            property.Ns = frag[i];
            i++;
            property.ctt = new byte[property.Ns*3];

            for (byte j = 0; j < property.Ns; j++)
            {
                property.ctt[k] = frag[i];
                i++;
                k++;
                b0 = (byte)(frag[i] >> 4);
                property.ctt[k] = b0;
                k++;
                b1 = (byte)(frag[i] << 4);
                property.ctt[k] = (byte)(b1 >> 4);
                k++;
                i++;

            }

            property.Ss = frag[i]; // in lossless mode of operations this is a predictor
            i++;
            property.Se = frag[i]; // in lossless mode of operations this has no meaning
            i++;
            b0 = (byte)(frag[i] >> 4);
            property.Ah = b0;
            b1 = (byte)(frag[i] << 4);
            property.Al = (byte)(b1 >> 4);  // in lossless mode of operations, this parameter specifies the point transform Pt.
            i++;

            // извлечение ECS
            RetrieveECS(frag, ref  i, elementLength);
        
        }

        /* сегмент DNL предоставляет механизм для определения или отображения числа линий в кадре.   */
        private void RetrieveDNLSegment(byte[] frag, ref int i)
        {
            byte b0 = frag[i];
            i++;
            byte b1 = frag[i];
            property.dnlLength = Convert.ToUInt16((b0 << 8) + b1);
            i++;
            b0 = frag[i];
            i++;
            b1 = frag[i];
            property.numLines = Convert.ToUInt16((b0 << 8) + b1);
            i++;

            
        }

         /* Построение дерева Хаффмана для двух таблиц*/
        /* Алгоритм:  в каком бы мы узле не находились, всегда пытаемся добавить значение в левую ветвь.
         * А если она занята, то в правую. А если и там нет места, то возвращаемся на уровень выше, и пробуем оттуда.
         * Остановиться надо на уровне равном длине кода. Левым ветвям соответствует значение 0, правым 1.  */

        /*Не нужно каждый раз начинать с вершины. Добавила значение - вернись на уровень выше.
         * Правая ветвь существует? Если да, то иду опять вверх.
         * Если нет, то создаю правую ветвь и иду туда*/

        private void BuildHuffmanTree(ref TreeNode root, ref int ctr, int acc, ref int path, ref int i, string code)
        {

            while (ctr < acc) // пока мы не заполнили все дерево
            {
                if (root == null)
                {
                    root = new TreeNode();
                    path++;
                    // если мы достигли нужной глубины дерева (то есть длины кода, которая приходится на значение)
                    if (path == property.newlength[i])
                    {
                        root.value = property.HUFFVAL[i];
                        root.code = code;
                        property.hcodes.Add(code);
                        ctr++;
                        i++;
                        path--;
                        return;
                    }
                }
                else
                {
                    BuildHuffmanTree(ref root.left, ref ctr, acc, ref path, ref i, code+"0");  // налево
                    if (root.right == null)
                    {
                        BuildHuffmanTree(ref root.right, ref ctr, acc, ref path, ref i, code+"1"); // направо
                    }
                    path--;
                    return;
                }
            }
        }
      
        /* перестраивает массив для дерева Хаффмана*/
        private void RebuildArray()
        {
            byte j=0;
            property.newlength = new List<byte>();
            for (byte i = 0; i < property.BITS.Count; i++ )
            {
                if (property.BITS[i] != 0)
                {
                    if (property.BITS[i] > 1)
                    {
                        for (byte k = 0; k < property.BITS[i] ; k++) 
                        {
                            property.newlength.Add(i);
                            j++;
                        }
                    }
                    else
                    {
                        property.newlength.Add(i);
                        j++;
                    }
                }
            }
            
        }

        private void GenerateSizeTable()
        {
            property.HUFFSIZE = new List<byte>();
            int k = 0;
            byte length = 1;
            int j = 1;

            while (length < 16) 
            {
                if (j > property.BITS[length])
                {
                    length++;
                    j = 1;
                }
                else 
                {
                    property.HUFFSIZE.Add(length);
                    k++;
                    j++;
                }
            
            }
            property.HUFFSIZE.Add(0); //!!!
            property.lastK = k; //!!!

        }

        private void GenerationOfHuffmanCodes() 
        {
            int code=0;
            int k = 0;
            property.HUFFCODE = new List<int>();
            byte esel = property.HUFFSIZE[0];
            while (true) 
            {
                property.HUFFCODE.Add(code);
                code++;
                k++;
                if (property.HUFFSIZE[k] != esel)
                {
                    if (property.HUFFSIZE[k] == 0)
                    {
                        return;
                    }
                    else 
                    {
                        while(property.HUFFSIZE[k]!=esel)
                        {
                            code = code << 1;
                            esel++;
                        }
                    }
                }
            
            }

        
        }

        private void Ordering()
        {
            int k=0;
            int length;
            property.EHUFFCO = new List<int>();
            property.EHUFSI = new List<byte>();
            
            while(k<property.lastK)
            {
                length = property.HUFFVAL[k];
                property.EHUFFCO.Add(property.HUFFCODE[k]);
                property.EHUFSI.Add(property.HUFFSIZE[k]);
                k++;
            }

        }
         
        /* Извлекает таблицу Хаффмана */
        private void RetrieveHuffmanTable(byte[] frag, ref int i)
        {
            Marker type2=Marker.Dummy;
            property.tableHuff = new List<byte>();
            property.BITS = new List<byte>();
            property.HUFFVAL = new List<byte>();
            property.hcodes = new List<string>();
            byte b0;
            byte b1;
            int acc=0;
            ushort j = 0;
            while (type2 == Marker.Dummy)
            {   
                b0=frag[i];
                b1=frag[i+1];
                if (b0 == 255 && b1 != 0 && b1 != 255)
                {
                    type2 = RetrieveMarkerType(b0, b1);
                }

                if (type2 == Marker.Dummy)
                {
                    property.tableHuff.Add(frag[i]);
                    i++;
                }
              
            }
            b0 = property.tableHuff[j];
            j++;
            b1 = property.tableHuff[j];
            property.huffmanLength = Convert.ToUInt16((b0<<8)+b1);
            j++;

            b0 = (byte)(property.tableHuff[j] >> 4);
            property.Tc = b0;
            b1 = (byte)(property.tableHuff[j] << 4);
            property.Th = (byte)(b1 >> 4);
            j++;
            property.BITS.Add(0);  // хак для таблицы HUFFSIZE
            for (byte k = 0; k < 16; k++)
            {
                property.BITS.Add(property.tableHuff[j]);
                if(property.tableHuff[j]!=0)
                    acc+=property.tableHuff[j];
                j++;
            }
            for (int k = 0; k < acc; k++)
            {
                property.HUFFVAL.Add(property.tableHuff[j]);
                j++;
            }

            int path=-1;
            int ii=0;
            int ctr=0;
            string code = "";
            RebuildArray();

            GenerateSizeTable();// HUFFSIZE
            GenerationOfHuffmanCodes(); // HUFFCODES
            BuildHuffmanTree(ref property.tree.root, ref  ctr, acc, ref  path, ref  ii,code);
            Ordering();


        }

        private void RetrieveComment(byte[] frag, ref int i)
        {
            byte b0 = frag[i];
            i++;
            byte b1 = frag[i];
            property.comment = new List<byte>();
            property.commentLength = Convert.ToUInt16((b0<<8)+b1);
            i++;
            for (ushort j = 0; j < property.commentLength-2; j++)
            { 
                property.comment.Add(frag[i]);
                i++;
            }

        
        }

        /*  Обход по дереву Хаффмана во время чтения ECS */
        private void GoGoTree(ref TreeNode root, byte bit, ref bool node, ref int val)
        {
            if (bit == 0)
            {
                if (root.left != null)
                {
                    root = root.left;
                    if (root.left == null && root.right == null)
                    {
                        node = true;
                        val = root.value;
                        return;
                    }

                }

            }
            if (bit == 1)
            {
                if (root.right != null)
                {
                    root = root.right;
                    if (root.left == null && root.right == null)
                    {
                        node = true;
                        val = root.value;
                        return;
                    }

                }

            }
        
        }

        private void CheckHuffCode(string acc, ref bool node,ref int val)
        {
            for (int i = 0; i < property.hcodes.Count; i++) 
            {
                if (acc == property.hcodes[i])
                {
                    val = property.HUFFVAL[i];
                    node = true;

                }
            }
        
        }

        private void DecoderTableGeneration() 
        {
            property.MinCode = new int[17];
            property.MinCode[0] = -1;
            property.MaxCode = new int[17];
            property.MaxCode[0] = -1;
            property.ValPtr = new int[17];  // содержит индекс начала списка значений в HUFFVAL которые декодируются кодами длины length
            

            int length = 0;
            int j = 0;
            
            while(true)
            {
                length++;
                if(length>16)
                    return;
                else
                {
                    if(property.BITS[length]==0)
                    {
                        property.MaxCode[length] = -1;
                        property.MinCode[length] = -1;

                    }
                    else// нет
                    {
                        property.ValPtr[length] = j; // содержит индекс начала списка значений в HUFFVAL которые декодируются кодами длины length
                        property.MinCode[length] = property.HUFFCODE[j]; // записываем минимальный код для данной длины 
                        j = j+ property.BITS[length] - 1; // диапазон в котором находятся коды для данной длины
                        property.MaxCode[length] = property.HUFFCODE[j]; //записываем максимальный код для данной длины 
                        j++;

                    }
                   
                }
            }

        }

        private void DecodeCycle() 
        {
            property.dc = new List<int>();
            byte cnt = 0;
            int T = 0;

            while(property.ptr < property.esc.Count)
            {
                property.dc.Add(Decode(ref cnt));
            }
        }
        
        /* The DECODE procedure decodes an 8-bit value  which,  for  the DC coefficient, determines the difference magnitude category   ISO 10918-1 */
        /* Процедура DECODE декодирует 8 битовое значение которое, для DC коэффициентов определяет difference magnitude category ISO 10918-1*/
        
        private int Decode(ref byte cnt) 
        {
            int length = 1; // длина кода
            byte val;
            byte by1 = 0;
            int code = NextBit(ref cnt, ref by1); //
            int j;

            while (code > property.MaxCode[length]) 
            {
                length++;
                code = (code << 1) + NextBit(ref cnt, ref by1); //
                
            }

            j = property.ValPtr[length];
            j = j + code - property.MinCode[length];
            val = property.HUFFVAL[j];

            return val;
        }
         
        
       /* Places next ssss bits into the low order of bits with MSB first. It calls NEXTBIT and it returns the value of DIFF to the calling procedure  */
        /*
        private int ReceiveSSSS(int ssss)
        {
            int l = 0;
            int v = 0;
            while(l!= ssss) 
            {
                v = (v << 1) + NextBit(); //  учесть входной параметр
                l++;
            }
            return v;
        }
         * */
        

        private byte NextByte() 
        {
            if (property.ptr < property.esc.Count) 
            {
                property.ptr++;
                return property.esc[property.ptr-1];
                
            }
            return 0; // 
        }

        /* NEXTBIT reads the next bit of compressed data and passes it to higher level routines. It also intercepts and removes stuff bytes and detects markers.
         NEXTBIT reads the bits of a byte starting with a MSB
         */
        private int NextBit(ref byte cnt, ref byte by1) // учесть предыдущий байт!
        {

            int i = 0;
            byte by2=0;
            int bit=0;

            if (cnt == 0)
            {
                by1 = NextByte();
                cnt = 8;
                if (by1 == 255) 
                {
                    by2 = NextByte();
                    if (by2 != 0)
                    {
                        //Error
                        // Process DNL marker
                    }
                    else//yes
                    {
                        
                    }
                }

            }
            //no
            
            bit = by1 >> 7;
            cnt--;
            by1 = (byte)(by1 << 1);

            return bit;
        }
        
        
        public void JpegDecoder(byte[] frag,int elementLength)
        {

            byte b0;
            byte b1;
            int i = 0;

            while ((i < elementLength - 1) && (type !=Marker.ImageEnd) )  // пока мы не дошли до конца Jpeg файла
            {
                
                    b0 = frag[i];
                    b1 = frag[i + 1];
                    // согласно ISO 10918-1 маркер может быть только "FF + 1..254"
                    if (b0 == 255 && b1 != 0 && b1 != 255)
                    {
                        type = RetrieveMarkerType(b0, b1);
                        i += 2; // установили указатель на элементе данных сразу после маркера
                    }
                    else
                        i++;
                    switch (type)
                    {
                        //case Marker.ImageStart:  
                        case Marker.Comment: 
                            {
                                RetrieveComment(frag, ref i);
                                type = Marker.Dummy;
                                continue;
                            }
                        case Marker.FrameHeader: 
                            {
                                RetrieveFrameHeader(frag, ref i);
                                type = Marker.Dummy;
                                continue; 
                            }
                        case Marker.ScanHeader: 
                            { RetrieveScanHeader(frag,ref i, elementLength);
                              type = Marker.Dummy;
                              continue;
                            }
                        case Marker.DNLSegment: 
                            {
                                RetrieveDNLSegment(frag, ref i);
                                type = Marker.Dummy;
                                continue;
                                
                            }
                        case Marker.HuffmanTables:
                            {
                                RetrieveHuffmanTable(frag, ref i);
                                type = Marker.Dummy;
                                continue;
                            }
                        case Marker.ImageEnd: return;
                        default: { pos++; continue; }
                    }
                
            }
            // Прочитали весь файл, теперь декодируем ECS
            //DecodeECS();
            DecoderTableGeneration();
            DecodeCycle();
        
        }


    };
}
