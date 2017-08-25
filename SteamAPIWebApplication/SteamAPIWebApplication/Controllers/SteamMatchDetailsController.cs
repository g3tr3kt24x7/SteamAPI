using SteamAPIWebApplication.CommonClasses;
using SteamAPIWebApplication.Models.SteamMatchDetailsAPI;
using SteamAPIWebApplication.ViewModels;
using SteamKit2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using SteamAPIWebApplication.Models;
using PagedList;
namespace SteamAPIWebApplication.Controllers
{
    public class SteamMatchDetailsController : Controller
    {
        // GET: SteamMatchDetails
        public ActionResult Index()
        {
            //List<SteamMatchDetailsAPI> matchDetailsList = new List<SteamMatchDetailsAPI>();
            List<SteamMatchDetailsFull> matchDetailsFull = new List<SteamMatchDetailsFull>();
            List<SteamPlayersMatchDetails> playersDetail = new List<SteamPlayersMatchDetails>();
            SteamMatchDetailsAPI matchDetails = new SteamMatchDetailsAPI();
            string steamId = User.Identity.GetUserId();
            //string steamId32bit = clsCommon.convert_steamid_64bit_to_32bit(User.Identity.GetUserId());
            using (dynamic steamMatchDetails = WebAPI.GetAsyncInterface("IDOTA2Match_570", "0E265171A60CF4F5263E677CEA8CE2B7"))
            {
                KeyValue kvMatch = steamMatchDetails.GetMatchHistory(account_id: steamId);
                //foreach(KeyValue k in kvMatch.Children)
                //{

                //}
                foreach (KeyValue k in kvMatch["matches"].Children.Take(20))
                {
                    //matchDetails.status = k["status"].ToString();
                    //matchDetails.statusDetail = k["statusDetails"].ToString();
                    SteamMatchDetailsFull matches = new SteamMatchDetailsFull()
                    {
                        match_id = k["match_id"].Value.ToString(),
                        //MatchDetailById = FilterMatchByID(k["match_id"].Value.ToString()),
                        match_seq_num = k["match_seq_num"].Value.ToString(),
                        start_time = clsCommon.ConvertUnixDateToDateTime(Convert.ToDouble(k["start_time"].Value.ToString())),
                        lobby_type = k["lobby_type"].Value.ToString(),
                        lobby_type_name = clsCommon.FilterLobbyType(k["lobby_type"].Value.ToString())
                    };
                    matchDetailsFull.Add(matches);
                    foreach (KeyValue kPlayers in k["players"].Children)
                    {
                        SteamPlayersMatchDetails players = new SteamPlayersMatchDetails()
                        {
                            match_id = k["match_id"].Value.ToString(),
                            account_id = kPlayers["account_id"].Value.ToString(),
                            steam_account_match = clsCommon.FilterAccounts(Convert.ToUInt64(kPlayers["account_id"].Value.ToString())),
                            player_slot = kPlayers["player_slot"].Value.ToString(),
                            hero_id = kPlayers["hero_id"].Value.ToString(),
                            hero_name = clsCommon.FilterDotaHeroes(kPlayers["hero_id"].Value.ToString()),
                            player_slot_side = clsCommon.FilterPlayerSlot(kPlayers["player_slot"].Value.ToString())
                        };
                        //players.steam_account_match = clsCommon.FilterAccounts(kPlayers["account_id"].Value.ToString());
                        //playersDetail.GroupBy(x => x.player_slot_side);
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
        [ChildActionOnly]
        public ActionResult MatchDetails()
        {
            //List<SteamMatchDetailsAPI> matchDetailsList = new List<SteamMatchDetailsAPI>();
            List<SteamMatchDetailsFull> matchDetailsFull = new List<SteamMatchDetailsFull>();
            List<SteamPlayersMatchDetails> playersDetail = new List<SteamPlayersMatchDetails>();
            SteamMatchDetailsAPI matchDetails = new SteamMatchDetailsAPI();
            string steamId = User.Identity.GetUserId();
            //string steamId32bit = clsCommon.convert_steamid_64bit_to_32bit(User.Identity.GetUserId());
            using (dynamic steamMatchDetails = WebAPI.GetAsyncInterface("IDOTA2Match_570", "0E265171A60CF4F5263E677CEA8CE2B7"))
            {
                Task<KeyValue> kvMatch = steamMatchDetails.GetMatchHistory(account_id: steamId);
                //foreach(KeyValue k in kvMatch.Children)
                //{

                //}

                foreach (KeyValue k in kvMatch.Result["matches"].Children.Take(20))
                {
                    //matchDetails.status = k["status"].ToString();
                    //matchDetails.statusDetail = k["statusDetails"].ToString();
                    SteamMatchDetailsFull matches = new SteamMatchDetailsFull()
                    {
                        match_id = k["match_id"].Value.ToString(),
                        //MatchDetailById = FilterMatchByID(k["match_id"].Value.ToString()),
                        match_seq_num = k["match_seq_num"].Value.ToString(),
                        start_time = clsCommon.ConvertUnixDateToDateTime(Convert.ToDouble(k["start_time"].Value.ToString())),
                        lobby_type = k["lobby_type"].Value.ToString(),
                        lobby_type_name = clsCommon.FilterLobbyType(k["lobby_type"].Value.ToString())
                    };
                    matchDetailsFull.Add(matches);
                    foreach (KeyValue kPlayers in k["players"].Children)
                    {
                        SteamPlayersMatchDetails players = new SteamPlayersMatchDetails()
                        {
                            match_id = k["match_id"].Value.ToString(),
                            account_id = kPlayers["account_id"].Value.ToString(),
                            steam_account_match = clsCommon.FilterAccounts(Convert.ToUInt64(kPlayers["account_id"].Value.ToString())),
                            player_slot = kPlayers["player_slot"].Value.ToString(),
                            hero_id = kPlayers["hero_id"].Value.ToString(),
                            hero_name = clsCommon.FilterDotaHeroes(kPlayers["hero_id"].Value.ToString()),
                            hero_image_sb = clsCommon.FilterDotaHeroImages(kPlayers["hero_id"].Value.ToString()),
                            player_slot_side = clsCommon.FilterPlayerSlot(kPlayers["player_slot"].Value.ToString()),
                            MatchDetailById = FilterMatchByID(k["match_id"].Value.ToString()),
                        };
                        //players.steam_account_match = clsCommon.FilterAccounts(kPlayers["account_id"].Value.ToString());
                        //playersDetail.GroupBy(x => x.player_slot_side);
                        playersDetail.Add(players);
                    }
                    //matchDetailsList.Add(matchDetails);
                }
                matchDetails.matches = matchDetailsFull;
                matchDetails.players = playersDetail;

                //matchDetails.steamMatchDetailsList = matchDetailsList;
            }
            return PartialView(matchDetails);
        }
        public ActionResult GetMatchDetailById(string matchid)
        {
            SteamMatchDetailViewModel vmSteamMatchDetails = new SteamMatchDetailViewModel();
            List<SteamMatchDetailByID> steamMatchDetailsID = new List<SteamMatchDetailByID>();
            SteamMatchDetailByID steamMatchDetailsIDIndi = new SteamMatchDetailByID();
            using (dynamic matchDetailId = WebAPI.GetAsyncInterface("IDOTA2Match_570", clsCommon.APIKey))
            {
                Task<KeyValue> kvMatchDetailId = matchDetailId.GetMatchDetails(match_id: matchid);
                steamMatchDetailsIDIndi.radiant_win = (kvMatchDetailId.Result.Children[1].Value == "1") ? "Radiant Victory" : "Dire Victory";
                steamMatchDetailsIDIndi.start_time = clsCommon.ConvertUnixDateToDateTime(Convert.ToDouble(kvMatchDetailId.Result.Children[4].Value)).ToString();
                DateTime dtStartTime = Convert.ToDateTime(steamMatchDetailsIDIndi.start_time);
                DateTime endDuration = dtStartTime.AddSeconds(Convert.ToDouble(kvMatchDetailId.Result.Children[2].Value));
                double tsDuration = (endDuration - dtStartTime).TotalMinutes;
                steamMatchDetailsIDIndi.duration = tsDuration.ToString("0.00").Replace('.', ':');
                DateTime firstbloodtime = dtStartTime.AddSeconds(Convert.ToDouble(kvMatchDetailId.Result.Children[12].Value));
                double tsFirstBloodTime = (firstbloodtime - dtStartTime).TotalMinutes;
                steamMatchDetailsIDIndi.first_blood_time = tsFirstBloodTime.ToString("0.00").Replace('.', ':');
                steamMatchDetailsIDIndi.radiant_score = kvMatchDetailId.Result.Children[21].Value;
                steamMatchDetailsIDIndi.dire_score = kvMatchDetailId.Result.Children[22].Value;
                steamMatchDetailsIDIndi.game_mode = clsCommon.FilterGameMode(kvMatchDetailId.Result.Children[18].Value);
                steamMatchDetailsIDIndi.match_id = matchid;
                foreach (var kv in kvMatchDetailId.Result["players"].Children)
                {
                    SteamMatchDetailByID matchDetailID = new SteamMatchDetailByID()
                    {
                        accountid = clsCommon.FilterAccounts(Convert.ToUInt64(kv["account_id"].Value)),
                        player_slot = clsCommon.FilterPlayerSlot(kv["player_slot"].Value.ToString()),
                        hero_id = clsCommon.FilterDotaHeroes(kv["hero_id"].Value.ToString()),
                        hero_image = clsCommon.FilterDotaHeroImages(kv["hero_id"].Value.ToString()),
                        item_0 = clsCommon.FilterItemsImageById(kv["item_0"].Value.ToString()),
                        item_1 = clsCommon.FilterItemsImageById(kv["item_1"].Value.ToString()),
                        item_2 = clsCommon.FilterItemsImageById(kv["item_2"].Value.ToString()),
                        item_3 = clsCommon.FilterItemsImageById(kv["item_3"].Value.ToString()),
                        item_4 = clsCommon.FilterItemsImageById(kv["item_4"].Value.ToString()),
                        item_5 = clsCommon.FilterItemsImageById(kv["item_5"].Value.ToString()),
                        kills = kv["kills"].Value.ToString(),
                        deaths = kv["deaths"].Value.ToString(),
                        assists = kv["assists"].Value.ToString(),
                        gold = kv["gold"].Value.ToString(),
                        last_hits = kv["last_hits"].Value.ToString(),
                        denies = kv["denies"].Value.ToString(),
                        gold_per_min = kv["gold_per_min"].Value.ToString(),
                        xp_per_min = kv["xp_per_min"].Value.ToString(),
                        gold_spent = kv["gold_spent"].Value.ToString(),
                        hero_damage = kv["hero_damage"].Value.ToString(),
                        tower_damage = kv["tower_damage"].Value.ToString(),
                        hero_healing = kv["hero_healing"].Value.ToString(),
                        level = kv["level"].Value.ToString(),
                        backpack_0 = clsCommon.FilterItemsImageById(kv["backpack_0"].Value.ToString()),
                        backpack_1 = clsCommon.FilterItemsImageById(kv["backpack_1"].Value.ToString()),
                        backpack_2 = clsCommon.FilterItemsImageById(kv["backpack_2"].Value.ToString())
                    };
                    steamMatchDetailsID.Add(matchDetailID);
                }

            }
            vmSteamMatchDetails.steamMatchDetails = steamMatchDetailsID;
            vmSteamMatchDetails.steamMatchDetailsIDIndividual = steamMatchDetailsIDIndi;
            return View(vmSteamMatchDetails);
        }
        public SteamMatchDetailViewModel FilterMatchByID(string matchid)
        {
            SteamMatchDetailViewModel vmSteamMatchDetails = new SteamMatchDetailViewModel();
            List<SteamMatchDetailByID> steamMatchDetailsID = new List<SteamMatchDetailByID>();
            SteamMatchDetailByID steamMatchDetailsIDIndi = new SteamMatchDetailByID();
            using (dynamic matchDetailId = WebAPI.GetAsyncInterface("IDOTA2Match_570", clsCommon.APIKey))
            {
                Task<KeyValue> kvMatchDetailId = matchDetailId.GetMatchDetails(match_id: matchid);
                steamMatchDetailsIDIndi.radiant_win = kvMatchDetailId.Result.Children[1].Value;
                steamMatchDetailsIDIndi.start_time = clsCommon.ConvertUnixDateToDateTime(Convert.ToDouble(kvMatchDetailId.Result.Children[4].Value)).ToString();
                DateTime dtStartTime = Convert.ToDateTime(steamMatchDetailsIDIndi.start_time);
                DateTime endDuration = dtStartTime.AddSeconds(Convert.ToDouble(kvMatchDetailId.Result.Children[2].Value));
                double tsDuration = (endDuration - dtStartTime).TotalMinutes;
                steamMatchDetailsIDIndi.duration = tsDuration.ToString("0.00").Replace('.', ':');
                steamMatchDetailsIDIndi.game_mode = clsCommon.FilterGameMode(kvMatchDetailId.Result.Children[18].Value);
                foreach (var kv in kvMatchDetailId.Result["players"].Children)
                {
                    SteamMatchDetailByID matchDetailID = new SteamMatchDetailByID()
                    {
                        accountid = clsCommon.FilterAccounts(Convert.ToUInt64(kv["account_id"].Value)),
                        player_slot = clsCommon.FilterPlayerSlot(kv["player_slot"].Value.ToString()),
                        hero_id = clsCommon.FilterDotaHeroes(kv["hero_id"].Value.ToString()),
                        hero_image = clsCommon.FilterDotaHeroImages(kv["hero_id"].Value.ToString()),
                        item_0 = clsCommon.FilterItemsByID(kv["item_0"].Value.ToString()),
                        item_1 = clsCommon.FilterItemsByID(kv["item_1"].Value.ToString()),
                        item_2 = clsCommon.FilterItemsByID(kv["item_2"].Value.ToString()),
                        item_3 = clsCommon.FilterItemsByID(kv["item_3"].Value.ToString()),
                        item_4 = clsCommon.FilterItemsByID(kv["item_4"].Value.ToString()),
                        item_5 = clsCommon.FilterItemsByID(kv["item_5"].Value.ToString()),
                        //kills = kv["kills"].Value.ToString(),
                        //deaths = kv["deaths"].Value.ToString(),
                        //assists = kv["assists"].Value.ToString(),
                        //gold = kv["gold"].Value.ToString(),
                        //last_hits = kv["last_hits"].Value.ToString(),
                        //denies = kv["denies"].Value.ToString(),
                        //gold_per_min = kv["gold_per_min"].Value.ToString(),
                        //xp_per_min = kv["xp_per_min"].Value.ToString(),
                        //gold_spent = kv["gold_spent"].Value.ToString(),
                        //hero_damage = kv["hero_damage"].Value.ToString(),
                        //tower_damage = kv["tower_damage"].Value.ToString(),
                        //hero_healing = kv["hero_healing"].Value.ToString(),
                        //level = kv["level"].Value.ToString(),
                        backpack_0 = clsCommon.FilterItemsByID(kv["backpack_0"].Value.ToString()),
                        backpack_1 = clsCommon.FilterItemsByID(kv["backpack_1"].Value.ToString()),
                        backpack_2 = clsCommon.FilterItemsByID(kv["backpack_2"].Value.ToString())
                    };
                    steamMatchDetailsID.Add(matchDetailID);
                }

            }
            vmSteamMatchDetails.steamMatchDetails = steamMatchDetailsID;
            vmSteamMatchDetails.steamMatchDetailsIDIndividual = steamMatchDetailsIDIndi;
            return vmSteamMatchDetails;
        }
        [ChildActionOnly]
        public ActionResult GetMatchDetailsNew()
        {
            SteamMatchDetailsAPI matchDetails = new SteamMatchDetailsAPI();
            List<SteamPlayersMatchDetails> playersDetail = new List<SteamPlayersMatchDetails>();
            using (dynamic steamMatchDetails = WebAPI.GetAsyncInterface("IDOTA2Match_570", clsCommon.APIKey))
            {
                Task<KeyValue> kvMatch = steamMatchDetails.GetMatchHistory(account_id: User.Identity.GetUserId());
                //playersDetail = kvMatch.Result["matches"]["players"].Children.ToList();
                foreach (var k in kvMatch.Result["matches"].Children.Take(10))
                {
                    foreach (var p in k["players"].Children)
                    {
                        if (User.Identity.GetUserId() == clsCommon.convert_steamid_32bit_to_64bit(Convert.ToUInt64(p["account_id"].Value)))
                        {
                            SteamPlayersMatchDetails players = new SteamPlayersMatchDetails()
                            {
                                match_id = k["match_id"].Value.ToString(),
                                account_id = p["account_id"].Value.ToString(),
                                steam_account_match = clsCommon.FilterAccounts(Convert.ToUInt64(p["account_id"].Value.ToString())),
                                player_slot = p["player_slot"].Value.ToString(),
                                hero_id = p["hero_id"].Value.ToString(),
                                hero_name = clsCommon.FilterDotaHeroes(p["hero_id"].Value.ToString()),
                                hero_image_sb = clsCommon.FilterDotaHeroImages(p["hero_id"].Value.ToString()),
                                player_slot_side = clsCommon.FilterPlayerSlot(p["player_slot"].Value.ToString()),
                                MatchDetailById = FilterMatchByID(k["match_id"].Value.ToString()),
                                lobby_name = clsCommon.FilterLobbyType(k["lobby_type"].Value.ToString())
                            };
                            playersDetail.Add(players);
                            break;
                        }
                    }
                }
                matchDetails.players = playersDetail;
            }
            return PartialView(matchDetails);
        }
        public ActionResult GetMatchDetailsFull(int? page)
        {
            IPagedList<SteamPlayersMatchDetails> matchPaged = null;
            SteamMatchDetailsAPI matchDetails = new SteamMatchDetailsAPI();
            List<SteamPlayersMatchDetails> playersDetail = new List<SteamPlayersMatchDetails>();
            using (dynamic steamMatchDetails = WebAPI.GetAsyncInterface("IDOTA2Match_570", clsCommon.APIKey))
            {
                Task<KeyValue> kvMatch = steamMatchDetails.GetMatchHistory(account_id: User.Identity.GetUserId());
                //playersDetail = kvMatch.Result["matches"]["players"].Children.ToList();
                foreach (var k in kvMatch.Result["matches"].Children)
                {
                    foreach (var p in k["players"].Children)
                    {
                        if (User.Identity.GetUserId() == clsCommon.convert_steamid_32bit_to_64bit(Convert.ToUInt64(p["account_id"].Value)))
                        {
                            SteamPlayersMatchDetails players = new SteamPlayersMatchDetails()
                            {
                                match_id = k["match_id"].Value.ToString(),
                                account_id = p["account_id"].Value.ToString(),
                                steam_account_match = clsCommon.FilterAccounts(Convert.ToUInt64(p["account_id"].Value.ToString())),
                                player_slot = p["player_slot"].Value.ToString(),
                                hero_id = p["hero_id"].Value.ToString(),
                                hero_name = clsCommon.FilterDotaHeroes(p["hero_id"].Value.ToString()),
                                hero_image_sb = clsCommon.FilterDotaHeroImages(p["hero_id"].Value.ToString()),
                                player_slot_side = clsCommon.FilterPlayerSlot(p["player_slot"].Value.ToString()),
                                MatchDetailById = FilterMatchByID(k["match_id"].Value.ToString()),
                                lobby_name = clsCommon.FilterLobbyType(k["lobby_type"].Value.ToString())
                            };
                            playersDetail.Add(players);
                            break;
                        }
                    }
                }
                int PageNumber = (page ?? 1);
                int PageSize = 10;
                matchDetails.players = playersDetail;
                matchPaged = matchDetails.players.ToPagedList(PageNumber, PageSize);
            }
            return View(matchPaged);
        }
    }
}