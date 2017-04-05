using SteamAPIWebApplication.Models.SteamNews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamAPIWebApplication.ViewModels
{
    public class SteamFriendsViewModel
    {
        public SteamVanityUserName vanityUserName { get; set; }
        public List<SteamFriendsAPI> FriendsList { get; set; }
        public SteamPublicPersonalInfo svPersonalInfo { get; set; }
        public List<SteamPublicPersonalInfo> svFriendsInfo { get; set; }
    }
}