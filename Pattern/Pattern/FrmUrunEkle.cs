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
    public partial class FrmUrunEkle : Form
    {
        
        public FrmUrunEkle()
        {
            InitializeComponent();
        }

        private void BtnUrunEkle_Click(object sender, EventArgs e)
        {
            if (TxtAdi.Text == String.Empty || TxtKod.Text == String.Empty || CmbKategori.Text == String.Empty ||
                   TxtFiyat.Text == String.Empty || TxtAdet.Text == String.Empty || CmbPazarlik.Text == String.Empty ||
                   CmbYipranma.Text == String.Empty)
            {
                MessageBox.Show("Lütfen gerekli alanları boş bırakmayınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {              
                urunEkle urun = new urunEkle();
                urun.KayitAl(TxtAdi.Text, TxtKod.Text, CmbKategori.Text, TxtFiyat.Text,
                                   TxtAdet.Text, CmbPazarlik.Text, CmbYipranma.Text);
                //tmrKontrol.Start();
            }          

        }
        //Kullanıcının anlamsız ya bir veri girmesini ve boş geçmesini engellemek için.
        private void SadeceHarf_BoslukGirilemez(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
            if ((int)e.KeyChar == 32)
            {
                e.Handled = true;
            }
        }

        private void SadeceSayi_BoslukGirilemez(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 32)
            {
                e.Handled = true;
            }
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
