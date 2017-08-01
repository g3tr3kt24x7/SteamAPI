using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SteamAPIWebApplication.Models
{
    public class LeagueGamesAll
    {
        [Key]
        public int LeagueID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string tournament_url { get; set; }
    }
}