using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using WindowsInput.Native;

namespace Once_Human_Midi_Maestro
{
    public partial class FormMain : Form
    {
        private GlobalKeyboardHook _globalKeyboardHook;

        public FormMain()
        {
            InitializeComponent();
            _globalKeyboardHook = new GlobalKeyboardHook();
            _globalKeyboardHook.KeyboardPressed += OnKeyPressed;
            _globalKeyboardHook.HookKeyboard();
        }

        // Importing necessary methods from user32.dll
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

        private IntPtr gameWindowHandle = IntPtr.Zero;
        private Thread midiThread;
        private CancellationTokenSource cancellationTokenSource;

        private void FormMain_Load(object sender, System.EventArgs e)
        {
            if (!GameWindowLookup())
            {
                MessageBox.Show("Game process not found. Make sure OnceHuman.exe is running.");
                return;
            }
        }

        private void buttonLoadMidi_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "MIDI files (*.mid)|*.mid|All files (*.*)|*.*";
                openFileDialog.Title = "Select a MIDI file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string midiFilePath = openFileDialog.FileName;
                    labelSelectedMidi.Text = midiFilePath;
                }
            }
        }

        private bool GameWindowLookup()
        {
            if (gameWindowHandle == IntPtr.Zero)
            {
                try
                {
                    Process[] processes = Process.GetProcessesByName("ONCE_HUMAN");
                    if (processes.Length == 0)
                    {
                        //MessageBox.Show("Game process not found. Make sure OnceHuman.exe is running.");
                        return false;
                    }

                    gameWindowHandle = processes[0].MainWindowHandle;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

                return true;
            }

            return true;
        }

        private void OnKeyPressed(object sender, KeyPressedEventArgs e)
        {
            Console.WriteLine(e.Key);

            if (e.Key == Keys.F5)
            {
                if (!GameWindowLookup())
                {
                    MessageBox.Show("Game process not found. Make sure OnceHuman.exe is running.");
                    return;
                }
                    
                cancellationTokenSource = new CancellationTokenSource();
                midiThread = new Thread(() => PlayMidi(labelSelectedMidi.Text, cancellationTokenSource.Token));
                midiThread.Start();
            }

            if (e.Key == Keys.F6)
            {
                if (cancellationTokenSource != null)
                    cancellationTokenSource.Cancel();

                SendKey(VirtualKeyCode.LCONTROL, false);
                SendKey(VirtualKeyCode.LSHIFT, false);
            }

        }

        private bool isCtrlDown = false;
        private bool isShiftDown = false;
        private void PlayMidi(string midiFilePath, CancellationToken token)
        {
            if (string.IsNullOrEmpty(midiFilePath))
            {
                MessageBox.Show("Please load a MIDI file first.");
                return;
            }

            try
            {
                MidiFile midiFile = new MidiFile(midiFilePath, false);
                int ticksPerQuarterNote = midiFile.DeltaTicksPerQuarterNote;
                int tempo = 500000; // Default tempo (microseconds per quarter note)

                // Find initial tempo
                foreach (var track in midiFile.Events)
                {
                    foreach (MidiEvent midiEvent in track)
                    {
                        if (midiEvent is MetaEvent metaEvent && metaEvent.MetaEventType == MetaEventType.SetTempo)
                        {
                            tempo = ((TempoEvent)metaEvent).MicrosecondsPerQuarterNote;
                            break;
                        }
                    }
                }

                List<(MidiEvent midiEvent, int absoluteTime)> allEvents = new List<(MidiEvent, int)>();
                int[] absoluteTimes = new int[midiFile.Tracks]; // Array to keep track of the absolute time for each track

                // Collect all events with their absolute times
                for (int trackIndex = 0; trackIndex < midiFile.Events.Tracks; trackIndex++)
                {
                    foreach (MidiEvent midiEvent in midiFile.Events[trackIndex])
                    {
                        allEvents.Add((midiEvent, absoluteTimes[trackIndex]));
                        absoluteTimes[trackIndex] += midiEvent.DeltaTime;
                    }
                }

                // Sort events by their absolute time
                allEvents.Sort((x, y) => x.absoluteTime.CompareTo(y.absoluteTime));
                bool playOnce = true;

                while (checkBoxRepeatSong.Checked || playOnce)
                {
                    int lastTime = 0;
                    foreach (var (midiEvent, absoluteTime) in allEvents)
                    {
                        if (token.IsCancellationRequested)
                        {
                            return;
                        }

                        int delay = (int)((absoluteTime - lastTime) * (tempo / ticksPerQuarterNote) / 1000); // Delay in milliseconds
                        delay = delay + (GetTrackBarValueSafe() * 10);
                        if (delay < 0) delay = 0;
                        Thread.Sleep(delay);
                        lastTime = absoluteTime;

                        if (midiEvent is NoteOnEvent noteOn && noteOn.CommandCode == MidiCommandCode.NoteOn)
                        {

                            if (MidiKeyMap.MidiToKey.ContainsKey(noteOn.NoteNumber) && noteOn.NoteName.Length < 4)
                            {
                                if (checkBoxSkipOctave3and5.Checked && MidiKeyMap.MidiToKey[noteOn.NoteNumber].Count > 1)
                                {
                                    DebugLog($"Skipped: {noteOn.NoteName} {noteOn.NoteNumber} ({string.Join(", ", MidiKeyMap.MidiToKey[noteOn.NoteNumber])})\n");
                                }
                                else
                                {

                                    if (IsControlKeyPressed(MidiKeyMap.MidiToKey[noteOn.NoteNumber]))
                                    {
                                        if (isShiftDown)
                                        {
                                            SendKey(VirtualKeyCode.LSHIFT, false);
                                            isShiftDown = false;
                                        }

                                        if (isCtrlDown)
                                        {
                                            SendKey(VirtualKeyCode.LSHIFT, false);
                                            isShiftDown = false;

                                            VirtualKeyCode lastKeyCode = MidiKeyMap.MidiToKey.ContainsKey(noteOn.NoteNumber) ? MidiKeyMap.MidiToKey[noteOn.NoteNumber].Last() : default;
                                            SendKey(lastKeyCode, true);
                                            SendKey(lastKeyCode, false);
                                        }
                                        else
                                        {
                                            SendKeyCombination(MidiKeyMap.MidiToKey[noteOn.NoteNumber], true);
                                            isCtrlDown = true;
                                        }
                                    }
                                    else if (IsShiftKeyPressed(MidiKeyMap.MidiToKey[noteOn.NoteNumber]))
                                    {

                                        if (isCtrlDown)
                                        {
                                            SendKey(VirtualKeyCode.LCONTROL, false);
                                            isCtrlDown = false;
                                        }

                                        if (isShiftDown)
                                        {
                                            SendKey(VirtualKeyCode.LCONTROL, false);
                                            isCtrlDown = false;

                                            VirtualKeyCode lastKeyCode = MidiKeyMap.MidiToKey.ContainsKey(noteOn.NoteNumber) ? MidiKeyMap.MidiToKey[noteOn.NoteNumber].Last() : default;
                                            SendKey(lastKeyCode, true);
                                            SendKey(lastKeyCode, false);
                                        }
                                        else
                                        {
                                            SendKeyCombination(MidiKeyMap.MidiToKey[noteOn.NoteNumber], true);
                                            isShiftDown = true;
                                        }
                                    }
                                    else
                                    {
                                        if (isCtrlDown)
                                        {
                                            SendKey(VirtualKeyCode.LCONTROL, false);
                                            isCtrlDown = false;
                                        }
                                        if (isShiftDown)
                                        {
                                            SendKey(VirtualKeyCode.LSHIFT, false);
                                            isShiftDown = false;
                                        }

                                        //VirtualKeyCode lastKeyCode = MidiKeyMap.midiToKeyMap.ContainsKey(noteOn.NoteNumber) ? MidiKeyMap.midiToKeyMap[noteOn.NoteNumber].Last() : default;
                                        //SendKey(lastKeyCode, true);
                                        //SendKey(lastKeyCode, false);

                                        SendKeyCombination(MidiKeyMap.MidiToKey[noteOn.NoteNumber], false);
                                        SendKeyCombination(MidiKeyMap.MidiToKey[noteOn.NoteNumber], true);
                                        SendKeyCombination(MidiKeyMap.MidiToKey[noteOn.NoteNumber], false);
                                    }
                                    DebugLog($"Key Down: {noteOn.NoteName} {noteOn.NoteNumber} ({string.Join(", ", MidiKeyMap.MidiToKey[noteOn.NoteNumber])})\n");
                                }
                            }
                            else
                            {
                                DebugLog($"Key Not in Game's Piano Keys: {noteOn.NoteName}\n");
                            }
                        }
                    }

                    playOnce = false;
                }

                SendKey(VirtualKeyCode.LCONTROL, false);
                SendKey(VirtualKeyCode.LSHIFT, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private bool IsControlKeyPressed(List<VirtualKeyCode> keys)
        {
            if (checkBoxMergeOctaves.Checked)
            {
                return false;
            }
            return keys.Contains(VirtualKeyCode.LCONTROL) || keys.Contains(VirtualKeyCode.RCONTROL);
        }

        private bool IsShiftKeyPressed(List<VirtualKeyCode> keys)
        {
            if (checkBoxMergeOctaves.Checked)
            {
                return false;
            }
            return keys.Contains(VirtualKeyCode.LSHIFT) || keys.Contains(VirtualKeyCode.RSHIFT);
        }

        private void SendKeyCombination(List<VirtualKeyCode> keys, bool keyDown)
        {
            foreach (var key in keys)
            {
                SendKey(key, keyDown);
            }
        }

        private void SendKey(VirtualKeyCode key, bool keyDown)
        {
            // Ensure the game window is in the foreground
            SetForegroundWindow(gameWindowHandle);

            INPUT[] inputs = new INPUT[1];
            inputs[0].type = INPUT_KEYBOARD;
            inputs[0].u.ki.wVk = (ushort)key;
            inputs[0].u.ki.wScan = 0;
            inputs[0].u.ki.dwFlags = keyDown ? 0 : KEYEVENTF_KEYUP;
            inputs[0].u.ki.time = 0;
            inputs[0].u.ki.dwExtraInfo = IntPtr.Zero;

            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
        }

        private void DebugLog(string Log)
        {
            // Check if Invoke is required
            if (richTextBoxDebug.InvokeRequired)
            {
                // Use BeginInvoke to asynchronously execute the update on the UI thread
                richTextBoxDebug.BeginInvoke(new Action(() =>
                {
                    richTextBoxDebug.AppendText(Log);

                    // Scroll to the end of the RichTextBox
                    richTextBoxDebug.SelectionStart = richTextBoxDebug.Text.Length;
                    richTextBoxDebug.ScrollToCaret();
                }));
            }
            else
            {
                // If already on the UI thread, update directly
                richTextBoxDebug.AppendText(Log);

                // Scroll to the end of the RichTextBox
                richTextBoxDebug.SelectionStart = richTextBoxDebug.Text.Length;
                richTextBoxDebug.ScrollToCaret();
            }
        }

        public delegate int SafeGetDelegate();
        private int GetTrackBarValueSafe()
        {
            if (trackBarTempo.InvokeRequired)
            {
                var d = new SafeGetDelegate(GetTrackBarValueSafe);
                return (int)trackBarTempo.Invoke(d);
            }
            else
            {
                return trackBarTempo.Value;
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _globalKeyboardHook.UnhookKeyboard();
            base.OnFormClosed(e);
        }

        private void trackBarTempo_ValueChanged(object sender, EventArgs e)
        {
            labelTempo.Text = GetTrackBarValueSafe().ToString();
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
                MessageBox.Show($"Failed to open URL: {ex.Message}");
            }
        }
    }
}
