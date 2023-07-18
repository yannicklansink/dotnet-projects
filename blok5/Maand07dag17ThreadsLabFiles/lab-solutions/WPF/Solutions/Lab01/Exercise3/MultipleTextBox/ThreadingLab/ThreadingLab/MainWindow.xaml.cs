using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
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

        BackgroundWorker[] bw = new BackgroundWorker[3];
        TextBox[] source;
        int sum;
        int numResults;
        //TextBoxes are named TextBox1, TextBox2, TextBox3 and ResultTextBox
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            CalculateButton.IsEnabled = false;
            source = new TextBox[] { TextBox1, TextBox2, TextBox3 };
            sum = 0;
            numResults = 0;
            for (int i = 0; i < 3; i++)
            {
                int input = int.Parse(source[i].Text);
                bw[i] = new BackgroundWorker();
                bw[i].DoWork += (object sender, DoWorkEventArgs e) =>
                {
                    Threading.SlowMath sm = new Threading.SlowMath();
                    e.Result = sm.Square((int)e.Argument);
                };
                bw[i].RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) =>
                {
                    Interlocked.Add(ref sum, (int)e.Result);
                    if (Interlocked.Increment(ref numResults) == 3)
                    {
                        ResultTextBox.Text = sum.ToString();
                        CalculateButton.IsEnabled = true;
                    }
                };
                bw[i].RunWorkerAsync(input);
            }
        }
    }
}
