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

        public static readonly DependencyProperty ControlLabelProperty =
            DependencyProperty.Register("ControlLabel", typeof(string), typeof(VolumeControlView),
                new PropertyMetadata("Volume", OnValueChanged)); // Default value is 50 for the vertical line

        public string ControlLabel
        {
            get { return (string)GetValue(ControlLabelProperty); }
            set { SetValue(ControlLabelProperty, value); }
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
            double radiusLine = 45;

            var splice = Value * 2.7;
            var angle = ((270 - splice) - 45);
            var radAngle = (angle < 0 ? 360 + angle : angle) * Math.PI / 180;

            Position = new Point((int)(Needle.X1 + radiusLine * Math.Cos(radAngle)), (int)(Needle.Y1 - radiusLine * Math.Sin(radAngle)));
        }

        #region Events

        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion
    }
}
