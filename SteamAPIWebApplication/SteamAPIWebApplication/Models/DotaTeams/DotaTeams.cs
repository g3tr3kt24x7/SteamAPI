using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamAPIWebApplication.Models.DotaTeams
{
    public class DotaTeams
    {
        public string team_id { get; set; }
        public string name { get; set; }
        public string tag { get; set; }
        public string time_created { get; set; }
        public string logo { get; set; }
        public string logo_sponsor { get; set; }
        public string country_code { get; set; }
        public string url { get; set; }
        public string player_0_account_id { get; set; }
        public string player_1_account_id { get; set; }
        public string player_2_account_id { get; set; }
        public string player_3_account_id { get; set; }
        public string player_4_account_id { get; set; }
        public string player_5_account_id { get; set; }
        public string player_6_account_id { get; set; }
        public string player_names_0 { get; set; }
        public string player_names_1 { get; set; }
        public string player_names_2 { get; set; }
        public string player_names_3 { get; set; }
        public string player_names_4 { get; set; }
        public string player_names_5 { get; set; }
        public string player_names_6 { get; set; }
        public string admin_account_id { get; set; }
        public string admin_account_name { get; set; }
    }
}