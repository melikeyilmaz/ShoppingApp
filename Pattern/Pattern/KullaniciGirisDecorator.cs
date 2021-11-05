using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
namespace Pattern
{
    //Decorator sinifi:abstract tanimlamak zorunlu
    //Decorator tipi hem Component arayüzünü uygular hem de kendi içerisinde Component tipinden 
    //bir nesne örneği referansını barındırır.
    public abstract class KullaniciGirisDecorator:KullaniciGiris
    {
        protected KullaniciGiris _giris;

        public KullaniciGirisDecorator(KullaniciGiris giris)
        {
            this._giris = giris;
        }
        public override void GirisYap(string ad, string sifre, Form frm1)
        {
            _giris.GirisYap(ad, sifre, frm1);
        }
    }
}
