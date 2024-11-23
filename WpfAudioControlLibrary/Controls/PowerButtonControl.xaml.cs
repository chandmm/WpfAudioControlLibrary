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
using System.Windows.Input;
using WpfAudioControlLibrary.Controls.ViewModels;

namespace WpfAudioControlLibrary.Controls
{
    public partial class PowerButtonControl : UserControl
    {
        public static readonly DependencyProperty ExitCommandProperty =
            DependencyProperty.Register("ExitCommand", typeof(ICommand), typeof(PowerButtonControl),
                new PropertyMetadata(null, null));
        public ICommand ExitCommand
        {
            get { return (ICommand)GetValue(ExitCommandProperty); }
            set { SetValue(ExitCommandProperty, value); }
        }

        public static readonly DependencyProperty PowerButtonLightFillProperty =
    DependencyProperty.Register("PowerButtonLightFill", typeof(string), typeof(PowerButtonControl),
        new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
        {
            if (dependencyObj is PowerButtonControl control
                && control.DataContext is PowerButtonControlViewModel viewModel)
            {
                viewModel.PowerButtonLightFill = (string)args.NewValue;
            }
        }));

        public string PowerButtonLightFill
        {
            get => (string)GetValue(PowerButtonLightFillProperty);
            set => SetValue(PowerButtonLightFillProperty, value);
        }

        public static readonly DependencyProperty PowerButtonStrokeFillProperty =
            DependencyProperty.Register("PowerButtonStrokeFill", typeof(string), typeof(PowerButtonControl),
                new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is PowerButtonControl control
                        && control.DataContext is PowerButtonControlViewModel viewModel)
                    {
                        viewModel.PowerButtonStrokeFill = (string)args.NewValue;
                    }
                }));

        public string PowerButtonStrokeFill
        {
            get => (string)GetValue(PowerButtonStrokeFillProperty);
            set => SetValue(PowerButtonStrokeFillProperty, value);
        }

        public static readonly DependencyProperty PowerButtonHighlightProperty =
            DependencyProperty.Register("PowerButtonHighlight", typeof(string), typeof(PowerButtonControl),
                new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is PowerButtonControl control
                        && control.DataContext is PowerButtonControlViewModel viewModel)
                    {
                        viewModel.PowerButtonHighlight = (string)args.NewValue;
                    }
                }));

        public string PowerButtonHighlight
        {
            get => (string)GetValue(PowerButtonHighlightProperty);
            set => SetValue(PowerButtonHighlightProperty, value);
        }


        public PowerButtonControl()
        {
            InitializeComponent();

            DataContext = new PowerButtonControlViewModel();
        }
    }
}
