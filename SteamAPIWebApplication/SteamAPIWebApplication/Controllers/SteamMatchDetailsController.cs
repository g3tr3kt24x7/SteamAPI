using SteamAPIWebApplication.CommonClasses;
using SteamAPIWebApplication.Models.SteamMatchDetailsAPI;
using SteamKit2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SteamAPIWebApplication.Controllers
{
    public class SteamMatchDetailsController : Controller
    {
        // GET: SteamMatchDetails
        public ActionResult Index(string steamid)
        {
            //List<SteamMatchDetailsAPI> matchDetailsList = new List<SteamMatchDetailsAPI>();
            List<SteamMatchDetailsFull> matchDetailsFull = new List<SteamMatchDetailsFull>();
            List<SteamPlayersMatchDetails> playersDetail = new List<SteamPlayersMatchDetails>();
            SteamMatchDetailsAPI matchDetails = new SteamMatchDetailsAPI();
            using (dynamic steamMatchDetails = WebAPI.GetInterface("IDOTA2Match_570", "0E265171A60CF4F5263E677CEA8CE2B7"))
            {
                KeyValue kvMatch = steamMatchDetails.GetMatchHistory(account_id: steamid);
                foreach(KeyValue k in kvMatch.Children)
                {

                }
                foreach (KeyValue k in kvMatch["matches"].Children)
                {
                    //matchDetails.status = k["status"].ToString();
                    //matchDetails.statusDetail = k["statusDetails"].ToString();
                    SteamMatchDetailsFull matches = new SteamMatchDetailsFull()
                    {
                        match_id = k["match_id"].Value.ToString(),
                        match_seq_num = k["match_seq_num"].Value.ToString(),
                        start_time = clsCommon.ConvertUnixDateToDateTime(Convert.ToDouble(k["start_time"].Value.ToString())),
                        lobby_type = k["lobby_type"].Value.ToString()
                    };
                    matchDetailsFull.Add(matches);
                    foreach (KeyValue kPlayers in k["players"].Children)
                    {
                        SteamPlayersMatchDetails players = new SteamPlayersMatchDetails()
                        {
                            match_id=k["match_id"].Value.ToString(),
                            account_id = kPlayers["account_id"].Value.ToString(),
                            player_slot = kPlayers["player_slot"].Value.ToString(),
                            hero_id = kPlayers["hero_id"].Value.ToString()
                        };
                        playersDetail.Add(players);
                    }
                    //matchDetailsList.Add(matchDetails);
                }
                matchDetails.matches = matchDetailsFull;
                matchDetails.players = playersDetail;
                //matchDetails.steamMatchDetailsList = matchDetailsList;
            }
            return View(matchDetails);
        }
    }
}