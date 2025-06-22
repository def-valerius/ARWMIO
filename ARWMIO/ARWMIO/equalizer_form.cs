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
    public partial class equalizer_form : Form
    {
        private int position = 0;
        private wPlay[] localWPlay;
        public equalizer_form()
        {
            InitializeComponent();
        }
        public void PassRefArrwPlay(ref wPlay[] wPlay)
        {
            localWPlay = wPlay;
            if (localWPlay != null)
            {
                for (int i = 0; i < wPlay.Length; i++)
                {
                    comboBox1.Items.Add(i);
                }
                UpdateControls(0);
                comboBox1.Select(0, 0);
            }
        }
        public void UpdateControls(int pos = 0)
        {
            if (localWPlay != null)
            {
                float[] bandwidthArr = new float[16];
                float[] gainArr = new float[16];
                float[] FrequencyArr = new float[16];

                for (int j = 0; j < localWPlay[pos].eqBands.Length; j++)
                {
                    bandwidthArr[j] = localWPlay[pos].eqBands[j].Bandwidth;
                    gainArr[j] = localWPlay[pos].eqBands[j].Gain;
                    FrequencyArr[j] = localWPlay[pos].eqBands[j].Frequency;
                }

                tbBandwidth1.Text = bandwidthArr[0].ToString();
                tbBandwidth2.Text = bandwidthArr[1].ToString();
                tbBandwidth3.Text = bandwidthArr[2].ToString();
                tbBandwidth4.Text = bandwidthArr[3].ToString();
                tbBandwidth5.Text = bandwidthArr[4].ToString();
                tbBandwidth6.Text = bandwidthArr[5].ToString();
                tbBandwidth7.Text = bandwidthArr[6].ToString();
                tbBandwidth8.Text = bandwidthArr[7].ToString();
                tbBandwidth9.Text = bandwidthArr[8].ToString();
                tbBandwidth10.Text = bandwidthArr[9].ToString();
                tbBandwidth11.Text = bandwidthArr[10].ToString();
                tbBandwidth12.Text = bandwidthArr[11].ToString();
                tbBandwidth13.Text = bandwidthArr[12].ToString();
                tbBandwidth14.Text = bandwidthArr[13].ToString();
                tbBandwidth15.Text = bandwidthArr[14].ToString();
                tbBandwidth16.Text = bandwidthArr[15].ToString();


                trackBar1.Value = (int)gainArr[0];
                trackBar2.Value = (int)gainArr[1];
                trackBar3.Value = (int)gainArr[2];
                trackBar4.Value = (int)gainArr[3];
                trackBar5.Value = (int)gainArr[4];
                trackBar6.Value = (int)gainArr[5];
                trackBar7.Value = (int)gainArr[6];
                trackBar8.Value = (int)gainArr[7];
                trackBar9.Value = (int)gainArr[8];
                trackBar10.Value = (int)gainArr[9];
                trackBar11.Value = (int)gainArr[10];
                trackBar12.Value = (int)gainArr[11];
                trackBar13.Value = (int)gainArr[12];
                trackBar14.Value = (int)gainArr[13];
                trackBar15.Value = (int)gainArr[14];
                trackBar16.Value = (int)gainArr[15];

                tbFreq1.Text = FrequencyArr[0].ToString();
                tbFreq2.Text = FrequencyArr[1].ToString();
                tbFreq3.Text = FrequencyArr[2].ToString();
                tbFreq4.Text = FrequencyArr[3].ToString();
                tbFreq5.Text = FrequencyArr[4].ToString();
                tbFreq6.Text = FrequencyArr[5].ToString();
                tbFreq7.Text = FrequencyArr[6].ToString();
                tbFreq8.Text = FrequencyArr[7].ToString();
                tbFreq9.Text = FrequencyArr[8].ToString();
                tbFreq10.Text = FrequencyArr[9].ToString();
                tbFreq11.Text = FrequencyArr[10].ToString();
                tbFreq12.Text = FrequencyArr[11].ToString();
                tbFreq13.Text = FrequencyArr[12].ToString();
                tbFreq14.Text = FrequencyArr[13].ToString();
                tbFreq15.Text = FrequencyArr[14].ToString();
                tbFreq16.Text = FrequencyArr[15].ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            #region arrays of bandwidth, gain, frequency values
            float[] bandwidthArr = {Convert.ToSingle(tbBandwidth1.Text),
                                    Convert.ToSingle(tbBandwidth2.Text),
                                    Convert.ToSingle(tbBandwidth3.Text),
                                    Convert.ToSingle(tbBandwidth4.Text),
                                    Convert.ToSingle(tbBandwidth5.Text),
                                    Convert.ToSingle(tbBandwidth6.Text),
                                    Convert.ToSingle(tbBandwidth7.Text),
                                    Convert.ToSingle(tbBandwidth8.Text),
                                    Convert.ToSingle(tbBandwidth9.Text),
                                    Convert.ToSingle(tbBandwidth10.Text),
                                    Convert.ToSingle(tbBandwidth11.Text),
                                    Convert.ToSingle(tbBandwidth12.Text),
                                    Convert.ToSingle(tbBandwidth13.Text),
                                    Convert.ToSingle(tbBandwidth14.Text),
                                    Convert.ToSingle(tbBandwidth15.Text),
                                    Convert.ToSingle(tbBandwidth16.Text)
            };
            float[] gainArr = { Convert.ToSingle(trackBar1.Value),
                                Convert.ToSingle(trackBar2.Value),
                                Convert.ToSingle(trackBar3.Value),
                                Convert.ToSingle(trackBar4.Value),
                                Convert.ToSingle(trackBar5.Value),
                                Convert.ToSingle(trackBar6.Value),
                                Convert.ToSingle(trackBar7.Value),
                                Convert.ToSingle(trackBar8.Value),
                                Convert.ToSingle(trackBar9.Value),
                                Convert.ToSingle(trackBar10.Value),
                                Convert.ToSingle(trackBar11.Value),
                                Convert.ToSingle(trackBar12.Value),
                                Convert.ToSingle(trackBar13.Value),
                                Convert.ToSingle(trackBar14.Value),
                                Convert.ToSingle(trackBar15.Value),
                                Convert.ToSingle(trackBar16.Value)
            };
            float[] FrequencyArr = { Convert.ToSingle(tbFreq1.Text),
                                     Convert.ToSingle(tbFreq2.Text),
                                     Convert.ToSingle(tbFreq3.Text),
                                     Convert.ToSingle(tbFreq4.Text),
                                     Convert.ToSingle(tbFreq5.Text),
                                     Convert.ToSingle(tbFreq6.Text),
                                     Convert.ToSingle(tbFreq7.Text),
                                     Convert.ToSingle(tbFreq8.Text),
                                     Convert.ToSingle(tbFreq9.Text),
                                     Convert.ToSingle(tbFreq10.Text),
                                     Convert.ToSingle(tbFreq11.Text),
                                     Convert.ToSingle(tbFreq12.Text),
                                     Convert.ToSingle(tbFreq13.Text),
                                     Convert.ToSingle(tbFreq14.Text),
                                     Convert.ToSingle(tbFreq15.Text),
                                     Convert.ToSingle(tbFreq16.Text)
            };
            #endregion

            if ((localWPlay != null) & (localWPlay.Length > 0))
            {
                for (int j = 0; j < localWPlay[position].eqBands.Length; j++)
                {
                    localWPlay[position].eqBands[j].Bandwidth = bandwidthArr[j];
                    localWPlay[position].eqBands[j].Gain = gainArr[j];
                    localWPlay[position].eqBands[j].Frequency = FrequencyArr[j];
                }
                localWPlay[position].equalizerProv.Update();
            }
        }

        #region trackbar and bextbox connection
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            tbGain1.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            tbGain2.Text = trackBar2.Value.ToString();
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            tbGain3.Text = trackBar3.Value.ToString();
        }

        private void trackBar4_ValueChanged(object sender, EventArgs e)
        {
            tbGain4.Text = trackBar4.Value.ToString();
        }

        private void trackBar5_ValueChanged(object sender, EventArgs e)
        {
            tbGain5.Text = trackBar5.Value.ToString();
        }

        private void trackBar6_ValueChanged(object sender, EventArgs e)
        {
            tbGain6.Text = trackBar6.Value.ToString();
        }

        private void trackBar7_ValueChanged(object sender, EventArgs e)
        {
            tbGain7.Text = trackBar7.Value.ToString();
        }

        private void trackBar8_ValueChanged(object sender, EventArgs e)
        {
            tbGain8.Text = trackBar8.Value.ToString();
        }

        private void trackBar9_ValueChanged(object sender, EventArgs e)
        {
            tbGain9.Text = trackBar9.Value.ToString();
        }

        private void trackBar10_ValueChanged(object sender, EventArgs e)
        {
            tbGain10.Text = trackBar10.Value.ToString();
        }

        private void trackBar11_ValueChanged(object sender, EventArgs e)
        {
            tbGain11.Text = trackBar11.Value.ToString();
        }

        private void trackBar12_ValueChanged(object sender, EventArgs e)
        {
            tbGain12.Text = trackBar12.Value.ToString();
        }

        private void trackBar13_ValueChanged(object sender, EventArgs e)
        {
            tbGain13.Text = trackBar13.Value.ToString();
        }

        private void trackBar14_ValueChanged(object sender, EventArgs e)
        {
            tbGain14.Text = trackBar14.Value.ToString();
        }

        private void trackBar15_ValueChanged(object sender, EventArgs e)
        {
            tbGain15.Text = trackBar15.Value.ToString();
        }

        private void trackBar16_ValueChanged(object sender, EventArgs e)
        {
            tbGain16.Text = trackBar16.Value.ToString();
        }

        private void tbGain1_Validated(object sender, EventArgs e)
        {
            try
            {
                trackBar1.Value = Convert.ToInt32(tbGain1.Text);
            }
            catch { }
        }

        private void tbGain2_Validated(object sender, EventArgs e)
        {
            try
            {
                trackBar2.Value = Convert.ToInt32(tbGain2.Text);
            }
            catch { }
        }

        private void tbGain3_Validated(object sender, EventArgs e)
        {
            try
            {
                trackBar3.Value = Convert.ToInt32(tbGain3.Text);
            }
            catch { }
        }

        private void tbGain4_Validated(object sender, EventArgs e)
        {
            try
            {
                trackBar4.Value = Convert.ToInt32(tbGain4.Text);
            }
            catch { }
        }

        private void tbGain5_Validated(object sender, EventArgs e)
        {
            try
            {
                trackBar5.Value = Convert.ToInt32(tbGain5.Text);
            }
            catch { }
        }

        private void tbGain6_Validated(object sender, EventArgs e)
        {
            try
            {
                trackBar6.Value = Convert.ToInt32(tbGain6.Text);
            }
            catch { }
        }

        private void tbGain7_Validated(object sender, EventArgs e)
        {
            try
            {
                trackBar7.Value = Convert.ToInt32(tbGain7.Text);
            }
            catch { }
        }

        private void tbGain8_Validated(object sender, EventArgs e)
        {
            try
            {
                trackBar8.Value = Convert.ToInt32(tbGain8.Text);
            }
            catch { }
        }

        private void tbGain9_Validated(object sender, EventArgs e)
        {
            try
            {
                trackBar9.Value = Convert.ToInt32(tbGain9.Text);
            }
            catch { }
        }

        private void tbGain10_Validated(object sender, EventArgs e)
        {
            try
            {
                trackBar10.Value = Convert.ToInt32(tbGain10.Text);
            }
            catch { }
        }

        private void tbGain11_Validated(object sender, EventArgs e)
        {
            try
            {
                trackBar11.Value = Convert.ToInt32(tbGain11.Text);
            }
            catch { }
        }

        private void tbGain12_Validated(object sender, EventArgs e)
        {
            try
            {
                trackBar12.Value = Convert.ToInt32(tbGain12.Text);
            }
            catch { }
        }

        private void tbGain13_Validated(object sender, EventArgs e)
        {
            try
            {
                trackBar13.Value = Convert.ToInt32(tbGain13.Text);
            }
            catch { }
        }

        private void tbGain14_Validated(object sender, EventArgs e)
        {
            try
            {
                trackBar14.Value = Convert.ToInt32(tbGain14.Text);
            }
            catch { }
        }

        private void tbGain15_Validated(object sender, EventArgs e)
        {
            try
            {
                trackBar15.Value = Convert.ToInt32(tbGain15.Text);
            }
            catch { }
        }

        private void tbGain16_Validated(object sender, EventArgs e)
        {
            try
            {
                trackBar16.Value = Convert.ToInt32(tbGain16.Text);
            }
            catch { }
        }
        #endregion

        private void comboBox1_Validated(object sender, EventArgs e)
        {
            position = comboBox1.SelectedIndex;
            UpdateControls(position);
        }
    }
}
