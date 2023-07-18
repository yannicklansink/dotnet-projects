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

        int sum;
        int numResults;
        TextBox[] source;
        //TextBoxes are named TextBox1, TextBox2, TextBox3 and ResultTextBox
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            CalculateButton.IsEnabled = false;
            sum = 0;
            numResults = 0;
            source = new TextBox[] { TextBox1, TextBox2, TextBox3 };
            for (int i = 0; i < 3; i++)
            {
                int input = int.Parse(source[i].Text);
                ThreadPool.QueueUserWorkItem(this.CalculateSlow,input);
            }
        }


        private void CalculateSlow(object num)
        {
            Threading.SlowMath sm = new Threading.SlowMath();
            int res = sm.Square((int)num);
            Interlocked.Add(ref sum, res);
            if (Interlocked.Increment(ref numResults) == 3)
                this.ResultTextBox.Dispatcher.Invoke((Action<string>)(s =>
                {
                    this.ResultTextBox.Text = s;
                    this.CalculateButton.IsEnabled = true;
                }), sum.ToString());
        }
    }
}
