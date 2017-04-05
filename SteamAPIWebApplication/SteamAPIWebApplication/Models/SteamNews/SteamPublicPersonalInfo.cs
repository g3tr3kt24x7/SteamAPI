using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamAPIWebApplication.Models.SteamNews
{
    public class SteamPublicPersonalInfo
    {
        public string steamid { get; set; }
        //1 Private
        //2 Friends only
        //3 Friends of Friends
        //4 Users Only
        //5 Public
        public string communityvisibilitystate { get; set; }
        public string profilestate { get; set; }
        public string personaname { get; set; }
        public string lastlogoff { get; set; }
        public string profileurl { get; set; }
        public string avatar { get; set; }
        public string avatarmedium { get; set; }
        public string avatarfull { get; set; }
        //0 Offline(Also set when the profile is Private)
        //1 Online
        //2 Busy
        //3 Away
        //4 Snooze
        //5 Looking to trade
        //6 Looking to play
        public string personastate { get; set; }
    }
}