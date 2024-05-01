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
        public int iDelay;
        public int iDelaySample;
        public float fPanning;
        public float fVolume;
        public string strInputDeviceID;
        public string strOutputDeviceID;

        public TimeSpan timespanTest; // TEST
        public WaveBuffer publicWaveBuffer = new WaveBuffer(20000);
        public byte[] byteArr;
        public int intBuffCnt;
        public int byteBuffCnt;
        public int floatBuffCnt;
        public int shortBuffCnt;

        private WasapiOut wOut;
        public WasapiCapture wCapture;
        //private BufferedWaveProvider buffWaveProv;
        private BufferedWaveProvider buffWaveProv;
        public void setValues(string pInputID, string pOutputID, float pfPitch, int piDelay, float pfPanning, float pfVolume, int piDelay_smpl)
        {
            strInputDeviceID = pInputID;
            strOutputDeviceID = pOutputID;
            fPitch = pfPitch;
            iDelay = piDelay;
            iDelaySample = piDelay_smpl;
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
            DateTime dtTest = DateTime.Now;

            void funcForBuff(object sender, WaveInEventArgs waveInEventArgs)
            {
                buffWaveProv.AddSamples(waveInEventArgs.Buffer, 0, waveInEventArgs.BytesRecorded);

                timespanTest = DateTime.Now - dtTest; // TEST
                dtTest = DateTime.Now;

                //publicWaveBuffer = new WaveBuffer(waveInEventArgs.Buffer);
                byteArr = new byte[waveInEventArgs.BytesRecorded];
                byteArr = waveInEventArgs.Buffer;

                intBuffCnt = publicWaveBuffer.numberOfBytes;
                //intBuffCnt = waveInEventArgs.BytesRecorded;
                byteBuffCnt = publicWaveBuffer.ByteBufferCount;
                floatBuffCnt = publicWaveBuffer.FloatBufferCount;
                shortBuffCnt = publicWaveBuffer.ShortBufferCount;

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
            offsetSampleProv1.DelayBy = new TimeSpan(0, 0, 0, 0, iDelay);
            offsetSampleProv1.DelayBySamples = iDelaySample;

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
