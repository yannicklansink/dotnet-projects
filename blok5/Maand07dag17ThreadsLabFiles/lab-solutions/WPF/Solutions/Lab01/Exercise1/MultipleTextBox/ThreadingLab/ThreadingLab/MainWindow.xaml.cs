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

        Thread[] th = new Thread[3];
        int[] res = new int[3];
        TextBox[] source;
        int[] input = new int[3];
        //TextBoxes are named TextBox1, TextBox2, TextBox3 and ResultTextBox
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            CalculateButton.IsEnabled = false;

            source = new TextBox[] { TextBox1, TextBox2, TextBox3 };
            for (int i = 0; i < 3; i++)
            {
                input[i] = int.Parse(source[i].Text);
                th[i] = new Thread(this.CalculateSlow);
                th[i].Start(i);
            }
            Thread th4 = new Thread(AddAndStoreResult);
            th4.Start();


        }

        private void AddAndStoreResult()
        {
            for (int i = 0; i < 3; i++)
                th[i].Join();
            int sum = 0;
            for (int i = 0; i < 3; i++)
                sum += res[i];

            this.ResultTextBox.Dispatcher.Invoke((Action<string>)(s =>
            {
                this.ResultTextBox.Text = s;
                this.CalculateButton.IsEnabled = true;
            }), sum.ToString());
        }

        private void CalculateSlow(object num)
        {
            Threading.SlowMath sm = new Threading.SlowMath();
            res[(int)num] = sm.Square(input[(int)num]);
        }
    }
}
