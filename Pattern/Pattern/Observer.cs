using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern
{
    // The 'Observer' abstract class
    abstract class Observer
    {
        // Herhangi bir değişimde gözlemleyiciler tarafından yapılması istenilen aksiyonlar.
        public abstract void Update();
    }
}
