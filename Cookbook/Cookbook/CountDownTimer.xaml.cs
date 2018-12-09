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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Cookbook
{
    /// Took this from https://gist.github.com/jchadwick/5105385
    /// <summary>
    /// Interaction logic for CountdownTimer.xaml
    /// </summary>
    public partial class CountdownTimer : UserControl
    {
        DispatcherTimer _timer = null;
        TimeSpan _time = TimeSpan.Zero;
        int stepTime = 0;
        int currentStep = 0;

        public CountdownTimer()
        {
            InitializeComponent();
        }


        public void setStepTime(int seconds, int stepNum)
        {
            stepTime = seconds;
            currentStep = stepNum;
            TimeSpan initialTime = TimeSpan.FromSeconds(stepTime);
            CountdownDisplay.Text = initialTime.ToString("c");
        }
    public void StartCountdown(double countDown)
    {
            // this part of  code taken from https://stackoverflow.com/questions/16748371/how-to-make-a-wpf-countdown-timer
           
            _time = TimeSpan.FromSeconds(countDown);

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                if (_time == TimeSpan.Zero)
                {
                    _timer.Stop();
                    CountdownTimer_Completed();
                }
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            _timer.Start();
        }

    private void CountdownTimer_Completed()
    {
           _time = TimeSpan.FromSeconds(stepTime);
            _startTimer.Content = "Start";
            MessageBox.Show("Time's up form Step " + currentStep  + " !");
    }

        private void _start_Click(object sender, RoutedEventArgs e)
        {
            if (_startTimer.Content.Equals("START TIMER"))
            { 
                if(_time == TimeSpan.Zero)
                {
                    StartCountdown(stepTime);
                }
                else
                {
                    StartCountdown(_time.TotalSeconds);
                }

                _startTimer.Content = "STOP TIMER";
            }
            else
            {
                //stop timer
                _timer.Stop();
                _startTimer.Content = "START TIMER";
            }
        }
    }
}
