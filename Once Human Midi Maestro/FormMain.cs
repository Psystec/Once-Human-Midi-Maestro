using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput.Native;
using System.Text;
using System.Net;

namespace Once_Human_Midi_Maestro
{
    public partial class FormMain : Form
    {
        private MidiIn midiIn;
        private IntPtr gameWindowHandle = IntPtr.Zero;
        private CancellationTokenSource cancellationTokenSource;
        private string selectedMidiPath;
        private bool isPlaying = false;

        private VisualPiano visualPiano;

        public FormMain()
        {
            InitializeComponent();
            this.Text = "Once Human MIDI Maestro by Psystec v2.7.3";
            InitializeMidiInput();

            MidiKeyMap.LoadFromJson("MidiKeyMap.json");

            visualPiano = new VisualPiano(panelPiano);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Settings.Init();

            if (!string.IsNullOrEmpty(Settings.settings.LastMidiFile))
            {
                selectedMidiPath = Settings.settings.LastMidiFile;
                labelSelectedMidi.Text = Path.GetFileName(selectedMidiPath);
                DebugLog($"Selected Midi File: {selectedMidiPath}\n");
            }

            if (Settings.settings.RepeatSong)
                checkBoxRepeatSong.Checked = true;
            if (Settings.settings.SkipOctave3and5)
                checkBoxSkipOctave3and5.Checked = true;
            if (Settings.settings.MergeOctave4)
                checkBoxMergeOctaves.Checked = true;
            if (Settings.settings.AlwaysOnTop)
                checkBoxAlwaysOnTop.Checked = true;
            trackBarTempo.Value = Settings.settings.Speed;
            labelTempo.Text = trackBarTempo.Value.ToString();
            trackBarModifierDelay.Value = Settings.settings.ModifierDelay;
            labelModifiedDelay.Text = trackBarModifierDelay.Value.ToString();

            if (!Settings.settings.Debug)
            {
                groupBoxDebug.Visible = false;
                this.Height = this.Height - 90;
            }


            if (!TryGetGameWindowHandle())
            {
                ShowErrorMessage("Game process not found. Make sure OnceHuman.exe is running.", false);
            }

            ToolTipLoader.LoadToolTips(buttonExportMidi, trackBarTempo, trackBarModifierDelay, checkBoxRepeatSong, checkBoxSkipOctave3and5, checkBoxMergeOctaves, checkBoxAlwaysOnTop, buttonSignal);

            groupBoxMidiShare.Visible = false;
            this.Width = this.Width - groupBoxMidiShare.Width;

            //listBoxMidiShare.Items.AddRange(MidiShare.ListMidiFiles());
        }

        private void InitializeMidiInput()
        {
            int deviceCount = MidiIn.NumberOfDevices;
            if (deviceCount > 0)
            {
                midiIn = new MidiIn(0);
                midiIn.MessageReceived += OnMidiMessageReceived;
                midiIn.Start();
                DebugLog("MIDI input devices found.\n");
            }
            else
            {
                DebugLog("No MIDI input devices found.\n");
            }
        }

        private void OnMidiMessageReceived(object sender, MidiInMessageEventArgs e)
        {
            if (e.MidiEvent.CommandCode == MidiCommandCode.NoteOff)
            {
                var noteOnEvent = (NoteEvent)e.MidiEvent;
                int noteNumber = noteOnEvent.NoteNumber;

                visualPiano.ReleaseKeyboard(noteNumber);
            }

            if (e.MidiEvent.CommandCode == MidiCommandCode.NoteOn)
            {
                var noteOnEvent = (NoteEvent)e.MidiEvent;
                int noteNumber = noteOnEvent.NoteNumber;

                if (MidiKeyMap.MidiToKey.ContainsKey(noteNumber))
                {
                    var keys = MidiKeyMap.MidiToKey[noteNumber];
                    bool shouldPressCtrl = keys.Contains(VirtualKeyCode.LCONTROL) || keys.Contains(VirtualKeyCode.RCONTROL);
                    bool shouldPressShift = keys.Contains(VirtualKeyCode.LSHIFT) || keys.Contains(VirtualKeyCode.RSHIFT);

                    // Press modifiers briefly
                    if (shouldPressCtrl)
                    {
                        SendKey(VirtualKeyCode.LCONTROL, true);
                        Thread.Sleep(GetTrackBarValueSafe(trackBarModifierDelay));
                    }
                    if (shouldPressShift)
                    {
                        SendKey(VirtualKeyCode.LSHIFT, true);
                        Thread.Sleep(GetTrackBarValueSafe(trackBarModifierDelay));
                    }

                    visualPiano.PressKeyboard(noteNumber);

                    // Press the main key
                    var keyWithoutModifiers = keys.Last(key => key != VirtualKeyCode.LCONTROL && key != VirtualKeyCode.RCONTROL && key != VirtualKeyCode.LSHIFT && key != VirtualKeyCode.RSHIFT);
                    SendKey(keyWithoutModifiers, true);
                    SendKey(keyWithoutModifiers, false);

                    // Immediately release modifiers
                    if (shouldPressCtrl)
                    {
                        SendKey(VirtualKeyCode.LCONTROL, false);
                        Thread.Sleep(GetTrackBarValueSafe(trackBarModifierDelay));
                    }
                    if (shouldPressShift)
                    {
                        SendKey(VirtualKeyCode.LSHIFT, false);
                        Thread.Sleep(GetTrackBarValueSafe(trackBarModifierDelay));
                    }

                    DebugLog($"MIDI Keyboard Down: {noteNumber} -> Game Key: {string.Join(", ", MidiKeyMap.MidiToKey[noteNumber])}\n");
                }
                else
                {
                    DebugLog($"MIDI Keyboard Not Mapped: {noteNumber}\n");
                }
            }
        }

        private void buttonLoadMidi_Click(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                DebugLog("A song is playing. Please stop it first.\n");
                return;
            }

            if (!TryGetGameWindowHandle())
            {
                ShowErrorMessage("Game process not found. Make sure OnceHuman.exe is running.");
            }

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "MIDI files (*.mid)|*.mid|All files (*.*)|*.*";
                openFileDialog.Title = "Select a MIDI file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedMidiPath = openFileDialog.FileName;
                    labelSelectedMidi.Text = Path.GetFileName(selectedMidiPath);
                    DebugLog($"Selected Midi File: {selectedMidiPath}\n");
                    Settings.settings.LastMidiFile = selectedMidiPath;
                    Settings.SaveSettings();
                }
            }
        }

        private bool TryGetGameWindowHandle()
        {
            try
            {
                var process = Process.GetProcessesByName("ONCE_HUMAN").FirstOrDefault();
                if (process == null)
                {
                    return false;
                }

                gameWindowHandle = process.MainWindowHandle;
                return true;
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error: {ex.Message}");
                return false;
            }
        }

        private async void StartPlayback()
        {
            DebugLog($"Playing Song: {selectedMidiPath}\n");

            cancellationTokenSource = new CancellationTokenSource();
            isPlaying = true;

            await Task.Run(() => PlayMidi(selectedMidiPath, cancellationTokenSource.Token));

            isPlaying = false;
        }

        private void StopPlayback()
        {
            cancellationTokenSource?.Cancel();
            isPlaying = false;
            DebugLog("Song Stop Requested.\n");

            ReleaseModifiers();
        }

        private void PlayMidi(string midiFilePath, CancellationToken token)
        {
            if (string.IsNullOrEmpty(midiFilePath))
            {
                ShowErrorMessage("Please load a MIDI file first.");
                return;
            }

            try
            {
                MidiFile midiFile = new MidiFile(midiFilePath, false);
                int ticksPerQuarterNote = midiFile.DeltaTicksPerQuarterNote;
                int tempo = GetInitialTempo(midiFile);

                var allEvents = CollectMidiEvents(midiFile);

                bool playOnce = true;
                bool isShiftDown = false;
                bool isCtrlDown = false;

                while (checkBoxRepeatSong.Checked || playOnce)
                {
                    int lastTime = 0;

                    foreach (var (midiEvent, absoluteTime) in allEvents)
                    {
                        if (token.IsCancellationRequested)
                        {
                            return;
                        }

                        if (midiEvent is NoteOnEvent noteOn && MidiKeyMap.MidiToKey.TryGetValue(noteOn.NoteNumber, out var keys))
                        {
                            int delay = CalculateDelay(absoluteTime, lastTime, tempo, ticksPerQuarterNote);
                            DebugLog($"Delay: {delay}\n");
                            Thread.Sleep(delay);

                            lastTime = absoluteTime;

                            if (ShouldSkipKey(noteOn))
                            {
                                DebugLog($"Skipped: {noteOn.NoteName} {noteOn.NoteNumber} ({string.Join(", ", keys)})\n");
                                continue;
                            }

                            if (delay < 60)
                                delay = 60;
                            visualPiano.HighlightKey(noteOn.NoteNumber, delay);

                            bool cngd = HandleModifiers(ref isCtrlDown, ref isShiftDown, keys);
                            if (cngd) Thread.Sleep(GetTrackBarValueSafe(trackBarModifierDelay));
                            PressKeyWithoutModifiers(keys);
                            DebugLog($"Key Down: {noteOn.NoteName} {noteOn.NoteNumber} ({string.Join(", ", keys)})\n");
                        }

                        // Lol
                        if (token.IsCancellationRequested)
                        {
                            return;
                        }
                    }

                    playOnce = false;
                }

                ReleaseModifiers();
                DebugLog("Song Ended.\n");
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error: {ex.Message}");
            }
        }

        private int GetInitialTempo(MidiFile midiFile)
        {
            foreach (var track in midiFile.Events)
            {
                var tempoEvent = track.OfType<TempoEvent>().FirstOrDefault();
                if (tempoEvent != null)
                {
                    return tempoEvent.MicrosecondsPerQuarterNote;
                }
            }

            return 500000; // Default tempo
        }

        private List<(MidiEvent midiEvent, int absoluteTime)> CollectMidiEvents(MidiFile midiFile)
        {
            var allEvents = new List<(MidiEvent, int)>();
            int[] absoluteTimes = new int[midiFile.Tracks];

            for (int trackIndex = 0; trackIndex < midiFile.Events.Tracks; trackIndex++)
            {
                foreach (MidiEvent midiEvent in midiFile.Events[trackIndex])
                {
                    absoluteTimes[trackIndex] += midiEvent.DeltaTime;

                    if (midiEvent is NoteOnEvent noteOnEvent && noteOnEvent.Velocity > 0)
                    {
                        allEvents.Add((midiEvent, absoluteTimes[trackIndex]));
                    }
                }
            }

            // Sort events by their absolute time
            allEvents.Sort((x, y) => x.Item2.CompareTo(y.Item2));
            return allEvents;
        }

        private int CalculateDelay(int absoluteTime, int lastTime, int tempo, int ticksPerQuarterNote)
        {
            int delay = (int)((absoluteTime - lastTime) * (tempo / ticksPerQuarterNote) / 1000);
            delay += GetTrackBarValueSafe(trackBarTempo) * -5;
            //delay += GetTrackBarValueSafe(trackBarModifierDelay);
            return delay < 0 ? 0 : delay;
        }

        private bool ShouldSkipKey(NoteOnEvent noteOn)
        {
            return checkBoxSkipOctave3and5.Checked && MidiKeyMap.MidiToKey[noteOn.NoteNumber].Count > 1;
        }

        bool prevCpress = false;
        bool prevSpress = false;
        private bool HandleModifiers(ref bool isCtrlDown, ref bool isShiftDown, List<VirtualKeyCode> keys)
        {
            bool shouldPressCtrl = IsControlKeyPressed(keys);
            bool shouldPressShift = IsShiftKeyPressed(keys);

            if (shouldPressCtrl != isCtrlDown)
            {
                SendKey(VirtualKeyCode.LCONTROL, shouldPressCtrl);
                isCtrlDown = shouldPressCtrl;
            }

            if (shouldPressShift != isShiftDown)
            {
                SendKey(VirtualKeyCode.LSHIFT, shouldPressShift);
                isShiftDown = shouldPressShift;
            }

            bool result = false;
            if (shouldPressCtrl == prevCpress && shouldPressShift == prevSpress)
                result = false;
            else
                result = true;
            prevCpress = shouldPressCtrl;
            prevSpress = shouldPressShift;
            return result;
        }

        private void PressKeyWithoutModifiers(List<VirtualKeyCode> keys)
        {
            var keyWithoutModifiers = keys.Last(key => key != VirtualKeyCode.LCONTROL && key != VirtualKeyCode.LSHIFT);
            SendKey(keyWithoutModifiers, true);
            SendKey(keyWithoutModifiers, false);
        }

        private void ReleaseModifiers()
        {
            SendKey(VirtualKeyCode.LCONTROL, false);
            SendKey(VirtualKeyCode.LSHIFT, false);
        }

        private bool IsControlKeyPressed(List<VirtualKeyCode> keys)
        {
            return !checkBoxMergeOctaves.Checked && (keys.Contains(VirtualKeyCode.LCONTROL) || keys.Contains(VirtualKeyCode.RCONTROL));
        }

        private bool IsShiftKeyPressed(List<VirtualKeyCode> keys)
        {
            return !checkBoxMergeOctaves.Checked && (keys.Contains(VirtualKeyCode.LSHIFT) || keys.Contains(VirtualKeyCode.RSHIFT));
        }

        private void SendKeyCombination(List<VirtualKeyCode> keys)
        {
            foreach (var key in keys)
            {
                SendKey(key, true);
                Thread.Sleep(3);
                SendKey(key, false);
            }
        }

        private void SendKey(VirtualKeyCode key, bool keyDown)
        {
            Win32Api.SetForegroundWindow(gameWindowHandle);

            var inputs = new Win32Api.INPUT[]
            {
                new Win32Api.INPUT
                {
                    type = Win32Api.INPUT_KEYBOARD,
                    u = new Win32Api.InputUnion
                    {
                        ki = new Win32Api.KEYBDINPUT
                        {
                            wVk = (ushort)key,
                            dwFlags = keyDown ? 0 : Win32Api.KEYEVENTF_KEYUP
                        }
                    }
                }
            };

            Win32Api.SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Win32Api.INPUT)));
        }

        private void DebugLog(string message)
        {
            if (richTextBoxDebug.InvokeRequired)
            {
                richTextBoxDebug.BeginInvoke(new Action(() =>
                {
                    richTextBoxDebug.AppendText(message);
                    ScrollDebugLogToEnd();
                }));
            }
            else
            {
                richTextBoxDebug.AppendText(message);
                ScrollDebugLogToEnd();
            }
        }

        private void ScrollDebugLogToEnd()
        {
            richTextBoxDebug.SelectionStart = richTextBoxDebug.Text.Length;
            richTextBoxDebug.ScrollToCaret();
        }

        private int GetTrackBarValueSafe(TrackBar trackBar)
        {
            if (trackBar.InvokeRequired)
            {
                return (int)trackBar.Invoke(new Func<int>(() => trackBar.Value));
            }
            else
            {
                return trackBar.Value;
            }
        }

        private void ShowErrorMessage(string message, bool popup = true)
        {
            if (popup)
                MessageBox.Show(message, "Once Human MIDI Maestro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DebugLog($"{message}\n");
        }

        private void trackBarTempo_ValueChanged(object sender, EventArgs e)
        {
            labelTempo.Text = GetTrackBarValueSafe(trackBarTempo).ToString();

            Settings.settings.Speed = GetTrackBarValueSafe(trackBarTempo);
            Settings.SaveSettings();
        }

        private void trackBarModifierDelay_Scroll(object sender, EventArgs e)
        {
            labelModifiedDelay.Text = GetTrackBarValueSafe(trackBarModifierDelay).ToString();

            Settings.settings.ModifierDelay = GetTrackBarValueSafe(trackBarModifierDelay);
            Settings.SaveSettings();
        }

        private void buttonDiscord_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://discord.gg/s3vqJRCGht",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Failed to open URL: {ex.Message}");
            }
        }

        private void buttonGitHub_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://github.com/Psystec/Once-Human-Midi-Maestro",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Failed to open URL: {ex.Message}");
            }
        }

        private void buttonSignal_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://signal.vercel.app",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Failed to open URL: {ex.Message}");
            }
        }

        private void buttonPlaySong_Click(object sender, EventArgs e)
        {
            if (!TryGetGameWindowHandle())
            {
                ShowErrorMessage("Game process not found. Make sure OnceHuman.exe is running.");
                return;
            }

            if (isPlaying)
            {
                DebugLog("A song is playing. Please stop it first.\n");
                return;
            }

            StartPlayback();
        }

        private void buttonStopSong_Click(object sender, EventArgs e)
        {
            StopPlayback();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            ReleaseModifiers();
            //midiIn?.Stop();
            //midiIn?.Dispose();
            //base.OnFormClosed(e);
        }

        private void buttonExportMidi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMidiPath))
            {
                MessageBox.Show("Please load a MIDI file first.");
                return;
            }

            StringBuilder stringBuilder = new StringBuilder();
            MidiFile midiFile = new MidiFile(selectedMidiPath, false);
            foreach (var track in midiFile.Events)
            {
                foreach (MidiEvent midiEvent in track)
                {
                    stringBuilder.AppendLine(midiEvent.ToString());
                }
            }

            try
            {
                File.WriteAllText(Path.GetFileName(selectedMidiPath) + ".txt", stringBuilder.ToString());
                MessageBox.Show($"MIDI file exported successfully to:\n\n{Path.GetFileName(selectedMidiPath) + ".txt"}");
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"failed to export midi file:\n\n{ex.ToString()}");
            }
        }

        private void checkBoxRepeatSong_CheckedChanged(object sender, EventArgs e)
        {
            Settings.settings.RepeatSong = checkBoxRepeatSong.Checked;
            Settings.SaveSettings();
        }

        private void checkBoxSkipOctave3and5_CheckedChanged(object sender, EventArgs e)
        {
            Settings.settings.SkipOctave3and5 = checkBoxSkipOctave3and5.Checked;
            Settings.SaveSettings();
        }

        private void checkBoxMergeOctaves_CheckedChanged(object sender, EventArgs e)
        {
            Settings.settings.MergeOctave4 = checkBoxMergeOctaves.Checked;
            Settings.SaveSettings();
        }
        private void checkBoxAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = checkBoxAlwaysOnTop.Checked;

            Settings.settings.AlwaysOnTop = checkBoxAlwaysOnTop.Checked;
            Settings.SaveSettings();
        }

        private void buttonMidiShare_Click(object sender, EventArgs e)
        {
            if (buttonMidiShare.Text == "MIDI Share <")
            {
                buttonMidiShare.Text = "MIDI Share >";
                groupBoxMidiShare.Visible = false;
                this.Width = this.Width - groupBoxMidiShare.Width;
            }
            else
            {
                buttonMidiShare.Text = "MIDI Share <";
                groupBoxMidiShare.Visible = true;
                this.Width = this.Width + 221;
            }
        }

        private void buttonMidiShareDownload_Click(object sender, EventArgs e)
        {
            if (listBoxMidiShare.SelectedItem == null)
            {
                MessageBox.Show("Please select a file from the list.");
                return;
            }

            if (!Directory.Exists("MIDI Files"))
                Directory.CreateDirectory("MIDI Files");

            string selectedFile = listBoxMidiShare.SelectedItem.ToString();
            string downloadPath = Path.Combine("MIDI Files", selectedFile);

            MidiShare.DownloadMidi(selectedFile, downloadPath);
        }

        private void buttonMidiShareUpload_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Before uploading, please ensure your file is properly formatted. This will help others easily find your MIDI file by its name. Please remove any underscores and special characters from the file name.", "MIDI Maestro Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            MidiShare.UploadMidi();
        }

        private void buttonMidiListReload_Click(object sender, EventArgs e)
        {
            listBoxMidiShare.Items.Clear();

            listBoxMidiShare.Items.AddRange(MidiShare.ListMidiFiles());
        }
    }
}
