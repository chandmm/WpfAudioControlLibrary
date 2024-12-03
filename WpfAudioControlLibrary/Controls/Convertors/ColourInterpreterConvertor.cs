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
using System.Globalization;
using System.Reflection;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfAudioControlLibrary.Controls.Convertors
{
    public class ColourInterpreterConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var colourValue = value as string;

            if (string.IsNullOrEmpty(colourValue))
            {
                return value;
            }

            var colorProperty = typeof(Colors)
                .GetProperty(colourValue, 
                BindingFlags.IgnoreCase 
                | BindingFlags.Static 
                | BindingFlags.Public);

            if (colorProperty != null)
            {
                return new SolidColorBrush((Color)colorProperty.GetValue(null));
            }

            try
            {
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString(colourValue));
            }
            catch
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
