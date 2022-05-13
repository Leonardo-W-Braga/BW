using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackAndWhite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            string imagepath = ofd.FileName;

            Bitmap OrinalImage = new Bitmap(imagepath);
            Bitmap BlackAndWhiteImage = new Bitmap(OrinalImage.Width, OrinalImage.Height);

            Graphics sg = Graphics.FromImage(BlackAndWhiteImage);
            Graphics g = this.CreateGraphics();

            Color c = Color.Black;
            Color v = Color.Black;

            int av = 0;

            for (int i = 0; i < OrinalImage.Width; i++)
            {
                for (int y = 0; y < OrinalImage.Height; y++)
                {
                    c = OrinalImage.GetPixel(i, y);
                    av = (c.R + c.B + c.G) / 3;
                    v = Color.FromArgb(c.A, av, av, av);
                    BlackAndWhiteImage.SetPixel(i, y, v);
                }
            }
            g.DrawImage(BlackAndWhiteImage, Point.Empty);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
