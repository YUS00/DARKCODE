namespace timer
{
    partial class Dades_usuari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dades_usuari));
            this.save_bttn = new System.Windows.Forms.Button();
            this.delete_bttn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.register_bttn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // save_bttn
            // 
            this.save_bttn.BackColor = System.Drawing.Color.White;
            this.save_bttn.ForeColor = System.Drawing.Color.Red;
            this.save_bttn.Location = new System.Drawing.Point(466, 272);
            this.save_bttn.Name = "save_bttn";
            this.save_bttn.Size = new System.Drawing.Size(75, 23);
            this.save_bttn.TabIndex = 14;
            this.save_bttn.Text = "CHECK";
            this.save_bttn.UseVisualStyleBackColor = false;
            this.save_bttn.Click += new System.EventHandler(this.check_bttn_Click);
            // 
            // delete_bttn
            // 
            this.delete_bttn.BackColor = System.Drawing.Color.White;
            this.delete_bttn.ForeColor = System.Drawing.Color.Red;
            this.delete_bttn.Location = new System.Drawing.Point(583, 272);
            this.delete_bttn.Name = "delete_bttn";
            this.delete_bttn.Size = new System.Drawing.Size(75, 23);
            this.delete_bttn.TabIndex = 13;
            this.delete_bttn.Text = "CLEAR";
            this.delete_bttn.UseVisualStyleBackColor = false;
            this.delete_bttn.Click += new System.EventHandler(this.delete_bttn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(22, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 31);
            this.label3.TabIndex = 12;
            this.label3.Text = "MAC ADDRESS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(22, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 31);
            this.label2.TabIndex = 11;
            this.label2.Text = "HOSTNAME";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlText;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(22, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(414, 31);
            this.label1.TabIndex = 10;
            this.label1.Text = "WELCOME TO THE DARK SIDE";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(28, 165);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(131, 24);
            this.textBox2.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(28, 272);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(118, 24);
            this.textBox1.TabIndex = 8;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "GUTI-THE-BEST",
            "YOUSEF-THE-BOOS",
            "CARLOS-THE-SENIOR"});
            this.comboBox1.Location = new System.Drawing.Point(528, 165);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(522, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 31);
            this.label4.TabIndex = 16;
            this.label4.Text = "USER";
            // 
            // register_bttn
            // 
            this.register_bttn.BackColor = System.Drawing.Color.White;
            this.register_bttn.ForeColor = System.Drawing.Color.Red;
            this.register_bttn.Location = new System.Drawing.Point(528, 314);
            this.register_bttn.Name = "register_bttn";
            this.register_bttn.Size = new System.Drawing.Size(75, 23);
            this.register_bttn.TabIndex = 17;
            this.register_bttn.Text = "REGISTER";
            this.register_bttn.UseVisualStyleBackColor = false;
            this.register_bttn.Click += new System.EventHandler(this.register_bttn_Click);
            // 
            // Dades_usuari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(699, 384);
            this.Controls.Add(this.register_bttn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.save_bttn);
            this.Controls.Add(this.delete_bttn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Dades_usuari";
            this.Text = "dades_usuari";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button save_bttn;
        private System.Windows.Forms.Button delete_bttn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button register_bttn;
    }
}