using System;
using System.Windows;
using System.Windows.Threading;
using Microsoft.AppCenter.Analytics;
using System.IO;

namespace mastermind_gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow
    {
        readonly Randnum _randnum = new Randnum();
        readonly DispatcherTimer _timer = new DispatcherTimer();
        int _randomnum;
        int _count;
        readonly string _lowfile = "scorelow.txt";

        private void Initialize()
        {
            _count = 0;
            _randomnum = _randnum.Randint(1000, 9999);
            Console.WriteLine(_randomnum);
            if (File.Exists(_lowfile))
            {

            }
            else
            {
                File.Create(_lowfile);
                File.WriteAllText(_lowfile, "90000");
            }
        }

        private void Checker(string text)
        {
                try
                {
                    if (int.Parse(text) == _randomnum)
                    {
                        Label.Content = "Correct. You took " + _count + " Tries.";
                        if (Int32.Parse(File.ReadAllText(_lowfile)) > _count){
                            Console.WriteLine("DEBUG");
                            File.WriteAllText(_lowfile, _count.ToString());
                        }
                        Initialize();
                    }
                    else if (text.Length != 4)
                    {
                        Label.Content = "Enter a Four digit number";
                        Guess.Text = "";
                        _count += 1;
                    }
                    else if (Int32.Parse(text) > _randomnum)
                    {
                        Label.Content = "Too High";
                        Guess.Text = "";
                        _count += 1;
                    }
                    else if (Int32.Parse(text) < _randomnum)
                    {
                        Label.Content = "Too Low";
                        Guess.Text = "";
                        _count += 1;
                    }

                }
                catch (FormatException)
                {
                    Label.Content = "Enter a Four digit number";
                }

        }

        public MainWindow()
        {
            InitializeComponent(); //Start MainWindow
            Initialize();
            _timer.Interval = TimeSpan.FromMilliseconds(15);
            _timer.Tick += TimerTick;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Label.Content = "Checking";
            Analytics.TrackEvent("Check Button Clicked");
            _timer.Start();

        }

        private void TimerTick(object sender, EventArgs e)
        {
            Progress.Value += 1;
            if (!(Progress.Value >= 100)) return;
            Progress.Value = 0;
            Checker(Guess.Text);
            _timer.Stop();
        }

    }

}
