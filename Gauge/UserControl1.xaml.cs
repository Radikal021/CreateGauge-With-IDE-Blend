using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Gauge
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        public void SetValuePoint(int Value)
        {
            double Mathpoint = Value * 2.6;
            double pointposition = -130 + Mathpoint;

            Storyboard DailBoard = new Storyboard();
            DoubleAnimationUsingKeyFrames DA = new DoubleAnimationUsingKeyFrames();
            EasingDoubleKeyFrame frame = new EasingDoubleKeyFrame();

            Storyboard.SetTarget(DA, arrowPointer);
            Storyboard.SetTargetProperty(DA, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)"));

            frame.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1));
            frame.Value = pointposition;

            DA.KeyFrames.Add(frame);
            DailBoard.Children.Add(DA);

            // Update the value indicator
            lbl_Value.Content = Value.ToString() + "%";

            // Start the animation
            DailBoard.Begin();
        }


    }
}
