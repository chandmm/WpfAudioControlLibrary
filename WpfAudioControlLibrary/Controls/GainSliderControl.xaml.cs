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
using System.Windows;
using System.Windows.Controls;
using WpfAudioControlLibrary.Controls.ViewModels;

namespace WpfAudioControlLibrary.Controls
{
    public partial class GainSliderControl : UserControl
    {
        public GainSliderControlViewModel ViewModel { get; private set; }

        public static readonly DependencyProperty GainProperty =
            DependencyProperty.Register("Gain", typeof(int), typeof(GainSliderControl),
                new PropertyMetadata(0, OnValueChanged));
        public int Gain
        {
            get { return (int)GetValue(GainProperty); }
            set { SetValue(GainProperty, value); }
        }

        public static readonly DependencyProperty ControlLabelProperty =
            DependencyProperty.Register("ControlLabel", typeof(string), typeof(GainSliderControl),
                new PropertyMetadata("ControlLabel", OnValueChanged));

        public string ControlLabel
        {
            get { return (string)GetValue(ControlLabelProperty); }
            set { SetValue(ControlLabelProperty, value); }
        }

        public static readonly DependencyProperty MaxProperty =
            DependencyProperty.Register("Max", typeof(int?), typeof(GainSliderControl),
                new PropertyMetadata(null, OnValueChanged));

        public int? Max
        {
            get { return (int?)GetValue(MaxProperty); }
            set { SetValue(MaxProperty, value); }
        }

        public static readonly DependencyProperty MinProperty =
            DependencyProperty.Register("Min", typeof(int?), typeof(GainSliderControl),
                new PropertyMetadata(null, OnValueChanged));

        public int? Min
        {
            get { return (int?)GetValue(MinProperty); }
            set { SetValue(MinProperty, value); }
        }

        public GainSliderControl()
        {
            InitializeComponent();

            ViewModel = new GainSliderControlViewModel();

            DataContext = this;
        }

        private void Slider_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs args)
        {
            if (sender is Slider sliderControl
                && sliderControl.DataContext is GainSliderControl control
                && control.ViewModel != null)
            {
                var val = control.ViewModel.ChangeGainFromMouseWheel(args.Delta);
                control.Gain = val;
            }

            args.Handled = true;
        }

        private static void OnValueChanged(DependencyObject dependency, DependencyPropertyChangedEventArgs args)
        {
            var control = (GainSliderControl)dependency;
            if (control.ViewModel != null)
            {
                var property = control.ViewModel
                    .GetType()
                    .GetProperties()
                    .FirstOrDefault(x => x.Name == args.Property.Name);

                if (property != null)
                {
                    property.SetValue(control.ViewModel, args.NewValue);
                }
            }
        }
    }
}
