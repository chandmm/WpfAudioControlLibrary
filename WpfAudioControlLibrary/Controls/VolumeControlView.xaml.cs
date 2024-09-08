using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace WpfAudioControlLibrary.Controls
{
    public partial class VolumeControlView : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(VolumeControlView),
                new PropertyMetadata(50.0, OnValueChanged)); // Default value is 50 for the vertical line

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        private Point _position;
        public Point Position
        {
            get => _position;
            set
            {
                _position = value;

                OnPropertyChanged();
            }
        }

        public VolumeControlView()
        {
            DataContext = this;
            
            InitializeComponent();

            UpdateLinePosition();
        }

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (VolumeControlView)d;
            control.UpdateLinePosition();
        }

        private void UpdateLinePosition()
        {
            // Line length remains constant
            double length = 45; // The distance from the center to the end of the line

            // Map the Value (0 to 100) to an angle (-135 to +135 degrees)
            double angle = (Value - 50) / 50 * 135;

            // Convert angle to radians
            double angleRadians = angle * Math.PI / 180;

            // Calculate new X2, Y2 based on angle
            double x2 = Needle.X1 + length * Math.Cos(angleRadians);
            double y2 = Needle.Y1 - length * Math.Sin(angleRadians);

            // Update line position

            Position = new Point(x2, y2);
        }

        #region Events

        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion
    }
}
