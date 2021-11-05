using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern
{
    //Strategy - Tüm ödeme strategy'lerimiz bu sınıftan türeyecek.
    public abstract class StrategyOdeme
    {
        public decimal OdemeMiktari { get; set; }

        public abstract void Ode(decimal tutar);
    }
}
