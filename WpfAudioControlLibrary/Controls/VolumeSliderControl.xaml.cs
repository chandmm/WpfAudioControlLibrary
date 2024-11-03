using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace WpfAudioControlLibrary.Controls
{
    public partial class VolumeSliderControl : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        // Default for Value is 0 to represent null/default startup state.
        public static readonly DependencyProperty VolumeProperty =
            DependencyProperty.Register("Volume", typeof(int), typeof(VolumeSliderControl),
                new PropertyMetadata(0, OnValueChanged));
        public int Volume
        {
            get { return (int)GetValue(VolumeProperty); }
            set { SetValue(VolumeProperty, value); }
        }

        public static readonly DependencyProperty ControlLabelProperty =
            DependencyProperty.Register("ControlLabel", typeof(string), typeof(VolumeSliderControl),
                new PropertyMetadata("Volume", null));

        public string ControlLabel
        {
            get { return (string)GetValue(ControlLabelProperty); }
            set { SetValue(ControlLabelProperty, value); }
        }

        public static readonly DependencyProperty MaxProperty =
            DependencyProperty.Register("Max", typeof(int), typeof(VolumeSliderControl),
                new PropertyMetadata(100, OnValueChanged));

        public int Max
        {
            get { return (int)GetValue(MaxProperty); }
            set { SetValue(MaxProperty, value); }
        }

        public static readonly DependencyProperty MinProperty =
            DependencyProperty.Register("Min", typeof(int), typeof(VolumeSliderControl),
                new PropertyMetadata(0, OnValueChanged));

        public int Min
        {
            get { return (int)GetValue(MinProperty); }
            set { SetValue(MinProperty, value); }
        }

        public static readonly DependencyProperty IsShowVolumeKnobProperty =
            DependencyProperty.Register("IsShowVolumeKnob", typeof(bool), typeof(VolumeSliderControl),
                new PropertyMetadata(false, OnValueChanged));

        public bool IsShowVolumeKnob
        {
            get { return (bool)GetValue(IsShowVolumeKnobProperty); }
            set { SetValue(IsShowVolumeKnobProperty, value); }
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

        private Point _positionOrigin;
        public Point PositionOrigin
        {
            get => _positionOrigin;
            set
            {
                _positionOrigin = value;

                OnPropertyChanged();
            }
        }

        public VolumeSliderControl()
        {
            DataContext = this;

            InitializeComponent();
        }

        private void Slider_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs args)
        {
            int delta = args.Delta;

            if (delta > 0)
            {
                Volume = (Volume + 1) > Max ? Max : Volume + 1;
            }

            if (delta < 0)
            {
                Volume = (Volume - 1) < Min ? Min : Volume - 1;
            }

            args.Handled = true;
        }

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (VolumeSliderControl)d;
        }

        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
