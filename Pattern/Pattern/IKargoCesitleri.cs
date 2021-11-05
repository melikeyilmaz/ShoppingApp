using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern
{
    //Kargo Çeşidi, bu modelde soyutlaşmış bir yapıdır. Yani, müşteri satın alma işlemini  
    //gerçekleştiriken, hangi tür (Hızlı Teslimat veya Ücretsiz Kargo) kargo seçmek istediğini
    //belirtmesi yeterli olacak. Bu durumu ayarlamak için IKargoCesitleri isminde bir interface 
    //oluşturuyorum ve ilgili formatları bu interface’den implemente ediyorum.
    public interface IKargoCesitleri
    {
        void Goster();
    }
}
