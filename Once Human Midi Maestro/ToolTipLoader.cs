using System.Windows.Forms;

namespace Once_Human_Midi_Maestro
{
    public static class ToolTipLoader
    {
        public static void LoadToolTips(Button buttonPlaySong, Button buttonStopSong, Button buttonExportMidi, TrackBar trackBarTempo, TrackBar trackBarModifierDelay, CheckBox checkBoxRepeatSong, CheckBox checkBoxSkipOctave3and5, CheckBox checkBoxMergeOctaves, CheckBox checkBoxAlwaysOnTop, Button buttonSignal)
        {
            ToolTip toolTip = new ToolTip
            {
                AutoPopDelay = 10000,
                InitialDelay = 500,
                ReshowDelay = 500,
                ShowAlways = true,
                ToolTipIcon = ToolTipIcon.Info,
                ToolTipTitle = "Once Human MIDI Maestro - Information"
            };

            if (buttonPlaySong != null)
            {
                toolTip.SetToolTip(buttonPlaySong, "You can press F5 to start the MIDI playback in game.");
            }

            if (buttonStopSong != null)
            {
                toolTip.SetToolTip(buttonStopSong, "You can press F6 to stop the MIDI playback in game.");
            }

            if (trackBarTempo != null)
            {
                toolTip.SetToolTip(trackBarTempo, "This will adjust the timing of MIDI notes sent to the piano, making them play faster or slower.");
            }

            if (trackBarModifierDelay != null)
            {
                toolTip.SetToolTip(trackBarModifierDelay, "This will introduce a delay between pressing a Shift or Control modifier key and the key button.");
            }

            if (checkBoxRepeatSong != null)
            {
                toolTip.SetToolTip(checkBoxRepeatSong, "This will loop the song till the end of days.");
            }
            
            if (checkBoxSkipOctave3and5 != null)
            {
                toolTip.SetToolTip(checkBoxSkipOctave3and5, "This will ignore all the key presses that is not on Octave 4.\nBasically, this will ignore all the keys that require Shift and Ctrl key presses.");
            }

            if (checkBoxMergeOctaves != null)
            {
                toolTip.SetToolTip(checkBoxMergeOctaves, "This will mearge all the keys in Octave 3 and 5 into Octave 4.\nBasically, this will ignore the Shift and Ctrl Key presses.");
            }

            if (checkBoxAlwaysOnTop != null)
            {
                toolTip.SetToolTip(checkBoxAlwaysOnTop, "This will always keep the Once Human MIDI Maestro window on top of everything else.\nVery usefull if you only have one screen.");
            }
            
            if (buttonExportMidi != null)
            {
                toolTip.SetToolTip(buttonExportMidi, "This will export the loaded MIDI file to a readable .txt file that can be found where the application is launched from.");
            }
            
            if (buttonSignal != null)
            {
                toolTip.SetToolTip(buttonSignal, "Signal is an Open Source MIDI creator where you can play and create MIDI files online.");
            }
        }
    }
}