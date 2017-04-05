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
        public string player_slot { get; set; }
        public string hero_id { get; set; }
        public string match_id { get; set; }
        #endregion
    }
}