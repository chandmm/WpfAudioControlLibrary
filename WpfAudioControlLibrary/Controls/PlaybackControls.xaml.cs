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
    public partial class PlaybackControls : UserControl
    {
        #region Dependencies

        public static readonly DependencyProperty SkipToStartCommandProperty =
            DependencyProperty.Register("SkipToStartCommand", typeof(ICommand), typeof(PlaybackControls),
                new PropertyMetadata(null, null));
        public ICommand SkipToStartCommand
        {
            get { return (ICommand)GetValue(SkipToStartCommandProperty); }
            set { SetValue(SkipToStartCommandProperty, value); }
        }

        public static readonly DependencyProperty StopCommandProperty =
            DependencyProperty.Register("StopCommand", typeof(ICommand), typeof(PlaybackControls),
                new PropertyMetadata(null, null));
        public ICommand StopCommand
        {
            get { return (ICommand)GetValue(StopCommandProperty); }
            set { SetValue(StopCommandProperty, value); }
        }

        public static readonly DependencyProperty PlayCommandProperty =
            DependencyProperty.Register("PlayCommand", typeof(ICommand), typeof(PlaybackControls),
                new PropertyMetadata(null, null));
        public ICommand PlayCommand
        {
            get { return (ICommand)GetValue(PlayCommandProperty); }
            set { SetValue(PlayCommandProperty, value); }
        }

        public static readonly DependencyProperty PauseCommandProperty =
            DependencyProperty.Register("PauseCommand", typeof(ICommand), typeof(PlaybackControls),
                new PropertyMetadata(null, null));
        public ICommand PauseCommand
        {
            get { return (ICommand)GetValue(PauseCommandProperty); }
            set { SetValue(PauseCommandProperty, value); }
        }

        public static readonly DependencyProperty SelectCommandProperty =
            DependencyProperty.Register("SelectCommand", typeof(ICommand), typeof(PlaybackControls),
                new PropertyMetadata(null, null));
        public ICommand SelectCommand
        {
            get { return (ICommand)GetValue(SelectCommandProperty); }
            set { SetValue(SelectCommandProperty, value); }
        }

        public static readonly DependencyProperty SkipToEndCommandProperty =
            DependencyProperty.Register("SkipToEndCommand", typeof(ICommand), typeof(PlaybackControls),
                new PropertyMetadata(null, null));
        public ICommand SkipToEndCommand
        {
            get { return (ICommand)GetValue(SkipToEndCommandProperty); }
            set { SetValue(SkipToEndCommandProperty, value); }
        }

        public static readonly DependencyProperty SetAutoplayModeToggleCommandProperty =
            DependencyProperty.Register("SetAutoplayModeToggleCommand", typeof(ICommand), typeof(PlaybackControls),
                new PropertyMetadata(null, null));
        public ICommand SetAutoplayModeToggleCommand
        {
            get { return (ICommand)GetValue(SetAutoplayModeToggleCommandProperty); }
            set { SetValue(SetAutoplayModeToggleCommandProperty, value); }
        }

        public static readonly DependencyProperty SetLoopPlayModeToggleCommandProperty =
            DependencyProperty.Register("SetLoopPlayModeToggleCommand", typeof(ICommand), typeof(PlaybackControls),
                new PropertyMetadata(null, null));
        public ICommand SetLoopPlayModeToggleCommand
        {
            get { return (ICommand)GetValue(SetLoopPlayModeToggleCommandProperty); }
            set { SetValue(SetLoopPlayModeToggleCommandProperty, value); }
        }

        public static readonly DependencyProperty IsAutoPlayCheckedProperty =
            DependencyProperty.Register("IsAutoPlayChecked", typeof(bool), typeof(PlaybackControls),
                new PropertyMetadata(false, null));
        public bool IsAutoPlayChecked
        {
            get { return (bool)GetValue(IsAutoPlayCheckedProperty); }
            set { SetValue(IsAutoPlayCheckedProperty, value); }
        }

        public static readonly DependencyProperty IsLoopPlayCheckedProperty =
            DependencyProperty.Register("IsLoopPlayChecked", typeof(bool), typeof(PlaybackControls),
                new PropertyMetadata(false, null));
        public bool IsLoopPlayChecked
        {
            get { return (bool)GetValue(IsLoopPlayCheckedProperty); }
            set { SetValue(IsLoopPlayCheckedProperty, value); }
        }

        #endregion

        #region Style Colour properties

        public static readonly DependencyProperty SkipToStartButtonFillProperty =
        DependencyProperty.Register("SkipToStartButtonFill", typeof(string), typeof(PlaybackControls),
            new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
            {
                if (dependencyObj is PlaybackControls control
                    && control.DataContext is PlaybackControlsViewModel viewModel)
                {
                    viewModel.SkipToStartButtonFill = (string)args.NewValue;
                }
            }));

        public string SkipToStartButtonFill
        {
            get => (string)GetValue(SkipToStartButtonFillProperty);
            set => SetValue(SkipToStartButtonFillProperty, value);
        }

        public static readonly DependencyProperty StopButtonFillProperty =
            DependencyProperty.Register("StopButtonFill", typeof(string), typeof(PlaybackControls),
                new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is PlaybackControls control
                        && control.DataContext is PlaybackControlsViewModel viewModel)
                    {
                        viewModel.StopButtonFill = (string)args.NewValue;
                    }
                }));

        public string StopButtonFill
        {
            get => (string)GetValue(StopButtonFillProperty);
            set => SetValue(StopButtonFillProperty, value);
        }

        public static readonly DependencyProperty PlayButtonFillProperty =
            DependencyProperty.Register("PlayButtonFill", typeof(string), typeof(PlaybackControls),
                new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is PlaybackControls control
                        && control.DataContext is PlaybackControlsViewModel viewModel)
                    {
                        viewModel.PlayButtonFill = (string)args.NewValue;
                    }
                }));

        public string PlayButtonFill
        {
            get => (string)GetValue(PlayButtonFillProperty);
            set => SetValue(PlayButtonFillProperty, value);
        }

        public static readonly DependencyProperty PauseButtonFillProperty =
            DependencyProperty.Register("PauseButtonFill", typeof(string), typeof(PlaybackControls),
                new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is PlaybackControls control
                        && control.DataContext is PlaybackControlsViewModel viewModel)
                    {
                        viewModel.PauseButtonFill = (string)args.NewValue;
                    }
                }));

        public string PauseButtonFill
        {
            get => (string)GetValue(PauseButtonFillProperty);
            set => SetValue(PauseButtonFillProperty, value);
        }

        public static readonly DependencyProperty SkipToEndButtonFillProperty =
            DependencyProperty.Register("SkipToEndButtonFill", typeof(string), typeof(PlaybackControls),
                new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is PlaybackControls control
                        && control.DataContext is PlaybackControlsViewModel viewModel)
                    {
                        viewModel.SkipToEndButtonFill = (string)args.NewValue;
                    }
                }));

        public string SkipToEndButtonFill
        {
            get => (string)GetValue(SkipToEndButtonFillProperty);
            set => SetValue(SkipToEndButtonFillProperty, value);
        }

        public static readonly DependencyProperty SelectButtonFillProperty =
            DependencyProperty.Register("SelectButtonFill", typeof(string), typeof(PlaybackControls),
                new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is PlaybackControls control
                        && control.DataContext is PlaybackControlsViewModel viewModel)
                    {
                        viewModel.SelectButtonFill = (string)args.NewValue;
                    }
                }));

        public string SelectButtonFill
        {
            get => (string)GetValue(SelectButtonFillProperty);
            set => SetValue(SelectButtonFillProperty, value);
        }

        public static readonly DependencyProperty SwitchOnBackgroundProperty =
            DependencyProperty.Register("SwitchOnBackground", typeof(string), typeof(PlaybackControls),
                new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is PlaybackControls control
                        && control.DataContext is PlaybackControlsViewModel viewModel)
                    {
                        viewModel.SwitchOnBackground = (string)args.NewValue;
                    }
                }));

        public string SwitchOnBackground
        {
            get => (string)GetValue(SwitchOnBackgroundProperty);
            set => SetValue(SwitchOnBackgroundProperty, value);
        }

        public static readonly DependencyProperty SwitchOffBackgroundProperty =
            DependencyProperty.Register("SwitchOffBackground", typeof(string), typeof(PlaybackControls),
                new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is PlaybackControls control
                        && control.DataContext is PlaybackControlsViewModel viewModel)
                    {
                        viewModel.SwitchOffBackground = (string)args.NewValue;
                    }
                }));

        public string SwitchOffBackground
        {
            get => (string)GetValue(SwitchOffBackgroundProperty);
            set => SetValue(SwitchOffBackgroundProperty, value);
        }

        public static readonly DependencyProperty SwitchForegroundProperty =
            DependencyProperty.Register("SwitchForeground", typeof(string), typeof(PlaybackControls),
                new PropertyMetadata(null, (DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) =>
                {
                    if (dependencyObj is PlaybackControls control
                        && control.DataContext is PlaybackControlsViewModel viewModel)
                    {
                        viewModel.SwitchForeground = (string)args.NewValue;
                    }
                }));

        public string SwitchForeground
        {
            get => (string)GetValue(SwitchForegroundProperty);
            set => SetValue(SwitchForegroundProperty, value);
        }


        #endregion

        public PlaybackControls()
        {
            InitializeComponent();
        }
    }
}
