using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern
{
    //Sorumluluğu alan Fabrika(Factory) Sınıfı:Urunlerin(nesne) oluşmasını sağlar.
    //Bu sınıf sayesinde nesne üretirken gerekli id' yi kullanıyoruz.
    static class UrunFactory
    {
        public static Urun GetName(int id)
        {

            if (id == 0)

                return new ErkekUrun();

            else

                return new KadinUrun();
        }
    }   
}

