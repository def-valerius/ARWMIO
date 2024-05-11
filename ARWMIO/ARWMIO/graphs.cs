using NAudio.CoreAudioApi;
using NAudio.Wave;
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
    public partial class graphs : Form
    {
        public wPlay[] wPlayArr;
        public WasapiLoopbackCapture[] wlbc;
        public bool loopback;
        private byte[][] byteArr = new byte[10][];
        private Graphics gGraph;
        public graphs()
        {
            InitializeComponent();
        }

        private void graphs_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(400, 400);
        }
        public void PassArray(byte[] arrFrom)
        {
            //byteArr[1] = arrFrom;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gGraph = Graphics.FromImage(bmp);
            //g.DrawLine(new Pen(Color.Green), 10, 10, 100, 10);
            gGraph.DrawRectangle(new Pen(Color.Green), 10, 10, 100, 20);
            gGraph.FillRectangle(new SolidBrush(Color.Green), 10, 10, 150, 20);
            pictureBox1.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gGraph = Graphics.FromImage(bmp);
            gGraph.FillRectangle(new SolidBrush(Color.White), 0, 0, pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gGraph = Graphics.FromImage(bmp);

            /*
            if ((wPlayArr[0].byteArr != null))
            {
                if ((wPlayArr[0].byteArr.Length % 4) == 0)
                {
                    float[] floatArr = new float[wPlayArr[0].byteArr.Length / 4];
                    int j = 0;
                    for (int i = 0; i < wPlayArr[0].byteArr.Length; i += 4)
                    {
                        floatArr[j] = System.BitConverter.ToSingle(wPlayArr[0].byteArr, i);
                        j++;
                    }

                    float max = 0;
                    for (int i = 0; i < floatArr.Length; i++)
                    {
                        var sample = floatArr[i];
                        if (sample < 0) sample -= sample;
                        if (sample > max) max = sample;
                    }
                    var vol = Math.Round(max, 2) * 100;
                    pictureBox1.Image = new Bitmap(400, 400);
                    gGraph.FillRectangle(new SolidBrush(Color.Green), 10, 10, System.Convert.ToInt32(vol), 20);
                    pictureBox1.Image = bmp;
                }
            }
            */

        }

        private void graphs_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!timer10ms.Enabled)
            {
                /*
                wlbc = new WasapiLoopbackCapture[wPlayArr.Length];
                for (int i = 0; i < wPlayArr.Length; i++)
                {
                    void DataAvailable(object senderA, WaveInEventArgs waveInEventArgs)
                    {
                        byteArr[i] = waveInEventArgs.Buffer;
                    }

                    //wlbc[i] = new WasapiLoopbackCapture(wPlayArr[i].wInput);
                    wlbc[i].DataAvailable += DataAvailable;
                    wlbc[i].ShareMode = AudioClientShareMode.Shared;
                    wlbc[i].StartRecording();
                }
                */
                timer10ms.Start();
                button4.Text = "stop timer";
            }
            else
            {
                /*
                for (int i = 0; i < wlbc.Length; i++)
                    wlbc[i].StopRecording();
                loopback = false;
                */
                timer10ms.Stop();
                button4.Text = "start timer";
            }
            /*
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gGraph = Graphics.FromImage(bmp);

            if ((wPlayArr[0].byteArr != null))
            {
                if ((wPlayArr[0].byteArr.Length % 4) == 0)
                {
                    float[] floatArr = new float[wPlayArr[0].byteArr.Length / 4];
                    int j = 0;
                    for (int i = 0; i < wPlayArr[0].byteArr.Length; i += 4)
                    {
                        floatArr[j] = System.BitConverter.ToSingle(wPlayArr[0].byteArr, i);
                        j++;
                    }

                    double d = floatArr.Length / pictureBox1.Image.Width;
                    int widthScale = Convert.ToInt32(Math.Floor(d));
                    int mCount = 0;
                    int mPoint = 0;
                    float fPoint = 0;
                    for (int m = 0; m < floatArr.Length; m++)
                    {
                        if (mCount < widthScale)
                        {
                            fPoint += floatArr[m];
                            mCount++;
                        }
                        else
                        {
                            mPoint++;
                            fPoint /= widthScale;
                            gGraph = Graphics.FromImage(bmp);
                            gGraph.DrawRectangle(new Pen(Color.Green), mPoint, 100 - Convert.ToInt32(Math.Floor(fPoint * 100)), 1, 1);
                            pictureBox1.Image = bmp;
                            mCount = 0;
                        }
                    }
                }
            }
            */
        }

        private void timer10ms_Tick(object sender, EventArgs e)
        {
            /*
            float[] arr = new float[100];
            int what = wPlayArr[0].volumeSampleProv1.Read(arr, 0, 100); // causes crackling noise
            textBox1.Text = what.ToString() + "; " + arr[0].ToString();
            */

            textBox1.Text = "";
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gGraph = Graphics.FromImage(bmp);
            gGraph.FillRectangle(new SolidBrush(Color.White), 0, 0, pictureBox1.Width, pictureBox1.Height);
            
            // vertical lines
            gGraph.DrawLine(new Pen(Color.Gray), pictureBox1.Width / 4, 0, pictureBox1.Width / 4, pictureBox1.Height);
            gGraph.DrawLine(new Pen(Color.Gray), pictureBox1.Width - pictureBox1.Width / 4, 0, pictureBox1.Width - pictureBox1.Width / 4, pictureBox1.Height);
            gGraph.DrawLine(new Pen(Color.Gray), pictureBox1.Width / 8, 0, pictureBox1.Width / 8, pictureBox1.Height);
            gGraph.DrawLine(new Pen(Color.Gray), pictureBox1.Width / 4 + pictureBox1.Width / 8, 0, pictureBox1.Width / 4 + pictureBox1.Width / 8, pictureBox1.Height);
            gGraph.DrawLine(new Pen(Color.Gray), pictureBox1.Width - pictureBox1.Width / 8, 0, pictureBox1.Width - pictureBox1.Width / 8, pictureBox1.Height);
            gGraph.DrawLine(new Pen(Color.Gray), pictureBox1.Width / 2 + pictureBox1.Width / 8, 0, pictureBox1.Width / 2 + pictureBox1.Width / 8, pictureBox1.Height);
            gGraph.DrawLine(new Pen(Color.Black, 2), pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);

            // horizontal line
            gGraph.DrawLine(new Pen(Color.Black, 2), 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);
           
            #region wPlayArr Test
            /*
            if (wPlayArr[0].byteArr != null)
            //if ((byteArr[0] != null))
            {
                if ((wPlayArr[0].byteArr.Length % 4) == 0)
                //if ((byteArr[0].Length % 4) == 0)
                {
                    byte[] buffArr = wPlayArr[0].byteArr;
                    //byte[] buffArr = byteArr[0];

                    float[] floatArr = new float[buffArr.Length / 4];
                    int j = 0;
                    for (int i = 0; i < buffArr.Length; i += 4)
                    {
                        floatArr[j] = System.BitConverter.ToSingle(buffArr, i);
                        j++;
                    }

                    double d = floatArr.Length / pictureBox1.Image.Width;
                    int widthScale = Convert.ToInt32(Math.Round(d));
                    int mCount = 0;
                    int mPoint = 0;
                    float fPoint = 0;

                    textBox1.Text = "len: " + floatArr.Length.ToString() + ", scale: " + widthScale.ToString() + "; ";

                    for (int m = 0; m < floatArr.Length; m++)
                    {
                        if (mCount < widthScale)
                        {
                            fPoint += floatArr[m];
                            mCount++;
                        }
                        else
                        {
                            mPoint++;
                            fPoint /= widthScale;
                            
                            gGraph.DrawRectangle(new Pen(Color.Green),
                                                 mPoint, (Convert.ToInt32(pictureBox1.Image.Height / 2) - Convert.ToInt32(Math.Round(fPoint * (pictureBox1.Image.Height / 2))) * 1),
                                                 1, 1);
                            //pictureBox1.Image = bmp;
                            mCount = 0;
                        }
                    }
                }
            }
            if ((wPlayArr[1].byteArr != null))
            //if ((byteArr[1] != null))
            {
                if ((wPlayArr[1].byteArr.Length % 4) == 0)
                //if ((byteArr[1].Length % 4) == 0)
                {
                    byte[] buffArr = wPlayArr[1].byteArr;
                    //byte[] buffArr = byteArr[1];

                    float[] floatArr = new float[buffArr.Length / 4];
                    int j = 0;
                    for (int i = 0; i < buffArr.Length; i += 4)
                    {
                        floatArr[j] = System.BitConverter.ToSingle(buffArr, i);
                        j++;
                    }

                    double d = floatArr.Length / pictureBox1.Image.Width;
                    int widthScale = Convert.ToInt32(Math.Floor(d));
                    int mCount = 0;
                    int mPoint = 0;
                    float fPoint = 0;
                    for (int m = 0; m < floatArr.Length; m++)
                    {
                        if (mCount < widthScale)
                        {
                            fPoint += floatArr[m];
                            mCount++;
                        }
                        else
                        {
                            mPoint++;
                            fPoint /= widthScale;
                            //pictureBox1.Image = bmp;
                            mCount = 0;
                        }
                    }
                }
            }
            */
            #endregion

            textBox1.Text += "w: " + pictureBox1.Width.ToString() + ", h: " + pictureBox1.Height.ToString() + "; ";

            //<buffer test
            if (wPlayArr.Length > 0)
            {
                Color[] arrColor = new Color[7];
                //arrColor = [Color.Green, Color.Red, Color.Blue, Color.Yellow, Color.Purple, Color.Orange, Color.Brown];
                arrColor[0] = Color.Green;
                arrColor[1] = Color.Red;
                arrColor[2] = Color.Blue;
                arrColor[3] = Color.Yellow;
                arrColor[4] = Color.Purple;
                arrColor[5] = Color.Orange;
                arrColor[6] = Color.Brown;
                int colorI = 0;
                Color penCol;

                for (int i = 0; i < wPlayArr.Length; i++)
                {
                    byte[] test = wPlayArr[i].byteArr;
                    int bytesRecorded = wPlayArr[i].byteArr.Length;
                    WaveBuffer wb = new WaveBuffer(test);
                    /*
                    WaveBuffer wb_1 = new WaveBuffer(wPlayArr[i].byteArr);
                    WaveBuffer wb = new WaveBuffer(wPlayArr[i].byteArr.Length);
                    wb_1.Copy(wb.ByteBuffer);
                    */
                    if (colorI < arrColor.Length)
                    {
                        penCol = arrColor[colorI];
                        colorI++;
                    }
                    else
                    {
                        colorI = 0;
                        penCol = arrColor[colorI];
                    }


                    double d = (wb.FloatBuffer.Length / 4) / pictureBox1.Image.Width;
                    //int widthScale = Convert.ToInt32(Math.Round(d));
                    float widthScale = Convert.ToSingle(d);
                    int mCount = 0;
                    int mPoint = 0;
                    float fPoint = 0;
                    int pM = 0, pN = 0;

                    textBox1.Text += "len: " + wb.FloatBuffer.Length.ToString() + ", scale: " + widthScale.ToString() + "; ";
                    //textBox1.Text += "len: " + bytesRecorded.ToString() + ", scale: " + widthScale.ToString() + "; ";
                    textBox1.Text += wb.GetType();

                    for (int m = 0; m < wb.FloatBuffer.Length / 4; m++)
                    {
                        #region width intger scale
                        /*
                        if (mCount < widthScale)
                        {
                            fPoint += wb.FloatBuffer[m];
                            mCount++;
                        }
                        else
                        {
                            mPoint++;
                            fPoint /= widthScale;

                            if ((fPoint >= -1) & (fPoint <= 1))
                            {
                                if ((m == widthScale) || (m == wb.FloatBuffer.Length - 1))
                                {
                                    pM = mPoint;
                                    pN = (Convert.ToInt32(pictureBox1.Image.Height / 2) - Convert.ToInt32(Math.Round(fPoint * (pictureBox1.Image.Height / 2))) * 1);
                                }
                                gGraph.DrawLine(new Pen(penCol), 
                                                pM, pN, 
                                                mPoint, (Convert.ToInt32(pictureBox1.Image.Height / 2) - Convert.ToInt32(Math.Round(fPoint * (pictureBox1.Image.Height / 2))) * 1));
                                pM = mPoint;
                                pN = (Convert.ToInt32(pictureBox1.Image.Height / 2) - Convert.ToInt32(Math.Round(fPoint * (pictureBox1.Image.Height / 2))) * 1);

                            }

                            mCount = 0;
                            fPoint = 0;
                        }
                        */
                        #endregion

                        #region width float scale
                        if ((m == 0) || (m == wb.FloatBuffer.Length / 4 - 1))
                        {
                            pM = Convert.ToInt32(Math.Round(m / widthScale));
                            pN = (Convert.ToInt32(pictureBox1.Image.Height / 2) - Convert.ToInt32(Math.Round(wb.FloatBuffer[m] * (pictureBox1.Image.Height / 2))) * 1);
                        }
                        gGraph.DrawLine(new Pen(penCol),
                                        pM, pN,
                                        Convert.ToInt32(Math.Round(m / widthScale)), (Convert.ToInt32(pictureBox1.Image.Height / 2) - Convert.ToInt32(Math.Round(wb.FloatBuffer[m] * (pictureBox1.Image.Height / 2))) * 1));
                        pM = Convert.ToInt32(Math.Round(m / widthScale));
                        pN = (Convert.ToInt32(pictureBox1.Image.Height / 2) - Convert.ToInt32(Math.Round(wb.FloatBuffer[m] * (pictureBox1.Image.Height / 2))) * 1);
                        #endregion
                        
                    }
                }
            }
            // buffer test>

            pictureBox1.Image = bmp;
        }

        private void graphs_Resize(object sender, EventArgs e)
        {
            if (!timer10ms.Enabled)
                textBox1.Text = "w: " + pictureBox1.Width.ToString() + ", h: " + pictureBox1.Height.ToString();
        }
    }
}