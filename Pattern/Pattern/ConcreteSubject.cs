using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern
{
    // The 'ConcreteSubject' class
    class ConcreteSubject : Subject
    {
        private string _subjectState;

        //Subject  durumunu alır ve ayarlar.
        public string SubjectState
        {
            get { return _subjectState; }
            set { _subjectState = value; }
        }
    }
}
