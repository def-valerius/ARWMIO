using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using NAudio.Extras;
using System.Threading;
using NAudio.Dsp;

namespace ARWMIO
{
    public class wPlay
    {
        public MMDevice wInput;
        public MMDevice wOutput;

        public float fPitch;
        public int iDelay;
        public int iDelaySample;
        public float fPanning;
        public float fVolume;
        public bool bStereo;
        public string strInputDeviceID;
        public string strOutputDeviceID;

        public TimeSpan timespanTest; // TEST
        public byte[] byteArr;
        private byte[] byteArrPre;
        public int iPartOfArray = 0;

        private WasapiOut wOut;
        public WasapiCapture wCapture;
        //private BufferedWaveProvider buffWaveProv;
        private BufferedWaveProvider buffWaveProv;

        public ISampleProvider sampleProvider1;
        public VolumeSampleProvider volumeSampleProv1;
        public SmbPitchShiftingSampleProvider smbPitchSampleProv1;
        public OffsetSampleProvider offsetSampleProv1;
        public PanningSampleProvider panSampleProv1;
        public Equalizer equalizerProv;
        public EqualizerBand[] eqBands;

        DateTime dtTest = DateTime.Now;
        public void setValues(string pInputID, string pOutputID, float pfPitch, int piDelay, float pfPanning, float pfVolume, int piDelay_smpl, bool pbStereo)
        {
            strInputDeviceID = pInputID;
            strOutputDeviceID = pOutputID;
            fPitch = pfPitch;
            iDelay = piDelay;
            iDelaySample = piDelay_smpl;
            fPanning = pfPanning;
            fVolume = pfVolume;
            bStereo = pbStereo;
        }

        public void wasapiPlay()
        {
            /*
            ISampleProvider sampleProvider1;
            VolumeSampleProvider volumeSampleProv1;
            SmbPitchShiftingSampleProvider smbPitchSampleProv1;
            OffsetSampleProvider offsetSampleProv1;
            PanningSampleProvider panSampleProv1;
            DateTime dtTest = DateTime.Now;
            */
            void funcForBuff(object sender, WaveInEventArgs waveInEventArgs)
            {
                buffWaveProv.AddSamples(waveInEventArgs.Buffer, 0, waveInEventArgs.BytesRecorded);

                timespanTest = DateTime.Now - dtTest; // TEST
                dtTest = DateTime.Now;

                //publicWaveBuffer = new WaveBuffer(waveInEventArgs.Buffer);
                if ((iPartOfArray < 4) & (waveInEventArgs.BytesRecorded > 0))
                {
                    byteArr = new byte[waveInEventArgs.BytesRecorded * (iPartOfArray + 1)];
                    if (iPartOfArray == 0)
                    {
                        byteArrPre = new byte[waveInEventArgs.BytesRecorded];
                        for (int i = 0; i < waveInEventArgs.BytesRecorded; i++)
                        {
                            byteArr[i] = waveInEventArgs.Buffer[i];
                            byteArrPre[i] = waveInEventArgs.Buffer[i];
                        }
                        /*
                        byteArr = waveInEventArgs.Buffer;
                        byteArrPre = waveInEventArgs.Buffer;
                        */
                        iPartOfArray++;
                    }
                    else
                    {
                        if (!(iPartOfArray == 3))
                        {
                            iPartOfArray++;
                        }
                        else
                        {
                            byte[] anotherArr = new byte[byteArrPre.Length - waveInEventArgs.BytesRecorded];
                            int j = 0;
                            for (int l = waveInEventArgs.BytesRecorded; l < byteArrPre.Length; l++)
                            {
                                anotherArr[j] = byteArrPre[l];
                                j++;
                            }
                            byteArrPre = anotherArr;
                        }
                        int i = 0;
                        for (i = 0; i < byteArrPre.Length; i++)
                            byteArr[i] = byteArrPre[i];

                        for (int j = 0; j < waveInEventArgs.BytesRecorded; j++)
                            byteArr[i + j] = waveInEventArgs.Buffer[j];

                        byteArrPre = byteArr;
                    }
                }
                /*
                byteArr = new byte[waveInEventArgs.BytesRecorded];
                byteArr = waveInEventArgs.Buffer;
                */
                /*
                double d = waveInEventArgs.BytesRecorded / 4;
                fArrFromSample = new float[Convert.ToInt32(Math.Round(d))];
                volumeSampleProv1.Read(fArrFromSample, 0, Convert.ToInt32(Math.Round(d))); // terrible lag, almost no sound
                */
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
            if (iDelaySample > 0)
                offsetSampleProv1.DelayBySamples = iDelaySample;

            if (bStereo)
            {
                volumeSampleProv1 = new VolumeSampleProvider(offsetSampleProv1);
            }
            else
            {
                panSampleProv1 = new PanningSampleProvider(offsetSampleProv1.ToMono(1f, 1f));
                panSampleProv1.Pan = fPanning;

                volumeSampleProv1 = new VolumeSampleProvider(panSampleProv1);
            }

            volumeSampleProv1.Volume = fVolume;

            eqBands = new EqualizerBand[]
                                    {
                                        new EqualizerBand{Bandwidth = 0.8f, Frequency = 20, Gain = 0 },
                                        new EqualizerBand{Bandwidth = 0.8f, Frequency = 40, Gain = 0 },
                                        new EqualizerBand{Bandwidth = 0.8f, Frequency = 80, Gain = 0 },
                                        new EqualizerBand{Bandwidth = 0.8f, Frequency = 160, Gain = 0 },
                                        new EqualizerBand{Bandwidth = 0.8f, Frequency = 320, Gain = 0 },
                                        new EqualizerBand{Bandwidth = 0.8f, Frequency = 640, Gain = 0 },
                                        new EqualizerBand{Bandwidth = 0.8f, Frequency = 1280, Gain = 0 },
                                        new EqualizerBand{Bandwidth = 0.8f, Frequency = 2560, Gain = 0 },
                                        new EqualizerBand{Bandwidth = 0.8f, Frequency = 5120, Gain = 0 },
                                        new EqualizerBand{Bandwidth = 0.8f, Frequency = 10240, Gain = 0 },
                                        new EqualizerBand{Bandwidth = 0.8f, Frequency = 20480, Gain = 0 },
                                        new EqualizerBand{Bandwidth = 0.8f, Frequency = 20480, Gain = 0 },
                                        new EqualizerBand{Bandwidth = 0.8f, Frequency = 20480, Gain = 0 },
                                        new EqualizerBand{Bandwidth = 0.8f, Frequency = 20480, Gain = 0 },
                                        new EqualizerBand{Bandwidth = 0.8f, Frequency = 20480, Gain = 0 },
                                        new EqualizerBand{Bandwidth = 0.8f, Frequency = 20480, Gain = 0 }
                                    };
            equalizerProv = new Equalizer(volumeSampleProv1, eqBands);

            //wOut.Init(volumeSampleProv1);
            wOut.Init(equalizerProv);
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
