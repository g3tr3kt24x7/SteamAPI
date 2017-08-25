using SteamAPIWebApplication.CommonClasses;
using SteamAPIWebApplication.Models;
using SteamKit2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SteamAPIWebApplication.Controllers
{
    public class LeagueGamesController : Controller
    {
        // GET: LeagueGames
        public ActionResult LeagueGames()
        {
            List<LeagueGamesAll> leagueGames = new List<LeagueGamesAll>();
            try
            {

                using (dynamic steamLeagueGames = WebAPI.GetInterface("IDOTA2Match_570", clsCommon.APIKey))
                {

                    KeyValue kvLeagueGames = steamLeagueGames.GetLeagueListing();
                    foreach (var league in kvLeagueGames["leagues"].Children)
                    {
                        LeagueGamesAll l = new LeagueGamesAll()
                        {
                            LeagueID = Convert.ToInt32(league["leagueid"].Value),
                            name = clsCommon.FilterLeagueGameName(league["name"].Value),
                            description = league["description"].Value,
                            tournament_url = league["tournament_url"].Value
                        };

                        leagueGames.Add(l);
                        //leagueGames.OrderByDescending(a => a.LeagueID);
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                throw ex;
            }
            return View(leagueGames.OrderByDescending(x => x.LeagueID));
        }
        [ChildActionOnly]
        public ActionResult LeagueGamePartial()
        {
            List<LeagueGamesAll> leagueGames = new List<LeagueGamesAll>();
            try
            {
                using (dynamic steamLeagueGames = WebAPI.GetInterface("IDOTA2Match_570", clsCommon.APIKey))
                {

                    KeyValue kvLeagueGames = steamLeagueGames.GetLeagueListing();
                    foreach (var league in kvLeagueGames["leagues"].Children)
                    {
                        LeagueGamesAll l = new LeagueGamesAll()
                        {
                            LeagueID = Convert.ToInt32(league["leagueid"].Value),
                            name = clsCommon.FilterLeagueGameName(league["name"].Value),
                            description = league["description"].Value,
                            tournament_url = league["tournament_url"].Value
                        };
                        leagueGames.Add(l);
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                throw ex;
            }
            return View(leagueGames.OrderByDescending(x => x.LeagueID).Take(7));
        }
        [ChildActionOnly]
        public ActionResult LiveLeagueGame()
        {
            using (dynamic steamLiveGames = WebAPI.GetInterface("IDOTA2Match_570", clsCommon.APIKey))
            {

            }
            return View();
        }
    }
}