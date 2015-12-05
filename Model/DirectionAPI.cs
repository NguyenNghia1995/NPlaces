using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPlaces.Model.Place;

namespace NPlaces.Model
{
    public class DirectionAPI
    {
        public static String KeyAPI = "AIzaSyAr0CF_nlb7OFfaadA6nl8qDQITNUSo4hs";
        public static String CreateDistanceRequest(Location source, Location destination)
        {
            String sourceStr = source.lat.ToString() + ","+ source.lng.ToString();
            String destinationStr = destination.lat.ToString() + "," + destination.lng.ToString();
            String request = string.Format("https://maps.googleapis.com/maps/api/directions/json?" + "origin={0}&destination={1}&transit_mode=bus&key={2}&alternatives=true&sensor=false&mode=transit&units=metric", sourceStr, destinationStr, KeyAPI);
            return request;
        }
      
        
    }
}
