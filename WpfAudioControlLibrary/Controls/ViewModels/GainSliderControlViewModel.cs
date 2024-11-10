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

namespace WpfAudioControlLibrary.Controls.ViewModels
{
    public class GainSliderControlViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        #region Properties

        private int _gain;
        public int Gain
        {
            get => _gain;
            set 
            { 
                _gain = value;

                OnPropertyChanged();
            }
        }

        private string _controlLabel;
        public string ControlLabel
        {
            get => _controlLabel;
            set
            {
                _controlLabel = value;

                OnPropertyChanged();
            }
        }

        private int _max;
        public int Max
        {
            get => _max;
            set
            {
                _max = value;

                OnPropertyChanged();
            }
        }

        private int _min;
        public int Min
        {
            get => _min;
            set
            {
                _min = value;

                OnPropertyChanged();
            }
        }

        private Point _position;
        public Point Position
        {
            get => _position;
            set
            {
                _position = value;

                OnPropertyChanged();
            }
        }

        private Point _positionOrigin;
        public Point PositionOrigin
        {
            get => _positionOrigin;
            set
            {
                _positionOrigin = value;

                OnPropertyChanged();
            }
        }

        #endregion

        #region Methods

        public int ChangeGainFromMouseWheel(int delta)
        {
            var gain = _gain;

            if (delta > 0)
            {
                gain = (gain + 1) > Max ? Max : gain + 1;
            }

            if (delta < 0)
            {
                gain = (gain - 1) < Min ? Min : gain - 1;
            }

            return gain;
        }

        #endregion

        #region Events and callbacks

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion
    }
}
