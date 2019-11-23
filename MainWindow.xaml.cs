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
        readonly DispatcherTimer timer = new DispatcherTimer();

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
                Randnum randnum = new Randnum();
                label.Content = randnum.Randint(1, 1000);
                timer.Stop();
            }
        }

    }

}
