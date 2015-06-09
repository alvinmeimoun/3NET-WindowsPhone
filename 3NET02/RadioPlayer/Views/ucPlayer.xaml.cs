using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.BackgroundAudio;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace RadioPlayer.Views
{
    public partial class ucPlayer : UserControl
    {
        public ucPlayer()
        {
            InitializeComponent();

            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            this.BtEmail.Height = this.BtEmail.ActualWidth;
            this.BtLogin.Height = this.BtLogin.ActualWidth;
            this.BtWebsite.Height = this.BtWebsite.ActualWidth;
            this.BtPlayer.Height = this.BtPlayer.ActualWidth;
        }
    }
}
