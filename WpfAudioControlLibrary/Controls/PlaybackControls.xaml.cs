using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfAudioControlLibrary.Controls
{
    public partial class PlaybackControls : UserControl
    {
        public static readonly DependencyProperty SkipToStartCommandProperty =
            DependencyProperty.Register("SkipToStartCommand", typeof(ICommand), typeof(PlaybackControls),
                new PropertyMetadata(null, null));
        public ICommand SkipToStartCommand
        {
            get { return (ICommand)GetValue(SkipToStartCommandProperty); }
            set { SetValue(SkipToStartCommandProperty, value); }
        }

        public static readonly DependencyProperty StopCommandProperty =
            DependencyProperty.Register("StopCommand", typeof(ICommand), typeof(PlaybackControls),
                new PropertyMetadata(null, null));
        public ICommand StopCommand
        {
            get { return (ICommand)GetValue(StopCommandProperty); }
            set { SetValue(StopCommandProperty, value); }
        }

        public static readonly DependencyProperty PlayCommandProperty =
            DependencyProperty.Register("PlayCommand", typeof(ICommand), typeof(PlaybackControls),
                new PropertyMetadata(null, null));
        public ICommand PlayCommand
        {
            get { return (ICommand)GetValue(PlayCommandProperty); }
            set { SetValue(PlayCommandProperty, value); }
        }

        public static readonly DependencyProperty PauseCommandProperty =
            DependencyProperty.Register("PauseCommand", typeof(ICommand), typeof(PlaybackControls),
                new PropertyMetadata(null, null));
        public ICommand PauseCommand
        {
            get { return (ICommand)GetValue(PauseCommandProperty); }
            set { SetValue(PauseCommandProperty, value); }
        }

        public static readonly DependencyProperty EjectCommandProperty =
            DependencyProperty.Register("EjectCommand", typeof(ICommand), typeof(PlaybackControls),
                new PropertyMetadata(null, null));
        public ICommand EjectCommand
        {
            get { return (ICommand)GetValue(EjectCommandProperty); }
            set { SetValue(EjectCommandProperty, value); }
        }

        public static readonly DependencyProperty IsAutoPlayCheckedProperty =
            DependencyProperty.Register("IsAutoPlayChecked", typeof(bool), typeof(PlaybackControls),
                new PropertyMetadata(false, null));
        public bool IsAutoPlayChecked
        {
            get { return (bool)GetValue(IsAutoPlayCheckedProperty); }
            set { SetValue(IsAutoPlayCheckedProperty, value); }
        }

        public static readonly DependencyProperty IsLoopPlayCheckedProperty =
            DependencyProperty.Register("IsLoopPlayChecked", typeof(bool), typeof(PlaybackControls),
                new PropertyMetadata(false, null));
        public bool IsLoopPlayChecked
        {
            get { return (bool)GetValue(IsLoopPlayCheckedProperty); }
            set { SetValue(IsLoopPlayCheckedProperty, value); }
        }

        public PlaybackControls()
        {
            InitializeComponent();
        }
    }
}
