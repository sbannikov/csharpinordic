﻿namespace Fractions
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textNumerator1 = new System.Windows.Forms.TextBox();
            this.buttonPlus = new System.Windows.Forms.Button();
            this.textDenominator1 = new System.Windows.Forms.TextBox();
            this.textNumerator2 = new System.Windows.Forms.TextBox();
            this.textNumerator = new System.Windows.Forms.TextBox();
            this.textDenominator2 = new System.Windows.Forms.TextBox();
            this.textDenominator = new System.Windows.Forms.TextBox();
            this.buttonMinus = new System.Windows.Forms.Button();
            this.buttonMul = new System.Windows.Forms.Button();
            this.buttonDiv = new System.Windows.Forms.Button();
            this.textNumber2 = new System.Windows.Forms.TextBox();
            this.textNumber = new System.Windows.Forms.TextBox();
            this.textNumber1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textNumerator1
            // 
            this.textNumerator1.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textNumerator1.Location = new System.Drawing.Point(243, 8);
            this.textNumerator1.Name = "textNumerator1";
            this.textNumerator1.Size = new System.Drawing.Size(225, 167);
            this.textNumerator1.TabIndex = 0;
            // 
            // buttonPlus
            // 
            this.buttonPlus.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonPlus.Location = new System.Drawing.Point(474, 8);
            this.buttonPlus.Name = "buttonPlus";
            this.buttonPlus.Size = new System.Drawing.Size(94, 89);
            this.buttonPlus.TabIndex = 1;
            this.buttonPlus.Text = "+";
            this.buttonPlus.UseVisualStyleBackColor = true;
            this.buttonPlus.Click += new System.EventHandler(this.buttonOperation_Click);
            // 
            // textDenominator1
            // 
            this.textDenominator1.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textDenominator1.Location = new System.Drawing.Point(243, 197);
            this.textDenominator1.Name = "textDenominator1";
            this.textDenominator1.Size = new System.Drawing.Size(225, 167);
            this.textDenominator1.TabIndex = 0;
            // 
            // textNumerator2
            // 
            this.textNumerator2.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textNumerator2.Location = new System.Drawing.Point(810, 8);
            this.textNumerator2.Name = "textNumerator2";
            this.textNumerator2.Size = new System.Drawing.Size(225, 167);
            this.textNumerator2.TabIndex = 0;
            // 
            // textNumerator
            // 
            this.textNumerator.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textNumerator.Location = new System.Drawing.Point(1272, 8);
            this.textNumerator.Name = "textNumerator";
            this.textNumerator.Size = new System.Drawing.Size(225, 167);
            this.textNumerator.TabIndex = 0;
            // 
            // textDenominator2
            // 
            this.textDenominator2.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textDenominator2.Location = new System.Drawing.Point(810, 197);
            this.textDenominator2.Name = "textDenominator2";
            this.textDenominator2.Size = new System.Drawing.Size(225, 167);
            this.textDenominator2.TabIndex = 0;
            // 
            // textDenominator
            // 
            this.textDenominator.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textDenominator.Location = new System.Drawing.Point(1272, 197);
            this.textDenominator.Name = "textDenominator";
            this.textDenominator.Size = new System.Drawing.Size(225, 167);
            this.textDenominator.TabIndex = 0;
            // 
            // buttonMinus
            // 
            this.buttonMinus.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonMinus.Location = new System.Drawing.Point(474, 103);
            this.buttonMinus.Name = "buttonMinus";
            this.buttonMinus.Size = new System.Drawing.Size(94, 89);
            this.buttonMinus.TabIndex = 1;
            this.buttonMinus.Text = "-";
            this.buttonMinus.UseVisualStyleBackColor = true;
            this.buttonMinus.Click += new System.EventHandler(this.buttonOperation_Click);
            // 
            // buttonMul
            // 
            this.buttonMul.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonMul.Location = new System.Drawing.Point(474, 198);
            this.buttonMul.Name = "buttonMul";
            this.buttonMul.Size = new System.Drawing.Size(94, 89);
            this.buttonMul.TabIndex = 1;
            this.buttonMul.Text = "*";
            this.buttonMul.UseVisualStyleBackColor = true;
            this.buttonMul.Click += new System.EventHandler(this.buttonOperation_Click);
            // 
            // buttonDiv
            // 
            this.buttonDiv.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonDiv.Location = new System.Drawing.Point(474, 293);
            this.buttonDiv.Name = "buttonDiv";
            this.buttonDiv.Size = new System.Drawing.Size(94, 89);
            this.buttonDiv.TabIndex = 1;
            this.buttonDiv.Text = "/";
            this.buttonDiv.UseVisualStyleBackColor = true;
            this.buttonDiv.Click += new System.EventHandler(this.buttonOperation_Click);
            // 
            // textNumber2
            // 
            this.textNumber2.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textNumber2.Location = new System.Drawing.Point(579, 107);
            this.textNumber2.Name = "textNumber2";
            this.textNumber2.Size = new System.Drawing.Size(225, 167);
            this.textNumber2.TabIndex = 0;
            // 
            // textNumber
            // 
            this.textNumber.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textNumber.Location = new System.Drawing.Point(1041, 107);
            this.textNumber.Name = "textNumber";
            this.textNumber.Size = new System.Drawing.Size(225, 167);
            this.textNumber.TabIndex = 0;
            // 
            // textNumber1
            // 
            this.textNumber1.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textNumber1.Location = new System.Drawing.Point(12, 103);
            this.textNumber1.Name = "textNumber1";
            this.textNumber1.Size = new System.Drawing.Size(225, 167);
            this.textNumber1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1508, 390);
            this.Controls.Add(this.buttonDiv);
            this.Controls.Add(this.buttonMul);
            this.Controls.Add(this.buttonMinus);
            this.Controls.Add(this.buttonPlus);
            this.Controls.Add(this.textDenominator);
            this.Controls.Add(this.textDenominator2);
            this.Controls.Add(this.textDenominator1);
            this.Controls.Add(this.textNumerator);
            this.Controls.Add(this.textNumber);
            this.Controls.Add(this.textNumber2);
            this.Controls.Add(this.textNumerator2);
            this.Controls.Add(this.textNumber1);
            this.Controls.Add(this.textNumerator1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textNumerator1;
        private Button buttonPlus;
        private TextBox textDenominator1;
        private TextBox textNumerator2;
        private TextBox textNumerator;
        private TextBox textDenominator2;
        private TextBox textDenominator;
        private Button buttonMinus;
        private Button buttonMul;
        private Button buttonDiv;
        private TextBox textNumber2;
        private TextBox textNumber;
        private TextBox textNumber1;
    }
}