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
    public partial class VolumeControlSliderAndKnobView : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        // Default for Value is 0 to represent null/default startup state.
        public static readonly DependencyProperty VolumeProperty =
            DependencyProperty.Register("Volume", typeof(int), typeof(VolumeControlSliderAndKnobView),
                new PropertyMetadata(0, OnValueChanged)); 
        public int Volume
        {
            get { return (int)GetValue(VolumeProperty); }
            set { SetValue(VolumeProperty, value); }
        }

        public static readonly DependencyProperty ControlLabelProperty =
            DependencyProperty.Register("ControlLabel", typeof(string), typeof(VolumeControlSliderAndKnobView),
                new PropertyMetadata("Volume", null)); 

        public string ControlLabel
        {
            get { return (string)GetValue(ControlLabelProperty); }
            set { SetValue(ControlLabelProperty, value); }
        }

        public static readonly DependencyProperty MaxProperty =
            DependencyProperty.Register("Max", typeof(int), typeof(VolumeControlSliderAndKnobView),
                new PropertyMetadata(100, OnValueChanged)); 

        public int Max
        {
            get { return (int)GetValue(MaxProperty); }
            set { SetValue(MaxProperty, value); }
        }

        public static readonly DependencyProperty MinProperty =
            DependencyProperty.Register("Min", typeof(int), typeof(VolumeControlSliderAndKnobView),
                new PropertyMetadata(0, OnValueChanged)); 

        public int Min
        {
            get { return (int)GetValue(MinProperty); }
            set { SetValue(MinProperty, value); }
        }

        public static readonly DependencyProperty IsShowVolumeKnobProperty =
            DependencyProperty.Register("IsShowVolumeKnob", typeof(bool), typeof(VolumeControlSliderAndKnobView),
                new PropertyMetadata(false, OnValueChanged));

        public bool IsShowVolumeKnob
        {
            get { return (bool)GetValue(IsShowVolumeKnobProperty); }
            set { SetValue(IsShowVolumeKnobProperty, value); }
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

        public VolumeControlSliderAndKnobView()
        {
            DataContext = this;
            
            InitializeComponent();

            PositionOrigin = new Point(50, 50);

            UpdateLinePosition();
        }

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (VolumeControlSliderAndKnobView)d;
            control.UpdateLinePosition();
        }

        private void UpdateLinePosition()
        {
            double radiusLine = 45;
            var value = Volume < Min ? Min : Volume;

            var splice = value * (270d/Max);
            var angle = ((270 - splice) - 45);
            var radAngle = (angle < 0 ? 360 + angle : angle) * Math.PI / 180;

            Position = new Point((int)(PositionOrigin.X + radiusLine * Math.Cos(radAngle)), (int)(PositionOrigin.Y - radiusLine * Math.Sin(radAngle)));
        }

        #region Events

        private void Slider_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs args)
        {
            int delta = args.Delta;

            if (delta > 0)
            {
                Volume = (Volume + 1) > Max ? Max : Volume + 1;
            }
            
            if (delta < 0)
            {
                Volume = (Volume - 1) < Min ? Min : Volume - 1;
            }

            args.Handled = true;
        }

        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion
    }
}
