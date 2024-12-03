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

namespace WpfAudioControlLibrary.Controls.ViewModels
{
    public class PlaybackControlsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _skipToStartButtonFill;
        public string SkipToStartButtonFill
        {
            get => _skipToStartButtonFill;
            set
            {
                _skipToStartButtonFill = value;

                OnPropertyChanged();
            }
        }

        private string _stopButtonFill;
        public string StopButtonFill
        {
            get => _stopButtonFill;
            set
            {
                _stopButtonFill = value;

                OnPropertyChanged();
            }
        }

        private string _playButtonFill;
        public string PlayButtonFill
        {
            get => _playButtonFill;
            set
            {
                _playButtonFill = value;

                OnPropertyChanged();
            }
        }

        private string _pauseButtonFill;
        public string PauseButtonFill
        {
            get => _pauseButtonFill;
            set
            {
                _pauseButtonFill = value;

                OnPropertyChanged();
            }
        }

        private string _skipToEndButtonFill;
        public string SkipToEndButtonFill
        {
            get => _skipToEndButtonFill;
            set
            {
                _skipToEndButtonFill = value;

                OnPropertyChanged();
            }
        }

        private string _selectButtonFill;
        public string SelectButtonFill
        {
            get => _selectButtonFill;
            set
            {
                _selectButtonFill = value;

                OnPropertyChanged();
            }
        }

        private string _switchOnBackground;
        public string SwitchOnBackground
        {
            get => _switchOnBackground;
            set
            {
                _switchOnBackground = value;

                OnPropertyChanged();
            }
        }

        private string _switchOffBackground;
        public string SwitchOffBackground
        {
            get => _switchOffBackground;
            set
            {
                _switchOffBackground = value;

                OnPropertyChanged();
            }
        }

        private string _switchForeground;
        public string SwitchForeground
        {
            get => _switchForeground;
            set
            {
                _switchForeground = value;

                OnPropertyChanged();
            }
        }

        public PlaybackControlsViewModel()
        {
            SkipToStartButtonFill = "Black";
            StopButtonFill = "Black";
            PlayButtonFill = "Black";
            PauseButtonFill = "Black";
            SkipToEndButtonFill = "Black";
            SelectButtonFill = "Black";
            SwitchOnBackground = "#62e3f6";
            SwitchOffBackground = "#000040";
            SwitchForeground = "White";
        }

        #region Event Handers

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion
    }
}
