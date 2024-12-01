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
    public partial class PlayIndicatorControl : UserControl
    {
        public static readonly DependencyProperty IsOnProperty =
            DependencyProperty.Register("IsOn", typeof(bool), typeof(PlayIndicatorControl),
                new PropertyMetadata(false, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is PlayIndicatorControl control
                        && control.DataContext is PlaybackIndicatorControlViewModel viewModel)
                    {
                        viewModel.IsOn = (bool)args.NewValue;
                    }
                }));

        public bool IsOn
        {
            get { return (bool)GetValue(IsOnProperty); }
            set { SetValue(IsOnProperty, value); }
        }


        #region Style colour Properties

        public static readonly DependencyProperty OffColourProperty =
        DependencyProperty.Register("OffColour", typeof(string), typeof(PlayIndicatorControl),
            new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
            {
                if (dependencyObj is PlayIndicatorControl control
                    && control.DataContext is PlaybackIndicatorControlViewModel viewModel)
                {
                    viewModel.OffColour = (string)args.NewValue;
                }
            }));

        public string OffColour
        {
            get => (string)GetValue(OffColourProperty);
            set => SetValue(OffColourProperty, value);
        }

        public static readonly DependencyProperty OnColourProperty =
        DependencyProperty.Register("OnColour", typeof(string), typeof(PlayIndicatorControl),
            new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
            {
                if (dependencyObj is PlayIndicatorControl control
                    && control.DataContext is PlaybackIndicatorControlViewModel viewModel)
                {
                    viewModel.OnColour = (string)args.NewValue;
                }
            }));

        public string OnColour
        {
            get => (string)GetValue(OnColourProperty);
            set => SetValue(OnColourProperty, value);
        }

        #endregion

        public PlayIndicatorControl()
        {
            DataContext = new PlaybackIndicatorControlViewModel();
            InitializeComponent();
        }
    }
}
