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
        private async void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            CalculateButton.IsEnabled = false;

            TextBox[] textBoxes = { TextBox1, TextBox2, TextBox3 };
            Task<int>[] tasks = new Task<int>[3];
            for (int i = 0; i < 3; i++)
            {
                int input = int.Parse(textBoxes[i].Text);
                Threading.SlowMath sm = new Threading.SlowMath();
                tasks[i] = sm.SquareAsync(input);
            }
            await Task.WhenAll(tasks);
            int sum = 0;
            for (int i = 0; i < 3; i++)
                sum += tasks[i].Result;
            ResultTextBox.Text = sum.ToString();
            CalculateButton.IsEnabled = true;
        }
    }
}
