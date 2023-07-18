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
    class ThreadContext
    {
        public SynchronizationContext SyncContext;
        public int Number;
    }
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
            SynchronizationContext synchronizationContext = SynchronizationContext.Current;
            ThreadContext context = new () { SyncContext = synchronizationContext, Number = input1 };
            Thread th = new Thread(this.CalculateSlow);
            th.Start(context);           
        }


        private void CalculateSlow(object context)
        {
            Threading.SlowMath sm = new Threading.SlowMath();
            ThreadContext threadContext = (ThreadContext)context;
            SynchronizationContext synchronizationContext = threadContext.SyncContext;
            int res = sm.Square(threadContext.Number);
            synchronizationContext.Post(s =>
            {
                this.ResultTextBox.Text = (string)s;
                this.CalculateButton.IsEnabled = true;
            }, res.ToString());
        }


    }
}
