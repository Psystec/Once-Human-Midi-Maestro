﻿namespace Once_Human_Midi_Maestro
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
            buttonUseMidiDevice = new System.Windows.Forms.Button();
            labelMidiDeviceLabel = new System.Windows.Forms.Label();
            comboBoxMidiDevices = new System.Windows.Forms.ComboBox();
            buttonMidiShare = new System.Windows.Forms.Button();
            buttonPlaySong = new System.Windows.Forms.Button();
            buttonStopSong = new System.Windows.Forms.Button();
            labelSelectedMidi = new System.Windows.Forms.Label();
            labelSelectedMidiLabel = new System.Windows.Forms.Label();
            buttonLoadMidi = new System.Windows.Forms.Button();
            buttonExportMidi = new System.Windows.Forms.Button();
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
            groupBoxDebug = new System.Windows.Forms.GroupBox();
            richTextBoxDebug = new System.Windows.Forms.RichTextBox();
            buttonDiscord = new System.Windows.Forms.Button();
            panelPiano = new System.Windows.Forms.Panel();
            buttonGitHub = new System.Windows.Forms.Button();
            buttonSignal = new System.Windows.Forms.Button();
            groupBoxMidiShare = new System.Windows.Forms.GroupBox();
            buttonPlayMIDI = new System.Windows.Forms.Button();
            textBoxMidiSearch = new System.Windows.Forms.TextBox();
            buttonMidiListReload = new System.Windows.Forms.Button();
            buttonMidiShareUpload = new System.Windows.Forms.Button();
            buttonMidiShareDownload = new System.Windows.Forms.Button();
            listBoxMidiShare = new System.Windows.Forms.ListBox();
            groupBoxMidiFile.SuspendLayout();
            groupBoxSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarModifierDelay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarTempo).BeginInit();
            groupBoxInformation.SuspendLayout();
            groupBoxDebug.SuspendLayout();
            groupBoxMidiShare.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxMidiFile
            // 
            groupBoxMidiFile.Controls.Add(buttonUseMidiDevice);
            groupBoxMidiFile.Controls.Add(labelMidiDeviceLabel);
            groupBoxMidiFile.Controls.Add(comboBoxMidiDevices);
            groupBoxMidiFile.Controls.Add(buttonMidiShare);
            groupBoxMidiFile.Controls.Add(buttonPlaySong);
            groupBoxMidiFile.Controls.Add(buttonStopSong);
            groupBoxMidiFile.Controls.Add(labelSelectedMidi);
            groupBoxMidiFile.Controls.Add(labelSelectedMidiLabel);
            groupBoxMidiFile.Controls.Add(buttonLoadMidi);
            groupBoxMidiFile.Location = new System.Drawing.Point(12, 12);
            groupBoxMidiFile.Name = "groupBoxMidiFile";
            groupBoxMidiFile.Size = new System.Drawing.Size(442, 110);
            groupBoxMidiFile.TabIndex = 0;
            groupBoxMidiFile.TabStop = false;
            groupBoxMidiFile.Text = "MIDI File";
            // 
            // buttonUseMidiDevice
            // 
            buttonUseMidiDevice.Location = new System.Drawing.Point(333, 76);
            buttonUseMidiDevice.Name = "buttonUseMidiDevice";
            buttonUseMidiDevice.Size = new System.Drawing.Size(103, 23);
            buttonUseMidiDevice.TabIndex = 8;
            buttonUseMidiDevice.Text = "Use MIDI Device";
            buttonUseMidiDevice.UseVisualStyleBackColor = true;
            buttonUseMidiDevice.Click += buttonUseMidiDevice_Click;
            // 
            // labelMidiDeviceLabel
            // 
            labelMidiDeviceLabel.AutoSize = true;
            labelMidiDeviceLabel.Location = new System.Drawing.Point(6, 80);
            labelMidiDeviceLabel.Name = "labelMidiDeviceLabel";
            labelMidiDeviceLabel.Size = new System.Drawing.Size(75, 15);
            labelMidiDeviceLabel.TabIndex = 7;
            labelMidiDeviceLabel.Text = "Midi Device :";
            // 
            // comboBoxMidiDevices
            // 
            comboBoxMidiDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxMidiDevices.FormattingEnabled = true;
            comboBoxMidiDevices.Location = new System.Drawing.Point(87, 77);
            comboBoxMidiDevices.Name = "comboBoxMidiDevices";
            comboBoxMidiDevices.Size = new System.Drawing.Size(240, 23);
            comboBoxMidiDevices.TabIndex = 6;
            // 
            // buttonMidiShare
            // 
            buttonMidiShare.Location = new System.Drawing.Point(351, 22);
            buttonMidiShare.Name = "buttonMidiShare";
            buttonMidiShare.Size = new System.Drawing.Size(85, 23);
            buttonMidiShare.TabIndex = 5;
            buttonMidiShare.Text = "MIDI Share >";
            buttonMidiShare.UseVisualStyleBackColor = true;
            buttonMidiShare.Click += buttonMidiShare_Click;
            // 
            // buttonPlaySong
            // 
            buttonPlaySong.Location = new System.Drawing.Point(122, 22);
            buttonPlaySong.Name = "buttonPlaySong";
            buttonPlaySong.Size = new System.Drawing.Size(75, 23);
            buttonPlaySong.TabIndex = 4;
            buttonPlaySong.Text = "Play Song";
            buttonPlaySong.UseVisualStyleBackColor = true;
            buttonPlaySong.Click += buttonPlaySong_Click;
            // 
            // buttonStopSong
            // 
            buttonStopSong.Location = new System.Drawing.Point(203, 22);
            buttonStopSong.Name = "buttonStopSong";
            buttonStopSong.Size = new System.Drawing.Size(75, 23);
            buttonStopSong.TabIndex = 3;
            buttonStopSong.Text = "Stop Song";
            buttonStopSong.UseVisualStyleBackColor = true;
            buttonStopSong.Click += buttonStopSong_Click;
            // 
            // labelSelectedMidi
            // 
            labelSelectedMidi.AutoSize = true;
            labelSelectedMidi.Location = new System.Drawing.Point(93, 53);
            labelSelectedMidi.Name = "labelSelectedMidi";
            labelSelectedMidi.Size = new System.Drawing.Size(29, 15);
            labelSelectedMidi.TabIndex = 2;
            labelSelectedMidi.Text = "N/A";
            // 
            // labelSelectedMidiLabel
            // 
            labelSelectedMidiLabel.AutoSize = true;
            labelSelectedMidiLabel.Location = new System.Drawing.Point(6, 53);
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
            // buttonExportMidi
            // 
            buttonExportMidi.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            buttonExportMidi.Location = new System.Drawing.Point(93, 544);
            buttonExportMidi.Name = "buttonExportMidi";
            buttonExportMidi.Size = new System.Drawing.Size(84, 23);
            buttonExportMidi.TabIndex = 5;
            buttonExportMidi.Text = "Export Midi";
            buttonExportMidi.UseVisualStyleBackColor = true;
            buttonExportMidi.Click += buttonExportMidi_Click;
            // 
            // groupBoxSettings
            // 
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
            groupBoxSettings.Location = new System.Drawing.Point(12, 128);
            groupBoxSettings.Name = "groupBoxSettings";
            groupBoxSettings.Size = new System.Drawing.Size(442, 130);
            groupBoxSettings.TabIndex = 1;
            groupBoxSettings.TabStop = false;
            groupBoxSettings.Text = "Settings";
            // 
            // labelModifiedDelay
            // 
            labelModifiedDelay.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            labelModifiedDelay.AutoSize = true;
            labelModifiedDelay.Location = new System.Drawing.Point(399, 85);
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
            trackBarModifierDelay.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            trackBarModifierDelay.Location = new System.Drawing.Point(262, 73);
            trackBarModifierDelay.Maximum = 100;
            trackBarModifierDelay.Name = "trackBarModifierDelay";
            trackBarModifierDelay.Size = new System.Drawing.Size(131, 45);
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
            checkBoxMergeOctaves.CheckedChanged += checkBoxMergeOctaves_CheckedChanged;
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
            checkBoxSkipOctave3and5.CheckedChanged += checkBoxSkipOctave3and5_CheckedChanged;
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
            checkBoxRepeatSong.CheckedChanged += checkBoxRepeatSong_CheckedChanged;
            // 
            // labelTempo
            // 
            labelTempo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            labelTempo.AutoSize = true;
            labelTempo.Location = new System.Drawing.Point(399, 35);
            labelTempo.Name = "labelTempo";
            labelTempo.Size = new System.Drawing.Size(13, 15);
            labelTempo.TabIndex = 3;
            labelTempo.Text = "0";
            // 
            // trackBarTempo
            // 
            trackBarTempo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            trackBarTempo.Location = new System.Drawing.Point(262, 22);
            trackBarTempo.Maximum = 20;
            trackBarTempo.Minimum = -10;
            trackBarTempo.Name = "trackBarTempo";
            trackBarTempo.Size = new System.Drawing.Size(131, 45);
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
            groupBoxInformation.Controls.Add(labelInformation4);
            groupBoxInformation.Controls.Add(labelInformation3);
            groupBoxInformation.Controls.Add(labelInformation2);
            groupBoxInformation.Location = new System.Drawing.Point(12, 264);
            groupBoxInformation.Name = "groupBoxInformation";
            groupBoxInformation.Size = new System.Drawing.Size(442, 69);
            groupBoxInformation.TabIndex = 2;
            groupBoxInformation.TabStop = false;
            groupBoxInformation.Text = "Information";
            // 
            // labelInformation4
            // 
            labelInformation4.AutoSize = true;
            labelInformation4.Location = new System.Drawing.Point(6, 49);
            labelInformation4.Name = "labelInformation4";
            labelInformation4.Size = new System.Drawing.Size(266, 15);
            labelInformation4.TabIndex = 3;
            labelInformation4.Text = "Press F5 to Start and F6 to Stop the MIDI in game.";
            // 
            // labelInformation3
            // 
            labelInformation3.AutoSize = true;
            labelInformation3.Location = new System.Drawing.Point(6, 34);
            labelInformation3.Name = "labelInformation3";
            labelInformation3.Size = new System.Drawing.Size(372, 15);
            labelInformation3.TabIndex = 2;
            labelInformation3.Text = "A song with lots of Shift and Control presses will stutter. (Game Issue)";
            // 
            // labelInformation2
            // 
            labelInformation2.AutoSize = true;
            labelInformation2.Location = new System.Drawing.Point(6, 19);
            labelInformation2.Name = "labelInformation2";
            labelInformation2.Size = new System.Drawing.Size(156, 15);
            labelInformation2.TabIndex = 1;
            labelInformation2.Text = "Use the small ingame piano.";
            // 
            // groupBoxDebug
            // 
            groupBoxDebug.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            groupBoxDebug.Controls.Add(richTextBoxDebug);
            groupBoxDebug.Location = new System.Drawing.Point(12, 427);
            groupBoxDebug.Name = "groupBoxDebug";
            groupBoxDebug.Size = new System.Drawing.Size(442, 111);
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
            richTextBoxDebug.Size = new System.Drawing.Size(430, 83);
            richTextBoxDebug.TabIndex = 0;
            richTextBoxDebug.Text = "";
            // 
            // buttonDiscord
            // 
            buttonDiscord.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            buttonDiscord.Location = new System.Drawing.Point(379, 544);
            buttonDiscord.Name = "buttonDiscord";
            buttonDiscord.Size = new System.Drawing.Size(75, 23);
            buttonDiscord.TabIndex = 4;
            buttonDiscord.Text = "Discord";
            buttonDiscord.UseVisualStyleBackColor = true;
            buttonDiscord.Click += buttonDiscord_Click;
            // 
            // panelPiano
            // 
            panelPiano.Location = new System.Drawing.Point(12, 339);
            panelPiano.Name = "panelPiano";
            panelPiano.Size = new System.Drawing.Size(442, 82);
            panelPiano.TabIndex = 5;
            // 
            // buttonGitHub
            // 
            buttonGitHub.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            buttonGitHub.Location = new System.Drawing.Point(298, 544);
            buttonGitHub.Name = "buttonGitHub";
            buttonGitHub.Size = new System.Drawing.Size(75, 23);
            buttonGitHub.TabIndex = 6;
            buttonGitHub.Text = "GitHub";
            buttonGitHub.UseVisualStyleBackColor = true;
            buttonGitHub.Click += buttonGitHub_Click;
            // 
            // buttonSignal
            // 
            buttonSignal.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            buttonSignal.Location = new System.Drawing.Point(12, 544);
            buttonSignal.Name = "buttonSignal";
            buttonSignal.Size = new System.Drawing.Size(75, 23);
            buttonSignal.TabIndex = 7;
            buttonSignal.Text = "Signal";
            buttonSignal.UseVisualStyleBackColor = true;
            buttonSignal.Click += buttonSignal_Click;
            // 
            // groupBoxMidiShare
            // 
            groupBoxMidiShare.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxMidiShare.Controls.Add(buttonPlayMIDI);
            groupBoxMidiShare.Controls.Add(textBoxMidiSearch);
            groupBoxMidiShare.Controls.Add(buttonMidiListReload);
            groupBoxMidiShare.Controls.Add(buttonMidiShareUpload);
            groupBoxMidiShare.Controls.Add(buttonMidiShareDownload);
            groupBoxMidiShare.Controls.Add(listBoxMidiShare);
            groupBoxMidiShare.Location = new System.Drawing.Point(460, 12);
            groupBoxMidiShare.Name = "groupBoxMidiShare";
            groupBoxMidiShare.Size = new System.Drawing.Size(250, 555);
            groupBoxMidiShare.TabIndex = 8;
            groupBoxMidiShare.TabStop = false;
            groupBoxMidiShare.Text = "MIDI Share";
            // 
            // buttonPlayMIDI
            // 
            buttonPlayMIDI.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            buttonPlayMIDI.Enabled = false;
            buttonPlayMIDI.Location = new System.Drawing.Point(169, 526);
            buttonPlayMIDI.Name = "buttonPlayMIDI";
            buttonPlayMIDI.Size = new System.Drawing.Size(75, 23);
            buttonPlayMIDI.TabIndex = 5;
            buttonPlayMIDI.Text = "Play";
            buttonPlayMIDI.UseVisualStyleBackColor = true;
            buttonPlayMIDI.Click += buttonPlayMIDI_Click;
            // 
            // textBoxMidiSearch
            // 
            textBoxMidiSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBoxMidiSearch.Location = new System.Drawing.Point(6, 22);
            textBoxMidiSearch.Name = "textBoxMidiSearch";
            textBoxMidiSearch.PlaceholderText = "Search";
            textBoxMidiSearch.Size = new System.Drawing.Size(238, 23);
            textBoxMidiSearch.TabIndex = 4;
            textBoxMidiSearch.TextChanged += textBoxMidiSearch_TextChanged;
            // 
            // buttonMidiListReload
            // 
            buttonMidiListReload.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            buttonMidiListReload.Location = new System.Drawing.Point(169, 497);
            buttonMidiListReload.Name = "buttonMidiListReload";
            buttonMidiListReload.Size = new System.Drawing.Size(75, 23);
            buttonMidiListReload.TabIndex = 3;
            buttonMidiListReload.Text = "Reload";
            buttonMidiListReload.UseVisualStyleBackColor = true;
            buttonMidiListReload.Click += buttonMidiListReload_Click;
            // 
            // buttonMidiShareUpload
            // 
            buttonMidiShareUpload.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            buttonMidiShareUpload.Location = new System.Drawing.Point(87, 526);
            buttonMidiShareUpload.Name = "buttonMidiShareUpload";
            buttonMidiShareUpload.Size = new System.Drawing.Size(75, 23);
            buttonMidiShareUpload.TabIndex = 2;
            buttonMidiShareUpload.Text = "Upload";
            buttonMidiShareUpload.UseVisualStyleBackColor = true;
            buttonMidiShareUpload.Click += buttonMidiShareUpload_Click;
            // 
            // buttonMidiShareDownload
            // 
            buttonMidiShareDownload.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            buttonMidiShareDownload.Location = new System.Drawing.Point(6, 526);
            buttonMidiShareDownload.Name = "buttonMidiShareDownload";
            buttonMidiShareDownload.Size = new System.Drawing.Size(75, 23);
            buttonMidiShareDownload.TabIndex = 1;
            buttonMidiShareDownload.Text = "Download";
            buttonMidiShareDownload.UseVisualStyleBackColor = true;
            buttonMidiShareDownload.Click += buttonMidiShareDownload_Click;
            // 
            // listBoxMidiShare
            // 
            listBoxMidiShare.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            listBoxMidiShare.FormattingEnabled = true;
            listBoxMidiShare.IntegralHeight = false;
            listBoxMidiShare.ItemHeight = 15;
            listBoxMidiShare.Location = new System.Drawing.Point(6, 51);
            listBoxMidiShare.Name = "listBoxMidiShare";
            listBoxMidiShare.Size = new System.Drawing.Size(238, 440);
            listBoxMidiShare.Sorted = true;
            listBoxMidiShare.TabIndex = 0;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(722, 579);
            Controls.Add(groupBoxMidiShare);
            Controls.Add(buttonExportMidi);
            Controls.Add(buttonSignal);
            Controls.Add(buttonGitHub);
            Controls.Add(panelPiano);
            Controls.Add(buttonDiscord);
            Controls.Add(groupBoxDebug);
            Controls.Add(groupBoxInformation);
            Controls.Add(groupBoxSettings);
            Controls.Add(groupBoxMidiFile);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MinimumSize = new System.Drawing.Size(393, 460);
            Name = "FormMain";
            Text = "Once Human Midi Maestro by Psystec";
            FormClosed += FormMain_FormClosed;
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
            groupBoxMidiShare.ResumeLayout(false);
            groupBoxMidiShare.PerformLayout();
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
        private System.Windows.Forms.Label labelInformation2;
        private System.Windows.Forms.Button buttonDiscord;
        private System.Windows.Forms.CheckBox checkBoxAlwaysOnTop;
        private System.Windows.Forms.Label labelInformation3;
        private System.Windows.Forms.Label labelModifierDelayLabel;
        private System.Windows.Forms.TrackBar trackBarModifierDelay;
        private System.Windows.Forms.Label labelModifiedDelay;
        private System.Windows.Forms.Panel panelPiano;
        private System.Windows.Forms.Button buttonGitHub;
        private System.Windows.Forms.Button buttonSignal;
        private System.Windows.Forms.Button buttonPlaySong;
        private System.Windows.Forms.Button buttonStopSong;
        private System.Windows.Forms.Button buttonExportMidi;
        private System.Windows.Forms.Button buttonMidiShare;
        private System.Windows.Forms.GroupBox groupBoxMidiShare;
        private System.Windows.Forms.Button buttonMidiShareUpload;
        private System.Windows.Forms.Button buttonMidiShareDownload;
        private System.Windows.Forms.ListBox listBoxMidiShare;
        private System.Windows.Forms.Button buttonMidiListReload;
        private System.Windows.Forms.TextBox textBoxMidiSearch;
        private System.Windows.Forms.Button buttonPlayMIDI;
        private System.Windows.Forms.Label labelInformation4;
        private System.Windows.Forms.Button buttonUseMidiDevice;
        private System.Windows.Forms.Label labelMidiDeviceLabel;
        private System.Windows.Forms.ComboBox comboBoxMidiDevices;
    }
}
