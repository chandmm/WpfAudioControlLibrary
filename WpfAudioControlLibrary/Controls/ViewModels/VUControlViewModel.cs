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
    public class VUControlViewModel : INotifyPropertyChanged
    {
        #region Fields

        private static int WindowSizeBounds = 400;
        private static int NeedleLength = 280;
        private static double HalfWayPointTheta = 50d;

        private readonly int _internalFsd = 100;
        private readonly int _internalMinimum = 0;
        private readonly int _internalMaximum = 100;

        private double _ratioMapToInternalRange = 1;

        public event PropertyChangedEventHandler? PropertyChanged;
        public double FsdRange { get; set; }

        #endregion

        #region Member Properties

        private double _gridWidth;
        public double GridWidth
        {
            get => _gridWidth;
            set
            {
                _gridWidth = value;

                OnPropertyChanged();
            }
        }

        private double _gridHeight;
        public double GridHeight
        {
            get => _gridHeight;
            set
            {
                _gridHeight = value;

                OnPropertyChanged();
            }
        }

        private int _x;
        public int X
        {
            get => _x;
            set
            {
                _x = value;

                OnPropertyChanged();
            }
        }

        private int _y;

        public int Y
        {
            get => _y;
            set
            {
                _y = value;

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

                UpdateNeedlePosition();
                UpdateOverDriveLight();
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

        private string _mark1;
        public string Mark1
        {
            get => _mark1;
            set
            {
                _mark1 = value;

                OnPropertyChanged();
            }
        }

        private string _mark2;
        public string Mark2
        {
            get => _mark2;
            set
            {
                _mark2 = value;

                OnPropertyChanged();
            }
        }

        private string _mark3;
        public string Mark3
        {
            get => _mark3;
            set
            {
                _mark3 = value;

                OnPropertyChanged();
            }
        }

        private string _mark4;
        public string Mark4
        {
            get => _mark4;
            set
            {
                _mark4 = value;

                OnPropertyChanged();
            }
        }

        private string _mark5;
        public string Mark5
        {
            get => _mark5;
            set
            {
                _mark5 = value;

                OnPropertyChanged();
            }
        }

        private string _mark6;
        public string Mark6
        {
            get => _mark6;
            set
            {
                _mark6 = value;

                OnPropertyChanged();
            }
        }

        private string _meterLabel;
        public string MeterLabel
        {
            get => _meterLabel;
            set
            {
                _meterLabel = value;

                OnPropertyChanged();
            }
        }

        private string _backplateText;
        public string BackplateText
        {
            get => _backplateText;
            set
            {
                _backplateText = value;

                OnPropertyChanged();
            }
        }

        private bool _isOverDrive;
        public bool IsOverDrive
        {
            get => _isOverDrive;
            set
            {
                _isOverDrive = value;

                OnPropertyChanged();
            }
        }

        private bool _isUseCustomOverDriveSetting;
        public bool IsUseCustomOverDriveSetting
        {
            get => _isUseCustomOverDriveSetting;
            set
            {
                _isUseCustomOverDriveSetting = value;

                OnPropertyChanged();
            }
        }

        private double? _needleThickness;
        public double? NeedleThickness
        {
            get => _needleThickness;
            set
            {
                _needleThickness = value;

                OnPropertyChanged();
            }
        }

        public int InternalFsd => _internalFsd;

        #endregion

        #region Style Properties

        public string _backgroundColour;
        public string BackgroundColour
        {
            get => _backgroundColour;
            set
            {
                _backgroundColour = value;

                OnPropertyChanged();
            }
        }

        private string _needleColour;
        public string NeedleColour
        {
            get => _needleColour;
            set
            {
                _needleColour = value;

                OnPropertyChanged();
            }
        }

        private string _decalColour;
        public string DecalColour
        {
            get => _decalColour;
            set
            {
                _decalColour = value;

                OnPropertyChanged();
            }
        }

        private string _overdriveLampColour;
        public string OverdriveLampColour
        {
            get => _overdriveLampColour;
            set
            {
                _overdriveLampColour = value;

                OnPropertyChanged();
            }
        }

        private string _overdriveLampOffColour;
        public string OverdriveLampOffColour
        {
            get => _overdriveLampOffColour;
            set
            {
                _overdriveLampOffColour = value;

                OnPropertyChanged();
            }
        }

        private string _meterLabelForeground;
        public string MeterLabelForeground
        {
            get => _meterLabelForeground;
            set
            {
                _meterLabelForeground = value;

                OnPropertyChanged();
            }
        }

        private string _bottomCoverFill;
        public string BottomCoverFill
        {
            get => _bottomCoverFill;
            set
            {
                _bottomCoverFill = value;

                OnPropertyChanged();
            }
        }

        #endregion

        public VUControlViewModel(double defaultMmin, double defaultMax)
        {
            FsdRange = defaultMmin - defaultMax;
            SetRatioMapToInternalRange();
            Value = defaultMmin;
            IsOverDrive = false;
            NeedleThickness = 4;

            // Sanity colours so something shows by default.
            BackgroundColour = "DodgerBlue";
            NeedleColour = "Black";
            DecalColour = "Black";
        }

        #region Logic

        private void UpdateOverDriveLight()
        {
            if (IsUseCustomOverDriveSetting)
            {
                return;
            }

            var threshHold = (int)(Maximum * 0.85);

            IsOverDrive = Value >= threshHold;
        }

        public void UpdateNeedlePosition()
        {
            var radianAngle = DegreesToRadians(CalculateNeedleAngle());

            var sineCos = Math.SinCos(radianAngle);

            X = (int)((WindowSizeBounds / 2) + (sineCos.Cos * NeedleLength));
            Y = (int)(WindowSizeBounds - (sineCos.Sin * NeedleLength));
        }

        private double CalculateNeedleAngle()
        {
            (double minAngle, double maxAngle) = GetMinMaxAngle();

            // Normalize the value to a range between 0 and 1
            double normalizedValue = (Value - Minimum) / FsdRange;

            // Calculate the angle based on the normalized value
            return minAngle + normalizedValue * (maxAngle - minAngle);
        }


        private (double, double) GetMinMaxAngle()
            => (90 + (90 - HalfWayPointTheta), HalfWayPointTheta);

        private double DegreesToRadians(double degrees)
            => degrees * (Math.PI / 180);

        public void SetRatioMapToInternalRange()
        {
            _ratioMapToInternalRange = _internalFsd / FsdRange;
        }

        #endregion

        #region Event Handlers

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion
    }
}
