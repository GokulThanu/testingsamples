using System.ComponentModel;

namespace Binding_Issue
{
    public partial class Form1 : Form, INotifyPropertyChanged
    {
        public Form1()
        {
            InitializeComponent();
            customControl1.DataBindings.Add(new Binding("Name1", this, "Value1", true, DataSourceUpdateMode.OnPropertyChanged));
            customControl1.DataBindings.Add(new Binding("Name2", this, "Value2", true, DataSourceUpdateMode.OnPropertyChanged));
            customControl1.DataBindings.Add(new Binding("Name3", this, "Value3", true, DataSourceUpdateMode.OnPropertyChanged));
        }

        private double? value1;

        public double? Value1
        {
            get { return value1; }
            set {
                if (value1 != value)
                {
                    value1 = value;
                    NotifyPropertyChanged(nameof(Value1));
                    textBox1.Text = value1.ToString();
                }
            }
        }
        private double? value2;

        public double? Value2
        {
            get { return value2; }
            set
            {
                if (value2 != value)
                {
                    value2 = value;
                    NotifyPropertyChanged(nameof(Value2));
                    textBox2.Text = value2.ToString();
                }
            }
        }
        private double? value3;

        public double? Value3
        {
            get { return value1; }
            set
            {
                if (value3 != value)
                {
                    value3 = value;
                    NotifyPropertyChanged(nameof(Value3));
                    textBox3.Text = value3.ToString();
                }
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}