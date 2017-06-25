using SteamAPIWebApplication.Models.SteamMatchDetailsAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamAPIWebApplication.ViewModels
{
    public class SteamMatchDetailViewModel
    {
        public List<SteamMatchDetailByID> steamMatchDetails { get; set; }
        public SteamMatchDetailByID steamMatchDetailsIDIndividual { get; set; }
    }
}