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
        }

        public RelayCommand OpenWebsiteCommand { get; private set; }
        public RelayCommand SendEmailCommand { get; private set; }

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
    }
}
