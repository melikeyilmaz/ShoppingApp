using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Pattern
{
    class urunEkle
    {
        //urunAdi, urunKodu, kategori, fiyat, adet, pazarlikBilgisi, yipranmaPayi gibi bilgileri alarak insert into 
        //komutu ile UrunEkle isimli veri tabanı tablosuna ekleyen metod.
        public void KayitAl(string urunAdi, string urunKodu, string kategori, string fiyat, string adet, string pazarlikBilgisi,
                            string yipranmaPayi)
        {
            Database db = new Database();
            if (db.baglanti.State == System.Data.ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand kayitAl = new SqlCommand("insert into UrunEkle values(@adi,@urunkodu,@kategori," +
                                                    "@fiyat,@adet,@pazarlikBil,@yipranmaPayi)", db.baglanti);
                kayitAl.Parameters.AddWithValue("@adi", urunAdi);
                kayitAl.Parameters.AddWithValue("@urunkodu", urunKodu);
                kayitAl.Parameters.AddWithValue("@kategori", kategori);
                kayitAl.Parameters.AddWithValue("@fiyat", fiyat);
                kayitAl.Parameters.AddWithValue("@adet", adet);
                kayitAl.Parameters.AddWithValue("@pazarlikBil", pazarlikBilgisi);
                kayitAl.Parameters.AddWithValue("@yipranmaPayi", yipranmaPayi);
                kayitAl.ExecuteNonQuery();
                MessageBox.Show("Ürün başarıyla eklenmiştir:", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                kayitAl.Dispose();//Rami boşaltma işlemi.
                
            }
            catch (Exception hata) { MessageBox.Show("" + hata); }
            finally
            {
                db.baglanti.Close();
            }
        }
    }
}
