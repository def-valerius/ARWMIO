using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Globalization;

namespace ARWMIO
{
    public partial class formMain : Form
    {
        public int intNumberOfSources;
        public bool blnAutoStart = false;

        private bool blnPlaying = false;
        private wPlay[] wPlayArr = null;

        public graphs graphsForm = new graphs();

        public formMain()
        {
            InitializeComponent();
        }

        public void setParameters(bool pAutoStart, string pFileName)
        {
            blnAutoStart = pAutoStart;
            if (File.Exists(pFileName))
            {
                dsList.ReadXml(pFileName);
            }
            
        }

        private void playStopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!blnPlaying)
            {
                blnPlaying = true;

                DataTable dtIOSource = new DataTable();
                dtIOSource = dsList.Tables["IOSource"];

                Thread[] threads = new Thread[dtIOSource.Rows.Count];
                wPlayArr = new wPlay[dtIOSource.Rows.Count];
                
                int i = 0;
                foreach (DataRow row in dtIOSource.Rows)
                {
                    if ((row["inputID"].ToString() != "") & (row["outputID"].ToString() != ""))
                    {
                        wPlayArr[i] = new wPlay();
                        wPlayArr[i].setValues(row["inputID"].ToString(),
                                              row["outputID"].ToString(),
                                              (float)row["pitch"],
                                              (int)row["delay"],
                                              (float)row["panning"],
                                              (float)row["volume"],
                                              (int)row["delay_smpl"],
                                              cbStereoInput.Checked
                                             );
                        wPlayArr[i].iFFTSize = Convert.ToInt32(tbFFTSize.Text);
                        wPlayArr[i].lOSamp = Convert.ToInt64(tbOSamp.Text);
                        threads[i] = new Thread(new ThreadStart(wPlayArr[i].wasapiPlay));
                        threads[i].Priority = ThreadPriority.Highest;
                        threads[i].Start(); // ?

                        i += 1;
                    }
                }
                /*
                for (int j = 0; j < i; j++) // sometimes multiple outputs have up to 30 ms delay between them, will this help?
                    threads[j].Start(); // ?
                */

                intNumberOfSources = i;

                playStopToolStripMenuItem.Text += "(Now Playing)";

                timer10ms.Start();

                //graphsForm.byteArr = wPlayArr[0].byteArr;
            }
            else
            {
                for (int i = 0; i < intNumberOfSources; i++)
                {
                    if (wPlayArr[i] != null)
                    {
                        wPlayArr[i].wasapiStop();
                    }

                }

                blnPlaying = false;

                playStopToolStripMenuItem.Text = "Play / Stop";

                timer10ms.Stop();

                pbVolume.Value = 0;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void wASAPIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var enumerator = new NAudio.CoreAudioApi.MMDeviceEnumerator();
            lbInputDevice.Items.Clear();
            int i = 0;
            foreach (var wasapi in enumerator.EnumerateAudioEndPoints(NAudio.CoreAudioApi.DataFlow.Capture, NAudio.CoreAudioApi.DeviceState.Active))
            {
                lbInputDevice.Items.Add(wasapi.DataFlow + @" "
                                           + wasapi.FriendlyName + @" "
                                           + wasapi.DeviceFriendlyName + @" "
                                           + wasapi.State + @"?"
                                           + wasapi.ID);
                i += 1;
            }
            // Output device set
            //var enumerator = new NAudio.CoreAudioApi.MMDeviceEnumerator();
            lbOutputDevice.Items.Clear();
            i = 0;
            foreach (var wasapi in enumerator.EnumerateAudioEndPoints(NAudio.CoreAudioApi.DataFlow.Render, NAudio.CoreAudioApi.DeviceState.Active))
            {
                lbOutputDevice.Items.Add(wasapi.DataFlow + @" "
                                           + wasapi.FriendlyName + @" "
                                           + wasapi.DeviceFriendlyName + @" "
                                           + wasapi.State + @"?"
                                           + wasapi.ID);
                i += 1;
            }
        }

        private void lbInputDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbID.Text = lbInputDevice.Text;
            tbInputID.Text = lbInputDevice.Text.Substring(lbInputDevice.Text.IndexOf("?") + 1);
        }
        private void lbOutputDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbID.Text = lbOutputDevice.Text;
            tbOutputID.Text = lbOutputDevice.Text.Substring(lbOutputDevice.Text.IndexOf("?") + 1);
        }

        private void formMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (blnPlaying)
            {
                for (int i = 0; i < intNumberOfSources; i++)
                {
                    if (wPlayArr[i] != null)
                    {
                        wPlayArr[i].wasapiStop();
                    }
                }
            }
        }

        #region add, delete buttons
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //bsIOSource.AddNew();
            int intDelayBuff = 0;
            int intDelaySmplBuff = 0;
            float fVolumeBuff = 1f;
            float fPanningBuff = 0f;
            float fPitchBuff = 1f;

            if (tbDelay_ms.Text != "") { intDelayBuff = Int32.Parse(tbDelay_ms.Text); }
            if (tbDelay_smpl.Text != "") { intDelaySmplBuff = Int32.Parse(tbDelay_smpl.Text); }
            if (tbVolume.Text != "") { fVolumeBuff = Convert.ToSingle(tbVolume.Text); }
            if (tbPanning.Text != "") { fPanningBuff = Convert.ToSingle(tbPanning.Text); }
            if (tbPitch.Text != "") { fPitchBuff = Convert.ToSingle(tbPitch.Text); }

            DataTable dtIOSource = new DataTable();
            dtIOSource = dsList.Tables["IOSource"];
            DataRow row = dtIOSource.Rows.Add(tbInputID.Text, 
                                              tbOutputID.Text,
                                              intDelayBuff,
                                              fVolumeBuff,
                                              fPanningBuff,
                                              fPitchBuff,
                                              intDelaySmplBuff
                                             );
            //row["inputID"] = tbInputID.Text;
            
            
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DataTable dtIOSource = new DataTable();
                dtIOSource = dsList.Tables["IOSource"];
                dtIOSource.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            }

        }
        #endregion

        #region toolstrip buttons
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dsList.WriteXml(saveFileDialog1.FileName);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dsList.ReadXml(openFileDialog1.FileName);
            }
            
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            if (blnAutoStart)
            {
                playStopToolStripMenuItem.PerformClick(); // ok?
            }
        }
        #endregion

        #region volume meter test
        private void button1_Click(object sender, EventArgs e)
        {
            if (!timer10ms.Enabled)
            {
                timer10ms.Start();
            }
            else
            {
                timer10ms.Stop();
            }
            
            if ((wPlayArr[0] != null) & false)
            {

                textBox1.Text += wPlayArr[0].wCapture.WaveFormat.ToString() + ", ";
                textBox1.Text += wPlayArr[0].wCapture.WaveFormat.SampleRate.ToString() + ", ";
                textBox1.Text += wPlayArr[0].wCapture.WaveFormat.BitsPerSample.ToString() + ", ";
                textBox1.Text += "[0]=" + wPlayArr[0].byteArr[0].ToString() + ", ";
                textBox1.Text += wPlayArr[0].byteArr.Length.ToString();

                // 32 float
                if ((wPlayArr[0].byteArr.Length % 4) == 0)
                {
                    float[] floatArr = new float[wPlayArr[0].byteArr.Length / 4];
                    int j = 0;
                    for (int i = 0; i < wPlayArr[0].byteArr.Length; i = i + 4)
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
                    textBox1.Text += "; " + max.ToString();
                }
                

                /*
                float max = 0;
                for (int i = 0; i < wPlayArr[0].publicWaveBuffer.ShortBufferCount / 4; i++)
                {
                    var sample = wPlayArr[0].publicWaveBuffer.ShortBuffer[i];

                    // absolute value 
                    //if (sample < 0) sample = -sample;
                    if (sample < 0) sample = 0;
                    // is this the max value?
                    if (sample > max) max = sample;
                }
                textBox1.Text += "; " + max.ToString();
                */

            }

        }
        #endregion

        private void timer10ms_Tick(object sender, EventArgs e)
        {
            #region some test shit
            /*
            DataTable dtIOSource = new DataTable();
            dtIOSource = dsList.Tables["IOSource"];
            int rowNum = 0;
            foreach (DataRow row in dtIOSource.Rows)
            {
                if ((wPlayArr != null) & (wPlayArr[rowNum] != null) & (wPlayArr[rowNum].byteArr != null))
                {
                    if ((wPlayArr[rowNum].byteArr.Length % 4) == 0)
                    {
                        byte[] buffArr = wPlayArr[0].byteArr; // ?
                        float[] floatArr = new float[wPlayArr[rowNum].byteArr.Length / 4];
                        int j = 0;
                        for (int i = 0; i < wPlayArr[rowNum].byteArr.Length - 1; i = i + 4)
                        {
                            floatArr[j] = System.BitConverter.ToSingle(buffArr, i);
                            j++;
                        }

                        float max = 0;
                        for (int i = 0; i < floatArr.Length; i++)
                        {
                            var sample = floatArr[i];
                            if (sample < 0) sample -= sample;
                            if (sample > max) max = sample;
                        }
                    }
                }
                rowNum += 1;
            }
            */
            #endregion

            if (intNumberOfSources > 0)
                if ((wPlayArr != null) & (wPlayArr[0] != null) & (wPlayArr[0].byteArr != null))
                {
                    graphsForm.PassArray(wPlayArr[0].byteArr);
                    graphsForm.wPlayArr = wPlayArr;

                    textBox1.Text = wPlayArr[0].timespanTest.ToString();

                    if ((wPlayArr[0].byteArr.Length % 4) == 0)
                    {
                        byte[] buffArr = wPlayArr[0].byteArr; // ?
                        float[] floatArr = new float[wPlayArr[0].byteArr.Length / 4];
                        int j = 0;
                        for (int i = 0; i < wPlayArr[0].byteArr.Length / 4; i += 4)
                        {
                            floatArr[j] = System.BitConverter.ToSingle(buffArr, i);
                            j++;
                        }

                        float max = 0;
                        for (int i = 0; i < floatArr.Length / 4; i++)
                        {
                            var sample = floatArr[i];
                            if (sample < 0) sample -= sample;
                            if (sample > max) max = sample;
                        }
                        var vol = Math.Round(max, 2) * 100;
                        pbVolume.Value = System.Convert.ToInt32(vol);
                    }
                }
        }

        private void graphsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphsForm.Show();
        }

        private void equalizerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            equalizer_form eqForm = new equalizer_form();
            eqForm.PassRefArrwPlay(ref wPlayArr);
            eqForm.Show();
        }

        private void idkControlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            control_idk idkForm = new control_idk();
            idkForm.PassRefArrwPlay(ref wPlayArr);
            idkForm.Show();
        }
    }
}
