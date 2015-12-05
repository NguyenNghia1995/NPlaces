using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NPlaces.Model;
using NPlaces.Model.Place;
using NPlaces.Model.PlaceDetail;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Imaging;

namespace NPlaces.Helper
{
    public class PlaceDetail
    {
        public String Name { get; set; }
        public Location Location { get; set; }
        public String Address { get; set; }
        public String PlaceId { get; set; }
        public String Icon { get; set; }
        public List<BitmapImage> ImageUrl { get; set; }
        public String Rating { get; set; }
        public String Website { get; set; }
        public List<Review> Reviews { get; set; }
        public String PhoneNumber { get; set; }
        public String Distance { get; set; }
        public PlaceDetail()
        {
            this.Name = String.Empty;
            this.Address = String.Empty;
            this.PlaceId = String.Empty;
            this.Icon = String.Empty;
            this.ImageUrl = new List<BitmapImage>();
            this.Rating = String.Empty;
            this.Website = String.Empty;
            this.Reviews = new List<Review>();
            this.Distance = String.Empty;
        }

        public PlaceDetail(String name, Location location, String address, String placeId, String icon, List<BitmapImage> imageUrl, String rating, String website, List<Review> review, String phoneNumber, String distance)
        {
            this.Name = name;
            this.Location = location;
            this.Address = address;
            this.PlaceId = placeId;
            this.Icon = icon;
            this.ImageUrl = imageUrl;
            this.Rating = rating;
            this.Website = website;
            this.Reviews = review;
            this.PhoneNumber = phoneNumber;
            this.Distance = distance;
        }



        public async Task GetDetailInfo(Place place)
        {
            this.Name = place.Name;
            this.PlaceId = place.PlaceId;
            this.Icon = place.IconPath;
            this.Location = place.Location;


            String requestPlaceDetail = PlaceAPI.CreatePlaceDetailRequest(this.PlaceId);
            String requestDirection = DirectionAPI.CreateDistanceRequest(Common.Common.CurentLocation, this.Location);
            String jsonDetailPlace = String.Empty;
            String jsonDirection = String.Empty;

            try
            {
                jsonDetailPlace = await WebHelper.GetStringFromRequest(requestPlaceDetail);
                if (jsonDetailPlace != String.Empty)
                {
                    PlaceDetailRootObject rootObjet = JsonConvert.DeserializeObject<PlaceDetailRootObject>(jsonDetailPlace);
                    if (rootObjet.status == "OK")
                    {
                       if(rootObjet.result.rating.ToString() != null || rootObjet.result.rating.ToString() != String.Empty)
                       {
                           this.Rating = rootObjet.result.rating.ToString();
                       }
                        
                        this.PhoneNumber = rootObjet.result.formatted_phone_number;
                        this.Website = rootObjet.result.website;
                        this.Address = rootObjet.result.formatted_address;

                        var photos = rootObjet.result.photos;
                        if (photos != null)
                        {
                            foreach (NPlaces.Model.Place.Photo item in photos)
                            {
                                this.ImageUrl.Add(new BitmapImage(new Uri(PlaceAPI.CreatePhotoPlaceRequest(item.photo_reference), UriKind.RelativeOrAbsolute)));
                            }
                        }

                        var reviews = rootObjet.result.reviews;
                        if (reviews != null)
                        {
                            foreach (Review item in reviews)
                            {
                                this.Reviews.Add(new Review(item.author_name, item.rating, item.text));
                            }
                        }
                    }
                }

                jsonDirection = await WebHelper.GetStringFromRequest(requestDirection);
                if(!String.IsNullOrEmpty(jsonDirection))
                {
                    DirectionRootObject directionRootObject = JsonConvert.DeserializeObject<DirectionRootObject>(jsonDirection);
                    if(directionRootObject.status == "OK")
                    {
                        var legs = directionRootObject.routes[0].legs;
                        if(legs != null)
                        {
                            this.Distance = legs[0].distance.text;
                            Debug.WriteLine(this.Distance);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }


      

    }
}
