using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pattern
{
    //The 'ConcreteObserver' class
    class ConcreteObserver : Observer
    {
        private string _name;
        private string _observerState;
        private ConcreteSubject _subject;

        // Constructor(Yapıcı metod)
        public ConcreteObserver(ConcreteSubject subject, string name)
        {
            this._subject = subject;
            this._name = name;
        }
        //Urun bilgilerinde guncelleme oldugunda gözlemcilere bilgi verir.
        public override void Update()
        {
             _observerState = _subject.SubjectState;
              MessageBox.Show("Ürünün:" + " " + _name  + " " + _observerState + "olmuştur");
            
        }

        public ConcreteSubject Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
    }
}

