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
    public class PlaybackIndicatorControlViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private bool _isOn;
        public bool IsOn
        {
            get => _isOn;
            set
            {
                _isOn = value;

                OnPropertyChanged();
            }
        }

        public string _onColour;
        public string OnColour
        {
            get => _onColour;
            set
            {
                _onColour = value;

                OnPropertyChanged();
            }
        }

        public string _offColour;
        public string OffColour
        {
            get => _offColour;
            set
            {
                _offColour = value;

                OnPropertyChanged();
            }
        }

        public PlaybackIndicatorControlViewModel()
        {
            OffColour = "#00004A";
            OnColour = "#0020FF";
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
