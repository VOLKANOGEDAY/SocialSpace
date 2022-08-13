using Microsoft.UI.Xaml;
using WinUIEx;

namespace SocialSpace
{
    public partial class App : Application
    {

        //initialize with dark theme
        public App()
        {
            this.InitializeComponent();
            RequestedTheme = ApplicationTheme.Dark;
        }

        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            m_window.Activate();
            m_window.Maximize();
        }

        private Window m_window;

    }
}
