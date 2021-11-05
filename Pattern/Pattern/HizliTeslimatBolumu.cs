using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Pattern
{
    //IKargoCesitleri isimli interfaceden implemente edilen HizliTeslimatBolumu sınıfı.
    public class HizliTeslimatBolumu : IKargoCesitleri
    {
        public void Goster()
        {
           MessageBox.Show("Hizli Teslimat Secenegi ile Urununuz Ayni Gun Icınde Adresinize Ulasacaktir.");
        }      
    }
}
