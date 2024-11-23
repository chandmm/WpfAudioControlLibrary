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
    public class StereoIndicatorControlViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _monoOnFill;
        public string MonoOnFill
        {
            get => _monoOnFill;
            set
            {
                _monoOnFill = value;

                OnPropertyChanged();
            }
        }

        private string _monoOffFill;
        public string MonoOffFill
        {
            get => _monoOffFill;
            set
            {
                _monoOffFill = value;

                OnPropertyChanged();
            }
        }

        private string _stereoOnFill;
        public string StereoOnFill
        {
            get => _stereoOnFill;
            set
            {
                _stereoOnFill = value;

                OnPropertyChanged();
            }
        }

        private string _stereoOffFill;
        public string StereoOffFill
        {
            get => _stereoOffFill;
            set
            {
                _stereoOffFill = value;

                OnPropertyChanged();
            }
        }

        private string _labelForeground;
        public string LabelForeground
        {
            get => _labelForeground;
            set
            {
                _labelForeground = value;

                OnPropertyChanged();
            }
        }


        public StereoIndicatorControlViewModel()
        {
            MonoOnFill = "#62e3f6";
            MonoOffFill = "#000040";
            StereoOnFill = "Red";
            StereoOffFill = "#200000";
            LabelForeground = "Black";
        }

        #region Event Handers

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion
    }
}
