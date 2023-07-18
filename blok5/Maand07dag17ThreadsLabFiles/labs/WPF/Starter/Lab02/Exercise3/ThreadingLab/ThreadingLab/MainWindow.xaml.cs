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
using Threading;

namespace ThreadingLab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private TextBox[] textboxes;

        public MainWindow()
        {
            InitializeComponent();
        }

        //TextBoxes are named TextBox1, TextBox2, TextBox3 and ResultTextBox
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            CalculateButton.IsEnabled = false;

            var values = textboxes.Select(textbox => int.Parse(textbox.Text)).ToArray();


            var task = Task.Run(() =>
            {
                return values.AsParallel()
                                .Select(textbox => int.Parse(textbox.Dispatcher.Invoke(() => textbox.Text)))
                                .Select(value => new SlowMath().Square(value))
                                .Sum();
            });

            //Console.WriteLine(task.GetType());
            task.ContinueWith(t =>
            {
                Dispatcher.Invoke(() =>
                {
                    ResultTextBox.Text = task.Result.ToString();
                    CalculateButton.IsEnabled = true;
                });
            });




        }


    }
}
