namespace Calculator
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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.FIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.comboMaterial = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textPrice = new System.Windows.Forms.TextBox();
            this.comboColor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.open = new System.Windows.Forms.OpenFileDialog();
            this.save = new System.Windows.Forms.SaveFileDialog();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FIleToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(800, 28);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // FIleToolStripMenuItem
            // 
            this.FIleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.toolStripSeparator1,
            this.ExitToolStripMenuItem});
            this.FIleToolStripMenuItem.Name = "FIleToolStripMenuItem";
            this.FIleToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.FIleToolStripMenuItem.Text = "Файл";
            // 
            // LoadToolStripMenuItem
            // 
            this.LoadToolStripMenuItem.Name = "LoadToolStripMenuItem";
            this.LoadToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.LoadToolStripMenuItem.Text = "Загрузить";
            this.LoadToolStripMenuItem.Click += new System.EventHandler(this.LoadToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Enabled = false;
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.SaveToolStripMenuItem.Text = "&Сохранить";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(163, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.ExitToolStripMenuItem.Text = "Выход";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Материал";
            // 
            // comboMaterial
            // 
            this.comboMaterial.FormattingEnabled = true;
            this.comboMaterial.Location = new System.Drawing.Point(111, 75);
            this.comboMaterial.Name = "comboMaterial";
            this.comboMaterial.Size = new System.Drawing.Size(677, 28);
            this.comboMaterial.TabIndex = 2;
            this.comboMaterial.SelectedIndexChanged += new System.EventHandler(this.comboMaterial_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Цена";
            // 
            // textPrice
            // 
            this.textPrice.Location = new System.Drawing.Point(111, 109);
            this.textPrice.Name = "textPrice";
            this.textPrice.Size = new System.Drawing.Size(677, 27);
            this.textPrice.TabIndex = 4;
            // 
            // comboColor
            // 
            this.comboColor.FormattingEnabled = true;
            this.comboColor.Location = new System.Drawing.Point(111, 41);
            this.comboColor.Name = "comboColor";
            this.comboColor.Size = new System.Drawing.Size(677, 28);
            this.comboColor.TabIndex = 2;
            this.comboColor.SelectedIndexChanged += new System.EventHandler(this.comboColor_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Цвет";
            // 
            // open
            // 
            this.open.FileName = "openFileDialog1";
            this.open.Filter = "Файлы CSV|*.csv|Файлы XML|*.xml|Файлы JSON|*.json|Все файлы|*.*";
            // 
            // save
            // 
            this.save.Filter = "Файлы CSV|*.csv|Файлы XML|*.xml|Файлы JSON|*.json|Все файлы|*.*";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboColor);
            this.Controls.Add(this.comboMaterial);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "MainForm";
            this.Text = "Калькулятор";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem FIleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboMaterial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textPrice;
        private System.Windows.Forms.ComboBox comboColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog open;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog save;
    }
}
