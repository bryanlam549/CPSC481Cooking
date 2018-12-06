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

namespace Cookbook
{
    /// Took this from https://gist.github.com/jchadwick/5105385
    /// <summary>
    /// Interaction logic for CountdownTimer.xaml
    /// </summary>
    public partial class CountdownTimer : UserControl
    {
        public CountdownTimer()
        {
            InitializeComponent();
           // MouseDoubleClick += (o, args) => StartCountdown(CountdownDisplay);
         }

    public void StartCountdown(FrameworkElement target, int countDown)
    {
        var countdownAnimation = new StringAnimationUsingKeyFrames();

        for (var i = 5; i > 0; i--)
        {
            var keyTime = TimeSpan.FromSeconds(5 - i);
            var frame = new DiscreteStringKeyFrame(i.ToString(), KeyTime.FromTimeSpan(keyTime));
            countdownAnimation.KeyFrames.Add(frame);
        }
        countdownAnimation.KeyFrames.Add(new DiscreteStringKeyFrame(" ", KeyTime.FromTimeSpan(TimeSpan.FromSeconds(6))));
        Storyboard.SetTargetName(countdownAnimation, target.Name);
        Storyboard.SetTargetProperty(countdownAnimation, new PropertyPath(TextBlock.TextProperty));

        var countdownStoryboard = new Storyboard();
        countdownStoryboard.Children.Add(countdownAnimation);
        countdownStoryboard.Completed += CountdownTimer_Completed;
        countdownStoryboard.Begin(this);
    }

    private void CountdownTimer_Completed(object sender, EventArgs e)
    {
        MessageBox.Show("Time's up!");
    }

        private void _start_Click(object sender, RoutedEventArgs e)
        {
            if (_start.Content.Equals("Start"))
            {
                StartCountdown(CountdownDisplay, 5);
                _start.Content = "Stop";
            }
            else
            {
                //stop timer
            }
        }
    }
}
