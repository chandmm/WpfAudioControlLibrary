/*
   WPF Audio Control Library: Set if controls applicable to audio applications
    Copyright (C) 2024  Michael Chand

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/
using System.Windows;
using System.Windows.Controls;
using WpfAudioControlLibrary.Controls.ViewModels;

namespace WpfAudioControlLibrary.Controls
{
    public partial class SeekSiderControl : UserControl
    {
        public SeekSliderControlViewModel ViewModel { get; private set; }

        #region Dependency Properties

        public static readonly DependencyProperty TickFrequencyProperty =
            DependencyProperty.Register("TickFrequency", typeof(double), typeof(SeekSiderControl),
                new PropertyMetadata(0d, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                    {
                        if (dependencyObj is SeekSiderControl control)
                        {
                            control.ViewModel.TickFrequency = (double)args.NewValue;
                        }
                    }));
        public double TickFrequency
        {
            get { return (double)GetValue(TickFrequencyProperty); }
            set { SetValue(TickFrequencyProperty, value); }
        }

        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(double), typeof(SeekSiderControl),
                new PropertyMetadata(0d, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is SeekSiderControl control)
                    {
                        control.ViewModel.Minimum = (double)args.NewValue;
                    }
                }));
        public double Minimum
        {
            get { return (double)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(double), typeof(SeekSiderControl),
                new PropertyMetadata(0d, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is SeekSiderControl control)
                    {
                        control.ViewModel.Maximum = (double)args.NewValue;
                    }
                }));
        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double?), typeof(SeekSiderControl),
                new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is SeekSiderControl control)
                    {
                        control.ViewModel.Value = (double?)args.NewValue;
                    }
                }));
        public double? Value
        {
            get { return (double?)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ElapsedHoursProperty =
            DependencyProperty.Register("ElapsedHours", typeof(int), typeof(SeekSiderControl),
                new PropertyMetadata(0, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) => 
                { 
                    if (dependencyObj is SeekSiderControl control) 
                    { 
                        control.ViewModel.ElapsedHours = (int)args.NewValue; 
                    } 
                }));
        public int ElapsedHours
        {
            get { return (int)GetValue(ElapsedHoursProperty); }
            set { SetValue(ElapsedHoursProperty, value); }
        }

        public static readonly DependencyProperty ElapsedMinutesProperty =
            DependencyProperty.Register("ElapsedMinutes", typeof(int), typeof(SeekSiderControl),
                new PropertyMetadata(0, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is SeekSiderControl control)
                    {
                        control.ViewModel.ElapsedMinutes = (int)args.NewValue;
                    }
                }));
        public int ElapsedMinutes
        {
            get { return (int)GetValue(ElapsedMinutesProperty); }
            set { SetValue(ElapsedMinutesProperty, value); }
        }

        public static readonly DependencyProperty ElapsedSecondsProperty =
            DependencyProperty.Register("ElapsedSeconds", typeof(int), typeof(SeekSiderControl),
                new PropertyMetadata(0, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is SeekSiderControl control)
                    {
                        control.ViewModel.ElapsedSeconds = (int)args.NewValue;
                    }
                }));
        public int ElapsedSeconds
        {
            get { return (int)GetValue(ElapsedSecondsProperty); }
            set { SetValue(ElapsedSecondsProperty, value); }
        }

        public static readonly DependencyProperty DurationMinutesProperty =
            DependencyProperty.Register("DurationMinutes", typeof(int), typeof(SeekSiderControl),
                new PropertyMetadata(0, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is SeekSiderControl control)
                    {
                        control.ViewModel.DurationMinutes = (int)args.NewValue;
                    }
                }));
        public int DurationMinutes
        {
            get { return (int)GetValue(DurationMinutesProperty); }
            set { SetValue(DurationMinutesProperty, value); }
        }

        public static readonly DependencyProperty DurationSecondsProperty =
            DependencyProperty.Register("DurationSeconds", typeof(int), typeof(SeekSiderControl),
                new PropertyMetadata(0, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is SeekSiderControl control)
                    {
                        control.ViewModel.DurationSeconds = (int)args.NewValue;
                    }
                }));
        public int DurationSeconds
        {
            get { return (int)GetValue(DurationSecondsProperty); }
            set { SetValue(DurationSecondsProperty, value); }
        }

        public static readonly DependencyProperty DurationHoursProperty =
           DependencyProperty.Register("DurationHours", typeof(int), typeof(SeekSiderControl),
               new PropertyMetadata(0, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
               {
                   if (dependencyObj is SeekSiderControl control)
                   {
                       control.ViewModel.DurationHours = (int)args.NewValue;
                   }
               }));
        public int DurationHours
        {
            get { return (int)GetValue(DurationHoursProperty); }
            set { SetValue(DurationHoursProperty, value); }
        }

        #endregion

        #region Style Colours

        public static readonly DependencyProperty SliderThumbGlowOverlayProperty =
           DependencyProperty.Register("SliderThumbGlowOverlay", typeof(string), typeof(SeekSiderControl),
               new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
               {
                   if (dependencyObj is SeekSiderControl control)
                   {
                       control.ViewModel.SliderThumbGlowOverlay = (string)args.NewValue;
                   }
               }));
        public string SliderThumbGlowOverlay
        {
            get { return (string)GetValue(SliderThumbGlowOverlayProperty); }
            set { SetValue(SliderThumbGlowOverlayProperty, value); }
        }

        public static readonly DependencyProperty SliderThumbGripBarBackgroundProperty =
            DependencyProperty.Register("SliderThumbGripBarBackground", typeof(string), typeof(SeekSiderControl),
                new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is SeekSiderControl control)
                    {
                        control.ViewModel.SliderThumbGripBarBackground = (string)args.NewValue;
                    }
                }));

        public string SliderThumbGripBarBackground
        {
            get { return (string)GetValue(SliderThumbGripBarBackgroundProperty); }
            set { SetValue(SliderThumbGripBarBackgroundProperty, value); }
        }

        public static readonly DependencyProperty SliderThumbPointBackgroundProperty =
            DependencyProperty.Register("SliderThumbPointBackground", typeof(string), typeof(SeekSiderControl),
                new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is SeekSiderControl control)
                    {
                        control.ViewModel.SliderThumbPointBackground = (string)args.NewValue;
                    }
                }));

        public string SliderThumbPointBackground
        {
            get { return (string)GetValue(SliderThumbPointBackgroundProperty); }
            set { SetValue(SliderThumbPointBackgroundProperty, value); }
        }

        public static readonly DependencyProperty SliderThumbBorderProperty =
            DependencyProperty.Register("SliderThumbBorder", typeof(string), typeof(SeekSiderControl),
                new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is SeekSiderControl control)
                    {
                        control.ViewModel.SliderThumbBorder = (string)args.NewValue;
                    }
                }));

        public string SliderThumbBorder
        {
            get { return (string)GetValue(SliderThumbBorderProperty); }
            set { SetValue(SliderThumbBorderProperty, value); }
        }

        public static readonly DependencyProperty SliderThumbForegroundProperty =
            DependencyProperty.Register("SliderThumbForeground", typeof(string), typeof(SeekSiderControl),
                new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is SeekSiderControl control)
                    {
                        control.ViewModel.SliderThumbForeground = (string)args.NewValue;
                    }
                }));

        public string SliderThumbForeground
        {
            get { return (string)GetValue(SliderThumbForegroundProperty); }
            set { SetValue(SliderThumbForegroundProperty, value); }
        }

        public static readonly DependencyProperty SliderThumbMouseOverBackgroundProperty =
            DependencyProperty.Register("SliderThumbMouseOverBackground", typeof(string), typeof(SeekSiderControl),
                new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is SeekSiderControl control)
                    {
                        control.ViewModel.SliderThumbMouseOverBackground = (string)args.NewValue;
                    }
                }));

        public string SliderThumbMouseOverBackground
        {
            get { return (string)GetValue(SliderThumbMouseOverBackgroundProperty); }
            set { SetValue(SliderThumbMouseOverBackgroundProperty, value); }
        }

        public static readonly DependencyProperty SliderThumbMouseOverBorderProperty =
            DependencyProperty.Register("SliderThumbMouseOverBorder", typeof(string), typeof(SeekSiderControl),
                new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is SeekSiderControl control)
                    {
                        control.ViewModel.SliderThumbMouseOverBorder = (string)args.NewValue;
                    }
                }));

        public string SliderThumbMouseOverBorder
        {
            get { return (string)GetValue(SliderThumbMouseOverBorderProperty); }
            set { SetValue(SliderThumbMouseOverBorderProperty, value); }
        }

        public static readonly DependencyProperty SliderThumbPressedBackgroundProperty =
            DependencyProperty.Register("SliderThumbPressedBackground", typeof(string), typeof(SeekSiderControl),
                new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is SeekSiderControl control)
                    {
                        control.ViewModel.SliderThumbPressedBackground = (string)args.NewValue;
                    }
                }));

        public string SliderThumbPressedBackground
        {
            get { return (string)GetValue(SliderThumbPressedBackgroundProperty); }
            set { SetValue(SliderThumbPressedBackgroundProperty, value); }
        }

        public static readonly DependencyProperty SliderThumbPressedBorderProperty =
            DependencyProperty.Register("SliderThumbPressedBorder", typeof(string), typeof(SeekSiderControl),
                new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is SeekSiderControl control)
                    {
                        control.ViewModel.SliderThumbPressedBorder = (string)args.NewValue;
                    }
                }));

        public string SliderThumbPressedBorder
        {
            get { return (string)GetValue(SliderThumbPressedBorderProperty); }
            set { SetValue(SliderThumbPressedBorderProperty, value); }
        }

        public static readonly DependencyProperty SliderThumbDisabledBackgroundProperty =
            DependencyProperty.Register("SliderThumbDisabledBackground", typeof(string), typeof(SeekSiderControl),
                new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is SeekSiderControl control)
                    {
                        control.ViewModel.SliderThumbDisabledBackground = (string)args.NewValue;
                    }
                }));

        public string SliderThumbDisabledBackground
        {
            get { return (string)GetValue(SliderThumbDisabledBackgroundProperty); }
            set { SetValue(SliderThumbDisabledBackgroundProperty, value); }
        }

        public static readonly DependencyProperty SliderThumbDisabledBorderProperty =
            DependencyProperty.Register("SliderThumbDisabledBorder", typeof(string), typeof(SeekSiderControl),
                new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is SeekSiderControl control)
                    {
                        control.ViewModel.SliderThumbDisabledBorder = (string)args.NewValue;
                    }
                }));

        public string SliderThumbDisabledBorder
        {
            get { return (string)GetValue(SliderThumbDisabledBorderProperty); }
            set { SetValue(SliderThumbDisabledBorderProperty, value); }
        }

        public static readonly DependencyProperty SliderThumbTrackBackgroundProperty =
            DependencyProperty.Register("SliderThumbTrackBackground", typeof(string), typeof(SeekSiderControl),
                new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is SeekSiderControl control)
                    {
                        control.ViewModel.SliderThumbTrackBackground = (string)args.NewValue;
                    }
                }));

        public string SliderThumbTrackBackground
        {
            get { return (string)GetValue(SliderThumbTrackBackgroundProperty); }
            set { SetValue(SliderThumbTrackBackgroundProperty, value); }
        }

        public static readonly DependencyProperty SliderThumbTrackBorderProperty =
            DependencyProperty.Register("SliderThumbTrackBorder", typeof(string), typeof(SeekSiderControl),
                new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is SeekSiderControl control)
                    {
                        control.ViewModel.SliderThumbTrackBorder = (string)args.NewValue;
                    }
                }));

        public string SliderThumbTrackBorder
        {
            get { return (string)GetValue(SliderThumbTrackBorderProperty); }
            set { SetValue(SliderThumbTrackBorderProperty, value); }
        }


        #endregion

        #region Initialisation

        public SeekSiderControl()
        {
            InitializeComponent();

            ViewModel = new SeekSliderControlViewModel();

            DataContext = this;
        }

        #endregion
    }
}
