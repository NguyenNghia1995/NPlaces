using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPlaces.Model;
using NPlaces.Model.Place;
using NPlaces.ViewModel;

namespace NPlaces.Common
{
    public class Common
    {
        public static Location CurentLocation = null;
        public static MenuViewModel MenuViewModel = new MenuViewModel();
        public static BaseViewModel ATMViewModel = new BaseViewModel();
        public static BaseViewModel BankViewModel = new BaseViewModel();
        public static BaseViewModel CafeViewModel = new BaseViewModel();
        public static BaseViewModel CinemaViewModel = new BaseViewModel();
        public static BaseViewModel FoodViewModel = new BaseViewModel();
        public static BaseViewModel HospitalViewModel = new BaseViewModel();
        public static BaseViewModel PoliceViewModel = new BaseViewModel();
        public static BaseViewModel UniversityViewModel = new BaseViewModel();
        public static BaseViewModel BarViewModel = new BaseViewModel();
        public static BaseViewModel ParkViewModel = new BaseViewModel();
        public static BaseViewModel PostOfficeViewModel = new BaseViewModel();
        public static BaseViewModel AllPlaceViewModel = new BaseViewModel();
       
    }
}
