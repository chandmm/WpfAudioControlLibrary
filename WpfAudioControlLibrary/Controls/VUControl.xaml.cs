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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using WpfAudioControlLibrary.Controls.ViewModels;

namespace WpfAudioControlLibrary.Controls
{
    public partial class VUControl : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        #region Fields

        private VUControlViewModel _viewModel;

        #endregion

        #region Dependency Properties

        public static readonly DependencyProperty MinimumProperty =
           DependencyProperty.Register("Minimum", typeof(double), typeof(VUControl), new PropertyMetadata(0.0, OnRangeChangedMinimum));

        public double Minimum
        {
            get => (double)GetValue(MinimumProperty);
            set => SetValue(MinimumProperty, value);
        }

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(double), typeof(VUControl), new PropertyMetadata(100.0, OnRangeChangedMaximum));
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

        #endregion

        #region Initialisation

        public VUControl()
        {
            DataContext = new VUControlViewModel();

            InitializeComponent();
        }

        #endregion

        #region Callback Methods

        private static void OnDataChanged(DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args)
        {
            if (dependencyObj is VUControl control
                && control.DataContext is VUControlViewModel viewModel)
            {
                viewModel.UpdateNeedlePositionUsingPcmData();
            }
        }

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

        #region Event Handlers

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion
    }
}
