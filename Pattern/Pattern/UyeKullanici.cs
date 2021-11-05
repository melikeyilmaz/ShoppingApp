using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace Pattern
{
    //Concrete Component:Sistem arayüzünü gerçekleyen/implemente eden somut sınıflardan birisidir.
    public class UyeKullanici :KullaniciGiris
    {
        //Isim ve sifreye göre GirisEkrani veritabanındaki bilgileri kontrol ediyoruz.
        //Veritabanında bulunan bir kayıt ise giriş başarılı oluyor. 
        //Degilse hata mesajı veriyor.
        Database db = new Database();        
        public override void GirisYap(string ad, string sifre, Form frm1)
        {
            if (db.baglanti.State == System.Data.ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand komut = new SqlCommand("select * from GirisEkrani where Ad='" + ad + "' AND " +
                                                    "Sifre='" + sifre + "'", db.baglanti);
                SqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    MessageBox.Show("Giriş Başarılı", "Tebrikler...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmAnaForm frm2 = new FrmAnaForm();
                    frm1.Hide();
                    frm2.ShowDialog(); //ShowDialogun farkı arkada gözüken formda işlem yaptırmaz.
                    Application.Exit();
                }
                else
                {
                    frm1.BackColor = Color.Red;
                    MessageBox.Show("Hatali Giriş", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    frm1.BackColor = Color.DeepSkyBlue;
                }
                komut.Dispose();
            }
            catch { }
            finally
            {
                db.baglanti.Close();
            }
        }
    }
}
