using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentificarTipoArquivo
{
    /// <summary>
    /// BINARIOS TIRADOS DO SITE -- https://www.garykessler.net/library/file_sigs.html
    /// </summary>
    public class Arquivo
    {
        public static Dictionary<byte[], string> imageFormatDecoders = new Dictionary<byte[], string>()
        {
            { Bmp, ".Bmp"},
            { Gif, ".Gif" },
            { Gif_v2, ".Gif" },
            { Png, ".Png"},
            { Jpeg, ".Jpeg"},
            { Jpg, ".Jpg"},
            { Jpg_v02, ".Jpg"},
            { Jpg_v03, ".Jpg"},
            { Tif, ".tif"},

            { Pdf, ".PDF"},

            { Zip, ".7z"},

            { Html, ".html"},
            { Html_v02, ".html"},

            { DocumentoWindows,".docx" },
            {DocumentoWindows,".xlsx" },

            { DocumentoOxps, ".Oxps"},

            { MensagemOutlook, ".msg"},
            { MensagemOutlook, ".doc"}
        };        

        //IMAGEN - BMP {0x42, 0x4D}
        private static readonly byte[] Bmp = new byte[] { 0x42, 0x4D };

        //IMAGEN - GIF {47 49 46 38 37 61}
        private static readonly byte[] Gif = new byte[] { 0x47, 0x49, 0x46, 0x38, 0x37, 0x61 };

        //IMAGEN - GIF versao 2 {47 49 46 38 39 61}
        private static readonly byte[] Gif_v2 = new byte[] { 0x47, 0x49, 0x46, 0x38, 0x39, 0x61 };

        //IMAGEN - PNG { 0x89 50 4E 47 0D 0A 1A 0A }
        private static readonly byte[] Png = new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };

        //IMAGEN - JPEG {0xFF D8 FF E0 xx xx 4A 46 49 46 00} desconsiderar as posicoes xx pq refere ao tamanho do arquivo
        private static readonly byte[] Jpeg = new byte[] { 0xFF, 0xD8, 0xFF, 0xE0, 0x00, 0x00, 0x4A, 0x46, 0x49, 0x46, 0x00 };

        //IMAGEN - JPEG {0xFF D8 FF E1 xx xx 45 78 69 66 00} desconsiderar as posicoes xx pq refere ao tamanho do arquivo
        private static readonly byte[] Jpg = new byte[] { 0xFF, 0xD8, 0xFF, 0xE1, 0x00, 0x00, 0x45, 0x78, 0x69, 0x66, 0x00 };

        //IMAGEN - JPEG {0xFF D8 FF E2 xx xx 45 78 69 66 00} desconsiderar as posicoes xx pq refere ao tamanho do arquivo
        private static readonly byte[] Jpg_v02 = new byte[] { 0xFF, 0xD8, 0xFF, 0xE2, 0x00, 0x00, 0x45, 0x78, 0x69, 0x66, 0x00 };

        //IMAGEN - JPEG {0xFF D8 FF E8 xx xx 53 50 49 46 46 00} desconsiderar as posicoes xx pq refere ao tamanho do arquivo
        private static readonly byte[] Jpg_v03 = new byte[] { 0xFF, 0xD8, 0xFF, 0xE8, 0x00, 0x00, 0x53, 0x50, 0x49, 0x46, 0x46, 0x00 };

        //IMAGEN - TIF { 49 49 2A 00 }
        private static readonly byte[] Tif = new byte[] { 0x49, 0x49, 0x2A, 0x00 };

        // PDF -- 0X25 50 44 46
        private static readonly byte[] Pdf = new byte[] { 0x25, 0x50, 0x44, 0x46 };

        // 7Z|7-Zip compressed file -{ 37 7A BC AF 27 1C }
        private static readonly byte[] Zip = new byte[] { 0x37, 0x7A, 0xBC, 0xAF, 0x27, 0x1C };

        // Arquivo HTML - { 3C 21 64 6F 63 74 79 70 } 
        private static readonly byte[] Html = new byte[] { 0x3C, 0x21, 0x64, 0x6F, 0x63, 0x74, 0x79, 0x70 };

        // Arquivo HTML - { 3C } 
        private static readonly byte[] Html_v02 = new byte[] { 0x3C };

        // Arquivo Docx, xlsx - { 50 4B 03 04 14 00 06 00 } 
        private static readonly byte[] DocumentoWindows = new byte[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x06, 0x00 };

        // Arquivo Oxps/XPS - { 50 4B 03 04 14 00 08 00 } 
        private static readonly byte[] DocumentoOxps = new byte[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x08, 0x00 };

        // Arquivo msg/doc - { D0 CF 11 E0 A1 B1 1A E1 } 
        private static readonly byte[] MensagemOutlook = new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 };

        //Arquivo RTF - { 7B 5C 72 74 66 31 }
        private static readonly byte[] TextoRtf = new byte[] { 0x7B, 0x5C, 0x72, 0x74, 0x66, 0x31 };

        //Arquivo wav - { 52 49 46 46 xx xx xx xx 57 41 56 45 66 6D 74 20 } -- desconsiderar as posicoes xx pq refere ao tamanho do arquivo
        private static readonly byte[] VideoWav = new byte[] { 0x52, 0x49, 0x46, 0x46, 0x00, 0x00, 0x00, 0x00, 0x57, 0x41, 0x56, 0x45, 0x66, 0x6D, 0x74, 0x20 };

        //Arquivo URL - { D4 2A	}
        private static readonly byte[] TextoUrl = new byte[] { 0xD4, 0x2A };
    }
}