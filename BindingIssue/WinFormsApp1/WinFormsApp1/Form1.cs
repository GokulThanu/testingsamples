namespace WinFormsApp1
{
    
    public partial class Form1 : Form
    {
        model a;
        BindingSource bindingSource;
        public Form1()
        {
            InitializeComponent();
            bindingSource = new BindingSource();
            a=new model();
            a.DoubleValue = 40;
            bindingSource.DataSource = a;
            class11.DataBindings.Add(new Binding("Value", bindingSource, "DoubleValue", true));
            
        }
    }

    public class model
    {
        private double? myVar = 0;

        public double? DoubleValue
        {
            get { return myVar; }
            set { myVar = value; }
        }

    }
}