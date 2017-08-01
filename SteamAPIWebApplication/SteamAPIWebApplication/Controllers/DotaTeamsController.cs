using SteamAPIWebApplication.CommonClasses;
using SteamAPIWebApplication.Models.DotaTeams;
using SteamKit2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace SteamAPIWebApplication.Controllers
{
    public class DotaTeamsController : Controller
    {
        // GET: DotaTeams
        public ActionResult DotaTeams()
        {
            List<DotaTeams> dt = new List<DotaTeams>();
            using (dynamic steamDotaTeams = WebAPI.GetInterface("IDOTA2Match_570", clsCommon.APIKey))
            {
                
                KeyValue kvDotaTeams = steamDotaTeams.GetTeamInfoByTeamID();
                foreach(var kDt in kvDotaTeams["teams"].Children)
                {
                    DotaTeams d = new DotaTeams()
                    {
                        team_id = kDt["team_id"].Value,
                        name = kDt["name"].Value,
                        tag = kDt["tag"].Value,
                        time_created = kDt["time_created"].Value,
                        logo = clsCommon.FilterLogoAndImages(570, kDt["logo"].Value),
                        logo_sponsor = kDt["logo_sponsor"].Value,
                        country_code = kDt["country_code"].Value,
                        url = kDt["url"].Value,
                        player_0_account_id = kDt["player_0_account_id"].Value ?? "",
                        player_names_0 = clsCommon.FilterAccounts(Convert.ToUInt64(kDt["player_0_account_id"].Value ?? "0")),
                        player_1_account_id = kDt["player_1_account_id"].Value ?? "",
                        player_names_1 = clsCommon.FilterAccounts(Convert.ToUInt64(kDt["player_1_account_id"].Value ?? "0")),
                        player_2_account_id = kDt["player_2_account_id"].Value ?? "",
                        player_names_2 = clsCommon.FilterAccounts(Convert.ToUInt64(kDt["player_2_account_id"].Value ?? "0")),
                        player_3_account_id = kDt["player_3_account_id"].Value ?? "",
                        player_names_3 = clsCommon.FilterAccounts(Convert.ToUInt64(kDt["player_3_account_id"].Value ?? "0")),
                        player_4_account_id = kDt["player_4_account_id"].Value ?? "",
                        player_names_4 = clsCommon.FilterAccounts(Convert.ToUInt64(kDt["player_4_account_id"].Value ?? "0")),
                        player_5_account_id = kDt["player_5_account_id"].Value ?? "",
                        player_names_5 = clsCommon.FilterAccounts(Convert.ToUInt64(kDt["player_5_account_id"].Value ?? "0")),
                        player_6_account_id = kDt["player_6_account_id"].Value ?? "",
                        player_names_6 = clsCommon.FilterAccounts(Convert.ToUInt64(kDt["player_6_account_id"].Value ?? "0")),
                        admin_account_id = kDt["admin_account_id"].Value ?? "",
                        admin_account_name = clsCommon.FilterAccounts(Convert.ToUInt64(kDt["admin_account_id"].Value ?? "0"))
                    };
                    dt.Add(d);
                }
            }
                return View(dt);
        }
        [ChildActionOnly]
        public ActionResult DotaTeamsPartial()
        {
            List<DotaTeams> dt = new List<DotaTeams>();
            using (dynamic steamDotaTeams = WebAPI.GetInterface("IDOTA2Match_570", clsCommon.APIKey))
            {

                KeyValue kvDotaTeams = steamDotaTeams.GetTeamInfoByTeamID();
                foreach (var kDt in kvDotaTeams["teams"].Children)
                {
                    DotaTeams d = new DotaTeams()
                    {
                        team_id = kDt["team_id"].Value,
                        name = kDt["name"].Value,
                        tag = kDt["tag"].Value,
                        time_created = kDt["time_created"].Value,
                        logo = clsCommon.FilterLogoAndImages(570, kDt["logo"].Value),
                        logo_sponsor = kDt["logo_sponsor"].Value,
                        country_code = kDt["country_code"].Value,
                        url = kDt["url"].Value,
                    };
                    dt.Add(d);
                }
            }
            return View(dt.Take(7));
            
        }
        private int getPlayerNo(string player_N_account_id)
        {
            string[] strSplit = player_N_account_id.Split('_');
            int returnValue = Convert.ToInt32(strSplit[1]);
            return returnValue;
        }
    }
}