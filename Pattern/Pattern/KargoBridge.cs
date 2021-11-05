using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern
{
    //Örnekte, hem HizliTeslimatBolumu hem de UcretsizKargoBolumu sınıfında bir IKargoCesitleri
    //arayüzü uyguladım. Daha sonra, iki kargo sınıfı arasında iletişim kuracak olan KargoBridge
    //isimli bu sınıfı tanımladım. 
    //KargoBridge sınıfının KargoTuruSec() işlevi bizi belirli bir kargo seçimine götürecektir. 
    //Amaç, FrmErkek ve FrmKadin sınıfının KargoBridge sınıfı aracılığıyla herhangi bir kargo
    //sınıfıyla konuştuğunu açıkça görüyoruz.
    public class KargoBridge
    {
        public void KargoTuruSec(IKargoCesitleri nesne)
        {
            nesne.Goster();
        }
    }
}
