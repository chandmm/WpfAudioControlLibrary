using System.Windows;
using System.Windows.Controls;

namespace WpfAudioControlLibrary.Controls
{
    public partial class SeekSiderControl : UserControl
    {
        public static readonly DependencyProperty TickFrequencyProperty =
            DependencyProperty.Register("TickFrequency", typeof(double), typeof(SeekSiderControl),
                new PropertyMetadata(0d, null));
        public double TickFrequency
        {
            get { return (double)GetValue(TickFrequencyProperty); }
            set { SetValue(TickFrequencyProperty, value); }
        }

        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(double), typeof(SeekSiderControl),
                new PropertyMetadata(0d, null));
        public double Minimum
        {
            get { return (double)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(double), typeof(SeekSiderControl),
                new PropertyMetadata(0d, null));
        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(SeekSiderControl),
                new PropertyMetadata(0d, null));
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ElapsedTextProperty =
            DependencyProperty.Register("ElapsedText", typeof(string), typeof(SeekSiderControl),
                new PropertyMetadata("Elapsed 0:0", null));
        public string ElapsedText
        {
            get { return (string)GetValue(ElapsedTextProperty); }
            set { SetValue(ElapsedTextProperty, value); }
        }

        public static readonly DependencyProperty DurationTextProperty =
            DependencyProperty.Register("DurationText", typeof(string), typeof(SeekSiderControl),
                new PropertyMetadata("Duration 0:0", null));
        public string DurationText
        {
            get { return (string)GetValue(DurationTextProperty); }
            set { SetValue(DurationTextProperty, value); }
        }

        public SeekSiderControl()
        {
            DataContext = this;

            InitializeComponent();
        }
    }
}
