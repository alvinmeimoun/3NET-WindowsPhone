using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using RadioPlayerLib.Beans;
using RadioPlayerLib.Exceptions;
using RadioPlayerLib.Services;

namespace RadioPlayer.Services
{
    public class LocationServiceWP8 : ILocationService
    {
        public async Task<LocationPoint> getCurrentLocation()
        {
            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 1000;

            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync(
                    maximumAge: TimeSpan.FromMinutes(5),
                    timeout: TimeSpan.FromSeconds(10)
                    );

                
                var rPoint = new LocationPoint();
                rPoint.Latitude = geoposition.Coordinate.Latitude;
                rPoint.Longitude = geoposition.Coordinate.Longitude;
                return rPoint;
            }
            catch (Exception ex)
            {
                if ((uint)ex.HResult == 0x80004004)
                {
                    throw new LocationDisabledException();
                }
                else
                {
                    throw ex;
                }
            }
        }
    }
}
