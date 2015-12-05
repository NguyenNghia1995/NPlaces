using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPlaces.Model;
using NPlaces.Model.Place;

namespace NPlaces.Helper
{
    public class Place
    {
        public String Name { get; set; }
        public Location Location { get; set; }
        public String PlaceId { get; set; }
        public String Address { get; set; }
        public string IconPath { get; set; }
      
        public Place()
        {

        }

        public Place(String name, String placeId, Location location, String address, String iconPath)
        {
            this.Name = name;
            this.PlaceId = placeId;
            this.Location = location;
            this.Address = address;
            this.IconPath = iconPath;
            
        }
    }
}
