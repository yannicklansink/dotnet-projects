using System;
using System.Collections.Generic;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private int totalResult = 0;
        private int numberOfCalculations = 0;

        //TextBoxes are named TextBox1, TextBox2, TextBox3 and ResultTextBox
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            CalculateButton.IsEnabled = false;
            totalResult = 0;
            numberOfCalculations = 0;

            Task.WhenAll(
                //CalculateSquare(TextBox1),
                //CalculateSquare(TextBox2),
                //CalculateSquare(TextBox3)
                // Select maakt een nieuwe Task voor alle TextBox(en) en WhenAll wacht tot all Tasks klaar zijn voor gebruik verder.
                new[] { TextBox1, TextBox2, TextBox3 }.Select(textbox => CalculateSquare(textbox))
            ).ContinueWith(t =>
            {
                //CalculateButton.Dispatcher.Invoke(() => CalculateButton.IsEnabled = true);
                CalculateButton.IsEnabled = true;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private Task CalculateSquare(TextBox inputTextBox)
        {
            return Task.Run(() =>
            {
                SlowMath slowMath = new SlowMath();
                string text = inputTextBox.Dispatcher.Invoke(() => inputTextBox.Text);

                int input = int.Parse(text);
                int result = slowMath.Square(input);

                Interlocked.Add(ref totalResult, result);
                int calculateCount = Interlocked.Increment(ref numberOfCalculations);

                if (calculateCount == 3)
                {
                    ResultTextBox.Dispatcher.Invoke(() =>
                    {
                        ResultTextBox.Text = totalResult.ToString();
                    });
                }
                
            });
        }



    }
}
