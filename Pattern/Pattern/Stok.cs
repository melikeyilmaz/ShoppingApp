using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Pattern
{
    class Stok
    {
        Database db = new Database();
        public string guncelleDurum { get; set; }
        public string silDurum { get; set; }
        
        //UrunEkle veritabanındaki verilerin tamamını çekip tabloya aktarma.
        public DataTable Tablolar()
        {
            if (db.baglanti.State == ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand veriAl = new SqlCommand("select * from UrunEkle", db.baglanti);
                SqlDataAdapter adaptor = new SqlDataAdapter(veriAl);// 1 // 2 // 3 //
                DataTable tablo = new DataTable(); //id(1) adi(a)
                adaptor.Fill(tablo);
                return tablo;
            }
            catch { return null; }
            finally
            {
                db.baglanti.Close();
            }
        }

        //UrunEkle tablosundaki kayıtları güncellemek için kullanılan metod.
        public void UrunGuncelle(int id,string urunAdi, string urunKodu, string kategori, string fiyat, string adet, string pazarlikBilgisi,
                            string yipranmaPayi)
        {
            if (db.baglanti.State == ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand guncelle = new SqlCommand("update UrunEkle set urunAdi=@adi, urunKodu=@urunkodu, " +
                    "kategori=@kategori, fiyat=@fiyat, adet=@adet, pazarlikBilgisi=@pazarlikBil, yipranmaPayi=@yipranmaPayi where id=@id", db.baglanti);
                guncelle.Parameters.AddWithValue("@adi", urunAdi);
                guncelle.Parameters.AddWithValue("@urunkodu", urunKodu);
                guncelle.Parameters.AddWithValue("@kategori", kategori);
                guncelle.Parameters.AddWithValue("@fiyat", fiyat);
                guncelle.Parameters.AddWithValue("@adet", adet);
                guncelle.Parameters.AddWithValue("@pazarlikBil", pazarlikBilgisi);
                guncelle.Parameters.AddWithValue("@yipranmaPayi", yipranmaPayi);             
                guncelle.Parameters.AddWithValue("@id", id);
                guncelle.ExecuteNonQuery();
                guncelleDurum = urunKodu+"kodlu" + urunAdi + "isimli ürünün verileri güncellenmiştir.";
            }
            catch { }
            finally
            {
                db.baglanti.Close();
            }
        }
        //Delete komutu ile id'ye göre UrunEkle tablosundan ilgili kaydı silme.
        public void UrunSil(int id)
        {
            if (db.baglanti.State == ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand sil = new SqlCommand("Delete UrunEkle where id=@id", db.baglanti);
                sil.Parameters.AddWithValue("@id", id);
                sil.ExecuteNonQuery();
                silDurum = "Silme işlemi başarılı";
            }
            catch { }
            finally
            {
                db.baglanti.Close();
            }
        }
        //LIKE komutu ile UrunEkle tablosundaki verileri arama.
        public DataTable UrunAra(string adi)
        {
            if (db.baglanti.State == ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand arama = new SqlCommand("select * from UrunEkle where urunAdi LIKE '%' + @adi + '%'", db.baglanti);
                arama.Parameters.AddWithValue("@adi", adi);
                SqlDataAdapter adaptor = new SqlDataAdapter(arama);
                DataTable tablo = new DataTable();
                adaptor.Fill(tablo);
                return tablo;
            }
            catch { return null; }
            finally
            {
                db.baglanti.Close();
            }
        }
    }
}
