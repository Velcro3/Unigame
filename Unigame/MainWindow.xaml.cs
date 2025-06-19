using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Unigame
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ExtendsContentIntoTitleBar = true;
            SetTitleBar(UItitle);
            InvokePageTransition(typeof(Overview), new SuppressNavigationTransitionInfo());
        }
        public void loginflow(object sender, RoutedEventArgs e)
        {
            // Placeholder for login flow logic
        }
        private void TitleBar_BackRequested(TitleBar sender, object args)
        {
            if (RootFrame.CanGoBack)
            {
                RootFrame.GoBack();
            }
        }
        private void TitleBar_PaneToggleRequested(TitleBar sender, object args)
        {
            NavigationRoot.IsPaneOpen = !NavigationRoot.IsPaneOpen;
        }
        public void NavbarLoaded(object sender, RoutedEventArgs e)
        {
            NavigationRoot.SelectedItem = NavigationRoot.MenuItems[0];
        }
        public void InvokePageTransition(Type pageType, NavigationTransitionInfo transitioninfo)
        {
            var currentPageType = RootFrame.CurrentSourcePageType;
            if (pageType != null && currentPageType != pageType)
            {
                RootFrame.Navigate(pageType, null, transitioninfo);
            }
        }
        private void NavbarInvoke(object sender, NavigationViewItemInvokedEventArgs e)
        {
            if (e.IsSettingsInvoked)
            {
                InvokePageTransition(typeof(Settings), e.RecommendedNavigationTransitionInfo);
            }
            else if (e.InvokedItemContainer != null)
            {
                var navTag = e.InvokedItemContainer.Tag.ToString();
                Type pagetype = null;
                switch (navTag)
                {
                    case "OverviewPage":
                        pagetype = typeof(Overview);
                        break;
                    case "AboutPage":
                        pagetype = typeof(About);
                        break;

                }
                if (pagetype != null)
                {
                    InvokePageTransition(pagetype, e.RecommendedNavigationTransitionInfo);
                }
            }
        }
    }
    }
