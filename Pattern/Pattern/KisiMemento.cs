using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern
{
    //Memento - Asıl nesnemizin alanlarını tutan memento sınıfımız.
    class KisiMemento
    {
        public string isim { get; set; }
        public string sifre { get; set; }
        public KisiMemento(string isim, string sifre)
        {
            this.isim = isim;
            this.sifre = sifre;
        }
    }
}
