using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileCreator
{
    public static class Extensions
    {
        public static Bitmap Remove(this Bitmap bmp, int x, int y)
        {
            bmp.SetPixel(x, y, Color.Black);
            return bmp;
        }

        public static Bitmap ClearCenter(this Bitmap bmp, int offset)
        {
            for(int y = offset; y < bmp.Height-offset;  y++)
            {
                for (int x = offset; x < bmp.Width-offset; x++)
                {
                    bmp = bmp.Remove(y, x);
                }
            }
            return bmp;
        }   

        public static Bitmap RemoveCorner(this Bitmap bmp, int offset)
        {
            Bitmap res = bmp.getCopy();
            for (int y = 0; y < offset; y++)
            {
                for (int x = bmp.Width - offset; x < bmp.Width; x++)
                {
                    res = res.Remove(y, x);
                }
            }
            return res;
        }

        public static Bitmap getCopy(this Bitmap bmp)
        {
            Bitmap rot = new Bitmap(bmp.Width, bmp.Height);
            for (int y = 0; y < bmp.Width; y++)
            {
                for (int x = 0; x < bmp.Height; x++)
                {
                    rot.SetPixel(x, y, bmp.GetPixel(x, y));
                }
            }
            return rot;
        }

        public static Bitmap RemoveBorder(this Bitmap bmp, int offset)
        {
            Bitmap res = bmp.getCopy();
            for (int y = offset; y < bmp.Height - offset; y++)
            {
                for (int x = bmp.Width - offset - 1; x < bmp.Width; x++)
                {
                    res = res.Remove(y, x);
                }
            }
            return res;
        }

        public static Bitmap rotate(this Bitmap bmp)
        {
            Bitmap rot = bmp.getCopy();
            rot.RotateFlip(RotateFlipType.Rotate90FlipNone);
            return rot;
        }

        public static Bitmap AddToTop(this Bitmap bmp, Bitmap top)
        {
            Bitmap ret = new Bitmap(bmp.Width, bmp.Height);
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    if (top.GetPixel(y, x).R == 0 && top.GetPixel(y, x).G == 0 && top.GetPixel(y, x).B == 0)
                    {
                        ret.SetPixel(y, x, bmp.GetPixel(y, x));
                    } else
                    {
                        ret.SetPixel(y, x, top.GetPixel(y, x));
                    }
                }
            }
            return ret;
        }
    }
}
