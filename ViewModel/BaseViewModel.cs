using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NPlaces.Helper;
using NPlaces.Model;
using NPlaces.Model.Place;
using Windows.UI.Popups;

namespace NPlaces.ViewModel
{
    public class BaseViewModel
    {
        private ObservableCollection<Place> _data = null;

        public bool IsLoaded { get; set; }
        public ObservableCollection<Place> Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }
        public BaseViewModel()
        {
            _data = new ObservableCollection<Place>();
            IsLoaded = false;
        }

        public async void GetNearPlaces(string type)
        {
            string locationStr = Common.Common.CurentLocation.lat.ToString() + "," + Common.Common.CurentLocation.lng.ToString();
            String request = PlaceAPI.CreateNearBySearhRequest(locationStr, type);

            try
            {
                string json = string.Empty;
                json = await WebHelper.GetStringFromRequest(request);
                if (json != string.Empty)
                {
                    PlaceRootObject rootObject = JsonConvert.DeserializeObject<PlaceRootObject>(json);
                    if(rootObject.status == "OK")
                    {
                        foreach (Result item in rootObject.results)
                        {
                            _data.Add(new Place(item.name, item.place_id, item.geometry.location, item.vicinity, item.icon));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }


            IsLoaded = true;
        }

        public async void  GetNearPlaces()
        {
            string locationStr = Common.Common.CurentLocation.lat.ToString() + "," + Common.Common.CurentLocation.lng.ToString();
            String request = PlaceAPI.CreateNearBySearhRequest(locationStr);

            try
            {
                string json = string.Empty;
                json = await WebHelper.GetStringFromRequest(request);
                if (json != string.Empty)
                {
                    PlaceRootObject rootObject = JsonConvert.DeserializeObject<PlaceRootObject>(json);
                    if (rootObject.status == "OK")
                    {
                        foreach (Result item in rootObject.results)
                        {
                            _data.Add(new Place(item.name, item.place_id, item.geometry.location, item.vicinity, item.icon));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }


            IsLoaded = true;
        }

    }
}
