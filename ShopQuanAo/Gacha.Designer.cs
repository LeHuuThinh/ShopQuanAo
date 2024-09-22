namespace ShopQuanAo
{
    partial class Gacha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gacha));
            this.btnGacha1 = new System.Windows.Forms.Button();
            this.lbGacha = new System.Windows.Forms.ListBox();
            this.btnGacha10 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRoll = new System.Windows.Forms.Label();
            this.txtNoti = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGacha1
            // 
            this.btnGacha1.Location = new System.Drawing.Point(109, 33);
            this.btnGacha1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGacha1.Name = "btnGacha1";
            this.btnGacha1.Size = new System.Drawing.Size(101, 44);
            this.btnGacha1.TabIndex = 0;
            this.btnGacha1.Text = "Săn  x1";
            this.btnGacha1.UseVisualStyleBackColor = true;
            this.btnGacha1.Click += new System.EventHandler(this.btnGacha_Click);
            // 
            // lbGacha
            // 
            this.lbGacha.FormattingEnabled = true;
            this.lbGacha.ItemHeight = 16;
            this.lbGacha.Location = new System.Drawing.Point(33, 133);
            this.lbGacha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbGacha.Name = "lbGacha";
            this.lbGacha.Size = new System.Drawing.Size(297, 276);
            this.lbGacha.TabIndex = 1;
            // 
            // btnGacha10
            // 
            this.btnGacha10.Location = new System.Drawing.Point(229, 33);
            this.btnGacha10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGacha10.Name = "btnGacha10";
            this.btnGacha10.Size = new System.Drawing.Size(101, 44);
            this.btnGacha10.TabIndex = 2;
            this.btnGacha10.Text = "Săn  x10";
            this.btnGacha10.UseVisualStyleBackColor = true;
            this.btnGacha10.Click += new System.EventHandler(this.btnGacha10_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(421, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Số lần săn hôm nay:";
            // 
            // lblRoll
            // 
            this.lblRoll.AutoSize = true;
            this.lblRoll.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoll.Location = new System.Drawing.Point(455, 80);
            this.lblRoll.Name = "lblRoll";
            this.lblRoll.Size = new System.Drawing.Size(53, 38);
            this.lblRoll.TabIndex = 4;
            this.lblRoll.Text = "50";
            // 
            // txtNoti
            // 
            this.txtNoti.Location = new System.Drawing.Point(109, 95);
            this.txtNoti.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNoti.Name = "txtNoti";
            this.txtNoti.ReadOnly = true;
            this.txtNoti.Size = new System.Drawing.Size(223, 22);
            this.txtNoti.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(376, 154);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(213, 210);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(395, 382);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nhà ngươi may mắn cỡ nào ?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Thử tài:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Thông báo";
            // 
            // Gacha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtNoti);
            this.Controls.Add(this.lblRoll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGacha10);
            this.Controls.Add(this.lbGacha);
            this.Controls.Add(this.btnGacha1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Gacha";
            this.Text = "Săn voucher";
            this.Load += new System.EventHandler(this.Gacha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGacha1;
        private System.Windows.Forms.ListBox lbGacha;
        private System.Windows.Forms.Button btnGacha10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRoll;
        private System.Windows.Forms.TextBox txtNoti;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}