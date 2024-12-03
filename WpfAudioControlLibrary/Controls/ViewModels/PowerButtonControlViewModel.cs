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
using System.Windows.Input;

namespace WpfAudioControlLibrary.Controls.ViewModels
{
    public class PowerButtonControlViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _powerButtonLightFill;
        public string PowerButtonLightFill
        {
            get => _powerButtonLightFill;
            set
            {
                _powerButtonLightFill = value;

                OnPropertyChanged();
            }
        }

        private string _powerButtonStrokeFill;
        public string PowerButtonStrokeFill
        {
            get => _powerButtonStrokeFill;
            set
            {
                _powerButtonStrokeFill = value;

                OnPropertyChanged();
            }
        }

        private string _powerButtonHighlight;
        public string PowerButtonHighlight
        {
            get => _powerButtonHighlight;
            set
            {
                _powerButtonHighlight = value;

                OnPropertyChanged();
            }
        }


        #region Commands

        private ICommand _exitCommand;
        public ICommand ExitCommand
        {
            get => _exitCommand;
            set
            {
                _exitCommand = value;

                OnPropertyChanged();
            }
        }

        #endregion

        public PowerButtonControlViewModel()
        {
            PowerButtonLightFill = "Red";
            PowerButtonStrokeFill = "Black";
            PowerButtonHighlight = "LimeGreen";
        }

        #region Event Handers

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion
    }
}
