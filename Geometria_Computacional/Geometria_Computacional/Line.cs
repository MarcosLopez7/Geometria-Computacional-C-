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
            this.bmp = new Bitmap(my, mx);
            this.imagen = i;
            this.maxY = my;
            this.maxX = mx;
        }

        /*DDALine arreglado*/
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
            else if (Math.Abs(dy) <= Math.Abs(dx))
            {
                m = dy / dx;
                

                if (dx < 0)
                {
                    y = Convert.ToDouble(y1);
                    for (int xi = x1; xi <= x0; xi++)
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
            }
            else
            {
                m = dx / dy;
                
                if (dy < 0)
                {
                    x = Convert.ToDouble(x1);
                    for (int yi = y1; yi <= y0; yi++)
                    {
                        bmp.SetPixel(Convert.ToInt32(x), yi, Color.FromArgb(0, 0, 0));
                        puntos[i] = Convert.ToInt32(x);
                        puntos[i + 1] = yi;
                        i += 2;
                        x += m;
                    }
                }
                else
                {
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
            }

            return i;
        }

        public void BresenhamLine(int x0, int y0, int x1, int y1)
        {
            int x, y, dx, dy, xend, p, incE, incNE, stepX, stepY;

            dx = x1 - x0;
            dy = y1 - y0;

            if (dy < 0)
            {
                dy = -dy;
                stepY = -1;
            }
            else
                stepY = 1;

            if (dx < 0)
            {
                dx = -dx;
                stepX = -1;
            }
            else
                stepX = 1;

            x = x0;
            y = y0;

            bmp.SetPixel(x0, y0, Color.FromArgb(0, 0, 0));

            if(dx > dy)
            {
                p = 2 * dy - dx;
                incE = 2 * dy;
                incNE = 2 * (dy - dx);
                while(x != x1)
                {
                    x += stepX;
                    if (p < 0)
                        p += incE;
                    else
                    {
                        y += stepY;
                        p += incNE;
                    }
                    bmp.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                }
            }
            else
            {
                p = 2 * dx - dy;
                incE = 2 * dx;
                incNE = 2 * (dx - dy);
                while(y!=y1)
                {
                    y += stepY;
                    if (p < 0)
                        p += incE;
                    else
                    {
                        x += stepX;
                        p += incNE;
                    }
                    bmp.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                }
            }
        }

        public void MidPointLine(int x0, int y0, int x1, int y1)
        {

            int dx, dy, d, incry, incre, incrne, slopegt1 = 0;
            dx = Math.Abs(x0 - x1);
            dy = Math.Abs(y0 - y1);

            if(dy > dx)
            {
                swap(ref x0, ref y0);
                swap(ref x1, ref y1);
                swap(ref dx, ref dy);
                slopegt1 = 1;
            }

            if(x0 > x1)
            {
                swap(ref x0, ref x1);
                swap(ref y0, ref y1);
            }

            if (y0 > y1)
                incry = -1;
            else
                incry = 1;

            d = 2 * dy - dx;
            incre = 2 * dy;
            incrne = 2 * (dy - dx);

            while(x0 < x1)
            {
                if (d <= 0)
                    d += incre;
                else 
                {
                    d += incrne;
                    y0 += incry;
                }

                x1++;

                if (slopegt1 == 0)
                    bmp.SetPixel(y0, x0, Color.FromArgb(0, 0, 0));
                else
                    bmp.SetPixel(x0, y0, Color.FromArgb(0, 0, 0));

            
            }
        }

        private void swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }

    }
}
