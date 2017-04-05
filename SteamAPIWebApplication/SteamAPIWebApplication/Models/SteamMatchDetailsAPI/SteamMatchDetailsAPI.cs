using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamAPIWebApplication.Models.SteamMatchDetailsAPI
{
    public class SteamMatchDetailsAPI
    {
        public string status { get; set; }
        public string statusDetail { get; set; }
        public string num_results { get; set; }
        public string total_results { get; set; }
        public string results_remaining { get; set; }
        public List<SteamMatchDetailsFull> matches { get; set; }
        public List<SteamPlayersMatchDetails> players { get; set; }
        //public List<SteamMatchDetailsAPI> steamMatchDetailsList { get; set; }
       
    }
}