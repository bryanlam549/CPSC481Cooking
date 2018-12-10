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
        String recipeName;


        public CountdownTimer()
        {
            InitializeComponent();
        }


        public void TriggerNotification()
        {
            // have the notification box in mainWindow so that it appears from any tab
           ((MainWindow)App.Current.MainWindow).notificationMessage.Text = "Timer is up for step #" + currentStep + " of " + recipeName; 
           ((MainWindow)App.Current.MainWindow).notificationBox.Visibility = System.Windows.Visibility.Visible;

            var a = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                FillBehavior = FillBehavior.Stop,
                BeginTime = TimeSpan.FromSeconds(2),
                Duration = new Duration(TimeSpan.FromSeconds(5))
            };
            var storyboard = new Storyboard();

            storyboard.Children.Add(a);
            Storyboard.SetTarget(a, ((MainWindow)App.Current.MainWindow).notificationBox);
            Storyboard.SetTargetProperty(a, new PropertyPath(OpacityProperty));
            storyboard.Completed += delegate { ((MainWindow)App.Current.MainWindow).notificationBox.Visibility = System.Windows.Visibility.Hidden; };
            storyboard.Begin();
        }


        public void setStepTime(int seconds, int stepNum, String recipeName)
        {
            stepTime = seconds;
            currentStep = stepNum;
            this.recipeName = recipeName;
            if (stepTime > 0)
            {
                TimeSpan initialTime = TimeSpan.FromSeconds(stepTime);
                CountdownDisplay.Text = initialTime.ToString("c");
            }
            else
            {
                this.Visibility = System.Windows.Visibility.Hidden;
                this.IsEnabled = false;
            }
        }
    public void StartCountdown(double countDown)
    {
            // this part of  code taken from https://stackoverflow.com/questions/16748371/how-to-make-a-wpf-countdown-timer
           
            _time = TimeSpan.FromSeconds(countDown);

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                CountdownDisplay.Text = _time.ToString("c");
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
            _startTimer.Content = "START TIMER";
            TriggerNotification();
    }

        private void _start_Click(object sender, RoutedEventArgs e)
        {
            //#FF9C3828
            if (_startTimer.Content.Equals("START TIMER"))
            {
                _startTimer.Background = Brushes.White;
                _startTimer.Foreground = Brushes.Black;
                _ellipse.Fill = new SolidColorBrush(Color.FromRgb(156, 56, 40));
                if (_time == TimeSpan.Zero)
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

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            //stop timer
            if (_timer != null)
            {
                _timer.Stop();
                _startTimer.Content = "START TIMER";
                _startTimer.Background = new SolidColorBrush(Color.FromRgb(156, 56, 40));
                _startTimer.Foreground = Brushes.Black;
                _ellipse.Fill = Brushes.White;
                if (stepTime > 0)
                {
                    _time = TimeSpan.FromSeconds(stepTime);
                    CountdownDisplay.Text = _time.ToString("c");
                }
            }

        }
    }
}
