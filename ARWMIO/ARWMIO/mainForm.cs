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

namespace ARWMIO
{
    public partial class formMain : Form
    {
        public int intNumberOfSources;
        public bool blnAutoStart = false;

        private bool blnPlaying = false;
        private wPlay[] wPlayArr = null;

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
                                              (int)row["latency"],
                                              (float)row["panning"],
                                              (float)row["volume"]
                                             );
                        threads[i] = new Thread(new ThreadStart(wPlayArr[i].wasapiPlay));
                        threads[i].Start();

                        i += 1;
                    }
                }

                intNumberOfSources = i;

                playStopToolStripMenuItem.Text += "(Now Playing)";
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
            int intLatencyBuff = 0;
            float fVolumeBuff = 1f;
            float fPanningBuff = 0f;
            float fPitchBuff = 1f;

            if (tbLatency.Text != "") { intLatencyBuff = Int32.Parse(tbLatency.Text); }
            if (tbVolume.Text != "") { fVolumeBuff = Convert.ToSingle(tbVolume.Text); }
            if (tbPanning.Text != "") { fPanningBuff = Convert.ToSingle(tbPanning.Text); }
            if (tbPitch.Text != "") { fPitchBuff = Convert.ToSingle(tbPitch.Text); }

            DataTable dtIOSource = new DataTable();
            dtIOSource = dsList.Tables["IOSource"];
            DataRow row = dtIOSource.Rows.Add(tbInputID.Text, 
                                              tbOutputID.Text,
                                              intLatencyBuff,
                                              fVolumeBuff,
                                              fPanningBuff,
                                              fPitchBuff
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

    }
}
