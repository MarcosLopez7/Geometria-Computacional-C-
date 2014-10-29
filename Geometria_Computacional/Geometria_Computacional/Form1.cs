using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometria_Computacional
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Computacional_Geometry trazado = new Computacional_Geometry(pictureBox1, 640, 480);
            int [] puntos = new int [1000];
            trazado.DDALine(200, 200, 300, 200, puntos);
            trazado.DDALine(200, 200, 200, 300, puntos);
            trazado.DDALine(300, 200, 300, 300, puntos);
            trazado.DDALine(200, 300, 300, 300, puntos);
            trazado.BresenhamLine(200, 200, 300, 300);
            trazado.BresenhamLine(300, 200, 200, 300);
            trazado.setImage();
        }
    }
}
