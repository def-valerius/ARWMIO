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
        private wPlay[] localWPlay;
        public equalizer_form()
        {
            InitializeComponent();
        }
        public void PassRefArrwPlay(ref wPlay[] wPlay)
        {
            localWPlay = wPlay;
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
                for (int i = 0; i < localWPlay.Length; i++)
                {
                    for (int j = 0; j < localWPlay[i].eqBands.Length; j++)
                    {
                        localWPlay[i].eqBands[j].Bandwidth = bandwidthArr[j];
                        localWPlay[i].eqBands[j].Gain = gainArr[j];
                        localWPlay[i].eqBands[j].Frequency = FrequencyArr[j];
                    }
                    localWPlay[i].equalizerProv.Update();
                }
            }
        }
    }
}
