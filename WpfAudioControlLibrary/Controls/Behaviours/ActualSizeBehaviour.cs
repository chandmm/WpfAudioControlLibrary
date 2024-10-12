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
using WpfAudioControlLibrary.Controls.ViewModels;

namespace WpfAudioControlLibrary.Controls.Behaviours
{
    public static class ActualSizeBehaviour
    {
        public static readonly DependencyProperty MonitorActualSizeProperty =
            DependencyProperty.RegisterAttached(
                "MonitorActualSize",
                typeof(bool),
                typeof(ActualSizeBehaviour),
                new PropertyMetadata(false, OnMonitorActualSizeChanged));

        public static bool GetMonitorActualSize(DependencyObject obj)
        {
            return (bool)obj.GetValue(MonitorActualSizeProperty);
        }

        public static void SetMonitorActualSize(DependencyObject obj, bool value)
        {
            obj.SetValue(MonitorActualSizeProperty, value);
        }

        private static void OnMonitorActualSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element && (bool)e.NewValue)
            {
                element.SizeChanged += (s, ev) =>
                {
                    var view = element.DataContext as VUControl;
                    if (view != null
                        && view.DataContext is VUControlViewModel viewModel)
                    {
                        viewModel.GridHeight = element.ActualHeight;
                        viewModel.GridWidth = element.ActualWidth;
                    }
                };
            }
        }
    }
}
