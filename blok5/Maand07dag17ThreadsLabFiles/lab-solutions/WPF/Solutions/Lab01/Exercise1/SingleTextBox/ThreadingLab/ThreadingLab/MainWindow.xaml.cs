using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace ThreadingLab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       //TextBoxes are named TextBox1, TextBox2, TextBox3 and ResultTextBox
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            CalculateButton.IsEnabled = false;
            int input1 = int.Parse(TextBox1.Text);
            Thread th = new Thread(this.CalculateSlow);
            th.Start(input1);           
        }


        private void CalculateSlow(object num)
        {
            Threading.SlowMath sm = new Threading.SlowMath();
            int res = sm.Square((int)num);
            this.ResultTextBox.Dispatcher.Invoke((Action<string>)(s =>
            {
                this.ResultTextBox.Text = s;
                this.CalculateButton.IsEnabled = true;
            }), res.ToString());
        }


    }
}
