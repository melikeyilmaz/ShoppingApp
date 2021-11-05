using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern
{
    //ConcreteStrategyKrediKarti - Kredi karti yöntemi ile ödeme strategy'miz.
    public class ConcreteStrategyKrediKarti : StrategyOdeme
    {
        private const decimal INDIRIMORANI = 0.03M;
        public decimal Indirim { get; private set; }
        public override void Ode(decimal tutar)
        {
            Indirim = tutar * INDIRIMORANI;
            OdemeMiktari = tutar - Indirim;
        }
    }
}
