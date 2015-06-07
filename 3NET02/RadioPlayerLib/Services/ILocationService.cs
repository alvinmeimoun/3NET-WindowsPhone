using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RadioPlayerLib.Beans;

namespace RadioPlayerLib.Services
{
    public interface ILocationService
    {
        /// <summary>
        /// Obtient la position actuelle
        /// </summary>
        /// <returns>LocaitonPoint de la position actuelle</returns>
        Task<LocationPoint> getCurrentLocation();
    }
}
