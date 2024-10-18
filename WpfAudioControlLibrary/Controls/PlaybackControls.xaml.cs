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

        public PlaybackControls()
        {
            InitializeComponent();
        }
    }
}
