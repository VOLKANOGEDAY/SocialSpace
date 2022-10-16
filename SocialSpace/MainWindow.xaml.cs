using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Linq;
using System.Collections.Generic;

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
            ("HomePage", typeof(HomePage)),
        };

        //navigation
        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigated += On_Navigated;
            NavView_Navigate("HomePage", new Microsoft.UI.Xaml.Media.Animation.EntranceNavigationTransitionInfo());
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {

            if (args.InvokedItemContainer != null)
            {
                var navItemTag = args.InvokedItemContainer.Tag.ToString();
                NavView_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
            }

        }

        private void NavView_Navigate(string navItemTag, Microsoft.UI.Xaml.Media.Animation.NavigationTransitionInfo transitionInfo)
        {

            Type page = null;
            var item = _pages.FirstOrDefault(p => p.Tag.Equals(navItemTag));
            page = item.Page;
            var preNavPageType = ContentFrame.CurrentSourcePageType;

            if (!(page is null) && !Type.Equals(preNavPageType, page))
            {
                ContentFrame.Navigate(page, null, transitionInfo);
            }

        }

        private void On_Navigated(object sender, NavigationEventArgs e)
        {

            if (ContentFrame.SourcePageType != null)
            {
                var item = _pages.FirstOrDefault(p => p.Page == e.SourcePageType);
                NavView.SelectedItem = NavView.MenuItems.OfType<NavigationViewItem>().First(n => n.Tag.Equals(item.Tag));
                NavView.Header = ((NavigationViewItem)NavView.SelectedItem)?.Content?.ToString();
            }

        }

    }
}
