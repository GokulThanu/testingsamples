using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binding_Issue
{
    public delegate void Name1ChangedEventHandler(object sender,ValueChangedEventArgs args);
    public class CustomControl:TextBox,INotifyPropertyChanged
    {
        #region Events

        public event Name1ChangedEventHandler Name1Changed;

        public event EventHandler<ValueChangedEventArgs> Name2Changed;

        public event EventHandler Name3Changed;

        #endregion
        private double? name1;

        public double? Name1
        {
            get { return name1; }
            set
            {
                if (name1 != value)
                {
                    name1 = value;
                    NotifyPropertyChanged(nameof(Name1));
                    if (Name1Changed != null)
                    {
                        Name1Changed(this, new ValueChangedEventArgs());
                    }
                }
            }
        }

        private double? name2;

        public double? Name2
        {
            get { return name2; }
            set
            {
                if (name2 != value)
                {
                    name2 = value;
                    NotifyPropertyChanged(nameof(Name2));
                    if (Name2Changed != null)
                    {
                        Name2Changed(this, new ValueChangedEventArgs());
                    }
                }
            }
        }

        private double? name3;

        public event PropertyChangedEventHandler? PropertyChanged;

        public double? Name3
        {
            get { return name3; }
            set 
            {
                if (name3 != value)
                {
                    name3 = value;
                    NotifyPropertyChanged(nameof(Name3));
                    if(Name3Changed != null)
                    {
                        Name3Changed(this, new EventArgs());
                    }
                }
            }
        }

        
        private void NotifyPropertyChanged (String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region overrides

        protected override void OnTextChanged(EventArgs e)
        {
            bool isparsed;
            double parsedvalue;
            if(base.Text!="")
            {
                isparsed = double.TryParse(base.Text, out parsedvalue); 
                if(isparsed)
                {
                    Name1 = Name2 = Name3 = parsedvalue;
                }
            }
            base.OnTextChanged(e);  
        }

        #endregion
    }
    public class ValueChangedEventArgs : EventArgs
    {
        #region Fields
        /// <summary>
        /// Gets or sets old value of <see cref="Syncfusion.WinForms.Input.SfNumericTextBox"/>.
        /// </summary>
        private double? old;

        /// <summary>
        /// Gets or sets new value of <see cref="Syncfusion.WinForms.Input.SfNumericTextBox"/>.
        /// </summary>
        private double? newValue;

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Syncfusion.WinForms.Input.Events.ValueChangedEventArgs"/> class.
        /// </summary>
        /// <param name="old">Old value</param>
        /// <param name="newValue">Changed new value</param>
        public ValueChangedEventArgs()
        {
           
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets new value of <see cref="Syncfusion.WinForms.Input.SfNumericTextBox"/>.
        /// </summary>
        public double? NewValue
        {
            get
            {
                return this.newValue;
            }
        }

        /// <summary>
        /// Gets old value of <see cref="Syncfusion.WinForms.Input.SfNumericTextBox"/>.
        /// </summary>
        public double? OldValue
        {
            get
            {
                return this.old;
            }
        }
        #endregion
    }
}
