using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace NPlaces.Helper
{
    class RatingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int n = 0;
            const String BasePath = "/Assets/Image/";
            string _temp = value.ToString();
            if (_temp != String.Empty)
                n = (int)Math.Round(double.Parse(_temp));

            switch (n)
            {
                case 0:
                    {
                        return BasePath + "ic_zero_stars.png";
                      
                    }
                case 1:
                    {
                        return BasePath + "ic_one_stars.png";
                      
                    }
                case 2:
                    {
                        return BasePath + "ic_two_stars.png";
                       
                    }
                case 3:
                    {
                        return BasePath + "ic_three_stars.png";
                        
                    }
                   
                case 4:
                    {
                        return BasePath + "ic_four_stars.png";
                      
                    }
                case 5:
                    {
                        return BasePath + "ic_five_stars.png";
                       
                    }
                default:
                    break;
            }
            return BasePath + "ic_zero_stars.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }

    }
}
