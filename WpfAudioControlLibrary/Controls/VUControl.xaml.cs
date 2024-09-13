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
            set => SetValue(ValueProperty, value);
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

        #endregion

        #region Initialisation

        public VUControl()
        {
            DataContext = this;

            InitializeComponent();
        }

        #endregion


        #region Callback Methods

        private static void OnDataChanged(DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args)
        {
        }

        private static void OnValueChanged(DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args)
        {
        }

        private static void OnRangeChanged(DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args)
        {
        }

        #endregion

        #region Event Handlers

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion
    }
}
