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
    class Ellipse : Computacional_Geometry
    {

        public Ellipse() { }
        public Ellipse(PictureBox i, int my, int mx) 
        {
            this.bmp = new Bitmap(my, mx);
            this.imagen = i;
            this.maxY = my;
            this.maxX = mx;
        }

        private int EllipsePoints(int x, int y, int [] puntos, int i)
        {
            bmp.SetPixel(maxX + x, maxY + y, Color.FromArgb(0, 0, 0));

            puntos[i] = maxX + x;
            puntos[i + 1] = maxY + y;
            i += 2;

            bmp.SetPixel(maxX - x, maxY + y, Color.FromArgb(0, 0, 0));
            bmp.SetPixel(maxX + x, maxY - y, Color.FromArgb(0, 0, 0));
            bmp.SetPixel(maxX - x, maxY - y, Color.FromArgb(0, 0, 0));

            return i;
        }

        public int MidPointEllipse(int a, int b, int [] puntos)
        {

            int i = 0;
            double d2;
            int x = 0;
            int y = b;

            double dl = b * b - (a * a * b) + (0.25 * a * a);

            bmp.SetPixel(x, y, Color.FromArgb(0, 0, 0));

            while((a*a*(y-0.5)) > (b*b*(x+1)))
            {
                if (dl < 0)
                    dl += b * b * (2 * x + 3);
                else
                {
                    dl += b * b * (2 * x + 3) + a * a * (-2 * y + 2);
                    y--;
                }
                x++;

                i = EllipsePoints(x, y, puntos, i);
            }

            d2 = b * b * (x + 0.5) * (x + 0.5) + a * a * (y - 1) * (y - 1) - a * a * b * b;

            while(y > 0)
            {
                if (d2 < 0)
                {
                    d2 += b * b * (2 * x + 2) + a * a * (-2 * y + 3);
                    x++;
                }
                else
                    d2 += a * a * (-2 * y + 3);
                y--;

                i = EllipsePoints(x, y, puntos, i);
            }

            return i;

        }

    }
}
