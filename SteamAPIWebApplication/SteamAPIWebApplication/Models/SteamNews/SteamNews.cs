using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamAPIWebApplication.Models.SteamNews
{
    public class SteamNews
    {
        public Int64 gid { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string is_external_url { get; set; }
        public string author { get; set; }
        public string contents { get; set; }
        public string feedlabel { get; set; }
        public string date { get; set; }
        public string feedname { get; set; }
    }
}