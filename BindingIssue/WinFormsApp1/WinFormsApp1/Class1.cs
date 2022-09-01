using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    
    public class Class1:TextBox,INotifyPropertyChanged
    {
        public  event EventHandler ValueChanged;
        public event PropertyChangedEventHandler? PropertyChanged;

       

        protected void RaisePropertyChangedEvent(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public Class1(){}

        private double? myVar = 0;

        public double? Value
        {
            get { return myVar; }
            set { myVar = value;
                RaisePropertyChangedEvent("Value");
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            if(Value == 40)
            {
                Value = 30;
            }
            base.OnGotFocus(e);
        }

    }

    
}
