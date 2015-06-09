using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using RadioPlayerLib.Services;

namespace RadioPlayerLib.ViewModel
{
    public class PlayerViewModel : ViewModelBase
    {
        public PlayerViewModel()
        {
            this.OpenWebsiteCommand = new RelayCommand(this.OpenWebsite);
            this.SendEmailCommand = new RelayCommand(this.OpenEmailClient);
            this.SwitchPlayingCommand = new RelayCommand(this.SwitchPlaying);
            this.OpenHistoryCommand = new RelayCommand(this.OpenHistory);

            var radioService = SimpleIoc.Default.GetInstance<IRadioService>();
            this.IsPlaying = radioService.IsWebRadioPlaying();
        }

        public RelayCommand OpenWebsiteCommand { get; private set; }
        public RelayCommand SendEmailCommand { get; private set; }

        public RelayCommand SwitchPlayingCommand { get; private set; }
        public RelayCommand OpenHistoryCommand { get; private set; }

        public bool IsPlaying { get; set; }

        private void OpenWebsite()
        {
            var webNavigationService = SimpleIoc.Default.GetInstance<IWebNavigationService>();
            webNavigationService.openUrlInBrowser("http://www.radiooxygene.com");
        }

        private void OpenEmailClient()
        {
            var webNavigationService = SimpleIoc.Default.GetInstance<IWebNavigationService>();
            webNavigationService.openEmailAppWithReceiver("test@test.com");
        }

        private void OpenHistory()
        {
            var navigationService = SimpleIoc.Default.GetInstance<INavigationService>();
            navigationService.NavigateTo(NavigationServiceBase.KEY_HISTORY_PAGE);
        }

        private void SwitchPlaying()
        {
            var radioService = SimpleIoc.Default.GetInstance<IRadioService>();

            if (IsPlaying)
            {
                radioService.StopWebRadio();
            }
            else
            {
                radioService.StartWebRadio("http://mp3lg3.tdf-cdn.com/4931/rad_143644.mp3", "Radio Star", "Les meilleurs sons du sud");
            }

            IsPlaying = !IsPlaying;
            RaisePropertyChanged("IsPlaying");
        }

    }
}
