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
            Circle trazado = new Circle(pictureBox1, 1200, 720);
            int [] puntos = new int [1000];
            trazado.MidPointCircle(200, 200, 100);
            trazado.setImage();
        }
    }
}
