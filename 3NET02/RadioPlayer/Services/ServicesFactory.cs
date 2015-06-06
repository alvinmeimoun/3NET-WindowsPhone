using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RadioPlayerLib.Services;

namespace RadioPlayer.Services
{
    public class ServicesFactory
    {
        public static void RegisterServices()
        {
            SimpleIoc.Default.Register<ILocationService, LocationServiceWP8>();
        }
    }
}
