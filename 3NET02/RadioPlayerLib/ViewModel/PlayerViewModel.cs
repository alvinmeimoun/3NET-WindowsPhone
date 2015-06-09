using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
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

            this.IsPlaying = false;
        }

        public RelayCommand OpenWebsiteCommand { get; private set; }
        public RelayCommand SendEmailCommand { get; private set; }

        public RelayCommand SwitchPlayingCommand { get; private set; }

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

        private void SwitchPlaying()
        {
            var radioService = SimpleIoc.Default.GetInstance<IRadioService>();

            if (IsPlaying)
            {
                radioService.StopWebRadio();
            }
            else
            {
                radioService.StartWebRadio("http://mp3lg3.tdf-cdn.com/4931/rad_143644.mp3");
            }

            IsPlaying = !IsPlaying;
            RaisePropertyChanged("IsPlaying");
        }

    }
}
