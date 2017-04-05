using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamAPIWebApplication.Models.SteamNews
{
    public class SteamFriendsAPI
    {
        public string steamid { get; set; }
        public string relationship { get; set; }
        public string friend_since { get; set; }
    }
}