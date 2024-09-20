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

namespace WpfAudioControlLibrary.Controls
{
    public partial class StereoIndicatorControl : UserControl
    {
        public static readonly DependencyProperty IsMonoProperty =
            DependencyProperty.Register("IsMono", typeof(bool), typeof(StereoIndicatorControl),
                new PropertyMetadata(false, null));
        public bool IsMono
        {
            get { return (bool)GetValue(IsMonoProperty); }
            set { SetValue(IsMonoProperty, value); }
        }

        public StereoIndicatorControl()
        {
            InitializeComponent();
        }
    }
}
