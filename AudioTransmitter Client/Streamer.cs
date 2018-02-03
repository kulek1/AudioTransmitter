using System;
using NAudio.Lame;
using NAudio.Wave;

namespace AudioTransmitter_Client
{
    class Streamer
    {
        static LameMP3FileWriter wri;
        static bool stopped = false;

        public void startRecord()
        {
            // Start recording from loopback
            IWaveIn waveIn = new WasapiLoopbackCapture();
            waveIn.DataAvailable += waveIn_DataAvailable;
            waveIn.RecordingStopped += waveIn_RecordingStopped;
            // Setup MP3 writer to output at 32kbit/sec (~2 minutes per MB)
            wri = new LameMP3FileWriter(@"C:\test\test_output.mp3", waveIn.WaveFormat, 192);
            waveIn.StartRecording();

            stopped = false;
        

            System.Threading.Thread.Sleep(4050);
            waveIn.StopRecording();
            // flush output to finish MP3 file correctly
            wri.Flush();
            // Dispose of objects
            waveIn.Dispose();
            wri.Dispose();
        }

        public void stopRecord()
        {
            stopped = true;
        }

        static void waveIn_RecordingStopped(object sender, StoppedEventArgs e)
        {
            // signal that recording has finished
            stopped = true;
        }

        static void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            // write recorded data to MP3 writer
            if (wri != null)
                wri.Write(e.Buffer, 0, e.BytesRecorded);
        }
    }
}