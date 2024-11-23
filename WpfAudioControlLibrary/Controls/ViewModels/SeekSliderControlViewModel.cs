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
    public class SeekSliderControlViewModel : INotifyPropertyChanged
    {
        #region Fields

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Properties

        private double _tickFrequency;
        public double TickFrequency
        {
            get => _tickFrequency;
            set 
            { 
                _tickFrequency = value;

                OnPropertyChanged();
            }
        }

        private double _minimum;
        public double Minimum
        {
            get => _minimum;
            set
            {
                _minimum = value;

                OnPropertyChanged();
            }
        }

        private double _maximum;
        public double Maximum
        {
            get => _maximum;
            set
            {
                _maximum = value;

                OnPropertyChanged();
            }
        }

        private double _value;
        public double Value
        {
            get => _value;
            set
            {
                _value = value;

                OnPropertyChanged();
            }
        }

        private int _elapsedHours;
        public int ElapsedHours
        {
            get => _elapsedHours;
            set
            {
                _elapsedHours = value;

                OnPropertyChanged();
            }
        }

        private int _elapsedMinutes;
        public int ElapsedMinutes
        {
            get => _elapsedMinutes;
            set
            {
                _elapsedMinutes = value;

                OnPropertyChanged();
            }
        }

        private int _elapsedSeconds;
        public int ElapsedSeconds
        {
            get => _elapsedSeconds;
            set
            {
                _elapsedSeconds = value;

                OnPropertyChanged();
            }
        }

        private int _durationMinutes;
        public int DurationMinutes
        {
            get => _durationMinutes;
            set
            {
                _durationMinutes = value;

                OnPropertyChanged();
            }
        }

        private int _durationSeconds;
        public int DurationSeconds
        {
            get => _durationSeconds;
            set
            {
                _durationSeconds = value;

                OnPropertyChanged();
            }
        }

        private int _durationHours;
        public int DurationHours
        {
            get => _durationHours;
            set
            {
                _durationHours = value;

                OnPropertyChanged();
            }
        }

        private string _sliderThumbGlowOverlay;
        public string SliderThumbGlowOverlay
        {
            get => _sliderThumbGlowOverlay;
            set
            {
                _sliderThumbGlowOverlay = value;

                OnPropertyChanged();
            }
        }

        private string _sliderThumbGripBarBackground;
        public string SliderThumbGripBarBackground
        {
            get => _sliderThumbGripBarBackground;
            set
            {
                _sliderThumbGripBarBackground = value;

                OnPropertyChanged();
            }
        }

        private string _sliderThumbPointBackground;
        public string SliderThumbPointBackground
        {
            get => _sliderThumbPointBackground;
            set
            {
                _sliderThumbPointBackground = value;

                OnPropertyChanged();
            }
        }

        private string _sliderThumbBorder;
        public string SliderThumbBorder
        {
            get => _sliderThumbBorder;
            set
            {
                _sliderThumbBorder = value;

                OnPropertyChanged();
            }
        }

        private string _sliderThumbForeground;
        public string SliderThumbForeground
        {
            get => _sliderThumbForeground;
            set
            {
                _sliderThumbForeground = value;

                OnPropertyChanged();
            }
        }

        private string _sliderThumbMouseOverBackground;
        public string SliderThumbMouseOverBackground
        {
            get => _sliderThumbMouseOverBackground;
            set
            {
                _sliderThumbMouseOverBackground = value;

                OnPropertyChanged();
            }
        }

        private string _sliderThumbMouseOverBorder;
        public string SliderThumbMouseOverBorder
        {
            get => _sliderThumbMouseOverBorder;
            set
            {
                _sliderThumbMouseOverBorder = value;

                OnPropertyChanged();
            }
        }

        private string _sliderThumbPressedBackground;
        public string SliderThumbPressedBackground
        {
            get => _sliderThumbPressedBackground;
            set
            {
                _sliderThumbPressedBackground = value;

                OnPropertyChanged();
            }
        }

        private string _sliderThumbPressedBorder;
        public string SliderThumbPressedBorder
        {
            get => _sliderThumbPressedBorder;
            set
            {
                _sliderThumbPressedBorder = value;

                OnPropertyChanged();
            }
        }

        private string _sliderThumbDisabledBackground;
        public string SliderThumbDisabledBackground
        {
            get => _sliderThumbDisabledBackground;
            set
            {
                _sliderThumbDisabledBackground = value;

                OnPropertyChanged();
            }
        }

        private string _sliderThumbDisabledBorder;
        public string SliderThumbDisabledBorder
        {
            get => _sliderThumbDisabledBorder;
            set
            {
                _sliderThumbDisabledBorder = value;

                OnPropertyChanged();
            }
        }

        private string _sliderThumbTrackBackground;
        public string SliderThumbTrackBackground
        {
            get => _sliderThumbTrackBackground;
            set
            {
                _sliderThumbTrackBackground = value;

                OnPropertyChanged();
            }
        }

        private string _sliderThumbTrackBorder;
        public string SliderThumbTrackBorder
        {
            get => _sliderThumbTrackBorder;
            set
            {
                _sliderThumbTrackBorder = value;

                OnPropertyChanged();
            }
        }


        #endregion

        public SeekSliderControlViewModel()
        {
            SliderThumbGlowOverlay = "OrangeRed";
            SliderThumbGripBarBackground = "#250a01";
            SliderThumbPointBackground = "White";
            SliderThumbBorder = "#FFACACAC";
            SliderThumbForeground = "DodgerBlue";
            SliderThumbMouseOverBackground = "#FFDCECFC";
            SliderThumbMouseOverBorder = "#FF7Eb4EA";
            SliderThumbPressedBackground = "#FFDAECFC";
            SliderThumbPressedBorder = "#FF569DE5";
            SliderThumbDisabledBackground = "#FFF0F0F0";
            SliderThumbDisabledBorder = "#FFD9D9D9";
            SliderThumbTrackBackground = "Cyan";
            SliderThumbTrackBorder = "Blue";
        }

        #region Event Handers

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion
    }
}
