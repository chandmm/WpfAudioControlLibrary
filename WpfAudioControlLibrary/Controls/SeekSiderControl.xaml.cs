using System.Windows;
using System.Windows.Controls;

namespace WpfAudioControlLibrary.Controls
{
    public partial class SeekSiderControl : UserControl
    {
        #region Dependency Properties

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

        public static readonly DependencyProperty ElapsedHoursProperty =
            DependencyProperty.Register("ElapsedHours", typeof(int), typeof(SeekSiderControl),
                new PropertyMetadata(0, null));
        public int ElapsedHours
        {
            get { return (int)GetValue(ElapsedHoursProperty); }
            set { SetValue(ElapsedHoursProperty, value); }
        }

        public static readonly DependencyProperty ElapsedMinutesProperty =
            DependencyProperty.Register("ElapsedMinutes", typeof(int), typeof(SeekSiderControl),
                new PropertyMetadata(0, null));
        public int ElapsedMinutes
        {
            get { return (int)GetValue(ElapsedMinutesProperty); }
            set { SetValue(ElapsedMinutesProperty, value); }
        }

        public static readonly DependencyProperty ElapsedSecondsProperty =
            DependencyProperty.Register("ElapsedSeconds", typeof(int), typeof(SeekSiderControl),
                new PropertyMetadata(0, null));
        public int ElapsedSeconds
        {
            get { return (int)GetValue(ElapsedSecondsProperty); }
            set { SetValue(ElapsedSecondsProperty, value); }
        }

        public static readonly DependencyProperty DurationMinutesProperty =
            DependencyProperty.Register("DurationMinutes", typeof(int), typeof(SeekSiderControl),
                new PropertyMetadata(0, null));
        public int DurationMinutes
        {
            get { return (int)GetValue(DurationMinutesProperty); }
            set { SetValue(DurationMinutesProperty, value); }
        }

        public static readonly DependencyProperty DurationSecondsProperty =
            DependencyProperty.Register("DurationSeconds", typeof(int), typeof(SeekSiderControl),
                new PropertyMetadata(0, null));
        public int DurationSeconds
        {
            get { return (int)GetValue(DurationSecondsProperty); }
            set { SetValue(DurationSecondsProperty, value); }
        }

        public static readonly DependencyProperty DurationHoursProperty =
           DependencyProperty.Register("DurationHours", typeof(int), typeof(SeekSiderControl),
               new PropertyMetadata(0, null));
        public int DurationHours
        {
            get { return (int)GetValue(DurationHoursProperty); }
            set { SetValue(DurationHoursProperty, value); }
        }

        #endregion

        #region Initialisation

        public SeekSiderControl()
        {
            DataContext = this;

            InitializeComponent();
        }

        #endregion
    }
}
