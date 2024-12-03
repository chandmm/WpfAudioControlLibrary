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
    public partial class VUControl : UserControl
    {
        #region Dependency Properties

        public static readonly DependencyProperty MinimumProperty =
           DependencyProperty.Register("Minimum", typeof(double?), typeof(VUControl), 
               new PropertyMetadata(null, OnRangeChangedMinimum));
        public double? Minimum
        {
            get => (double?)GetValue(MinimumProperty);
            set => SetValue(MinimumProperty, value);
        }

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(double?), typeof(VUControl), new PropertyMetadata(null, OnRangeChangedMaximum));
        public double? Maximum
        {
            get => (double?)GetValue(MaximumProperty);
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
            }
        }

        public static readonly DependencyProperty Mark1Property =
            DependencyProperty.Register("Mark1", typeof(string), typeof(VUControl), new PropertyMetadata("0", (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
            {
                if (dependencyObj is VUControl control
                    && control.DataContext is VUControlViewModel viewModel)
                {
                    viewModel.Mark1 = (string)args.NewValue;
                }
            }));
        public string Mark1
        {
            get => (string)GetValue(Mark1Property);
            set => SetValue(Mark1Property, value);
        }

        public static readonly DependencyProperty Mark2Property =
            DependencyProperty.Register("Mark2", typeof(string), typeof(VUControl), new PropertyMetadata("50", (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) => 
            {
                if (dependencyObj is VUControl control
                    && control.DataContext is VUControlViewModel viewModel)
                {
                    viewModel.Mark2 = (string)args.NewValue;
                }
            }));
        public string Mark2
        {
            get => (string)GetValue(Mark2Property);
            set => SetValue(Mark2Property, value);
        }

        public static readonly DependencyProperty Mark3Property =
            DependencyProperty.Register("Mark3", typeof(string), typeof(VUControl), new PropertyMetadata("75", (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
            {
                if (dependencyObj is VUControl control
                    && control.DataContext is VUControlViewModel viewModel)
                {
                    viewModel.Mark3 = (string)args.NewValue;
                }
            }));
        public string Mark3
        {
            get => (string)GetValue(Mark3Property);
            set => SetValue(Mark3Property, value);
        }

        public static readonly DependencyProperty Mark4Property =
            DependencyProperty.Register("Mark4", typeof(string), typeof(VUControl), new PropertyMetadata("100", (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
            {
                if (dependencyObj is VUControl control
                    && control.DataContext is VUControlViewModel viewModel)
                {
                    viewModel.Mark4 = (string)args.NewValue;
                }
            }));
        public string Mark4
        {
            get => (string)GetValue(Mark4Property);
            set => SetValue(Mark4Property, value);
        }

        public static readonly DependencyProperty Mark5Property =
           DependencyProperty.Register("Mark5", typeof(string), typeof(VUControl), new PropertyMetadata("100", (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
           {
               if (dependencyObj is VUControl control
                   && control.DataContext is VUControlViewModel viewModel)
               {
                   viewModel.Mark5 = (string)args.NewValue;
               }
           }));
        public string Mark5
        {
            get => (string)GetValue(Mark5Property);
            set => SetValue(Mark5Property, value);
        }

        public static readonly DependencyProperty Mark6Property =
           DependencyProperty.Register("Mark6", typeof(string), typeof(VUControl), new PropertyMetadata("100", (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
           {
               if (dependencyObj is VUControl control
                   && control.DataContext is VUControlViewModel viewModel)
               {
                   viewModel.Mark6 = (string)args.NewValue;
               }
           }));
        public string Mark6
        {
            get => (string)GetValue(Mark6Property);
            set => SetValue(Mark6Property, value);
        }

        public static readonly DependencyProperty BackplateTextProperty =
            DependencyProperty.Register("BackplateText", typeof(string), typeof(VUControl), new PropertyMetadata("Michael Chand VU", (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
            {
                if (dependencyObj is VUControl control
                && control.DataContext is VUControlViewModel viewModel)
                {
                    viewModel.BackplateText = (string)args.NewValue;
                }
            }));
        public string BackplateText
        {
            get => (string)GetValue(BackplateTextProperty);
            set => SetValue(BackplateTextProperty, value);
        }

        public static readonly DependencyProperty MeterLabelProperty =
            DependencyProperty.Register("MeterLabel", typeof(string), typeof(VUControl), new PropertyMetadata("Michael Chand VU", (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
            {
                if (dependencyObj is VUControl control
                && control.DataContext is VUControlViewModel viewModel)
                {
                    viewModel.MeterLabel = (string)args.NewValue;
                }
            }));
        public string MeterLabel
        {
            get => (string)GetValue(MeterLabelProperty);
            set => SetValue(MeterLabelProperty, value);
        }

        public static readonly DependencyProperty IsOverDriveProperty =
            DependencyProperty.Register("IsOverDrive", typeof(bool), typeof(VUControl), new PropertyMetadata(false, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
            {
                if (dependencyObj is VUControl control
                && control.DataContext is VUControlViewModel viewModel)
                {
                    viewModel.IsOverDrive = (bool)args.NewValue;
                }
            }));
        public bool IsOverDrive
        {
            get => (bool)GetValue(IsOverDriveProperty);
            set => SetValue(IsOverDriveProperty, value);
        }

        public static readonly DependencyProperty IsUseCustomOverDriveSettingProperty =
            DependencyProperty.Register("IsUseCustomOverDriveSetting", typeof(bool), typeof(VUControl), new PropertyMetadata(false, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
            {
                if (dependencyObj is VUControl control
                && control.DataContext is VUControlViewModel viewModel)
                {
                    viewModel.IsUseCustomOverDriveSetting = (bool)args.NewValue;
                }
            }));
        public bool IsUseCustomOverDriveSetting
        {
            get => (bool)GetValue(IsUseCustomOverDriveSettingProperty);
            set => SetValue(IsUseCustomOverDriveSettingProperty, value);
        }

        public static readonly DependencyProperty NeedleThicknessProperty =
            DependencyProperty.Register("NeedleThickness", typeof(double?), typeof(VUControl), new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
            {
                if (dependencyObj is VUControl control
                && control.DataContext is VUControlViewModel viewModel)
                {
                    viewModel.NeedleThickness = (double?)args.NewValue;
                }
            }));
        public double? NeedleThickness
        {
            get => (double?)GetValue(NeedleThicknessProperty);
            set => SetValue(NeedleThicknessProperty, value);
        }

        #endregion

        #region Style Properties

        public static readonly DependencyProperty BackgroundColourProperty =
            DependencyProperty.Register("BackgroundColour", typeof(string), typeof(VUControl), new PropertyMetadata("Transparent", (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
            {
                if (dependencyObj is VUControl control
                && control.DataContext is VUControlViewModel viewModel)
                {
                    viewModel.BackgroundColour = (string)args.NewValue;
                }
            }));
        public string BackgroundColour
        {
            get => (string)GetValue(BackgroundColourProperty);
            set => SetValue(BackgroundColourProperty, value);
        }

        public static readonly DependencyProperty NeedleColourProperty =
            DependencyProperty.Register("NeedleColour", typeof(string), typeof(VUControl), new PropertyMetadata("Transparent", (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
            {
                if (dependencyObj is VUControl control
                && control.DataContext is VUControlViewModel viewModel)
                {
                    viewModel.NeedleColour = (string)args.NewValue;
                }
            }));
        public string NeedleColour
        {
            get => (string)GetValue(NeedleColourProperty);
            set => SetValue(NeedleColourProperty, value);
        }

        public static readonly DependencyProperty DecalColourProperty =
            DependencyProperty.Register("DecalColour", typeof(string), typeof(VUControl), new PropertyMetadata("Transparent", (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
            {
                if (dependencyObj is VUControl control
                && control.DataContext is VUControlViewModel viewModel)
                {
                    viewModel.DecalColour = (string)args.NewValue;
                }
            }));
        public string DecalColour
        {
            get => (string)GetValue(DecalColourProperty);
            set => SetValue(DecalColourProperty, value);
        }

        public static readonly DependencyProperty OverdriveLampColourProperty =
            DependencyProperty.Register("OverdriveLampColour", typeof(string), typeof(VUControl), new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
            {
                if (dependencyObj is VUControl control
                && control.DataContext is VUControlViewModel viewModel)
                {
                    viewModel.OverdriveLampColour = (string)args.NewValue;
                }
            }));
        public string OverdriveLampColour
        {
            get => (string)GetValue(OverdriveLampColourProperty);
            set => SetValue(OverdriveLampColourProperty, value);
        }

        public static readonly DependencyProperty OverdriveLampOffColourProperty =
            DependencyProperty.Register("OverdriveLampOffColour", typeof(string), typeof(VUControl), new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
            {
                if (dependencyObj is VUControl control
                && control.DataContext is VUControlViewModel viewModel)
                {
                    viewModel.OverdriveLampOffColour = (string)args.NewValue;
                }
            }));
        public string OverdriveLampOffColour
        {
            get => (string)GetValue(OverdriveLampOffColourProperty);
            set => SetValue(OverdriveLampOffColourProperty, value);
        }

        public static readonly DependencyProperty MeterLabelForegroundProperty =
            DependencyProperty.Register("MeterLabelForeground", typeof(string), typeof(VUControl), new PropertyMetadata("Transparent", (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
            {
                if (dependencyObj is VUControl control
                && control.DataContext is VUControlViewModel viewModel)
                {
                    viewModel.MeterLabelForeground = (string)args.NewValue;
                }
            }));
        public string MeterLabelForeground
        {
            get => (string)GetValue(MeterLabelForegroundProperty);
            set => SetValue(MeterLabelForegroundProperty, value);
        }

        public static readonly DependencyProperty BottomCoverFillProperty =
            DependencyProperty.Register("BottomCoverFill", typeof(string), typeof(VUControl), new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
            {
                if (dependencyObj is VUControl control
                && control.DataContext is VUControlViewModel viewModel)
                {
                    viewModel.BottomCoverFill = (string)args.NewValue;
                }
            }));
        public string BottomCoverFill
        {
            get => (string)GetValue(BottomCoverFillProperty);
            set => SetValue(BottomCoverFillProperty, value);
        }

        #endregion

        #region Initialisation

        public VUControl()
        {
            InitializeComponent();
            DataContext = new VUControlViewModel(0, 100);
        }

        #endregion

        #region Callback Methods

        private static void OnValueChanged(DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args)
        {
            if (dependencyObj is VUControl control
                && control.DataContext is VUControlViewModel viewModel)
            {
                viewModel.Value = (double)args.NewValue;
            }
        }

        private static void OnRangeChangedMinimum(DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args)
        {
            if (dependencyObj is VUControl control
                && control.DataContext is VUControlViewModel viewModel)
            {
                viewModel.Minimum = (double)args.NewValue;

                viewModel.FsdRange = (viewModel.Maximum - viewModel.Minimum);

                viewModel.SetRatioMapToInternalRange();
            }
        }

        private static void OnRangeChangedMaximum(DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args)
        {
            if (dependencyObj is VUControl control
                && control.DataContext is VUControlViewModel viewModel)
            {
                viewModel.Maximum = (double)args.NewValue;

                viewModel.FsdRange = (viewModel.Maximum - viewModel.Minimum);

                viewModel.SetRatioMapToInternalRange();
            }
        }

        #endregion
    }
}
