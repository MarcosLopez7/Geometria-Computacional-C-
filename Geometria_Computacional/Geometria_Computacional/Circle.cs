using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace Geometria_Computacional
{
    class Circle : Computacional_Geometry
    {

        public Circle() { }
        public Circle(PictureBox i, int my, int mx) 
        {
            this.bmp = new Bitmap(640, 480);
            this.imagen = i;
            this.maxY = my;
            this.maxX = mx;
        }

        private int CirclePoint(int x, int y, int [] puntos, int i)
        {
            bmp.SetPixel(maxX + x, maxY + y, Color.FromArgb(0, 0, 0));

            puntos[i] = maxX + x;
            puntos[i + 1] = maxY + y;
            i += 2;

            bmp.SetPixel(maxX + y, maxY + x, Color.FromArgb(0, 0, 0));
            bmp.SetPixel(maxX - x, maxY + y, Color.FromArgb(0, 0, 0));
            bmp.SetPixel(maxX + y, maxY - x, Color.FromArgb(0, 0, 0));
            bmp.SetPixel(maxX + x, maxY - y, Color.FromArgb(0, 0, 0));
            bmp.SetPixel(maxX - y, maxY + x, Color.FromArgb(0, 0, 0));
            bmp.SetPixel(maxX - x, maxY - y, Color.FromArgb(0, 0, 0));
            bmp.SetPixel(maxX - y, maxY - x, Color.FromArgb(0, 0, 0));

            return i;
        }

        public int MidPointCircle(int radius, int [] puntos)
        {
            int x = 0;
            int y = radius;
            double p = 5.0 / 4.0 - radius;
            int i = 0;
            i = CirclePoint(x, y, puntos, i);

            while(y > x)
            {
                if (p < 0)
                    p += 2.0 * x + 1.0;
                else
                {
                    p += 2.0 * (x - y) + 1.0;
                    y--;
                }

                x++;

                i = CirclePoint(x, y, puntos, i);
            }

            return i;
        }

    }
}
