using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfAudioControlLibrary.Controls
{
    public partial class PowerButtonControl : UserControl
    {
        public static readonly DependencyProperty ExitCommandProperty =
            DependencyProperty.Register("ExitCommand", typeof(ICommand), typeof(PowerButtonControl),
                new PropertyMetadata(null, null));
        public ICommand ExitCommand
        {
            get { return (ICommand)GetValue(ExitCommandProperty); }
            set { SetValue(ExitCommandProperty, value); }
        }

        public PowerButtonControl()
        {
            InitializeComponent();
        }
    }
}
