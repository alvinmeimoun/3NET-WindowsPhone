using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioPlayerLib.Services
{
    public interface IRadioService
    {
        void StartWebRadio(string streamUrl);
        void StopWebRadio();
        bool IsWebRadioPlaying();
    }
}
