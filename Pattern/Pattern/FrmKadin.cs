using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;

namespace Pattern
{
    public partial class FrmKadin : Form
    {
        public FrmKadin()
        {
            InitializeComponent();
        }
        public string alanKisi { get; set; }
        public int Fiyati { get; set; }
        public int Tutar { get; set; }
        public int Miktar { get; set; }      
        public int GeciciTutar = 0;
        ArrayList urunler = new ArrayList();
        public static ConcreteStrategyNakit Nakit = new ConcreteStrategyNakit();
        public static ConcreteStrategyKrediKarti Kredili = new ConcreteStrategyKrediKarti();
        void UrunYazdir()
        {
            string urun = "";
            for (int i = 0; i < urunler.Count; i++)
            {
                urun += urunler[i].ToString() + ","; //urunler ArrayListinin içerisinden i'yi al ve ToString'e çevir.
            }
            if (urunler.Count >= 1)
            {
                urun = urun.Remove(urun.Length - 1, 1); //ürünün Length özelliğinden 1 çıkar ve 1. satırından al.
            }
            TxtUrunAdi.Text = urun;
          
        }

        private void GiyimUrunTikla(object sender, EventArgs e)
        {
            Database db = new Database();
            if (((Button)sender).BackColor == Color.GreenYellow)
            {
                ((Button)sender).BackColor = Color.Yellow;
                //Eğer tıklanan butonun texti urunler ArrayListinin içerisinde yoksa urunlerin textini yaz.
                if (!urunler.Contains(((Button)sender).Text))
                {
                    urunler.Add(((Button)sender).Text);//Gelen butonun textini ekler.
                }
                UrunYazdir();
            }
            //Eğer buton seçiliyse BackColor özelliğini green yap yani seçili halden çıkar.Urunler Arraylistinin içinden sildireceğiz.
            //Aynı zamanda TxtUrunAdi.Text in içinden de sildireceğiz.
            else if (((Button)sender).BackColor == Color.Yellow)
            {
                ((Button)sender).BackColor = Color.GreenYellow;
                if (urunler.Contains(((Button)sender).Text))
                {
                    urunler.Remove(((Button)sender).Text); //Gelen butonun textini sildir.
                }
                UrunYazdir();
            }
            else if (((Button)sender).BackColor == Color.Red)
            {
                DialogResult cevap = MessageBox.Show("Urunu almaktan vaz mı gectiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (cevap == DialogResult.Yes)
                {
                    if (!urunler.Contains(((Button)sender).Text))
                    {
                        db.baglanti.Open();
                        SqlCommand komut = new SqlCommand("delete from UrunAlma where UrunAdi=@urunno", db.baglanti);
                        komut.Parameters.AddWithValue("@urunno", " " + ((Button)sender).Text);
                        komut.ExecuteNonQuery();
                        SqlCommand komut2 = new SqlCommand("update Urun set durumu='Bos',urunuAlan=NULL  where urunAdi=@urunadi", db.baglanti);
                        komut2.Parameters.AddWithValue("@urunadi", " " + ((Button)sender).Text);
                        komut2.ExecuteNonQuery();
                        alanKisi = TxtAdi.Text + " " + TxtSoyadi.Text;
                        SqlCommand komut3 = new SqlCommand("update Urun set urunuAlan = @urunAlan,urunAdi=@urunadi where " +
                                                            "durumu = 'Dolu' AND urunAdi=@urunadi ", db.baglanti);
                        komut3.Parameters.AddWithValue("@urunAlan", alanKisi);
                        komut3.Parameters.AddWithValue("@urunadi", TxtUrunAdi.Text);
                        komut3.ExecuteNonQuery();
                        MessageBox.Show("Ürün satış iptali yapıldı");
                        ((Button)sender).BackColor = Color.GreenYellow;
                        db.baglanti.Close();
                    }
                    UrunYazdir();
                }
                if (cevap == DialogResult.No)
                {
                    MessageBox.Show("Ürün Satışı Yapılmadı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
      
        private void BtnSepeteEkle2_Click(object sender, EventArgs e)
        {
            //Bilgileri eksiksiz bir şekilde girmeden sepete ekleme işlemi yapılamaz.
            if (TxtAdi.Text == String.Empty || TxtSoyadi.Text == String.Empty || CmbCinsiyet.Text == String.Empty ||
              MskTxtTelefon.Text == String.Empty || TxtMail.Text == String.Empty || TxtKimlikNo.Text == String.Empty ||
              CmbKargo.Text == String.Empty || TxtAdres.Text == String.Empty || TxtUrunAdi.Text == String.Empty ||TxtAdet.Text==String.Empty)
            {
                MessageBox.Show("Lütfen gerekli alanları boş bırakmayınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //Factory sınıfı çağırılarak üretilen yeni nesne
                var Kadin = UrunFactory.GetName(1);
                for (int i = 0; i < urunler.Count; i++)
                {
                    string urun = " " + urunler[i].ToString();
                    Kadin.KayitAl(TxtAdi.Text, TxtSoyadi.Text, CmbCinsiyet.Text, MskTxtTelefon.Text,
                                   TxtMail.Text, TxtKimlikNo.Text, TxtAdres.Text, CmbKargo.Text, urun, TxtAdet.Text, lblIndirimliTutar.Text);
                }
                timer.Start();
            }
        }

        private void FrmGiyimUrunleri_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Database db = new Database();
            if (db.baglanti.State == ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand donustur = new SqlCommand("select * from Urun where durumu=@durum", db.baglanti);
                donustur.Parameters.AddWithValue("@durum", "Dolu");
                SqlDataReader donusturOku = donustur.ExecuteReader();
                while (donusturOku.Read())
                {
                    string butonAdi = donusturOku["butonAdi"].ToString();
                    string durumu = donusturOku["durumu"].ToString();
                    //Satılan ürünlerin butonlarını kırmızı yapmak için.
                    if (butonAdi == "urun1" && durumu == "Dolu")
                    {
                        urun1.BackColor = Color.Red;
                    }
                    if (butonAdi == "urun2" && durumu == "Dolu")
                    {
                        urun2.BackColor = Color.Red;
                    }
                    if (butonAdi == "urun3" && durumu == "Dolu")
                    {
                        urun3.BackColor = Color.Red;
                    }
                    if (butonAdi == "urun4" && durumu == "Dolu")
                    {
                        urun4.BackColor = Color.Red;
                    }
                    if (butonAdi == "urun5" && durumu == "Dolu")
                    {
                        urun5.BackColor = Color.Red;
                    }
                    if (butonAdi == "urun6" && durumu == "Dolu")
                    {
                        urun6.BackColor = Color.Red;
                    }
                    if (butonAdi == "urun7" && durumu == "Dolu")
                    {
                        urun7.BackColor = Color.Red;
                    }
                    if (butonAdi == "urun8" && durumu == "Dolu")
                    {
                        urun8.BackColor = Color.Red;
                    }
                    if (butonAdi == "urun9" && durumu == "Dolu")
                    {
                        urun9.BackColor = Color.Red;
                    }
                }
                donustur.Dispose();
                donusturOku.Close();
                db.baglanti.Close();
                timer.Stop();
            }
            catch (Exception hata) { System.Windows.Forms.MessageBox.Show("" + hata); }
            finally
            {
                db.baglanti.Close();
            }
        }      


        private void BtnHesapla_Click_1(object sender, EventArgs e)
        {
            if (urun1.BackColor==Color.Yellow)
            {               
                Fiyati = Convert.ToInt32(LblKazak.Text);
                Miktar = Convert.ToInt32(TxtAdet.Text);               
            }
            if (urun2.BackColor==Color.Yellow)
            {
                 Fiyati = Convert.ToInt32(LblKaban.Text);
                 Miktar = Convert.ToInt32(TxtAdet.Text);
            }
            if (urun3.BackColor==Color.Yellow)
            {
                Fiyati = Convert.ToInt32(LblCeket.Text);
                Miktar = Convert.ToInt32(TxtAdet.Text);
            }
            if (urun4.BackColor == Color.Yellow)
            {
                Fiyati = Convert.ToInt32(LblTshirt.Text);
                Miktar = Convert.ToInt32(TxtAdet.Text);
            }
            if (urun5.BackColor == Color.Yellow)
            {
                Fiyati = Convert.ToInt32(LblEsofman.Text);
                Miktar = Convert.ToInt32(TxtAdet.Text);
            }
            if (urun6.BackColor == Color.Yellow)
            {
                Fiyati = Convert.ToInt32(LblPantolon.Text);
                Miktar = Convert.ToInt32(TxtAdet.Text);
            }
            if (urun7.BackColor == Color.Yellow)
            {
                Fiyati = Convert.ToInt32(LblTerlik.Text);
                Miktar = Convert.ToInt32(TxtAdet.Text);
            }
            if (urun8.BackColor == Color.Yellow)
            {
                Fiyati = Convert.ToInt32(LblAyakkabi.Text);
                Miktar = Convert.ToInt32(TxtAdet.Text);       
            }
            if (urun9.BackColor == Color.Yellow)
            {
                Fiyati = Convert.ToInt32(LblBot.Text);
                Miktar = Convert.ToInt32(TxtAdet.Text);              
            }
            GeciciTutar = Fiyati * Miktar;
            lblToplam.Text = GeciciTutar.ToString() + "  TL";
        }
        //Nakit ödeme seçeneğini seçersek ConcreteStrategyNakit sınıfındaki metodu çalıştıracaktır. 
        private void rbNakit_CheckedChanged(object sender, EventArgs e)
        {
            Kredili.OdemeMiktari = 0;
            Nakit.Ode(GeciciTutar);
            lblIndirimliTutar.Text = Nakit.OdemeMiktari.ToString() + " TL";
            BtnSepeteEkle.Enabled = true;
        }
        //Kredi kartlı ödeme seçeneğini seçersek ConcreteStrategyKrediKarti sınıfındaki metodu çalıştıracaktır. 
        private void rbKredi_CheckedChanged(object sender, EventArgs e)
        {
            Nakit.OdemeMiktari = 0;
            Kredili.Ode(GeciciTutar);
            lblIndirimliTutar.Text = Kredili.OdemeMiktari.ToString() + " TL";
            BtnSepeteEkle.Enabled = true;
        }

        private void BtnSatilmis_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kırmızı Renkli Butonlar Satılmış Ürünleri Gösterir.", "Bilgi");
        }

        private void BtnSatista_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yeşil Renkli Butonlar Satışta Olan Ürünleri Gösterir.", "Bilgi");
        }

        private void BtnSecili_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sarı Renkli Butonlar Seçili Ürünleri Gösterir.", "Bilgi");
        }
        //İlgili alanlara harf dışında başka bir şey girilmesini engelleme ve boşluk girmeyi önleme.
        private void SadeceHarf_BoslukGirilemez(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
              && !char.IsSeparator(e.KeyChar);
            //Boşluk girilmemesi için.
            if ((int)e.KeyChar == 32)
            {
                e.Handled = true;
            }
        }
        //İlgili alanlara sayı dışında başka bir şey girilmesini engelleme ve boşluk girmeyi önleme.
        private void SadeceSayi_BoslukGirilemez(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 32)
            {
                e.Handled = true;
            }
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        //İlgili alanlara boşluk girmeyi önleme.
        private void Bos_Gecilemez(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 32)
            {
                e.Handled = true;
            }
        }
        KargoBridge bridge = new KargoBridge();
        UcretsizKargoBolumu ucretsizKargo = new UcretsizKargoBolumu();
        HizliTeslimatBolumu hizliTeslimat = new HizliTeslimatBolumu();
        //ComboBoxtaki seçime göre KargoBridge isimli köprü üzerinden ilgili sınıfa ulaşılmış olur. 
        private void CmbKargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedcmbox = CmbKargo.SelectedItem.ToString();
            if (selectedcmbox.ToString() == "Hizli Teslimat")
            {
                bridge.KargoTuruSec(hizliTeslimat);
            }
            else
            {
                bridge.KargoTuruSec(ucretsizKargo);
            }
        }       
    }
}
