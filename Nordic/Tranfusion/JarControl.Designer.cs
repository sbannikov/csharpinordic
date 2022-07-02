namespace Tranfusion
{
    partial class JarControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.jar = new System.Windows.Forms.Panel();
            this.level = new System.Windows.Forms.Panel();
            this.text = new System.Windows.Forms.Label();
            this.jar.SuspendLayout();
            this.level.SuspendLayout();
            this.SuspendLayout();
            // 
            // jar
            // 
            this.jar.BackColor = System.Drawing.Color.AntiqueWhite;
            this.jar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jar.Controls.Add(this.level);
            this.jar.Location = new System.Drawing.Point(3, 3);
            this.jar.Name = "jar";
            this.jar.Size = new System.Drawing.Size(144, 144);
            this.jar.TabIndex = 0;
            // 
            // level
            // 
            this.level.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.level.BackColor = System.Drawing.Color.SaddleBrown;
            this.level.Controls.Add(this.text);
            this.level.Location = new System.Drawing.Point(3, 59);
            this.level.Name = "level";
            this.level.Size = new System.Drawing.Size(136, 80);
            this.level.TabIndex = 0;
            // 
            // text
            // 
            this.text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.text.AutoSize = true;
            this.text.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.text.ForeColor = System.Drawing.SystemColors.Control;
            this.text.Location = new System.Drawing.Point(0, 34);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(38, 45);
            this.text.TabIndex = 1;
            this.text.Text = "0";
            // 
            // JarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.jar);
            this.Name = "JarControl";
            this.jar.ResumeLayout(false);
            this.level.ResumeLayout(false);
            this.level.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel jar;
        private Panel level;
        private Label text;
    }
}
