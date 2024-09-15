using System.Windows;

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
                    var viewModel = element.DataContext as VUControl;
                    if (viewModel != null)
                    {
                        viewModel.GridHeight = element.ActualHeight;
                        viewModel.GridWidth = element.ActualWidth;
                    }
                };
            }
        }
    }
}
