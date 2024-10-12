using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfAudioControlLibrary.Controls.ViewModels
{
    public class VUControlViewModel : INotifyPropertyChanged
    {
        #region Fields

        public double FsdRange { get; set; }
        private static int WindowSizeBounds = 400;
        private static int NeedleLength = 280;
        private static double HalfTheta = 50d;

        private readonly int _internalFsd = 100;
        private readonly int _internalMinimum = 0;
        private readonly int _internalMaximum = 100;

        private double _ratioMapToInternalRange = 1;

        public event PropertyChangedEventHandler? PropertyChanged;

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

        private byte[] _data;
        public byte[] Data
        {
            get => _data;
            set 
            { 
                _data = value;

                OnPropertyChanged();
            }
        }

        public int InternalFsd => _internalFsd;

        #endregion

        public VUControlViewModel()
        {
            Minimum = 0;
            Maximum = 100;
            Value = Minimum;
        }

        #region Logic

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
            => (90 + (90 - HalfTheta), HalfTheta);

        private double DegreesToRadians(double degrees)
            => degrees * (Math.PI / 180);

        public void SetRatioMapToInternalRange()
        {
            _ratioMapToInternalRange = _internalFsd / FsdRange;
        }

        public void UpdateNeedlePositionUsingPcmData()
        {
            if (Data != null
                && Data.Any())
            {
                // TODO: Add Db calculation logic from PCM samples.
                // Data is an array of bytes of PCM samples.
            }
        }

        #endregion

        #region Event Handlers

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion
    }
}
