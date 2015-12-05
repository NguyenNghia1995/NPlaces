using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPlaces.Model
{
   public class Menu
    {
        public String  Title { get; set; }
        public String  TAG { get; set; }
        public String  IconPath { get; set; }

        public Menu()
        {

        }

        public Menu(String title, String tag, String iconPath)
        {
            this.Title = title;
            this.IconPath = iconPath;
            this.TAG = tag;
        }
    }

}
