using SteamAPIWebApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamAPIWebApplication.Models.SteamMatchDetailsAPI
{
    public class SteamPlayersMatchDetails
    {
        #region Players
        public string account_id { get; set; }
        public string steam_account_match { get; set; }
        public string player_slot { get; set; }
        public string player_slot_side { get; set; }
        public string hero_id { get; set; }
        public string hero_name { get; set; }
        public string match_id { get; set; }
        public string hero_image_sb { get; set; }
        public SteamMatchDetailViewModel MatchDetailById { get; set; }
        public string lobby_name { get; set; }
        #endregion
    }
}