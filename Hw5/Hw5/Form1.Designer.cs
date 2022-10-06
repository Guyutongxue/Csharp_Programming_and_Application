namespace Hw5
{
    partial class Form1
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
            this.textBoxTh1 = new System.Windows.Forms.TextBox();
            this.textBoxTh2 = new System.Windows.Forms.TextBox();
            this.textBoxL1 = new System.Windows.Forms.TextBox();
            this.textBoxL2 = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.buttonStColor = new System.Windows.Forms.Button();
            this.buttonEdColor = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxTh1
            // 
            this.textBoxTh1.Location = new System.Drawing.Point(75, 469);
            this.textBoxTh1.Name = "textBoxTh1";
            this.textBoxTh1.Size = new System.Drawing.Size(125, 27);
            this.textBoxTh1.TabIndex = 0;
            this.textBoxTh1.Text = "40";
            this.textBoxTh1.TextChanged += new System.EventHandler(this.textBoxTh1_TextChanged);
            // 
            // textBoxTh2
            // 
            this.textBoxTh2.Location = new System.Drawing.Point(75, 514);
            this.textBoxTh2.Name = "textBoxTh2";
            this.textBoxTh2.Size = new System.Drawing.Size(125, 27);
            this.textBoxTh2.TabIndex = 1;
            this.textBoxTh2.Text = "30";
            this.textBoxTh2.TextChanged += new System.EventHandler(this.textBoxTh2_TextChanged);
            // 
            // textBoxL1
            // 
            this.textBoxL1.Location = new System.Drawing.Point(237, 469);
            this.textBoxL1.Name = "textBoxL1";
            this.textBoxL1.Size = new System.Drawing.Size(125, 27);
            this.textBoxL1.TabIndex = 2;
            this.textBoxL1.Text = "0.6";
            this.textBoxL1.TextChanged += new System.EventHandler(this.textBoxL1_TextChanged);
            // 
            // textBoxL2
            // 
            this.textBoxL2.Location = new System.Drawing.Point(237, 514);
            this.textBoxL2.Name = "textBoxL2";
            this.textBoxL2.Size = new System.Drawing.Size(125, 27);
            this.textBoxL2.TabIndex = 3;
            this.textBoxL2.Text = "0.7";
            this.textBoxL2.TextChanged += new System.EventHandler(this.textBoxL2_TextChanged);
            // 
            // buttonStColor
            // 
            this.buttonStColor.BackColor = System.Drawing.Color.Red;
            this.buttonStColor.Location = new System.Drawing.Point(410, 467);
            this.buttonStColor.Name = "buttonStColor";
            this.buttonStColor.Size = new System.Drawing.Size(94, 29);
            this.buttonStColor.TabIndex = 4;
            this.buttonStColor.Text = "button1";
            this.buttonStColor.UseVisualStyleBackColor = false;
            this.buttonStColor.Click += new System.EventHandler(this.buttonStColor_Click);
            // 
            // buttonEdColor
            // 
            this.buttonEdColor.BackColor = System.Drawing.Color.Lime;
            this.buttonEdColor.Location = new System.Drawing.Point(410, 514);
            this.buttonEdColor.Name = "buttonEdColor";
            this.buttonEdColor.Size = new System.Drawing.Size(94, 29);
            this.buttonEdColor.TabIndex = 5;
            this.buttonEdColor.Text = "button1";
            this.buttonEdColor.UseVisualStyleBackColor = false;
            this.buttonEdColor.Click += new System.EventHandler(this.buttonEdColor_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(438, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 6;
            this.button1.Text = "DRAW";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(582, 568);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonEdColor);
            this.Controls.Add(this.buttonStColor);
            this.Controls.Add(this.textBoxL2);
            this.Controls.Add(this.textBoxL1);
            this.Controls.Add(this.textBoxTh2);
            this.Controls.Add(this.textBoxTh1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBoxTh1;
        private TextBox textBoxTh2;
        private TextBox textBoxL1;
        private TextBox textBoxL2;
        private ColorDialog colorDialog1;
        private Button buttonStColor;
        private Button buttonEdColor;
        private Button button1;
    }
}