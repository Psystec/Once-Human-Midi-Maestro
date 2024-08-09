namespace Once_Human_Midi_Maestro
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            groupBoxMidiFile = new System.Windows.Forms.GroupBox();
            labelSelectedMidi = new System.Windows.Forms.Label();
            labelSelectedMidiLabel = new System.Windows.Forms.Label();
            buttonLoadMidi = new System.Windows.Forms.Button();
            groupBoxSettings = new System.Windows.Forms.GroupBox();
            labelModifiedDelay = new System.Windows.Forms.Label();
            labelModifierDelayLabel = new System.Windows.Forms.Label();
            trackBarModifierDelay = new System.Windows.Forms.TrackBar();
            checkBoxAlwaysOnTop = new System.Windows.Forms.CheckBox();
            checkBoxMergeOctaves = new System.Windows.Forms.CheckBox();
            checkBoxSkipOctave3and5 = new System.Windows.Forms.CheckBox();
            checkBoxRepeatSong = new System.Windows.Forms.CheckBox();
            labelTempo = new System.Windows.Forms.Label();
            trackBarTempo = new System.Windows.Forms.TrackBar();
            labelSpeedLabel = new System.Windows.Forms.Label();
            groupBoxInformation = new System.Windows.Forms.GroupBox();
            labelInformation4 = new System.Windows.Forms.Label();
            labelInformation3 = new System.Windows.Forms.Label();
            labelInformation2 = new System.Windows.Forms.Label();
            labelInformation1 = new System.Windows.Forms.Label();
            groupBoxDebug = new System.Windows.Forms.GroupBox();
            richTextBoxDebug = new System.Windows.Forms.RichTextBox();
            buttonDiscord = new System.Windows.Forms.Button();
            panelPiano = new System.Windows.Forms.Panel();
            groupBoxMidiFile.SuspendLayout();
            groupBoxSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarModifierDelay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarTempo).BeginInit();
            groupBoxInformation.SuspendLayout();
            groupBoxDebug.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxMidiFile
            // 
            groupBoxMidiFile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxMidiFile.Controls.Add(labelSelectedMidi);
            groupBoxMidiFile.Controls.Add(labelSelectedMidiLabel);
            groupBoxMidiFile.Controls.Add(buttonLoadMidi);
            groupBoxMidiFile.Location = new System.Drawing.Point(12, 12);
            groupBoxMidiFile.Name = "groupBoxMidiFile";
            groupBoxMidiFile.Size = new System.Drawing.Size(478, 62);
            groupBoxMidiFile.TabIndex = 0;
            groupBoxMidiFile.TabStop = false;
            groupBoxMidiFile.Text = "MIDI File";
            // 
            // labelSelectedMidi
            // 
            labelSelectedMidi.AutoSize = true;
            labelSelectedMidi.Location = new System.Drawing.Point(174, 26);
            labelSelectedMidi.Name = "labelSelectedMidi";
            labelSelectedMidi.Size = new System.Drawing.Size(29, 15);
            labelSelectedMidi.TabIndex = 2;
            labelSelectedMidi.Text = "N/A";
            // 
            // labelSelectedMidiLabel
            // 
            labelSelectedMidiLabel.AutoSize = true;
            labelSelectedMidiLabel.Location = new System.Drawing.Point(87, 26);
            labelSelectedMidiLabel.Name = "labelSelectedMidiLabel";
            labelSelectedMidiLabel.Size = new System.Drawing.Size(81, 15);
            labelSelectedMidiLabel.TabIndex = 1;
            labelSelectedMidiLabel.Text = "Selected Midi:";
            // 
            // buttonLoadMidi
            // 
            buttonLoadMidi.Location = new System.Drawing.Point(6, 22);
            buttonLoadMidi.Name = "buttonLoadMidi";
            buttonLoadMidi.Size = new System.Drawing.Size(75, 23);
            buttonLoadMidi.TabIndex = 0;
            buttonLoadMidi.Text = "Load Midi";
            buttonLoadMidi.UseVisualStyleBackColor = true;
            buttonLoadMidi.Click += buttonLoadMidi_Click;
            // 
            // groupBoxSettings
            // 
            groupBoxSettings.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxSettings.Controls.Add(labelModifiedDelay);
            groupBoxSettings.Controls.Add(labelModifierDelayLabel);
            groupBoxSettings.Controls.Add(trackBarModifierDelay);
            groupBoxSettings.Controls.Add(checkBoxAlwaysOnTop);
            groupBoxSettings.Controls.Add(checkBoxMergeOctaves);
            groupBoxSettings.Controls.Add(checkBoxSkipOctave3and5);
            groupBoxSettings.Controls.Add(checkBoxRepeatSong);
            groupBoxSettings.Controls.Add(labelTempo);
            groupBoxSettings.Controls.Add(trackBarTempo);
            groupBoxSettings.Controls.Add(labelSpeedLabel);
            groupBoxSettings.Location = new System.Drawing.Point(12, 80);
            groupBoxSettings.Name = "groupBoxSettings";
            groupBoxSettings.Size = new System.Drawing.Size(478, 130);
            groupBoxSettings.TabIndex = 1;
            groupBoxSettings.TabStop = false;
            groupBoxSettings.Text = "Settings";
            // 
            // labelModifiedDelay
            // 
            labelModifiedDelay.AutoSize = true;
            labelModifiedDelay.Location = new System.Drawing.Point(442, 85);
            labelModifiedDelay.Name = "labelModifiedDelay";
            labelModifiedDelay.Size = new System.Drawing.Size(13, 15);
            labelModifiedDelay.TabIndex = 10;
            labelModifiedDelay.Text = "0";
            // 
            // labelModifierDelayLabel
            // 
            labelModifierDelayLabel.AutoSize = true;
            labelModifierDelayLabel.Location = new System.Drawing.Point(169, 85);
            labelModifierDelayLabel.Name = "labelModifierDelayLabel";
            labelModifierDelayLabel.Size = new System.Drawing.Size(87, 15);
            labelModifierDelayLabel.TabIndex = 9;
            labelModifierDelayLabel.Text = "Modifier Delay:";
            // 
            // trackBarModifierDelay
            // 
            trackBarModifierDelay.Location = new System.Drawing.Point(262, 73);
            trackBarModifierDelay.Maximum = 100;
            trackBarModifierDelay.Name = "trackBarModifierDelay";
            trackBarModifierDelay.Size = new System.Drawing.Size(174, 45);
            trackBarModifierDelay.TabIndex = 8;
            trackBarModifierDelay.TickStyle = System.Windows.Forms.TickStyle.Both;
            trackBarModifierDelay.Scroll += trackBarModifierDelay_Scroll;
            // 
            // checkBoxAlwaysOnTop
            // 
            checkBoxAlwaysOnTop.AutoSize = true;
            checkBoxAlwaysOnTop.Location = new System.Drawing.Point(6, 97);
            checkBoxAlwaysOnTop.Name = "checkBoxAlwaysOnTop";
            checkBoxAlwaysOnTop.Size = new System.Drawing.Size(104, 19);
            checkBoxAlwaysOnTop.TabIndex = 7;
            checkBoxAlwaysOnTop.Text = "Always On Top";
            checkBoxAlwaysOnTop.UseVisualStyleBackColor = true;
            checkBoxAlwaysOnTop.CheckedChanged += checkBoxAlwaysOnTop_CheckedChanged;
            // 
            // checkBoxMergeOctaves
            // 
            checkBoxMergeOctaves.AutoSize = true;
            checkBoxMergeOctaves.Location = new System.Drawing.Point(6, 72);
            checkBoxMergeOctaves.Name = "checkBoxMergeOctaves";
            checkBoxMergeOctaves.Size = new System.Drawing.Size(109, 19);
            checkBoxMergeOctaves.TabIndex = 6;
            checkBoxMergeOctaves.Text = "Merge Octave 4";
            checkBoxMergeOctaves.UseVisualStyleBackColor = true;
            // 
            // checkBoxSkipOctave3and5
            // 
            checkBoxSkipOctave3and5.AutoSize = true;
            checkBoxSkipOctave3and5.Location = new System.Drawing.Point(6, 47);
            checkBoxSkipOctave3and5.Name = "checkBoxSkipOctave3and5";
            checkBoxSkipOctave3and5.Size = new System.Drawing.Size(129, 19);
            checkBoxSkipOctave3and5.TabIndex = 5;
            checkBoxSkipOctave3and5.Text = "Skip Octave 3 and 5";
            checkBoxSkipOctave3and5.UseVisualStyleBackColor = true;
            // 
            // checkBoxRepeatSong
            // 
            checkBoxRepeatSong.AutoSize = true;
            checkBoxRepeatSong.Location = new System.Drawing.Point(6, 22);
            checkBoxRepeatSong.Name = "checkBoxRepeatSong";
            checkBoxRepeatSong.Size = new System.Drawing.Size(92, 19);
            checkBoxRepeatSong.TabIndex = 4;
            checkBoxRepeatSong.Text = "Repeat Song";
            checkBoxRepeatSong.UseVisualStyleBackColor = true;
            // 
            // labelTempo
            // 
            labelTempo.AutoSize = true;
            labelTempo.Location = new System.Drawing.Point(442, 35);
            labelTempo.Name = "labelTempo";
            labelTempo.Size = new System.Drawing.Size(13, 15);
            labelTempo.TabIndex = 3;
            labelTempo.Text = "0";
            // 
            // trackBarTempo
            // 
            trackBarTempo.Location = new System.Drawing.Point(262, 22);
            trackBarTempo.Maximum = 20;
            trackBarTempo.Minimum = -10;
            trackBarTempo.Name = "trackBarTempo";
            trackBarTempo.Size = new System.Drawing.Size(174, 45);
            trackBarTempo.TabIndex = 2;
            trackBarTempo.TickStyle = System.Windows.Forms.TickStyle.Both;
            trackBarTempo.ValueChanged += trackBarTempo_ValueChanged;
            // 
            // labelSpeedLabel
            // 
            labelSpeedLabel.AutoSize = true;
            labelSpeedLabel.Location = new System.Drawing.Point(210, 35);
            labelSpeedLabel.Name = "labelSpeedLabel";
            labelSpeedLabel.Size = new System.Drawing.Size(42, 15);
            labelSpeedLabel.TabIndex = 0;
            labelSpeedLabel.Text = "Speed:";
            // 
            // groupBoxInformation
            // 
            groupBoxInformation.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxInformation.Controls.Add(labelInformation4);
            groupBoxInformation.Controls.Add(labelInformation3);
            groupBoxInformation.Controls.Add(labelInformation2);
            groupBoxInformation.Controls.Add(labelInformation1);
            groupBoxInformation.Location = new System.Drawing.Point(12, 216);
            groupBoxInformation.Name = "groupBoxInformation";
            groupBoxInformation.Size = new System.Drawing.Size(478, 87);
            groupBoxInformation.TabIndex = 2;
            groupBoxInformation.TabStop = false;
            groupBoxInformation.Text = "Information";
            // 
            // labelInformation4
            // 
            labelInformation4.AutoSize = true;
            labelInformation4.Location = new System.Drawing.Point(6, 64);
            labelInformation4.Name = "labelInformation4";
            labelInformation4.Size = new System.Drawing.Size(375, 15);
            labelInformation4.TabIndex = 3;
            labelInformation4.Text = "Modefier Delay adds a delay in ms. between Shift and Ctrl key presses.";
            // 
            // labelInformation3
            // 
            labelInformation3.AutoSize = true;
            labelInformation3.Location = new System.Drawing.Point(6, 49);
            labelInformation3.Name = "labelInformation3";
            labelInformation3.Size = new System.Drawing.Size(372, 15);
            labelInformation3.TabIndex = 2;
            labelInformation3.Text = "A song with lots of Shift and Control presses will stutter. (Game Issue)";
            // 
            // labelInformation2
            // 
            labelInformation2.AutoSize = true;
            labelInformation2.Location = new System.Drawing.Point(6, 34);
            labelInformation2.Name = "labelInformation2";
            labelInformation2.Size = new System.Drawing.Size(156, 15);
            labelInformation2.TabIndex = 1;
            labelInformation2.Text = "Use the small ingame piano.";
            // 
            // labelInformation1
            // 
            labelInformation1.AutoSize = true;
            labelInformation1.Location = new System.Drawing.Point(6, 19);
            labelInformation1.Name = "labelInformation1";
            labelInformation1.Size = new System.Drawing.Size(170, 15);
            labelInformation1.TabIndex = 0;
            labelInformation1.Text = "Press F5 to start and F6 to stop.";
            // 
            // groupBoxDebug
            // 
            groupBoxDebug.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxDebug.Controls.Add(richTextBoxDebug);
            groupBoxDebug.Location = new System.Drawing.Point(12, 447);
            groupBoxDebug.Name = "groupBoxDebug";
            groupBoxDebug.Size = new System.Drawing.Size(478, 111);
            groupBoxDebug.TabIndex = 3;
            groupBoxDebug.TabStop = false;
            groupBoxDebug.Text = "Debug";
            // 
            // richTextBoxDebug
            // 
            richTextBoxDebug.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            richTextBoxDebug.BorderStyle = System.Windows.Forms.BorderStyle.None;
            richTextBoxDebug.Location = new System.Drawing.Point(6, 22);
            richTextBoxDebug.Name = "richTextBoxDebug";
            richTextBoxDebug.Size = new System.Drawing.Size(466, 83);
            richTextBoxDebug.TabIndex = 0;
            richTextBoxDebug.Text = "";
            // 
            // buttonDiscord
            // 
            buttonDiscord.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            buttonDiscord.Location = new System.Drawing.Point(415, 564);
            buttonDiscord.Name = "buttonDiscord";
            buttonDiscord.Size = new System.Drawing.Size(75, 23);
            buttonDiscord.TabIndex = 4;
            buttonDiscord.Text = "Discord";
            buttonDiscord.UseVisualStyleBackColor = true;
            buttonDiscord.Click += buttonDiscord_Click;
            // 
            // panelPiano
            // 
            panelPiano.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelPiano.Location = new System.Drawing.Point(18, 309);
            panelPiano.Name = "panelPiano";
            panelPiano.Size = new System.Drawing.Size(472, 121);
            panelPiano.TabIndex = 5;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(502, 599);
            Controls.Add(panelPiano);
            Controls.Add(buttonDiscord);
            Controls.Add(groupBoxDebug);
            Controls.Add(groupBoxInformation);
            Controls.Add(groupBoxSettings);
            Controls.Add(groupBoxMidiFile);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "FormMain";
            Text = "Once Human Midi Maestro by Psystec";
            Load += FormMain_Load;
            groupBoxMidiFile.ResumeLayout(false);
            groupBoxMidiFile.PerformLayout();
            groupBoxSettings.ResumeLayout(false);
            groupBoxSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarModifierDelay).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarTempo).EndInit();
            groupBoxInformation.ResumeLayout(false);
            groupBoxInformation.PerformLayout();
            groupBoxDebug.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxMidiFile;
        private System.Windows.Forms.Label labelSelectedMidi;
        private System.Windows.Forms.Label labelSelectedMidiLabel;
        private System.Windows.Forms.Button buttonLoadMidi;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.TrackBar trackBarTempo;
        private System.Windows.Forms.Label labelSpeedLabel;
        private System.Windows.Forms.Label labelTempo;
        private System.Windows.Forms.CheckBox checkBoxMergeOctaves;
        private System.Windows.Forms.CheckBox checkBoxSkipOctave3and5;
        private System.Windows.Forms.CheckBox checkBoxRepeatSong;
        private System.Windows.Forms.GroupBox groupBoxInformation;
        private System.Windows.Forms.GroupBox groupBoxDebug;
        private System.Windows.Forms.RichTextBox richTextBoxDebug;
        private System.Windows.Forms.Label labelInformation1;
        private System.Windows.Forms.Label labelInformation2;
        private System.Windows.Forms.Button buttonDiscord;
        private System.Windows.Forms.CheckBox checkBoxAlwaysOnTop;
        private System.Windows.Forms.Label labelInformation3;
        private System.Windows.Forms.Label labelModifierDelayLabel;
        private System.Windows.Forms.TrackBar trackBarModifierDelay;
        private System.Windows.Forms.Label labelModifiedDelay;
        private System.Windows.Forms.Label labelInformation4;
        private System.Windows.Forms.Panel panelPiano;
    }
}
