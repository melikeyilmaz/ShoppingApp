using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;
namespace Pattern
{
    //ConcreteDecorator:Bileşenlere yeni sorumlulukları eklemekle görevli tiptir. 
    //Ek işlevler bu tip içerisinde tanımlanan üyelerdir.
    public class YeniKullanici :KullaniciGirisDecorator
    {
        protected KullaniciGiris _giris;

        public YeniKullanici(KullaniciGiris giris):base(giris)
        {
            this._giris = giris;
        }
        Database db = new Database();
        public override void GirisYap(string ad, string sifre, Form frm1)
        {
            KayitOl(ad, sifre);
        }
        //Yeni Kullanıcıyı GirisEkrani veri tabanına ekleme metodu.
        private void KayitOl(string ad, string sifre)
        {            
            if (db.baglanti.State == System.Data.ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand yeniKayit = new SqlCommand("insert into GirisEkrani values(@adi,@sifre)", db.baglanti);
                yeniKayit.Parameters.AddWithValue("@adi", ad);
                yeniKayit.Parameters.AddWithValue("@sifre", sifre);
                yeniKayit.ExecuteNonQuery();
                MessageBox.Show("Kulanıcı kaydı başarılı bir şekilde gerçekleştirilmiştir:", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                yeniKayit.Dispose();//Rami boşaltma işlemi.                            
            }
            catch { }
            finally
            {
                db.baglanti.Close();
            }

        }
    }
}
