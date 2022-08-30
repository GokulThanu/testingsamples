using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    
    public class Class1:TextBox
    {
        public  event EventHandler ValueChanged;
       
        public Class1(){}

        private double? myVar = 0;

        public double? Value
        {
            get { return myVar; }
            set { myVar = value; }
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
