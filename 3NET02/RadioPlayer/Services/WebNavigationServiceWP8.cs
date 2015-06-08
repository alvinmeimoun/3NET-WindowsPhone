using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Phone.Tasks;
using RadioPlayerLib.Services;

namespace RadioPlayer.Services
{
    public class WebNavigationServiceWP8 : IWebNavigationService
    {
        public void openUrlInBrowser(string url)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();

            webBrowserTask.Uri = new Uri(url, UriKind.Absolute);

            webBrowserTask.Show();
        }

        public void openEmailAppWithReceiver(string emailAddress)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();

            emailComposeTask.To = emailAddress;

            emailComposeTask.Show();
        }
    }
}
