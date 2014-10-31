using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace Geometria_Computacional
{
    class Computacional_Geometry
    {
        protected Bitmap bmp {get; set;}
        protected PictureBox imagen { get; set; }
        protected int maxY { get; set; }
        protected int maxX { get; set; }

        public Computacional_Geometry()
        {
            bmp = null;
            imagen = null;
            maxY = 0;
            maxX = 0;
        }
        public Computacional_Geometry(PictureBox i, int my, int mx)
        {
            this.bmp = new Bitmap(640, 480);
            this.imagen = i;
            this.maxY = my;
            this.maxX = mx;
        }

        

        public void setImage()
        {
            imagen.Image = bmp;
        }

    }
}
