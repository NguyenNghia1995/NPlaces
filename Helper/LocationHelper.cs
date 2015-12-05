using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPlaces.Model;
using NPlaces.Model.Place;
using Windows.Devices.Geolocation;

namespace NPlaces.Helper
{
    public class LocationHelper
    {
        public async static Task<Location> GetCurrentLocation()
        {
            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;
            Location location = null;

            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync(TimeSpan.FromMinutes(5), TimeSpan.FromSeconds(10));
                location = new Location(geoposition.Coordinate.Latitude, geoposition.Coordinate.Longitude);
            }
            catch (Exception ex)
            {
               
            }
            return location;
        }
    }
}
