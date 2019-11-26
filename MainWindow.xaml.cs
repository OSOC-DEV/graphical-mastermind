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
using System.Windows.Threading;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace mastermind_gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        readonly Randnum randnum = new Randnum();
        readonly DispatcherTimer timer = new DispatcherTimer();
        int randomnum = 0;

        int Initialize()
        {
            randomnum = randnum.Randint(1000, 9999);
            return 0;
        }

        void Checker(string text)
        {
                try
                {
                    if (Int32.Parse(text) == randomnum)
                    {
                        label.Content = "Correct";
                        Initialize();
                    }
                    else if (Int32.Parse(text) > randomnum)
                    {
                        label.Content = "Too High";
                    }
                    else if (Int32.Parse(text) < randomnum)
                    {
                        label.Content = "Too Low";
                    }
                    else if (text.Length != 4)
                    {
                        label.Content = "Enter a Four digit number";
                    }
                }
                catch (System.FormatException)
                {
                    label.Content = "Enter a Four digit number";
                }

        }

        public MainWindow()
        {
            InitializeComponent(); //Start MainWindow
            timer.Interval = TimeSpan.FromMilliseconds(25);
            timer.Tick += TimerTick;
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            label.Content = "Checking";
            Analytics.TrackEvent("Check Button Clicked");
            timer.Start();

        }

        private void TimerTick(object sender, EventArgs e)
        {
            progress.Value += 1;
            if (progress.Value >= 100)
            {
                progress.Value = 0;
                Checker(guess.Text);
                timer.Stop();
            }
        }

    }

}
