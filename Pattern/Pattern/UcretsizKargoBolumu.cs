using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Pattern
{
    //IKargoCesitleri isimli interfaceden implemente edilen UcretsizKargoBolumu sınıfı.
    public class UcretsizKargoBolumu : IKargoCesitleri
    {
        public void Goster()
        {
            MessageBox.Show("Ucretsiz Kargo Secenegi ile Urununuz Belirtilen Adresinize Teslim Edilecektir.");
        }
    }
}
