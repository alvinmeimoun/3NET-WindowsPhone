using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Phone.BackgroundAudio;
using RadioPlayerLib.Services;

namespace RadioPlayer.Services
{
    public class RadioServiceWP8 : IRadioService
    {
        public void StartWebRadio(string streamUrl, string title, string description)
        {
            AudioTrack track = new AudioTrack(new Uri(streamUrl, UriKind.Absolute), title, description, null, null);
            BackgroundAudioPlayer.Instance.Track = track;
            BackgroundAudioPlayer.Instance.Play();
        }

        public void StopWebRadio()
        {
            BackgroundAudioPlayer.Instance.Stop();
            BackgroundAudioPlayer.Instance.Track = null;
        }

        public bool IsWebRadioPlaying()
        {
            if (BackgroundAudioPlayer.Instance != null && BackgroundAudioPlayer.Instance.Track != null)
            {
                return true;
            }
            return false;
        }
    }
}
