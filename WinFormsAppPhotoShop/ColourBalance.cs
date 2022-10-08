using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppPhotoShop
{
    internal class ColourBalance
    {
        public static UInt32 ColorBalance_R(UInt32 point, int poz, int length )
        {
            int r, g, b;

            int N = (100 / length) * poz;

            r = (int)(((point & 0x00FF0000) >> 16) + N * 128 / 100);
            g = (int)((point & 0x0000FF00)>> 8);
            b = (int)(point & 0x000000FF);

            if (r < 0) r = 0;
            if(r > 255) r = 255;

            point = 0xFF000000 | ((UInt32)r<< 16)| ((UInt32)g<< 8)| ((UInt32)b);

            return point;
        }

        public static UInt32 ColorBalance_B(UInt32 point, int poz, int length)
        {
            int r, g, b;

            int N = (100 / length) * poz;

            r = (int)((point & 0x00FF0000) >> 16);
            g = (int)(((point & 0x0000FF00) >> 8) + N * 128 / 100);
            b = (int)(point & 0x000000FF);

            if (g < 0) g = 0;
            if (g > 255) g = 255;

            point = 0xFF000000 | ((UInt32)r << 16) | ((UInt32)g << 8) | ((UInt32)b);

            return point;
        }

        public static UInt32 ColorBalance_b(UInt32 point, int poz, int length)
        {
            int r, g, b;

            int N = (100 / length) * poz;

            r = (int)((point & 0x00FF0000) >> 16);
            g = (int)((point & 0x0000FF00) >> 8);
            b = (int)((point & 0x000000FF) + N * 128 / 100);

            if (b < 0) b = 0;
            if (b > 255) b = 255;

            point = 0xFF000000 | ((UInt32)r << 16) | ((UInt32)g << 8) | ((UInt32)b);

            return point;
        }
    }
}
