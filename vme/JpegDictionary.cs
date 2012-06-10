using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vme
{
    class JpegDictionary
    {
        public Dictionary<string, string>jdict = new Dictionary<string, string>() 
        {
        /*Start of frame markers  - маркеры начала кадра*/
        {"FFC0","Baseline DCT"},
        {"FFC1","Extended sequential DCT"},
        {"FFC2","Progressive DCT"},
        {"FFC3","Lossless (sequential)"},
        {"FFC4","Define Huffman tables"},
        {"FFC5","Differential sequential DCT"},
        {"FFC6","Differential progressive DCT"},
        {"FFC7","Differential lossless"},
        {"FFC8","...Reserved for JPG extensions"},
        {"FFC9","Extended sequential DCT"},
        {"FFCA","Progressive DCT"},
        {"FFCB","Lossless(sequential)"},
        /**/
        {"FFCC","Define arithmetic coding conditioning(s)"},
        /* Start of frame markers  Differential Huffman coding - маркеры начала кадра Диферренциальное кодирование по Хаффману*/
        {"FFCD","Differential sequential DCT"},
        {"FFCE","Differential progressive DCT"},
        {"FFCF","Differential lossless(sequential)"},

        /*Restart interval termination*/
        {"FFD0","Restart with module 8 count (m)"},
        {"FFD1","Restart with module 8 count (m)"},
        {"FFD2","Restart with module 8 count (m)"},
        {"FFD3","Restart with module 8 count (m)"},
        {"FFD4","Restart with module 8 count (m)"},
        {"FFD5","Restart with module 8 count (m)"},
        {"FFD6","Restart with module 8 count (m)"},
        {"FFD7","Restart with module 8 count (m)"},

        /*Start and end of image markers - маркеры начала и конца изображения */
        {"FFD8","Start of image"},
        {"FFD9","End of Image"},

        /*  */
        {"FFDA","Start of scan"},
        {"FFDB","Define quantization tables"},
        {"FFDC","Define number of lines"},
        {"FFDD","Define restart interval"},
        {"FFDE","Define hierachical progression"},
        {"FFDF","Expand reference component"},

        {"FFE0","...Reserved for application segments"},
        {"FFE1","...Reserved for application segments"},
        {"FFE2","...Reserved for application segments"},
        {"FFE3","...Reserved for application segments"},
        {"FFE4","...Reserved for application segments"},
        {"FFE5","...Reserved for application segments"},
        {"FFE6","...Reserved for application segments"},
        {"FFE7","...Reserved for application segments"},
        {"FFE8","...Reserved for application segments"},
        {"FFE9","...Reserved for application segments"},
        {"FFEA","...Reserved for application segments"},
        {"FFEB","...Reserved for application segments"},
        {"FFEC","...Reserved for application segments"},
        {"FFED","...Reserved for application segments"},
        {"FFEE","...Reserved for application segments"},
        {"FFEF","...Reserved for application segments"},

        {"FFF0","...Reserved for JPEG extensions"},
        {"FFF1","...Reserved for JPEG extensions"},
        {"FFF2","...Reserved for JPEG extensions"},
        {"FFF3","...Reserved for JPEG extensions"},
        {"FFF4","...Reserved for JPEG extensions"},
        {"FFF5","...Reserved for JPEG extensions"},
        {"FFF6","...Reserved for JPEG extensions"},
        {"FFF7","...Reserved for JPEG extensions"},
        {"FFF8","...Reserved for JPEG extensions"},
        {"FFF9","...Reserved for JPEG extensions"},
        {"FFFA","...Reserved for JPEG extensions"},
        {"FFFB","...Reserved for JPEG extensions"},
        {"FFFC","...Reserved for JPEG extensions"},
        {"FFFD","...Reserved for JPEG extensions"},
        {"FFFF","...Reserved for JPEG extensions"},
        {"FFFE","Comment"}
        };
    };
}
