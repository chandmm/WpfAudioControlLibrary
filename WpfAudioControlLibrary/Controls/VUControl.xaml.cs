using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace WpfAudioControlLibrary.Controls
{
    public partial class VUControl : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

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

        #endregion

        #region Initialisation

        public VUControl()
        {
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
