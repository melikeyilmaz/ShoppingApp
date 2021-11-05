using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern
{
    class Kisi
    {
        //Originator - Ayarlarımızın tutulduğu sınıfımız
        //Bu sınıf durumu tutulacak olan nesnemiz oluyor, 
        //eski veya yeni halini tutmamızı sağlayacak metotlar burada yer almaktadır.
        public string isim { get; set; }
        public string sifre { get; set; }
        KisiMemento kisi = null;
        
        public void Kaydet(string isim, string sifre)
        {
            this.isim = isim;
            this.sifre = sifre;
            kisi = new KisiMemento(isim, sifre);
        }
        public void OncekiniYukle()
        {
            isim = kisi.isim;
            sifre = kisi.sifre;
        }
    }
}
