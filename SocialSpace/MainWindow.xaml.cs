using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialSpace
{
    public sealed partial class MainWindow : WinUIEx.WindowEx
    {

        //initialize
        public MainWindow()
        {
            this.InitializeComponent();
            ExtendsContentIntoTitleBar = true;
            SetTitleBar(AppTitleBar);
        }

        //navigation items
        private readonly List<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
        {
            ("DiscordPage", typeof(DiscordPage)),
            ("FacebookPage", typeof(FacebookPage)),
            ("GithubPage", typeof(GithubPage)),
            ("GmailPage", typeof(GmailPage)),
            ("InstagramPage", typeof(InstagramPage)),
            ("PinterestPage", typeof(PinterestPage)),
            ("RedditPage", typeof(RedditPage)),
            ("SpotifyPage", typeof(SpotifyPage)),
            ("TelegramPage", typeof(TelegramPage)),
            ("TiktokPage", typeof(TiktokPage)),
            ("TwitchPage", typeof(TwitchPage)),
            ("TwitterPage", typeof(TwitterPage)),
            ("WhatsappPage", typeof(WhatsappPage)),
            ("YoutubePage", typeof(YoutubePage)),
        };

        //navigation
        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigated += On_Navigated;
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {

            if (args.IsSettingsInvoked == true)
            {
                NavView_Navigate("settings", args.RecommendedNavigationTransitionInfo);
            }

            else if (args.InvokedItemContainer != null)
            {
                var navItemTag = args.InvokedItemContainer.Tag.ToString();
                NavView_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
            }

        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {

            if (args.IsSettingsSelected == true)
            {
                NavView_Navigate("settings", args.RecommendedNavigationTransitionInfo);
            }

            else if (args.SelectedItemContainer != null)
            {
                var navItemTag = args.SelectedItemContainer.Tag.ToString();
                NavView_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
            }

        }

        private void NavView_Navigate(string navItemTag, Microsoft.UI.Xaml.Media.Animation.NavigationTransitionInfo transitionInfo)
        {

            Type _page = null;

            if (navItemTag == "settings")
            {
                _page = typeof(SettingsPage);
            }

            else
            {
                var item = _pages.FirstOrDefault(p => p.Tag.Equals(navItemTag));
                _page = item.Page;
            }

            var preNavPageType = ContentFrame.CurrentSourcePageType;

            if (!(_page is null) && !Type.Equals(preNavPageType, _page))
            {
                ContentFrame.Navigate(_page, null, transitionInfo);
            }

        }

        private void On_Navigated(object sender, NavigationEventArgs e)
        {

            if (ContentFrame.SourcePageType == typeof(SettingsPage))
            {
                NavView.SelectedItem = (NavigationViewItem)NavView.SettingsItem;
                NavView.Header = "Settings";
            }

            else if (ContentFrame.SourcePageType != null)
            {
                var item = _pages.FirstOrDefault(p => p.Page == e.SourcePageType);
                NavView.SelectedItem = NavView.MenuItems.OfType<NavigationViewItem>().First(n => n.Tag.Equals(item.Tag));
                NavView.Header = ((NavigationViewItem)NavView.SelectedItem)?.Content?.ToString();
            }

        }

    }
}
