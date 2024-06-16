using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARWMIO
{
    public partial class control_idk : Form
    {
        public wPlay[] localWPlay;
        public int iX = 0, iY = 0;
        public bool bChange = false;
        Graphics gGraph;
        public control_idk()
        {
            InitializeComponent();
        }

        public void clearPicture()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gGraph = Graphics.FromImage(bmp);
            
            gGraph.FillRectangle(new SolidBrush(Color.White), 0, 0, pictureBox1.Width, pictureBox1.Height);
            gGraph.DrawLine(new Pen(Color.Black), 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);
            gGraph.DrawLine(new Pen(Color.Black), pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);

            pictureBox1.Image = bmp;
        }
        public void PassRefArrwPlay(ref wPlay[] wPlay)
        {
            localWPlay = wPlay;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = iX.ToString() + ", " + iY.ToString();
            clearPicture();
            Bitmap bmp = (Bitmap)pictureBox1.Image;
            gGraph = Graphics.FromImage(bmp);
            gGraph.FillRectangle(new SolidBrush(Color.Green), iX - 2, iY - 2, 4, 4);

            pictureBox1.Image = bmp;

            int iXOffset = iX - pictureBox1.Width / 2;
            int iYOffset = iY - pictureBox1.Height / 2;
            textBox1.Text = iX.ToString() + "," + iY.ToString() + "; " + iXOffset.ToString() + "," + iYOffset.ToString();

            localWPlay[0].volumeSampleProv1.Volume = (float)(1 - (iYOffset / ((float)pictureBox1.Height / 2)));
            textBox1.Text += "; " + localWPlay[0].volumeSampleProv1.Volume.ToString();
            localWPlay[0].smbPitchSampleProv1.PitchFactor = (float)(1 - (iXOffset / ((float)pictureBox1.Width / 2)));
            textBox1.Text += "; " + localWPlay[0].smbPitchSampleProv1.PitchFactor.ToString();

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (bChange)
            {
                iX = e.X;
                iY = e.Y;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!bChange)
            {
                bChange = true;
            }
            else
            {
                bChange = false;
            }
        }

        private void control_idk_Load(object sender, EventArgs e)
        {
            clearPicture();
        }
    }
}
