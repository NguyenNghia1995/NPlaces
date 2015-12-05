using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NPlaces.Helper;
using NPlaces.Model;
using NPlaces.Model.Place;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace NPlaces
{


    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private DispatcherTimer m_memoryTimer;

        private void CheckMemoryUse()
        {
            m_memoryTimer = new DispatcherTimer();
            m_memoryTimer.Interval = new TimeSpan(0, 0, 1);
            m_memoryTimer.Tick += m_memoryTimer_Tick;
            m_memoryTimer.Start();
        }

        void m_memoryTimer_Tick(object sender, object e)
        {
            try
            {
                Debug.WriteLine((MemoryManager.AppMemoryUsage / 1024).ToString() + "K/" + (MemoryManager.AppMemoryUsageLimit/ 1024).ToString() + "K");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            DrawerLayout.InitializeDrawerLayout();
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        

        void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            if (DrawerLayout.IsDrawerOpen)
            {
                DrawerLayout.CloseDrawer();
                e.Handled = true;
            }
            else
            {
                Application.Current.Exit();
            }
        }



        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            CheckMemoryUse();
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                if (e.NavigationMode == NavigationMode.New)
                {
                    LoadingGrid.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    ContentGrid.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    if (!Common.Common.MenuViewModel.IsLoaded)
                        Common.Common.MenuViewModel.GetMenu();
                    ListMenuItems.ItemsSource = Common.Common.MenuViewModel.MenuData;

                    Common.Common.CurentLocation = await LocationHelper.GetCurrentLocation();

                    if (!Common.Common.AllPlaceViewModel.IsLoaded)
                         Common.Common.AllPlaceViewModel.GetNearPlaces();

                    lvContent.ItemsSource = Common.Common.AllPlaceViewModel.Data;

                    LoadingGrid.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    ContentGrid.Visibility = Windows.UI.Xaml.Visibility.Visible;
                }
            }
            else
            {
                MessageDialog dialog = new MessageDialog("please check your network, and try again");
                await dialog.ShowAsync();
            }
        }


        private void DrawerIcon_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (DrawerLayout.IsDrawerOpen)
                DrawerLayout.CloseDrawer();
            else
                DrawerLayout.OpenDrawer();
        }

        private void lvContent_ItemClick(object sender, ItemClickEventArgs e)
        {
            Place place = e.ClickedItem as Place;
            Frame.Navigate(typeof(DetailPage), place);
        }

        private async void ListMenuItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            Menu menu = e.ClickedItem as Menu;
            txtTitle.Text = menu.Title;

            LoadingGrid.Visibility = Windows.UI.Xaml.Visibility.Visible;
            ContentGrid.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

            switch (menu.TAG)
            {
                case "ATM":
                    {
                        if (!Common.Common.ATMViewModel.IsLoaded)
                             Common.Common.ATMViewModel.GetNearPlaces(SupportType.Atm);
                        lvContent.ItemsSource = Common.Common.ATMViewModel.Data;
                        break;
                    }
                case "BANK":
                    {
                        if (!Common.Common.BankViewModel.IsLoaded)
                             Common.Common.BankViewModel.GetNearPlaces(SupportType.Bank);
                        lvContent.ItemsSource = Common.Common.BankViewModel.Data;
                        break;
                    }

                case "CAFE":
                    {
                        if (!Common.Common.CafeViewModel.IsLoaded)
                             Common.Common.CafeViewModel.GetNearPlaces(SupportType.Cafe);
                        lvContent.ItemsSource = Common.Common.CafeViewModel.Data;
                        break;
                    }
                case "CINEMA":
                    {
                        if (!Common.Common.CinemaViewModel.IsLoaded)
                             Common.Common.CinemaViewModel.GetNearPlaces(SupportType.Cinema);
                        lvContent.ItemsSource = Common.Common.CinemaViewModel.Data;
                        break;
                    }
                case "FOOD":
                    {
                        if (!Common.Common.FoodViewModel.IsLoaded)
                             Common.Common.FoodViewModel.GetNearPlaces(SupportType.Food);
                        lvContent.ItemsSource = Common.Common.FoodViewModel.Data;
                        break;
                    }
                case "HOSPITAL":
                    {
                        if (!Common.Common.HospitalViewModel.IsLoaded)
                             Common.Common.HospitalViewModel.GetNearPlaces(SupportType.Hospital);
                        lvContent.ItemsSource = Common.Common.HospitalViewModel.Data;
                        break;
                    }
                case "POLICE":
                    {
                        if (!Common.Common.PoliceViewModel.IsLoaded)
                             Common.Common.PoliceViewModel.GetNearPlaces(SupportType.Police);
                        lvContent.ItemsSource = Common.Common.PoliceViewModel.Data;
                        break;
                    }
                case "UNIVERSITY":
                    {
                        if (!Common.Common.UniversityViewModel.IsLoaded)
                             Common.Common.UniversityViewModel.GetNearPlaces(SupportType.University);
                        lvContent.ItemsSource = Common.Common.UniversityViewModel.Data;
                        break;
                    }
                case "BAR":
                    {
                        if (!Common.Common.BarViewModel.IsLoaded)
                             Common.Common.BarViewModel.GetNearPlaces(SupportType.Bar);
                        lvContent.ItemsSource = Common.Common.BarViewModel.Data;
                        break;
                    }
                case "PARK":
                    {
                        if (!Common.Common.ParkViewModel.IsLoaded)
                             Common.Common.ParkViewModel.GetNearPlaces(SupportType.Park);
                        lvContent.ItemsSource = Common.Common.ParkViewModel.Data;
                        break;
                    }
                case "POSTOFFICE":
                    {
                        if (!Common.Common.PostOfficeViewModel.IsLoaded)
                             Common.Common.PostOfficeViewModel.GetNearPlaces(SupportType.PostOffice);
                        lvContent.ItemsSource = Common.Common.PostOfficeViewModel.Data;
                        break;
                    }
                case "ALLPLACE":
                    {
                        if (!Common.Common.AllPlaceViewModel.IsLoaded)
                             Common.Common.AllPlaceViewModel.GetNearPlaces();
                        lvContent.ItemsSource = Common.Common.AllPlaceViewModel.Data;
                        break;
                    }
                default:
                    break;
            }
            DrawerLayout.CloseDrawer();
            LoadingGrid.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            ContentGrid.Visibility = Windows.UI.Xaml.Visibility.Visible;

        }

    }
}
