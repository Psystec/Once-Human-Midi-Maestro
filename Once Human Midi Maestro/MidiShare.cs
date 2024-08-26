using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Once_Human_Midi_Maestro
{
    public class MidiShare
    {
        private const string FtpServer = "ftp.psystec.com";
        private const string FtpUsername = "Maestro@midimaestro.psystec.com";
        private const string FtpPassword = "N?i?h,JqC=t[";
        private const string FtpUrl = "ftp://" + FtpServer + "/";

        public static string[] ListMidiFiles()
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FtpUrl);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(FtpUsername, FtpPassword);
                request.UsePassive = true;
                request.KeepAlive = false;
                request.EnableSsl = false;

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    List<string> files = new List<string>();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.EndsWith(".mid", StringComparison.OrdinalIgnoreCase))
                        {
                            files.Add(line);
                        }
                    }

                    return files.ToArray();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving file list: {ex.Message}");
                return null;
            }
        }

        public static void UploadMidi()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "MIDI files (*.mid)|*.mid|All files (*.*)|*.*";
                openFileDialog.Title = "Select a MIDI file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    string fileName = Path.GetFileName(filePath);

                    string uploadUrl = FtpUrl + fileName;

                    try
                    {
                        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uploadUrl);
                        request.Method = WebRequestMethods.Ftp.UploadFile;
                        request.Credentials = new NetworkCredential(FtpUsername, FtpPassword);
                        request.UsePassive = true;
                        request.KeepAlive = false;
                        request.EnableSsl = false;

                        byte[] fileContents = File.ReadAllBytes(filePath);

                        request.ContentLength = fileContents.Length;

                        using (Stream requestStream = request.GetRequestStream())
                        {
                            requestStream.Write(fileContents, 0, fileContents.Length);
                        }

                        using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                        {
                            MessageBox.Show($"Upload Complete.", "Midi Maestro Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error uploading file: {ex.Message}");
                    }
                }
            }
        }

        public static void DownloadMidi(string MidiFile, string DownloadPath)
        {
            string downloadUrl = FtpUrl + MidiFile;

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(downloadUrl);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(FtpUsername, FtpPassword);
                request.UsePassive = true;
                request.KeepAlive = false;
                request.EnableSsl = false;

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                using (Stream responseStream = response.GetResponseStream())
                using (FileStream fileStream = new FileStream(DownloadPath, FileMode.Create))
                {
                    responseStream.CopyTo(fileStream);
                    MessageBox.Show($"Download Complete.", "Midi Maestro Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error downloading file: {ex.Message}");
            }
        }

        public static void PlayMidi(string MidiFile)
        {
            try
            {
                // Load the MIDI file
                MidiFile midiFile = new MidiFile(MidiFile, false);

                // Create a MidiOut device (default device 0)
                using (var midiOut = new MidiOut(0))
                {
                    // Loop through each track in the MIDI file
                    foreach (IList<MidiEvent> track in midiFile.Events)
                    {
                        // Loop through each event in the track
                        foreach (var midiEvent in track)
                        {
                            // Send the event to the MIDI output device
                            midiOut.Send(midiEvent.GetAsShortMessage());

                            // Sleep for the event's delta time (time between events) to maintain timing
                            Thread.Sleep((int)midiEvent.DeltaTime);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing file: {ex.Message}");
            }
        }
    }
}
