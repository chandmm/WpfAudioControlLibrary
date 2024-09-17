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
using System.Windows.Controls;

namespace WpfAudioControlLibrary.Controls
{
    public partial class VolumeControlView : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        // Default for Value is 0 to represent null/default startup state.
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(VolumeControlView),
                new PropertyMetadata(0, OnValueChanged)); 
        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ControlLabelProperty =
            DependencyProperty.Register("ControlLabel", typeof(string), typeof(VolumeControlView),
                new PropertyMetadata("Volume", null)); 

        public string ControlLabel
        {
            get { return (string)GetValue(ControlLabelProperty); }
            set { SetValue(ControlLabelProperty, value); }
        }

        public static readonly DependencyProperty MaxProperty =
            DependencyProperty.Register("Max", typeof(int), typeof(VolumeControlView),
                new PropertyMetadata(100, OnValueChanged)); 

        public int Max
        {
            get { return (int)GetValue(MaxProperty); }
            set { SetValue(MaxProperty, value); }
        }

        public static readonly DependencyProperty MinProperty =
            DependencyProperty.Register("Min", typeof(int), typeof(VolumeControlView),
                new PropertyMetadata(0, OnValueChanged)); 

        public int Min
        {
            get { return (int)GetValue(MinProperty); }
            set { SetValue(MinProperty, value); }
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

        public VolumeControlView()
        {
            DataContext = this;
            
            InitializeComponent();

            PositionOrigin = new Point(50, 50);

            UpdateLinePosition();
        }

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (VolumeControlView)d;
            control.UpdateLinePosition();
        }

        private void UpdateLinePosition()
        {
            double radiusLine = 45;
            var value = Value < Min ? Min : Value;

            var splice = value * (270d/Max);
            var angle = ((270 - splice) - 45);
            var radAngle = (angle < 0 ? 360 + angle : angle) * Math.PI / 180;

            Position = new Point((int)(PositionOrigin.X + radiusLine * Math.Cos(radAngle)), (int)(PositionOrigin.Y - radiusLine * Math.Sin(radAngle)));
        }

        #region Events

        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion
    }
}
