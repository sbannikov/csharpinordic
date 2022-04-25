namespace Lesson8
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
            this.buttonRoll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonRoll
            // 
            this.buttonRoll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRoll.Location = new System.Drawing.Point(12, 12);
            this.buttonRoll.Name = "buttonRoll";
            this.buttonRoll.Size = new System.Drawing.Size(458, 70);
            this.buttonRoll.TabIndex = 0;
            this.buttonRoll.Text = "Бросить кубик";
            this.buttonRoll.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 453);
            this.Controls.Add(this.buttonRoll);
            this.MinimumSize = new System.Drawing.Size(0, 140);
            this.Name = "MainForm";
            this.Text = "Бросок кубика";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonRoll;
    }
}
