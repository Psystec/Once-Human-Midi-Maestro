using NAudio.Wave;
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

namespace Once_Human_Midi_Maestro
{
    public partial class FormMain : Form
    {
        //private GlobalKeyboardHook _globalKeyboardHook;
        private MidiIn midiIn;
        private IntPtr gameWindowHandle = IntPtr.Zero;
        private CancellationTokenSource cancellationTokenSource;
        private string selectedMidiPath;
        private bool isPlaying = false;

        private VisualPiano visualPiano;

        public FormMain()
        {
            InitializeComponent();
            this.Text = "Once Human MIDI Maestro by Psystec v2.3.0";
            //_globalKeyboardHook = new GlobalKeyboardHook();
            //_globalKeyboardHook.KeyboardPressed += OnKeyPressed;
            //_globalKeyboardHook.HookKeyboard();

            InitializeMidiInput();

            visualPiano = new VisualPiano(panelPiano);
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs, int cbSize);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [StructLayout(LayoutKind.Sequential)]
        public struct INPUT
        {
            public uint type;
            public InputUnion u;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct InputUnion
        {
            [FieldOffset(0)] public MOUSEINPUT mi;
            [FieldOffset(0)] public KEYBDINPUT ki;
            [FieldOffset(0)] public HARDWAREINPUT hi;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HARDWAREINPUT
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }

        private const int INPUT_KEYBOARD = 1;
        private const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
        private const uint KEYEVENTF_KEYUP = 0x0002;

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            checkBoxAlwaysOnTop.Checked = true;


            if (!TryGetGameWindowHandle())
            {
                ShowErrorMessage("Game process not found. Make sure OnceHuman.exe is running.");
            }
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

        //private void OnKeyPressed(object sender, KeyPressedEventArgs e)
        //{
        //    if (e.Key == Keys.F5 && !isPlaying)
        //    {
        //        if (!TryGetGameWindowHandle())
        //        {
        //            ShowErrorMessage("Game process not found. Make sure OnceHuman.exe is running.");
        //            return;
        //        }

        //        StartPlayback();
        //    }

        //    if (e.Key == Keys.F6 && isPlaying)
        //    {
        //        StopPlayback();
        //    }
        //}

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

                var allEvents = CollectMidiEvents(midiFile, ticksPerQuarterNote, tempo);

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
                            Thread.Sleep(delay);
                            DebugLog($"Delay: {delay}\n");
                            lastTime = absoluteTime;

                            if (ShouldSkipKey(noteOn))
                            {
                                DebugLog($"Skipped: {noteOn.NoteName} {noteOn.NoteNumber} ({string.Join(", ", keys)})\n");
                                continue;
                            }

                            if (delay < 50)
                                delay = 50;
                            visualPiano.HighlightKey(noteOn.NoteNumber, delay);

                            HandleModifiers(ref isCtrlDown, ref isShiftDown, keys);
                            PressKey(keys);
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

        private List<(MidiEvent midiEvent, int absoluteTime)> CollectMidiEvents(MidiFile midiFile, int ticksPerQuarterNote, int tempo)
        {
            var allEvents = new List<(MidiEvent, int)>();
            int[] absoluteTimes = new int[midiFile.Tracks];

            for (int trackIndex = 0; trackIndex < midiFile.Events.Tracks; trackIndex++)
            {
                foreach (MidiEvent midiEvent in midiFile.Events[trackIndex])
                {
                    allEvents.Add((midiEvent, absoluteTimes[trackIndex]));
                    absoluteTimes[trackIndex] += midiEvent.DeltaTime;
                }
            }

            // Sort events by their absolute time using positional access (Item1 for midiEvent, Item2 for absoluteTime)
            allEvents.Sort((x, y) => x.Item2.CompareTo(y.Item2));
            return allEvents;
        }

        private int CalculateDelay(int absoluteTime, int lastTime, int tempo, int ticksPerQuarterNote)
        {
            int delay = (int)((absoluteTime - lastTime) * (tempo / ticksPerQuarterNote) / 1000);
            delay += GetTrackBarValueSafe(trackBarTempo) * -20;
            return delay < 0 ? 0 : delay;
        }

        private bool ShouldSkipKey(NoteOnEvent noteOn)
        {
            return checkBoxSkipOctave3and5.Checked && MidiKeyMap.MidiToKey[noteOn.NoteNumber].Count > 1;
        }

        private void HandleModifiers(ref bool isCtrlDown, ref bool isShiftDown, List<VirtualKeyCode> keys)
        {
            bool shouldPressCtrl = IsControlKeyPressed(keys);
            bool shouldPressShift = IsShiftKeyPressed(keys);

            if (shouldPressCtrl != isCtrlDown)
            {
                SendKey(VirtualKeyCode.LCONTROL, shouldPressCtrl);
                isCtrlDown = shouldPressCtrl;
                Thread.Sleep(GetTrackBarValueSafe(trackBarModifierDelay));
            }

            if (shouldPressShift != isShiftDown)
            {
                SendKey(VirtualKeyCode.LSHIFT, shouldPressShift);
                isShiftDown = shouldPressShift;
                Thread.Sleep(GetTrackBarValueSafe(trackBarModifierDelay));
            }
        }

        private void PressKey(List<VirtualKeyCode> keys)
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
            SetForegroundWindow(gameWindowHandle);

            var inputs = new INPUT[]
            {
                new INPUT
                {
                    type = INPUT_KEYBOARD,
                    u = new InputUnion
                    {
                        ki = new KEYBDINPUT
                        {
                            wVk = (ushort)key,
                            dwFlags = keyDown ? 0 : KEYEVENTF_KEYUP
                        }
                    }
                }
            };

            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
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

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Once Human MIDI Maestro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DebugLog($"{message}\n");
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            //_globalKeyboardHook.UnhookKeyboard();
            midiIn?.Stop();
            midiIn?.Dispose();
            base.OnFormClosed(e);
        }

        private void trackBarTempo_ValueChanged(object sender, EventArgs e)
        {
            labelTempo.Text = GetTrackBarValueSafe(trackBarTempo).ToString();
        }

        private void trackBarModifierDelay_Scroll(object sender, EventArgs e)
        {
            labelModifiedDelay.Text = GetTrackBarValueSafe(trackBarModifierDelay).ToString();
        }

        private void checkBoxAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = checkBoxAlwaysOnTop.Checked;
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

            StartPlayback();
        }

        private void buttonStopSong_Click(object sender, EventArgs e)
        {
            StopPlayback();
        }
    }
}
