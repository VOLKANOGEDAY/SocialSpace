using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.Web.WebView2.Core;
using System;

namespace SocialSpace
{
    public sealed partial class TwitterPage : Page
    {

        //initialize
        public TwitterPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
            Loaded += WebViewLoaded;
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

        //permissions
        private async void WebViewLoaded(object sender, RoutedEventArgs e)
        {
            await WebView.EnsureCoreWebView2Async();
            WebView.CoreWebView2.PermissionRequested += HandlePermissionRequest;
        }

        private void HandlePermissionRequest(object sender, CoreWebView2PermissionRequestedEventArgs e)
        {

            if (e.PermissionKind == CoreWebView2PermissionKind.Camera)
            {
                e.State = CoreWebView2PermissionState.Allow;
            }

            if (e.PermissionKind == CoreWebView2PermissionKind.Microphone)
            {
                e.State = CoreWebView2PermissionState.Allow;
            }

            if (e.PermissionKind == CoreWebView2PermissionKind.Geolocation)
            {
                e.State = CoreWebView2PermissionState.Allow;
            }

            if (e.PermissionKind == CoreWebView2PermissionKind.Notifications)
            {
                e.State = CoreWebView2PermissionState.Allow;
            }

        }

    }
}