using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using NPlaces.Model;

namespace NPlaces.ViewModel
{
    public class MenuViewModel
    {
        private ObservableCollection<Menu> _menuData = null;

        private const string BasePath = "/Assets/Menu/nav_"; 

        public bool IsLoaded { get; set; }
        public ObservableCollection<Menu> MenuData
        {
            get
            {
                return _menuData;
            }
            set
            {
                _menuData = value;
            }
        }
        public MenuViewModel()
        {
            _menuData = new ObservableCollection<Menu>();
            IsLoaded = false;
        }

        public void GetMenu()
        {
            _menuData.Add(new Menu("Atm", "ATM", BasePath + "atm.png"));
            _menuData.Add(new Menu("Bank", "BANK", BasePath +  "bank.png"));
            _menuData.Add(new Menu("Cafe", "CAFE", BasePath + "cafe.png"));
            _menuData.Add(new Menu("Cinema", "CINEMA", BasePath +  "cinema.png"));
            _menuData.Add(new Menu("Food", "FOOD", BasePath +  "food.png"));
            _menuData.Add(new Menu("Hospital", "HOSPITAL", BasePath + "hospital.png"));
            _menuData.Add(new Menu("Police", "POLICE", BasePath +  "police.png"));
            _menuData.Add(new Menu("University", "UNIVERSITY", BasePath + "university.png"));
            _menuData.Add(new Menu("Bar", "BAR", BasePath + "bar.png"));
            _menuData.Add(new Menu("Park", "PARK", BasePath + "park.png"));
            _menuData.Add(new Menu("Post Office", "POSTOFFICE", BasePath + "post_office.png"));
            _menuData.Add(new Menu("All Place", "AllPLACE", BasePath + "allplace.png"));
            IsLoaded = true;
        }
    }
}
