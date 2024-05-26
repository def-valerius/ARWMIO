using NAudio.CoreAudioApi;
using NAudio.Dsp;
using NAudio.Extras;
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
        public TimeSpan tsPerf;
        public DateTime dtTest;

        public int iAmountOfBuffers;
        public float fVertScale = 1, fHorizScale = 1;
        public int iBytesToShow;
        public float fCoefficient = 1;
        public int iCounter = 0;
        public int iMode = 0; // 0 - Wave, 1 - Spectrum Analysis
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

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gGraph = Graphics.FromImage(bmp);
            gGraph.FillRectangle(new SolidBrush(Color.White), 0, 0, pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
        }

        private void graphs_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
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
                timer1.Start();
                button4.Text = "stop timer";
            }
            else
            {
                /*
                for (int i = 0; i < wlbc.Length; i++)
                    wlbc[i].StopRecording();
                loopback = false;
                */
                timer1.Stop();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*
            float[] arr = new float[100];
            int what = wPlayArr[0].volumeSampleProv1.Read(arr, 0, 100); // causes crackling noise
            textBox1.Text = what.ToString() + "; " + arr[0].ToString();
            */

            tsPerf = DateTime.Now - dtTest;
            dtTest = DateTime.Now;

            textBox1.Text = "";
            textBox1.Text = "T: " + tsPerf.ToString() + "; ";
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
                    byte[] bufferArr;
                    if ((iBytesToShow > 0) & false) // test
                    {
                        bufferArr = new byte[iBytesToShow];
                        for (int b = 0; b < iBytesToShow; b++)
                            bufferArr[b] = wPlayArr[i].byteArr[b];
                    }
                    else
                    {
                        bufferArr = wPlayArr[i].byteArr;
                    }
                    /*
                    byte[] bufferArr2 = new byte[Convert.ToInt32(Math.Round(bufferArr.Length * fCoefficient))];
                    int index;
                    for (int c = 0; c < bufferArr2.Length; c++)
                    {
                        index = Convert.ToInt32(Math.Round(c * fCoefficient));
                        bufferArr2[c] = bufferArr[index];
                    }

                    bufferArr = bufferArr2;
                    */
                    int bytesRecorded = wPlayArr[i].byteArr.Length;
                    WaveBuffer wb = new WaveBuffer(bufferArr);

                    float[] fBufferArr = wb.FloatBuffer;

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

                    if (iMode == 0)
                    {
                        //double d = wb.FloatBuffer.Length / 4;
                        double d = fBufferArr.Length / 4;
                        d /= pictureBox1.Image.Width;

                        //int widthScale = Convert.ToInt32(Math.Round(d));
                        //float widthScale = Convert.ToSingle(d);
                        float widthScale = Convert.ToSingle(d) * fHorizScale;
                        int mCount = 0;
                        int mPoint = 0;
                        float fPoint = 0;
                        int pM = 0, pN = 0;

                        textBox1.Text += "len: " + wb.FloatBuffer.Length.ToString() + ", scale: " + widthScale.ToString() + "; ";
                        //textBox1.Text += "len: " + bytesRecorded.ToString() + ", scale: " + widthScale.ToString() + "; ";
                        textBox1.Text += wb.GetType();

                        int m;
                        //for ( m = 0; m < wb.FloatBuffer.Length / 4; m++)
                        //for (m = 0; m < fBufferArr.Length / 4; m++)
                        for (m = 0 + iCounter; m < ((fBufferArr.Length / 4) - iBytesToShow + iCounter); m++)
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
                            //if ((m == 0) || (m == wb.FloatBuffer.Length / 4 - 1))
                            if ((m == 0) || (m == fBufferArr.Length / 4 - 1))
                            {
                                //pM = Convert.ToInt32(Math.Round(m / widthScale));
                                pM = Convert.ToInt32(Math.Round((m / widthScale) - iCounter));
                                //pN = (Convert.ToInt32(pictureBox1.Image.Height / 2) - Convert.ToInt32(Math.Round(wb.FloatBuffer[m] * (pictureBox1.Image.Height / 2)) * fVertScale));
                                pN = Convert.ToInt32(pictureBox1.Image.Height / 2) - Convert.ToInt32(Math.Round(fBufferArr[m] * (pictureBox1.Image.Height / 2) * fVertScale));
                            }

                            gGraph.DrawLine(new Pen(penCol),
                                            pM, pN,
                                            //Convert.ToInt32(Math.Round(m / widthScale)), (Convert.ToInt32(pictureBox1.Image.Height / 2) - Convert.ToInt32(Math.Round(wb.FloatBuffer[m] * (pictureBox1.Image.Height / 2))) * fVertScale));
                                            //Convert.ToInt32(Math.Round(m / widthScale)), Convert.ToInt32(pictureBox1.Image.Height / 2) - Convert.ToInt32(Math.Round(fBufferArr[m] * (pictureBox1.Image.Height / 2) * fVertScale))
                                            Convert.ToInt32(Math.Round((m / widthScale) - iCounter)), Convert.ToInt32(pictureBox1.Image.Height / 2) - Convert.ToInt32(Math.Round(fBufferArr[m] * (pictureBox1.Image.Height / 2) * fVertScale))
                                           );

                            /*
                            float x = Convert.ToInt32(Math.Round(m / widthScale));
                            float y = Convert.ToInt32(pictureBox1.Image.Height / 2);
                            //float shit = (float)Math.Round(wb.FloatBuffer[m] * (pictureBox1.Image.Height / 2));
                            float shit = (float)Math.Round(fBufferArr[m] * (pictureBox1.Image.Height / 2));
                            y = shit * fVertScale;
                            y = Convert.ToInt32(y);
                            gGraph.DrawLine(new Pen(penCol),
                                            pM, pN,
                                            x, y);
                            */
                            //pM = Convert.ToInt32(Math.Round(m / widthScale));
                            pM = Convert.ToInt32(Math.Round((m / widthScale) - iCounter));
                            //pN = (Convert.ToInt32(pictureBox1.Image.Height / 2) - Convert.ToInt32(Math.Round(wb.FloatBuffer[m] * (pictureBox1.Image.Height / 2)) * fVertScale));
                            pN = Convert.ToInt32(pictureBox1.Image.Height / 2) - Convert.ToInt32(Math.Round(fBufferArr[m] * (pictureBox1.Image.Height / 2) * fVertScale));
                            #endregion
                        }
                        iCounter += Convert.ToInt32(fCoefficient);
                        if (iCounter > iBytesToShow)
                            iCounter = 0;
                    }

                    if (iMode == 1)
                    {
                        Complex[] fftBuffer = new Complex[8192]; // 512, 1024, 2048, 4096, 8192, 16384

                        int m = Convert.ToInt32(Math.Log(8192, 2.0));

                        //for (int fftPos = 0; fftPos < fftBuffer.Length; fftPos++)
                        for (int fftPos = 0; fftPos < fftBuffer.Length; fftPos += wPlayArr[i].volumeSampleProv1.WaveFormat.Channels)
                        {
                            //fftBuffer[fftPos].X = (float)(fBufferArr[fftPos] * FastFourierTransform.HammingWindow(fftPos, fftBuffer.Length));
                            //fftBuffer[fftPos].X = (float)(fBufferArr[fftPos] * FastFourierTransform.HannWindow(fftPos, fftBuffer.Length));
                            //fftBuffer[fftPos].X = (float)(fBufferArr[fftPos] * FastFourierTransform.BlackmannHarrisWindow(fftPos, fftBuffer.Length));
                            fftBuffer[fftPos].X = (float)fBufferArr[fftPos];
                            fftBuffer[fftPos].Y = 0;
                        }

                        FastFourierTransform.FFT(true, m, fftBuffer);

                        double d = (double)fftBuffer.Length / (double)pictureBox1.Width;
                        d *= fHorizScale;
                        d /= 8;
                        float widthScale = Convert.ToSingle(d);
                        int pM = 0, pN = 0;
                        int m2;

                        textBox1.Text += "len: " + wb.FloatBuffer.Length.ToString() + ", scale: " + widthScale.ToString() + "; ";
                        textBox1.Text += fftBuffer.Length.ToString() + "; ";

                        float maxVal = 0;
                        int maxValPos = 0;
                        for (m2 = 0; m2 < fftBuffer.Length / 8; m2++) // why is it in 8 chunks?
                        {
                            double intensityDB = Math.Log10(Math.Sqrt(fftBuffer[m2].X * fftBuffer[m2].X + fftBuffer[m2].Y * fftBuffer[m2].Y));
                            /*
                            if (intensityDB < -100) intensityDB = -100;
                            double dValue = intensityDB;
                            */
                            if (   (Math.Abs(fftBuffer[m2].X) > 1000) 
                                || (Math.Abs(fftBuffer[m2].Y) > 1000)
                               ) intensityDB = -50;

                            double NaN = Double.NaN;
                            if (intensityDB == NaN)
                                intensityDB = -50;

                            double minDB = -90;
                            if (intensityDB < minDB) intensityDB = minDB;
                            double percent = intensityDB / minDB;
                            double dValue = -percent;

                            if (m2 == 0) maxVal = (float)dValue;

                            if (dValue > maxVal)
                            {
                                maxVal = (float)dValue;
                                maxValPos = m2;
                            }

                            if ((m2 == 0) || (m2 == fftBuffer.Length - 1))
                            {
                                pM = Convert.ToInt32(Math.Round(m2 / widthScale));
                                //pN = Convert.ToInt32(pictureBox1.Image.Height / 2) - Convert.ToInt32(Math.Round(fftBuffer[m2].X * (pictureBox1.Image.Height / 2) * fVertScale));
                                pN = Convert.ToInt32(pictureBox1.Image.Height / 2) - Convert.ToInt32(Math.Round(dValue * (pictureBox1.Image.Height / 2) * fVertScale));
                            }
                            gGraph.DrawLine(new Pen(penCol),
                                            pM, 
                                            pN,
                                            Convert.ToInt32(Math.Round(m2 / widthScale)),
                                            //Convert.ToInt32(pictureBox1.Image.Height / 2) - Convert.ToInt32(Math.Round(fftBuffer[m2].X * (pictureBox1.Image.Height / 2) * fVertScale))
                                            Convert.ToInt32(pictureBox1.Image.Height / 2) - Convert.ToInt32(Math.Round(dValue * (pictureBox1.Image.Height / 2) * fVertScale))
                                           );
                            pM = Convert.ToInt32(Math.Round(m2 / widthScale));
                            //pN = Convert.ToInt32(pictureBox1.Image.Height / 2) - Convert.ToInt32(Math.Round(fftBuffer[m2].X * (pictureBox1.Image.Height / 2) * fVertScale));
                            pN = Convert.ToInt32(pictureBox1.Image.Height / 2) - Convert.ToInt32(Math.Round(dValue * (pictureBox1.Image.Height / 2) * fVertScale));
                        }
                        textBox1.Text += maxValPos.ToString() + ": " + maxVal.ToString();
                    }
                }
            }
            // buffer test>

            pictureBox1.Image = bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                fVertScale = Convert.ToSingle(tbVertScale.Text);
            }
            catch { tbVertScale.Text = fVertScale.ToString(); }
            try
            {
                fHorizScale = Convert.ToSingle(tbHorizScale.Text);
            }
            catch { tbHorizScale.Text = fHorizScale.ToString(); }
            try
            {
                iAmountOfBuffers = Convert.ToInt32(tbAmountOFBuffers.Text);
                for (int i = 0; i < wPlayArr.Length; i++)
                    wPlayArr[i].iAmountOFBuffers = iAmountOfBuffers;
            }
            catch { tbAmountOFBuffers.Text = iAmountOfBuffers.ToString(); }
            try 
            {
                timer1.Interval = Convert.ToInt32(tbInterval.Text);
            }
            catch { tbInterval.Text = timer1.Interval.ToString(); }
            try
            {
                iBytesToShow = Convert.ToInt32(tbBytesToShow.Text);
                if (iBytesToShow < 0)
                {
                    iBytesToShow = 0;
                    tbBytesToShow.Text = iBytesToShow.ToString();
                }
            }
            catch { tbBytesToShow.Text = iBytesToShow.ToString(); }
            try
            {
                fCoefficient = Convert.ToSingle(textBox2.Text);
            }
            catch { textBox2.Text = fCoefficient.ToString(); }
        }

        private void cbMode_Validated(object sender, EventArgs e)
        {
            switch (cbMode.Text)
            {
                case "Wave":
                    iMode = 0;
                    break;
                case "Spectrum Analysis":
                    iMode = 1;
                    break;
                default:
                    iMode = 0;
                    break;
            }
        }

        private void graphs_Resize(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                textBox1.Text = "w: " + pictureBox1.Width.ToString() + ", h: " + pictureBox1.Height.ToString();
        }
    }
}