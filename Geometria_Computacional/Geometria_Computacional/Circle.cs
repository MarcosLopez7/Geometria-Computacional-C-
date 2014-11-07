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
            this.bmp = new Bitmap(my, mx);
            this.imagen = i;
            this.maxY = my;
            this.maxX = mx;
        }

       

        public void MidPointCircle(int x0, int y0, int radius)
        {

            int x = radius;
            int y = 0;
            int radiusError = 1 - x;

            while (x >= y)
            {
                bmp.SetPixel(x + x0, y + y0, Color.FromArgb(0, 0, 0));
                bmp.SetPixel(y + x0, x + y0, Color.FromArgb(0, 0, 0));
                bmp.SetPixel(-x + x0, y + y0, Color.FromArgb(0, 0, 0));
                bmp.SetPixel(-y + x0, x + y0, Color.FromArgb(0, 0, 0));
                bmp.SetPixel(-x + x0, -y + y0, Color.FromArgb(0, 0, 0));
                bmp.SetPixel(-y + x0, -x + y0, Color.FromArgb(0, 0, 0));
                bmp.SetPixel(x + x0, -y + y0, Color.FromArgb(0, 0, 0));
                bmp.SetPixel(y + x0, -x + y0, Color.FromArgb(0, 0, 0));

                y++;
                if (radiusError < 0)
                    radiusError += 2 * y + 1;
                else
                {
                    x--;
                    radiusError += 2 * (y - x + 1);
                }
            }
        }

    }
}
