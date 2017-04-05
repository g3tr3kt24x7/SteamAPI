using SteamAPIWebApplication.Models.SteamNews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamAPIWebApplication.ViewModels
{
    public class SteamHomeViewModel
    {
        public List<SteamNews> steamNews { get; set; }
        public SteamVanityUserName vanityUserName { get; set; }
    }
}