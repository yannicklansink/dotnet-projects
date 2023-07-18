using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

        private TextBox[] textBoxes;

        public MainWindow()
        {
            InitializeComponent();
            textBoxes = new[] { TextBox1, TextBox2, TextBox3 };
        }

        //TextBoxes are named TextBox1, TextBox2, TextBox3 and ResultTextBox
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            CalculateButton.IsEnabled = false;
            int totalResult = 0;
            int numberOfCalculations = 0;

            Task.Run(() =>
            {
                Parallel.For(0, 5, (index) =>
                {
                    Console.WriteLine("Name: {0}, Thread Id= {1}", index, Thread.CurrentThread.ManagedThreadId);
                    SlowMath slowMath = new SlowMath();
                    int userInput = int.Parse(textBoxes[index].Dispatcher.Invoke(() => textBoxes[index].Text));
                    int result = slowMath.Square(userInput);

                    Interlocked.Add(ref totalResult, result);
                    Interlocked.Increment(ref numberOfCalculations);
                });

            }).ContinueWith(t =>
            {
                if (numberOfCalculations == 3)
                {
                    ResultTextBox.Dispatcher.Invoke(() =>
                    {
                        ResultTextBox.Text = totalResult.ToString();
                        CalculateButton.IsEnabled = true;
                    });
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());

        }


    }
}
