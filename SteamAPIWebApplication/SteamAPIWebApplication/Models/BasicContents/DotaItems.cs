using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamAPIWebApplication.Models.BasicContents
{
    public class DotaItems
    {
        public string id { get; set; }

        public string name { get; set; }

        public string cost { get; set; }
        //change later
        public string secret_shop { get; set; }
        //change later
        public string side_shop { get; set; }
        //change later
        public string recipe { get; set; }

        public string localized_name { get; set; }
        //59x33px small horizontal portrait
        public string item_image_sb { get; set; }
        //205x105px large horizontal portrait
        public string item_image_lg { get; set; }
        //256x144px full-quality horizontal portrait
        public string item_image_full { get; set; }
        //235x272px full-quality vertical portrait(note that this is a.jpg)
        public string item_image_vert { get; set; }
    }
}