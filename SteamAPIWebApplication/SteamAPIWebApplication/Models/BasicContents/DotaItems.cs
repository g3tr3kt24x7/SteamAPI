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
    }
}