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
            checkBoxMergeOctaves = new System.Windows.Forms.CheckBox();
            checkBoxSkipOctave3and5 = new System.Windows.Forms.CheckBox();
            checkBoxRepeatSong = new System.Windows.Forms.CheckBox();
            labelTempo = new System.Windows.Forms.Label();
            trackBarTempo = new System.Windows.Forms.TrackBar();
            labelTempoLabel = new System.Windows.Forms.Label();
            groupBoxInformation = new System.Windows.Forms.GroupBox();
            labelInformation2 = new System.Windows.Forms.Label();
            labelInformation1 = new System.Windows.Forms.Label();
            groupBoxDebug = new System.Windows.Forms.GroupBox();
            richTextBoxDebug = new System.Windows.Forms.RichTextBox();
            buttonDiscord = new System.Windows.Forms.Button();
            groupBoxMidiFile.SuspendLayout();
            groupBoxSettings.SuspendLayout();
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
            groupBoxMidiFile.Size = new System.Drawing.Size(403, 62);
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
            groupBoxSettings.Controls.Add(checkBoxMergeOctaves);
            groupBoxSettings.Controls.Add(checkBoxSkipOctave3and5);
            groupBoxSettings.Controls.Add(checkBoxRepeatSong);
            groupBoxSettings.Controls.Add(labelTempo);
            groupBoxSettings.Controls.Add(trackBarTempo);
            groupBoxSettings.Controls.Add(labelTempoLabel);
            groupBoxSettings.Location = new System.Drawing.Point(12, 80);
            groupBoxSettings.Name = "groupBoxSettings";
            groupBoxSettings.Size = new System.Drawing.Size(403, 108);
            groupBoxSettings.TabIndex = 1;
            groupBoxSettings.TabStop = false;
            groupBoxSettings.Text = "Settings";
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
            labelTempo.Location = new System.Drawing.Point(319, 49);
            labelTempo.Name = "labelTempo";
            labelTempo.Size = new System.Drawing.Size(13, 15);
            labelTempo.TabIndex = 3;
            labelTempo.Text = "0";
            // 
            // trackBarTempo
            // 
            trackBarTempo.Location = new System.Drawing.Point(209, 36);
            trackBarTempo.Minimum = -10;
            trackBarTempo.Name = "trackBarTempo";
            trackBarTempo.Size = new System.Drawing.Size(104, 45);
            trackBarTempo.TabIndex = 2;
            trackBarTempo.TickStyle = System.Windows.Forms.TickStyle.Both;
            trackBarTempo.ValueChanged += trackBarTempo_ValueChanged;
            // 
            // labelTempoLabel
            // 
            labelTempoLabel.AutoSize = true;
            labelTempoLabel.Location = new System.Drawing.Point(157, 49);
            labelTempoLabel.Name = "labelTempoLabel";
            labelTempoLabel.Size = new System.Drawing.Size(46, 15);
            labelTempoLabel.TabIndex = 0;
            labelTempoLabel.Text = "Tempo:";
            // 
            // groupBoxInformation
            // 
            groupBoxInformation.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxInformation.Controls.Add(labelInformation2);
            groupBoxInformation.Controls.Add(labelInformation1);
            groupBoxInformation.Location = new System.Drawing.Point(12, 194);
            groupBoxInformation.Name = "groupBoxInformation";
            groupBoxInformation.Size = new System.Drawing.Size(403, 59);
            groupBoxInformation.TabIndex = 2;
            groupBoxInformation.TabStop = false;
            groupBoxInformation.Text = "Information";
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
            groupBoxDebug.Location = new System.Drawing.Point(12, 259);
            groupBoxDebug.Name = "groupBoxDebug";
            groupBoxDebug.Size = new System.Drawing.Size(403, 108);
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
            richTextBoxDebug.Size = new System.Drawing.Size(391, 80);
            richTextBoxDebug.TabIndex = 0;
            richTextBoxDebug.Text = "";
            // 
            // buttonDiscord
            // 
            buttonDiscord.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            buttonDiscord.Location = new System.Drawing.Point(340, 373);
            buttonDiscord.Name = "buttonDiscord";
            buttonDiscord.Size = new System.Drawing.Size(75, 23);
            buttonDiscord.TabIndex = 4;
            buttonDiscord.Text = "Discord";
            buttonDiscord.UseVisualStyleBackColor = true;
            buttonDiscord.Click += buttonDiscord_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(427, 408);
            Controls.Add(buttonDiscord);
            Controls.Add(groupBoxDebug);
            Controls.Add(groupBoxInformation);
            Controls.Add(groupBoxSettings);
            Controls.Add(groupBoxMidiFile);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "FormMain";
            Text = "Onec Human Hidi Maestro by Psystec";
            Load += FormMain_Load;
            groupBoxMidiFile.ResumeLayout(false);
            groupBoxMidiFile.PerformLayout();
            groupBoxSettings.ResumeLayout(false);
            groupBoxSettings.PerformLayout();
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
        private System.Windows.Forms.Label labelTempoLabel;
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
    }
}
