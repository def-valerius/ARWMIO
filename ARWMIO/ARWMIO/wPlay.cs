using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System.Threading;

namespace ARWMIO
{
    class wPlay
    {
        public MMDevice wInput;
        public MMDevice wOutput;

        public float fPitch;
        public int iLatency;
        public float fPanning;
        public float fVolume;
        public string strInputDeviceID;
        public string strOutputDeviceID;

        private WasapiOut wOut;
        private WasapiCapture wCapture;
        private BufferedWaveProvider buffWaveProv;
        public void setValues(string pInputID, string pOutputID, float pfPitch, int piLatency, float pfPanning, float pfVolume)
        {
            strInputDeviceID = pInputID;
            strOutputDeviceID = pOutputID;
            fPitch = pfPitch;
            iLatency = piLatency;
            fPanning = pfPanning;
            fVolume = pfVolume;
        }

        public void wasapiPlay()
        {
            ISampleProvider sampleProvider1;
            VolumeSampleProvider volumeSampleProv1;
            SmbPitchShiftingSampleProvider smbPitchSampleProv1;
            OffsetSampleProvider offsetSampleProv1;
            PanningSampleProvider panSampleProv1;

            void funcForBuff(object sender, WaveInEventArgs waveInEventArgs)
            {
                buffWaveProv.AddSamples(waveInEventArgs.Buffer, 0, waveInEventArgs.BytesRecorded);
            }

            var enumerator = new NAudio.CoreAudioApi.MMDeviceEnumerator();
            wInput = enumerator.GetDevice(strInputDeviceID);
            wOutput = enumerator.GetDevice(strOutputDeviceID);

            wOut = new WasapiOut(wOutput, AudioClientShareMode.Shared, true, 10);
            wCapture = new WasapiCapture(wInput, true, 10);

            buffWaveProv = new BufferedWaveProvider(wCapture.WaveFormat);

            wCapture.DataAvailable += funcForBuff;

            sampleProvider1 = buffWaveProv.ToSampleProvider();
            smbPitchSampleProv1 = new SmbPitchShiftingSampleProvider(sampleProvider1);
            smbPitchSampleProv1.PitchFactor = fPitch;

            offsetSampleProv1 = new OffsetSampleProvider(smbPitchSampleProv1);
            offsetSampleProv1.DelayBy = new TimeSpan(0, 0, 0, 0, iLatency);

            panSampleProv1 = new PanningSampleProvider(offsetSampleProv1.ToMono(1f, 1f));
            panSampleProv1.Pan = fPanning;

            volumeSampleProv1 = new VolumeSampleProvider(panSampleProv1);
            volumeSampleProv1.Volume = fVolume;

            wOut.Init(volumeSampleProv1);
            wCapture.StartRecording();
            wOut.Play();

        }
        public void wasapiStop()
        {
            if (wCapture != null)
            {
                wCapture.StopRecording();
                wCapture.Dispose();
                wCapture = null;
            }

            if (wOut != null)
            {
                wOut.Stop();
                wOut.Dispose();
                wOut = null;
            }

            if (buffWaveProv != null)
            {
                buffWaveProv.ClearBuffer(); // ?
                buffWaveProv = null;
            }
        }
    }
}
