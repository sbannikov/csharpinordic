﻿namespace SpeechRecognition
{
    partial class MainForm
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
            this.recording = new System.Windows.Forms.Button();
            this.text = new System.Windows.Forms.TextBox();
            this.reading = new System.Windows.Forms.Button();
            this.syntesize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // recording
            // 
            this.recording.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recording.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.recording.Location = new System.Drawing.Point(12, 12);
            this.recording.Name = "recording";
            this.recording.Size = new System.Drawing.Size(776, 90);
            this.recording.TabIndex = 0;
            this.recording.Text = "Записывать звук";
            this.recording.UseVisualStyleBackColor = true;
            this.recording.MouseDown += new System.Windows.Forms.MouseEventHandler(this.recording_MouseDown);
            this.recording.MouseUp += new System.Windows.Forms.MouseEventHandler(this.recording_MouseUp);
            // 
            // text
            // 
            this.text.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.text.Location = new System.Drawing.Point(12, 300);
            this.text.Multiline = true;
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(776, 253);
            this.text.TabIndex = 1;
            // 
            // reading
            // 
            this.reading.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.reading.Location = new System.Drawing.Point(12, 108);
            this.reading.Name = "reading";
            this.reading.Size = new System.Drawing.Size(776, 90);
            this.reading.TabIndex = 2;
            this.reading.Text = "Распознать записанный звук";
            this.reading.UseVisualStyleBackColor = true;
            this.reading.Click += new System.EventHandler(this.reading_Click);
            // 
            // syntesize
            // 
            this.syntesize.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.syntesize.Location = new System.Drawing.Point(12, 204);
            this.syntesize.Name = "syntesize";
            this.syntesize.Size = new System.Drawing.Size(776, 90);
            this.syntesize.TabIndex = 3;
            this.syntesize.Text = "Синтезировать речь";
            this.syntesize.UseVisualStyleBackColor = true;
            this.syntesize.Click += new System.EventHandler(this.syntesize_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 565);
            this.Controls.Add(this.syntesize);
            this.Controls.Add(this.reading);
            this.Controls.Add(this.text);
            this.Controls.Add(this.recording);
            this.Name = "MainForm";
            this.Text = "Распознавание речи";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button recording;
        private TextBox text;
        private Button reading;
        private Button syntesize;
    }
}