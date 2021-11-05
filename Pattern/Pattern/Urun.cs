using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Pattern
{
    //Base Class
    //The 'Product' Abstract Class: KadinUrun ve ErkekUrun sınıfları bu Urun sınıfından kalıtım alır.
    public abstract class Urun
    {
        public abstract void UrunGuncelle(string urun, string kisiAdSoyad);
        public abstract void KayitAl(string adi, string soyadi, string cinsiyet, string telefonNo, string mail, string tcNo, string adres,string kargo,
                            string urunNo, string urunAdet,string ucret);
    }
}
