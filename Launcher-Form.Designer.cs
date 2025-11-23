namespace Calculator
{
    partial class Launcher_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher_Form));
            this.btnTextMode = new System.Windows.Forms.Button();
            this.btnClassicMode = new System.Windows.Forms.Button();
            this.lblChooseCalculator = new System.Windows.Forms.Label();
            this.btnAbout = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTextMode
            // 
            this.btnTextMode.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnTextMode.FlatAppearance.BorderSize = 2;
            this.btnTextMode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnTextMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTextMode.Location = new System.Drawing.Point(95, 266);
            this.btnTextMode.Name = "btnTextMode";
            this.btnTextMode.Size = new System.Drawing.Size(120, 64);
            this.btnTextMode.TabIndex = 0;
            this.btnTextMode.Text = "Text Mode";
            this.btnTextMode.UseVisualStyleBackColor = false;
            this.btnTextMode.Click += new System.EventHandler(this.btnTextMode_Click);
            // 
            // btnClassicMode
            // 
            this.btnClassicMode.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnClassicMode.FlatAppearance.BorderSize = 2;
            this.btnClassicMode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClassicMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClassicMode.Location = new System.Drawing.Point(404, 266);
            this.btnClassicMode.Name = "btnClassicMode";
            this.btnClassicMode.Size = new System.Drawing.Size(120, 64);
            this.btnClassicMode.TabIndex = 1;
            this.btnClassicMode.Text = "Classic Mode";
            this.btnClassicMode.UseVisualStyleBackColor = false;
            this.btnClassicMode.Click += new System.EventHandler(this.btnClassicMode_Click);
            // 
            // lblChooseCalculator
            // 
            this.lblChooseCalculator.AutoSize = true;
            this.lblChooseCalculator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblChooseCalculator.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseCalculator.Location = new System.Drawing.Point(189, 18);
            this.lblChooseCalculator.Name = "lblChooseCalculator";
            this.lblChooseCalculator.Size = new System.Drawing.Size(248, 31);
            this.lblChooseCalculator.TabIndex = 2;
            this.lblChooseCalculator.Text = "Choose Calculator";
            // 
            // btnAbout
            // 
            this.btnAbout.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnAbout.FlatAppearance.BorderSize = 2;
            this.btnAbout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.btnAbout.Location = new System.Drawing.Point(264, 283);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(87, 30);
            this.btnAbout.TabIndex = 5;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Firebrick;
            this.label3.Location = new System.Drawing.Point(241, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 34);
            this.label3.TabIndex = 11;
            this.label3.Text = "© 2025 - Developed by\r\nShihab Ghitany\r\n";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Calculator.Properties.Resources.cc1;
            this.pictureBox2.Location = new System.Drawing.Point(307, 62);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(290, 180);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Calculator.Properties.Resources.tc1;
            this.pictureBox1.Location = new System.Drawing.Point(8, 62);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(290, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Launcher_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 342);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblChooseCalculator);
            this.Controls.Add(this.btnClassicMode);
            this.Controls.Add(this.btnTextMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Launcher_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculator Launcher";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTextMode;
        private System.Windows.Forms.Button btnClassicMode;
        private System.Windows.Forms.Label lblChooseCalculator;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Label label3;
    }
}