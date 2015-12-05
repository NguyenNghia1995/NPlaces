using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPlaces.Model
{
    public class PlaceAPI
    {
      //AIzaSyA61FgkFX4r0131E59W_zxANonP2BF_FV8
        public static String KeyAPI = "AIzaSyBSweJmCJ9j3Vpo7R2m9fi_osowLbWS9EM";
        public static String NearBySearchRequest = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?";
        public static String QuerySearchRequest = "https://maps.googleapis.com/maps/api/place/textsearch/json?";
        public static String PlaceDetailRequest = "https://maps.googleapis.com/maps/api/place/details/json?";
        public static String PhotoPlaceRequest = "https://maps.googleapis.com/maps/api/place/photo?";
        
       
        public static string CreateNearBySearhRequest(string location, string type, string language = "vi")
        {
            String request = string.Format(NearBySearchRequest + "location={0}&type={1}&rankby=distance&language={2}&key={3}", location, type, language, KeyAPI);
            return request;
        }

        public static string CreateNearBySearhRequest(string location)
        {
            String request = string.Format(NearBySearchRequest + "location={0}&radius=10000&key={1}", location, KeyAPI);
            return request;
        }

        public static string CreatePlaceDetailRequest(string placeId)
        {
            String request = string.Format(PlaceDetailRequest + "placeid={0}&key={1}",placeId,KeyAPI);
            return request;
        }

        public static string CreatePhotoPlaceRequest(string photoReference)
        {
            String request = string.Format(PhotoPlaceRequest + "photoreference={0}&maxheight={1}&maxwidth={2}&key={3}", photoReference,960, 960, KeyAPI);
            return request;
        }
    }
}
