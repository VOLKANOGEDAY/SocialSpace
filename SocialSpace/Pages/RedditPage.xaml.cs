using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace SocialSpace
{
    public sealed partial class RedditPage : Page
    {

        //initialize
        public RedditPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        //back button
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (WebView.CanGoBack)
            {
                WebView.GoBack();
            }
        }

        //forward button
        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            if (WebView.CanGoForward)
            {
                WebView.GoForward();
            }
        }

        //refresh button
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            WebView.Reload();
        }

    }
}