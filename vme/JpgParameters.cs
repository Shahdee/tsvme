using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace vme
{
    class JpgParameters
    {
        public JpegDictionary jdic;  // словарь маркеров 

        public JpgParameters(){
            jdic = new JpegDictionary();

            tree = new TBinarySTree();  // новое дерево Хаффмана

            ptr = 0;  // указатель для массива сегмента ecs
        }

        public ushort commentLength;
        public List<byte> comment;
        public TBinarySTree tree;
        public List<byte> tableHuff;
        public List<string> hcodes;
        /* ВРЕ - Описание таблицы Хаффмана*/      
        public ushort huffmanLength;
        public byte Tc; // класс таблицы  0=DC, 1=AC
        public byte Th; // идентификатор назначения таблицы
        public List<byte> BITS;
        public List<byte> HUFFVAL;
        public List<byte> newlength;

        public int[] MinCode;
        public int[] MaxCode;
        public int[] ValPtr;
        public List<byte> HUFFSIZE;
        public List<int> HUFFCODE;
        public List<int> EHUFFCO;
        public List<byte> EHUFSI;
        public int ptr;

        /*SOF - Описание кадра */

        public ushort frameLength; // длина кадра
        public byte P;     // точность сэмпла
        public ushort Y;   // если 0 - то тогда число линий определяется DNL маркером и параметрами в конце первого скана (?)
        public ushort X;   // число сэмплов на линию
        public byte Nf;    // число компонентов изображения в кадре

        /* Component-spec. parameters - параметры компонентов спецификации */
        /*
        public byte C;     // идентификатор компонента 
        public byte H;     // фактор горизонтального сэмплинга 4bits
        public byte V;     //фактор вертикального сэмплинга 4bits
        public byte Tq;    // селектор источника таблицы квантизации
         * */

        public byte[] chvtq;    // сюда будут заносится все C H V Tq параметры, поскольку в заголовке кадра их всего Nf штук

        /*EOF - конец описания кадра*/

        //---------------------------------------------------------------------------------------------------------------------------

        /* SOS -  Описание скана */

        public int scanLength;     // длина заголовка кадра
        public int Ns;             // число компонентов изображения в скане
        public int Ss;             // Используется для выбора предсказателя
        public int Se;             // Конец спектральной выборки , в lossless должен быть равен нулю
        public int Ah;             // Successive approximation bit position high 
        public int Al;             // Successive approximation bit position low or point transform 

        public List<byte> esc;
        public List<int> dc;
       
        public int lastK;
        
        /* DNL Segment */
        public ushort dnlLength;
        public ushort numLines;

        /* Component-spec. parameters - параметры компонентов спецификации */
        /*
        public int Cs;             // селектор компонента скана
        public int Td;             // DC entropy coding table destination selector
        public int Ta;             // AC entropy coding table destination selector
         * */

        public byte[] ctt;    // сюда будут заносится все C H V Tq параметры, поскольку в заголовке кадра их всего Nf штук

        /* EOS - конец описания скана */
    }
}
