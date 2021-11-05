namespace Pattern
{
    partial class FrmAnaForm
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
            this.components = new System.ComponentModel.Container();
            this.LblTarih = new System.Windows.Forms.Label();
            this.LblSaat = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.BtnMusteriGorusleri = new System.Windows.Forms.Button();
            this.BtnCikis = new System.Windows.Forms.Button();
            this.BtnStokIslemleri = new System.Windows.Forms.Button();
            this.BtnUrunEkle = new System.Windows.Forms.Button();
            this.BtnKadinGiyim = new System.Windows.Forms.Button();
            this.BtnErkekGiyim = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnKullaniciGiris = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LblTarih
            // 
            this.LblTarih.AutoSize = true;
            this.LblTarih.BackColor = System.Drawing.Color.MistyRose;
            this.LblTarih.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblTarih.ForeColor = System.Drawing.SystemColors.Highlight;
            this.LblTarih.Location = new System.Drawing.Point(707, 36);
            this.LblTarih.Name = "LblTarih";
            this.LblTarih.Size = new System.Drawing.Size(48, 21);
            this.LblTarih.TabIndex = 2;
            this.LblTarih.Text = "Tarih";
            // 
            // LblSaat
            // 
            this.LblSaat.AutoSize = true;
            this.LblSaat.BackColor = System.Drawing.Color.MistyRose;
            this.LblSaat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblSaat.ForeColor = System.Drawing.SystemColors.Highlight;
            this.LblSaat.Location = new System.Drawing.Point(773, 64);
            this.LblSaat.Name = "LblSaat";
            this.LblSaat.Size = new System.Drawing.Size(43, 21);
            this.LblSaat.TabIndex = 3;
            this.LblSaat.Text = "Saat";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.DarkOrchid;
            this.label1.Location = new System.Drawing.Point(82, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(672, 30);
            this.label1.TabIndex = 16;
            this.label1.Text = "Aşağıda Verilen Butonlardan Birini Seçerek İşleminizi Yapabilirsiniz.";
            // 
            // BtnMusteriGorusleri
            // 
            this.BtnMusteriGorusleri.BackgroundImage = global::Pattern.Properties.Resources.MusteriGorusleri;
            this.BtnMusteriGorusleri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnMusteriGorusleri.Location = new System.Drawing.Point(579, 359);
            this.BtnMusteriGorusleri.Name = "BtnMusteriGorusleri";
            this.BtnMusteriGorusleri.Size = new System.Drawing.Size(279, 183);
            this.BtnMusteriGorusleri.TabIndex = 17;
            this.BtnMusteriGorusleri.UseVisualStyleBackColor = true;
            this.BtnMusteriGorusleri.Click += new System.EventHandler(this.BtnMusteriGorusleri_Click);
            // 
            // BtnCikis
            // 
            this.BtnCikis.BackgroundImage = global::Pattern.Properties.Resources.cikis;
            this.BtnCikis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnCikis.Location = new System.Drawing.Point(766, 548);
            this.BtnCikis.Name = "BtnCikis";
            this.BtnCikis.Size = new System.Drawing.Size(84, 73);
            this.BtnCikis.TabIndex = 9;
            this.BtnCikis.UseVisualStyleBackColor = true;
            this.BtnCikis.Click += new System.EventHandler(this.BtnCikis_Click);
            // 
            // BtnStokIslemleri
            // 
            this.BtnStokIslemleri.BackgroundImage = global::Pattern.Properties.Resources.stoktablosu;
            this.BtnStokIslemleri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnStokIslemleri.Location = new System.Drawing.Point(294, 359);
            this.BtnStokIslemleri.Name = "BtnStokIslemleri";
            this.BtnStokIslemleri.Size = new System.Drawing.Size(279, 183);
            this.BtnStokIslemleri.TabIndex = 8;
            this.BtnStokIslemleri.UseVisualStyleBackColor = true;
            this.BtnStokIslemleri.Click += new System.EventHandler(this.BtnStokIslemleri_Click);
            // 
            // BtnUrunEkle
            // 
            this.BtnUrunEkle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnUrunEkle.BackgroundImage = global::Pattern.Properties.Resources.yeniurun;
            this.BtnUrunEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnUrunEkle.Location = new System.Drawing.Point(9, 359);
            this.BtnUrunEkle.Name = "BtnUrunEkle";
            this.BtnUrunEkle.Size = new System.Drawing.Size(279, 183);
            this.BtnUrunEkle.TabIndex = 7;
            this.BtnUrunEkle.UseVisualStyleBackColor = true;
            this.BtnUrunEkle.Click += new System.EventHandler(this.BtnUrunEkle_Click);
            // 
            // BtnKadinGiyim
            // 
            this.BtnKadinGiyim.BackgroundImage = global::Pattern.Properties.Resources.kadin;
            this.BtnKadinGiyim.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnKadinGiyim.Location = new System.Drawing.Point(579, 170);
            this.BtnKadinGiyim.Name = "BtnKadinGiyim";
            this.BtnKadinGiyim.Size = new System.Drawing.Size(279, 183);
            this.BtnKadinGiyim.TabIndex = 6;
            this.BtnKadinGiyim.UseVisualStyleBackColor = true;
            this.BtnKadinGiyim.Click += new System.EventHandler(this.BtnKadinGiyim_Click);
            // 
            // BtnErkekGiyim
            // 
            this.BtnErkekGiyim.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnErkekGiyim.BackgroundImage = global::Pattern.Properties.Resources.erkek;
            this.BtnErkekGiyim.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnErkekGiyim.Location = new System.Drawing.Point(294, 170);
            this.BtnErkekGiyim.Name = "BtnErkekGiyim";
            this.BtnErkekGiyim.Size = new System.Drawing.Size(279, 183);
            this.BtnErkekGiyim.TabIndex = 5;
            this.BtnErkekGiyim.UseVisualStyleBackColor = true;
            this.BtnErkekGiyim.Click += new System.EventHandler(this.BtnErkekGiyim_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Pattern.Properties.Resources.resim;
            this.pictureBox1.Location = new System.Drawing.Point(2, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(699, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // BtnKullaniciGiris
            // 
            this.BtnKullaniciGiris.BackColor = System.Drawing.Color.Transparent;
            this.BtnKullaniciGiris.BackgroundImage = global::Pattern.Properties.Resources.giris;
            this.BtnKullaniciGiris.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnKullaniciGiris.Location = new System.Drawing.Point(9, 170);
            this.BtnKullaniciGiris.Name = "BtnKullaniciGiris";
            this.BtnKullaniciGiris.Size = new System.Drawing.Size(279, 183);
            this.BtnKullaniciGiris.TabIndex = 1;
            this.BtnKullaniciGiris.UseVisualStyleBackColor = false;
            this.BtnKullaniciGiris.Click += new System.EventHandler(this.BtnKullaniciGiris_Click);
            // 
            // FrmAnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(862, 623);
            this.Controls.Add(this.BtnMusteriGorusleri);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnCikis);
            this.Controls.Add(this.BtnStokIslemleri);
            this.Controls.Add(this.BtnUrunEkle);
            this.Controls.Add(this.BtnKadinGiyim);
            this.Controls.Add(this.BtnErkekGiyim);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LblSaat);
            this.Controls.Add(this.LblTarih);
            this.Controls.Add(this.BtnKullaniciGiris);
            this.Name = "FrmAnaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ana Form";
            this.Load += new System.EventHandler(this.FrmAnaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnKullaniciGiris;
        private System.Windows.Forms.Label LblTarih;
        private System.Windows.Forms.Label LblSaat;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnErkekGiyim;
        private System.Windows.Forms.Button BtnKadinGiyim;
        private System.Windows.Forms.Button BtnUrunEkle;
        private System.Windows.Forms.Button BtnStokIslemleri;
        private System.Windows.Forms.Button BtnCikis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnMusteriGorusleri;
    }
}