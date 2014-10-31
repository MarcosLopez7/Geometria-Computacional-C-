using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Geometria_Computacional
{
    class Line : Computacional_Geometry
    {

        public Line() { }
        public Line(PictureBox i, int my, int mx) 
        {
            this.bmp = new Bitmap(640, 480);
            this.imagen = i;
            this.maxY = my;
            this.maxX = mx;
        }

        public int DDALine(int x0, int y0, int x1, int y1, int[] puntos)
        {

            int i = 0;

            double dx, dy, m, x, y;
            dx = x1 - x0;
            dy = y1 - y0;

            if (dx == 0)
            {
                for (int yi = y0; yi <= y1; yi++)
                {

                    bmp.SetPixel(x0, yi, Color.FromArgb(0, 0, 0));
                    puntos[i] = x0;
                    puntos[i + 1] = yi;
                    i += 2;
                }
            }
            else if (dy == 0)
            {
                for (int xi = x0; xi <= x1; xi++)
                {
                    bmp.SetPixel(xi, y0, Color.FromArgb(0, 0, 0));
                    puntos[i] = xi;
                    puntos[i + 1] = y0;
                    i += 2;
                }
            }
            else if (dy <= dx)
            {
                m = dy / dx;
                y = Convert.ToDouble(y0);

                for (int xi = x0; xi <= x1; xi++)
                {
                    bmp.SetPixel(xi, Convert.ToInt32(y), Color.FromArgb(0, 0, 0));
                    puntos[i] = xi;
                    puntos[i + 1] = Convert.ToInt32(y);
                    i += 2;
                    y += m;
                }
            }
            else
            {
                m = dx / dy;
                x = Convert.ToDouble(x0);
                for (int yi = y0; yi <= y1; yi++)
                {
                    bmp.SetPixel(Convert.ToInt32(x), yi, Color.FromArgb(0, 0, 0));
                    puntos[i] = Convert.ToInt32(x);
                    puntos[i + 1] = yi;
                    i += 2;
                    x += m;
                }
            }

            return i;
        }

        public void BresenhamLine(float x0, float y0, float x1, float y1)
        {
            int x, y, dx, dy, xend, p, incE, incNE;

            dx = Convert.ToInt32(Math.Abs(x1 - x0));
            dy = Convert.ToInt32(Math.Abs(y1 - y0));

            p = 2 * dy - dx;
            incE = 2 * dy;
            incNE = 2 * (dy - dx);

            if (x0 > x1)
            {
                x = Convert.ToInt32(x1);
                y = Convert.ToInt32(y1);
                xend = Convert.ToInt32(x0);
            }
            else
            {
                x = Convert.ToInt32(x0);
                y = Convert.ToInt32(y0);
                xend = Convert.ToInt32(x1);
            }

            while (x <= xend)
            {
                bmp.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                x++;
                if (p < 0)
                    p += incE;
                else
                {
                    y++;
                    p += incNE;
                }
            }
        }


        public void MidPointLine(int x0, int y0, int x1, int y1)
        {

            int x, y, dx, dy, xend, p, incE, incNE;

            dx = x1 - x0;
            dy = y1 - y0;

            p = 2 * dy - dx;
            incE = 2 * dy;
            incNE = 2 * (dy - dx);

            if (x0 > x1)
            {
                x = x1;
                y = y1;
                xend = x0;
            }
            else
            {
                x = x0;
                y = y0;
                xend = x1;
            }

            while (x <= xend)
            {
                bmp.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                x++;
                if (p <= 0)
                    p += incE;
                else
                {
                    y++;
                    p += incNE;
                }

            }

        }

    }
}
