using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Once_Human_Midi_Maestro
{
    public class VisualPiano
    {
        private List<PianoKeyButton> pianoKeys = new List<PianoKeyButton>();
        private Panel pianoPanel;

        public VisualPiano(Panel panel)
        {
            pianoPanel = panel;
            pianoPanel.SizeChanged += PianoPanel_SizeChanged; // Handle resizing
            CreatePianoKeys();
        }

        private void CreatePianoKeys()
        {
            pianoKeys.Clear();
            pianoPanel.Controls.Clear();

            int whiteKeyCount = 21; // 7 white keys per octave * 3 octaves
            int whiteKeyWidth = pianoPanel.Width / whiteKeyCount;
            int whiteKeyHeight = pianoPanel.Height;
            int blackKeyWidth = whiteKeyWidth / 2;
            int blackKeyHeight = whiteKeyHeight * 2 / 3;
            int currentX = 0;

            int keyNumber = 48; // Start numbering keys from 48

            for (int octave = 0; octave < 3; octave++)
            {
                for (int note = 0; note < 12; note++)
                {
                    bool isBlackKey = IsBlackKey(note);
                    int keyWidth = isBlackKey ? blackKeyWidth : whiteKeyWidth;
                    int keyHeight = isBlackKey ? blackKeyHeight : whiteKeyHeight;

                    if (!isBlackKey)
                    {
                        // Add the white key
                        Button whiteKeyButton = CreateKeyButton(keyNumber, keyWidth, keyHeight, currentX, 0, Color.White);
                        pianoKeys.Add(new PianoKeyButton { KeyNumber = keyNumber++, IsBlackKey = false, Button = whiteKeyButton });
                        pianoPanel.Controls.Add(whiteKeyButton);

                        currentX += whiteKeyWidth;
                    }
                    else
                    {
                        // Position the black key between the two adjacent white keys
                        int blackKeyX = currentX - (blackKeyWidth / 2);
                        Button blackKeyButton = CreateKeyButton(keyNumber, blackKeyWidth, blackKeyHeight, blackKeyX, 0, Color.Black);
                        pianoKeys.Add(new PianoKeyButton { KeyNumber = keyNumber++, IsBlackKey = true, Button = blackKeyButton });
                        pianoPanel.Controls.Add(blackKeyButton);

                        blackKeyButton.BringToFront(); // Ensure black keys are drawn on top
                    }
                }
            }
        }

        // Handle panel resizing
        private void PianoPanel_SizeChanged(object sender, EventArgs e)
        {
            CreatePianoKeys(); // Recreate the keys with the new panel size
        }

        // Function to create a Button representing a piano key
        private Button CreateKeyButton(int keyNumber, int width, int height, int left, int top, Color color)
        {
            return new Button
            {
                Width = width,
                Height = height,
                Left = left,
                Top = top,
                BackColor = color,
                FlatStyle = FlatStyle.Flat,
                Tag = keyNumber
            };
        }

        // Async function to highlight a key and automatically unhighlight it after a delay
        public async Task HighlightKey(int keyNumber, int delay = 50) // Default delay of 500ms
        {
            var key = pianoKeys.FirstOrDefault(k => k.KeyNumber == keyNumber);
            if (key != null)
            {
                key.Button.BackColor = Color.Aqua; // Change the color to highlight the key

                // Await the delay asynchronously
                await Task.Delay(delay);

                // Unhighlight the key after the delay
                UnhighlightKey(keyNumber);
            }
        }

        // Function to unhighlight a key by its number
        public void UnhighlightKey(int keyNumber)
        {
            var key = pianoKeys.FirstOrDefault(k => k.KeyNumber == keyNumber);
            if (key != null)
            {
                key.Button.BackColor = key.IsBlackKey ? Color.Black : Color.White; // Reset the color to its original state
            }
        }

        private bool IsBlackKey(int note)
        {
            return note == 1 || note == 3 || note == 6 || note == 8 || note == 10;
        }
    }

    public class PianoKeyButton
    {
        public int KeyNumber { get; set; } // Unique number assigned to each key
        public bool IsBlackKey { get; set; }
        public Button Button { get; set; } // The button representing the key
    }
}