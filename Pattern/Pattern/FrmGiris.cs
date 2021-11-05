using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pattern
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void FrmAdminGiris_Load(object sender, EventArgs e)
        {
            TxtSifre.PasswordChar = '*';
        }

        private void BtnGirisYap_MouseHover(object sender, EventArgs e)
        {
            //Mouse üstünde durduğu zaman...
            BtnGirisYap.BackColor = Color.AliceBlue;
        }

        private void BtnGirisYap_MouseLeave(object sender, EventArgs e)
        {
            //Mouse üstünden ayrıldığında...
            BtnGirisYap.BackColor = Color.Crimson;
        }
        
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            string kullaniciAd = TxtKullaniciAdi.Text;
            string kullaniciSifre = TxtSifre.Text;
            UyeKullanici uye = new UyeKullanici();
            uye.GirisYap(kullaniciAd, kullaniciSifre, this);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmUyeOl frmuye = new FrmUyeOl();
            this.Hide();
            frmuye.ShowDialog();            
        }
    }
}
