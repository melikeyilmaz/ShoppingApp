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
    public partial class FrmUyeOl : Form
    {
        public FrmUyeOl()
        {
            InitializeComponent();
        }
        Kisi kullanici = new Kisi();
        private void BtnUyeOl_MouseHover(object sender, EventArgs e)
        {
            //Mouse üstünde durduğu zaman...
            BtnUyeOl.BackColor = Color.DarkCyan;
        }
        private void BtnUyeOl_MouseLeave(object sender, EventArgs e)
        {
            //Mouse üstünden ayrıldığında...
            BtnUyeOl.BackColor = Color.Chartreuse;
        }
        private void BtnUyeOl_Click(object sender, EventArgs e)
        {
            string kullaniciAd = TxtKullaniciAdi.Text;
            string kullaniciSifre = TxtSifre.Text;
            KullaniciGiris _giris = null;
            YeniKullanici yKullanici = new YeniKullanici(_giris);
            yKullanici.GirisYap(kullaniciAd, kullaniciSifre, this);

            FrmGiris frm2 = new FrmGiris();
            this.Hide();
            frm2.ShowDialog();

        }
        //Memento Design Pattern sayesinde kullanici adi ve sifre bilgilerini kaydedip dilediğimizde 
        //geri yükleme şansı buluyoruz.
        private void BtnAlanTemizle_Click(object sender, EventArgs e)
        {
            kullanici.Kaydet(this.TxtKullaniciAdi.Text, this.TxtSifre.Text);
            TxtKullaniciAdi.Clear();
            TxtSifre.Clear();
        }
        public void Goster()
        {
            this.TxtKullaniciAdi.Text = kullanici.isim;
            this.TxtSifre.Text = kullanici.sifre;
        }

        private void BtnGeriAl_Click(object sender, EventArgs e)
        {
            kullanici.OncekiniYukle();
            Goster();
        }
    }
}
