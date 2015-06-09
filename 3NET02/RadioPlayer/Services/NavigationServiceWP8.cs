using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Views;
using RadioPlayerLib.Services;

namespace RadioPlayer.Services
{
    public class NavigationServiceWP8 : NavigationServiceBase, INavigationService
    {
        private Dictionary<string, Uri> configureDictionary = new Dictionary<string, Uri>();

        public NavigationServiceWP8()
        {
            configure();
        }

        private void configure()
        {
            configureDictionary.Add(KEY_MAIN_PAGE, new Uri("/MainPage.xaml", UriKind.Relative));
            configureDictionary.Add(KEY_HISTORY_PAGE, new Uri("/Views/pFrequencyHistory.xaml", UriKind.Relative));
        }

        public void GoBack()
        {
            App.RootFrame.GoBack();
        }

        public void NavigateTo(string pageKey)
        {
            App.RootFrame.Navigate(configureDictionary[pageKey]);
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            // Doesn't work on Windows Phone 8 Silverlight
            throw new NotImplementedException();
        }

        public string CurrentPageKey { get; private set; }
    }
}
