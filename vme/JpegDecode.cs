using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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


        /* Извлекает заголовок скана изображения */
        private void RetrieveScanHeader(byte[] frag, ref int i) 
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

            property.Ss = frag[i];
            i++;
            property.Sc = frag[i];
            i++;
            b0 = (byte)(frag[i] >> 4);
            property.Ah = b0;
            b1 = (byte)(frag[i] << 4);
            property.Al = (byte)(b1 >> 4);  // in lossless mode of operations, this parameter specifies the point transform Pt.
            i++;
        
        }

        private void GenerateHuffSizeTable() 
        {
            byte k = 0;
            byte l = 1;
            byte j = 1; // j=1 &!
            byte lastk;
            property.huffsize = new List<byte>();

            while (l < 16)
            {
                if (j > property.lll[l])  // if j>bits(j)
                {
                    l++;
                    j = 1;
                    
                    
                }
                else
                {
                    property.huffsize.Add(l);
                    k++;
                    j++;
                    continue;
                }



            }
            property.huffsize[k] = 0;
            lastk = k;

            
        }

        /* Извлекает таблицу Хаффмана */
        private void RetrieveHuffmanTable(byte[] frag, ref int i)
        {
            Marker type2=Marker.Dummy;
            property.tableHuff = new List<byte>();
            property.lll = new List<byte>();
            property.vvv = new List<byte>();
            byte b0;
            byte b1;
            byte acc=0;
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
            for (byte k = 0; k < 16; k++)
            {
                property.lll.Add(property.tableHuff[j]);
                if(property.tableHuff[j]!=0)
                    acc+=property.tableHuff[j];
                j++;
            }
            for (byte k = 0; k < acc; k++)
            {
                property.vvv.Add(property.tableHuff[j]);
                j++;
            }
            GenerateHuffSizeTable();


        
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
                            { RetrieveScanHeader(frag,ref i);
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
        
        }


    };
}
