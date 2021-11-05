using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Pattern
{
    // A 'ConcreteProduct' class :Urun sınıfından kalıtım alır.
    //UrunGuncelle ve KayitAl metodlarını override eder.
    public class ErkekUrun : Urun
    {
        public string kisininAdiSoyadi { get; set; }
        //Ad, soyad, cinsiyet, telefonNo, mail, tcNo, urunNo, urunAdet gibi bilgileri alarak insert into 
        //komutu ile UrunAlma isimli veri tabanı tablosuna ekleyen metod.
        public override void KayitAl(string adi, string soyadi, string cinsiyet, string telefonNo, string mail, string tcNo, string adres, string kargo,
                            string urunNo, string urunAdet, string ucret)
        {
            Database db = new Database();
            if (db.baglanti.State == System.Data.ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand kayitAl = new SqlCommand("insert into UrunAlma values(@adi,@soyadi,@cinsiyet," +
                                                    "@telefon,@mail,@tc,@adres,@kargo,@urun,@urunAdet,@ucret)", db.baglanti);
                kayitAl.Parameters.AddWithValue("@adi", adi);
                kayitAl.Parameters.AddWithValue("@soyadi", soyadi);
                kayitAl.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                kayitAl.Parameters.AddWithValue("@telefon", telefonNo);
                kayitAl.Parameters.AddWithValue("@mail", mail);
                kayitAl.Parameters.AddWithValue("@tc", tcNo);
                kayitAl.Parameters.AddWithValue("@adres", adres);
                kayitAl.Parameters.AddWithValue("@kargo", kargo);
                kayitAl.Parameters.AddWithValue("@urun", urunNo);
                kayitAl.Parameters.AddWithValue("@urunAdet", urunAdet);
                kayitAl.Parameters.AddWithValue("@ucret", ucret);
                kayitAl.ExecuteNonQuery();
                MessageBox.Show("Müşteri kaydı başarılı bir şekilde oluşturulmuştur:" + urunNo + " " + "isimli ürün" + " " + adi +
                " " + soyadi + " " + "isimli kişiye satılmıştır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                kayitAl.Dispose();//Rami boşaltma işlemi.
                kisininAdiSoyadi = adi + " " + soyadi;
                UrunGuncelle(urunNo, kisininAdiSoyadi);
            }
            catch (Exception hata) { MessageBox.Show("" + hata); }
            finally
            {
                db.baglanti.Close();
            }
        }
        //Urun tablosunda urunuaAlan ve durumu bilgilerini güncelleme metodu.
        public override void UrunGuncelle(string urun, string kisiAdSoyad)
        {
            Database db = new Database();
            if (db.baglanti.State == System.Data.ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand guncelle = new SqlCommand("update Urun set urunuAlan=@alanKisi, durumu=@durum" +
                                                        " where urunAdi=@urunadi", db.baglanti);
                guncelle.Parameters.AddWithValue("@alanKisi", kisiAdSoyad);
                guncelle.Parameters.AddWithValue("@durum", "Dolu");
                guncelle.Parameters.AddWithValue("@urunadi", urun);
                guncelle.ExecuteNonQuery();
                MessageBox.Show("urun alindii");
                guncelle.Dispose();

            }
            catch (Exception hata) { System.Windows.Forms.MessageBox.Show("" + hata); }
            finally
            {
                db.baglanti.Close();
            }
        }
    }
}
