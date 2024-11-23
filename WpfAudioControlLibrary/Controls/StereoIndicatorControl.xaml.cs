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
    #region Properties

    public partial class StereoIndicatorControl : UserControl
    {
        public static readonly DependencyProperty IsMonoProperty =
            DependencyProperty.Register("IsMono", typeof(bool), typeof(StereoIndicatorControl),
                new PropertyMetadata(false, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is StereoIndicatorControl control
                        && control.DataContext is StereoIndicatorControlViewModel viewModel)
                    {
                        viewModel.IsMono = (bool)args.NewValue;
                    }
                }));
        public bool IsMono
        {
            get { return (bool)GetValue(IsMonoProperty); }
            set { SetValue(IsMonoProperty, value); }
        }

        #endregion

        #region Style colour Properties

        public static readonly DependencyProperty MonoOnFillProperty =
        DependencyProperty.Register("MonoOnFill", typeof(string), typeof(StereoIndicatorControl),
            new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
            {
                if (dependencyObj is StereoIndicatorControl control
                    && control.DataContext is StereoIndicatorControlViewModel viewModel)
                {
                    viewModel.MonoOnFill = (string)args.NewValue;
                }
            }));

        public string MonoOnFill
        {
            get => (string)GetValue(MonoOnFillProperty);
            set => SetValue(MonoOnFillProperty, value);
        }

        public static readonly DependencyProperty MonoOffFillProperty =
            DependencyProperty.Register("MonoOffFill", typeof(string), typeof(StereoIndicatorControl),
                new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is StereoIndicatorControl control
                        && control.DataContext is StereoIndicatorControlViewModel viewModel)
                    {
                        viewModel.MonoOffFill = (string)args.NewValue;
                    }
                }));

        public string MonoOffFill
        {
            get => (string)GetValue(MonoOffFillProperty);
            set => SetValue(MonoOffFillProperty, value);
        }

        public static readonly DependencyProperty StereoOnFillProperty =
            DependencyProperty.Register("StereoOnFill", typeof(string), typeof(StereoIndicatorControl),
                new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is StereoIndicatorControl control
                        && control.DataContext is StereoIndicatorControlViewModel viewModel)
                    {
                        viewModel.StereoOnFill = (string)args.NewValue;
                    }
                }));

        public string StereoOnFill
        {
            get => (string)GetValue(StereoOnFillProperty);
            set => SetValue(StereoOnFillProperty, value);
        }

        public static readonly DependencyProperty StereoOffFillProperty =
            DependencyProperty.Register("StereoOffFill", typeof(string), typeof(StereoIndicatorControl),
                new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is StereoIndicatorControl control
                        && control.DataContext is StereoIndicatorControlViewModel viewModel)
                    {
                        viewModel.StereoOffFill = (string)args.NewValue;
                    }
                }));

        public string StereoOffFill
        {
            get => (string)GetValue(StereoOffFillProperty);
            set => SetValue(StereoOffFillProperty, value);
        }

        public static readonly DependencyProperty LabelForegroundProperty =
            DependencyProperty.Register("LabelForeground", typeof(string), typeof(StereoIndicatorControl),
                new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is StereoIndicatorControl control
                        && control.DataContext is StereoIndicatorControlViewModel viewModel)
                    {
                        viewModel.LabelForeground = (string)args.NewValue;
                    }
                }));

        public string LabelForeground
        {
            get => (string)GetValue(LabelForegroundProperty);
            set => SetValue(LabelForegroundProperty, value);
        }

        #endregion

        public StereoIndicatorControl()
        {
            InitializeComponent();

            DataContext = new StereoIndicatorControlViewModel();
        }
    }
}
