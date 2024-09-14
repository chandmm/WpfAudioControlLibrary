using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace WpfAudioControlLibrary.Controls
{
    public partial class VUControl : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        #region Fields

        private static double FsdRange;
        private static int WindowSizeBounds = 400;
        private static int NeedleLength = 280;
        private static double HalfTheta = 50d;

        #endregion

        #region Dependency Properties

        public static readonly DependencyProperty MinimumProperty =
           DependencyProperty.Register("Minimum", typeof(double), typeof(VUControl), new PropertyMetadata(0.0, OnRangeChanged));

        public double Minimum
        {
            get => (double)GetValue(MinimumProperty);
            set => SetValue(MinimumProperty, value);
        }

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(double), typeof(VUControl), new PropertyMetadata(1.0, OnRangeChanged));
        public double Maximum
        {
            get => (double)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(VUControl), new PropertyMetadata(0.0, OnValueChanged));
        public double Value
        {
            get => (double)GetValue(ValueProperty);
            set
            {
                SetValue(ValueProperty, value);

                UpdateNeedlePosition();
            }
        }

        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(byte[]), typeof(VUControl), new PropertyMetadata(default(byte[]), OnDataChanged));
        public byte[] Data
        {
            get => (byte[])GetValue(DataProperty);
            set => SetValue(DataProperty, value);
        }

        public static readonly DependencyProperty Mark1Property =
            DependencyProperty.Register("Mark1", typeof(string), typeof(VUControl), new PropertyMetadata("0", null));
        public string Mark1
        {
            get => (string)GetValue(Mark1Property);
            set => SetValue(Mark1Property, value);
        }

        public static readonly DependencyProperty Mark2Property =
            DependencyProperty.Register("Mark2", typeof(string), typeof(VUControl), new PropertyMetadata("0", null));
        public string Mark2
        {
            get => (string)GetValue(Mark2Property);
            set => SetValue(Mark2Property, value);
        }

        public static readonly DependencyProperty Mark3Property =
            DependencyProperty.Register("Mark3", typeof(string), typeof(VUControl), new PropertyMetadata("0", null));
        public string Mark3
        {
            get => (string)GetValue(Mark3Property);
            set => SetValue(Mark3Property, value);
        }

        public static readonly DependencyProperty Mark4Property =
            DependencyProperty.Register("Mark4", typeof(string), typeof(VUControl), new PropertyMetadata("0", null));
        public string Mark4
        {
            get => (string)GetValue(Mark4Property);
            set => SetValue(Mark4Property, value);
        }

        #endregion

        #region Member Properties

        private double _gridWidth;
        public double GridWidth
        {
            get => _gridWidth;
            set
            {
                _gridWidth = value;

                OnPropertyChanged();
            }
        }

        private double _gridHeight;
        public double GridHeight
        {
            get => _gridHeight;
            set
            {
                _gridHeight = value;

                OnPropertyChanged();
            }
        }

        private int _x;
        public int X
        {
            get => _x;
            set
            {
                _x = value;

                OnPropertyChanged();
            }
        }

        private int _y;
        public int Y
        {
            get => _y;
            set
            {
                _y = value;

                OnPropertyChanged();
            }
        }

        #endregion

        #region Initialisation

        public VUControl()
        {
            DataContext = this;

            InitializeComponent();

            Value = Minimum;

            OnPropertyChanged(nameof(Value));
        }

        #endregion


        #region Callback Methods

        /*
         x 360

            11 x 40 = 440 + 70 = 510

            (x,y) = (360, 510)

            hypotenuse = sqrt(360 X x^2 + 510 * x^2);
            = 624.259 (Line length).

           stsrting xy = (40,330)
         */

        private static void OnDataChanged(DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args)
        {
        }

        private static void OnValueChanged(DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args)
        {
            if (dependencyObj is VUControl control
                && (control.DataContext as VUControl) != null)
            {
                var viewModel = control.DataContext as VUControl;

                viewModel.Value = (double)args.NewValue;
            }
        }

        private static void OnRangeChanged(DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args)
        {
            if (dependencyObj is VUControl control
                && (control.DataContext as VUControl) != null)
            {
                var viewModel = control.DataContext as VUControl;

                FsdRange = viewModel.Maximum - viewModel.Minimum;

                // work out min value and max value theta degrees.
                // Move only between these angles. Let the Viewbox take care of uniformity.
            }
        }

        private void UpdateNeedlePosition()
        {
            var radianAngle = DegreesToRadians(CalculateNeedleAngle());

            var sineCos = Math.SinCos(radianAngle);

            X = (int)((WindowSizeBounds / 2) + (sineCos.Cos * NeedleLength));
            Y = (int)(WindowSizeBounds - (sineCos.Sin * NeedleLength));
        }

        private double CalculateNeedleAngle()
        {
            (double minAngle, double maxAngle) = GetMinMaxAngle();

            // Normalize the value to a range between 0 and 1
            double normalizedValue = (Value - Minimum) / FsdRange;

            // Calculate the angle based on the normalized value
            return minAngle + normalizedValue * (maxAngle - minAngle);
        }


        private (double, double) GetMinMaxAngle()
            => (90 + (90 - HalfTheta), HalfTheta);

        private double DegreesToRadians(double degrees)
            => degrees * (Math.PI / 180);

        #endregion

        #region Event Handlers

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion
    }
}
