using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ARWMIO
{
    public partial class formMain : Form
    {
        private bool blnPlaying = false;
        private wPlay[] wPlayArr = null;

        public formMain()
        {
            InitializeComponent();
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
            else
            {
                DataTable dtIOSource = new DataTable();
                dtIOSource = dsList.Tables["IOSource"];

                int i = 0;
                foreach (DataRow row in dtIOSource.Rows)
                {
                    if (wPlayArr[i] != null)
                    {
                        wPlayArr[i].wasapiStop();
                    }

                    i += 1;
                }

                blnPlaying = false;
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

    }
}
