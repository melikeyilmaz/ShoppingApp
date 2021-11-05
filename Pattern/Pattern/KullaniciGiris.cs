using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
namespace Pattern
{
    //Component:Dinamik olarak sorumluluklar eklenebilecek olan asıl nesne için sunulan arayüzdür.
    //Interface veya abstract sınıf olarak tasarlanabilir.
    public abstract class KullaniciGiris
    {
        public abstract void GirisYap(string ad, string sifre, Form frm1);
    }
}
