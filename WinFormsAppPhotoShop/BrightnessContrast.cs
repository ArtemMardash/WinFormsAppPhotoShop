using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppPhotoShop
{
    internal class BrightnessContrast
    {
        public static UInt32 Brightness(UInt32 point, int poz, int length)
        {
            int r, g, b;

            int N = (100 / length) * poz;

            r = (int)(((point & 0x00FF0000) >> 16) + N * 128 / 100);
            g = (int)(((point & 0x0000FF00)>> 8) + N * 128 / 100);
            b = (int)((point & 0x000000FF) + N * 128 / 100);

            if(r < 0) r = 0;
            if(g < 0) g = 0;
            if(b < 0) b = 0;
            if(r > 255) r = 255;
            if(b > 255) b = 255;
            if(g > 255) g = 255;

            point = 0xFF000000 | (UInt32)r >> 16 | (UInt32)g >> 8 | (UInt32)b;
            return point;
        }

        public static UInt32 Contrast(UInt32 point, int poz, int length)
        {
            int r, g, b;
            
            int N = (100/length) * poz;

            if(N >= 0)
            {
                if (N == 100) N = 99;
                r = (int)((((point &0x00FF0000)>> 16) + N * 128 / 100) / (100-N));
                g = (int)((((point & 0x0000FF00) >> 8) + N*128 / 100) / (100-N));
                b = (int)(((point & 0x000000FF) + N*128 / 100) / (100-N));
            }
            else
            {
                r = (int)((((point & 0x00FF0000) >> 16) * (100 - (-N)) + 128 * (-N)) / 100);
                g = (int)((((point &0x0000FF00) >> 8) * (100 - (-N)) + 128 * (-N)) /100);
                b = (int)(((point & 0x000000FF) * (100 - (-N)) + 128 * (-N)) / 100);
            }

            if(r < 0) r = 0;
            if(b < 0) b = 0;
            if(g < 0) g = 0;
            if(r > 255) r = 255;
            if(g > 255) g = 255;
            if(b > 255) b = 255;

            point = 0xFF000000| (UInt32)r >> 16| (UInt32)g >> 8| (UInt32)b;

            return point;
        }
    }
}
