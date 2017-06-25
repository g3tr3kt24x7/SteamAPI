using SteamAPIWebApplication.Models;
using SteamAPIWebApplication.Models.BasicContents;
using SteamKit2;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SteamAPIWebApplication.CommonClasses
{
    public class clsCommon
    {
        public static string APIKey = "0E265171A60CF4F5263E677CEA8CE2B7";
        public static DateTime ConvertUnixDateToDateTime(double unixDate)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            epoch = epoch.AddSeconds(unixDate).ToLocalTime();
            return epoch;
        }
        public static List<DotaHeroes> GetHeroes(int heroid)
        {
            List<DotaHeroes> heroes = new List<DotaHeroes>();
            DotaHeroes h = new DotaHeroes();
            using (dynamic steamHeroes = WebAPI.GetInterface("IEconDOTA2_570", APIKey))
            {
                KeyValue keyHeroes = steamHeroes.GetHeroes();
                foreach (KeyValue k in keyHeroes["heroes"].Children)
                {
                    if (heroid == 0)
                    {
                        h = new DotaHeroes()
                        {
                            name = k["name"].Value.ToString(),
                            id = k["id"].Value.ToString()
                        };
                    //h.localized_name = k["localized_name"].Value.ToString();

                }
                    else
                    {
                        if (heroid == Convert.ToInt32(k["id"].Value))
                        {
                            h = new DotaHeroes()
                            {
                                name = k["name"].Value.ToString(),
                                id = k["id"].Value.ToString()
                            };
                        
                            //h.localized_name = k["localized_name"].Value.ToString();
                            break;
                        }
                    }
                    heroes.Add(h);
                }
            }
            return heroes;
        }
        public static List<DotaItems> GetIngameItems()
        {
            using (dynamic dotaItems = WebAPI.GetInterface("IEconDOTA2_570", APIKey))
            {
                List<DotaItems> items = new List<DotaItems>();
                KeyValue keyItems = dotaItems.GetGameItems();
                foreach(KeyValue k in keyItems["items"].Children)
                {
                    DotaItems i = new DotaItems()
                    {
                        id = k["id"].Value.ToString(),
                        name=k["name"].Value.ToString(),
                        cost=k["cost"].Value.ToString(),
                        secret_shop=k["secret_shop"].Value.ToString(),
                        side_shop=k["side_shop"].Value.ToString(),
                        recipe=k["recipe"].Value.ToString()
                    };
                    items.Add(FilterItems(i));
                }
                return items;
            }
        }
       
        
        public static string FilterPersonalState(string personastate)
        {
            switch (personastate)
            {
                case "0":
                    return "Offline";
                case "1":
                    return "Online";
                case "2":
                    return "Busy";
                case "3":
                    return "Away";
                case "4":
                    return "Snooze";
                case "5":
                    return "Looking to trade";
                case "6":
                    return "Looking to play";
                default:
                    return "Not Found";
            }
        }
        public static string FilterAccounts(ulong accountid)
        {
            using (dynamic steamUsers = WebAPI.GetInterface("ISteamUser", "0E265171A60CF4F5263E677CEA8CE2B7"))
            {
                string userSteam = "Anonymous";
                SteamID a = new SteamID(accountid);
                string abc = convert_steamid_32bit_to_64bit(accountid);
                KeyValue kvProfile = steamUsers.GetPlayerSummaries(steamids: abc);
                foreach (KeyValue k in kvProfile["players"]["player"].Children)
                {
                    userSteam = k["personaname"].Value.ToString();
               
                }
                return userSteam;
            }
        }
        public static string FilterPlayerSlot(string playerSlot)
        {
            switch(playerSlot)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "0":
                    return "Radiant";
                case "128":
                case "129":
                case "130":
                case "131":
                case "132":
                    return "Dire";
                default:
                    return "Not Found";

            }
        }

        public static string FilterLobbyType(string lobbyType)
        {
            switch(lobbyType)
            {
                case "-1":
                    return "Invalid";
                case "0":
                    return "Public matchmaking";
                case "1":
                    return "Practise";
                case "2":
                    return "Tournament";
                case "3":
                    return "Tutorial";
                case "4":
                    return "Co-op with bots";
                case "5":
                    return "Team match";
                case "6":
                    return "Solo Queue";
                case "7":
                    return "Ranked Matchmaking";
                case "8":
                    return "1v1 Solo Mid";
                default:
                    return "Not Found";
            }
            
        }
        public static string FilterDotaHeroes(string heroid)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string heroName = db.heroes.Where(x => x.id == heroid).FirstOrDefault().name.ToString();
            return heroName;
        }
        public static string convert_steamid_64bit_to_32bit(string accountid)
        {
            string result = (Convert.ToDouble(accountid) - 76561197960265728).ToString();
            //result = (Convert.ToDouble(result.Substring(accountid, 3)) - 61197960265728).ToString();


            return result;
        }
        public static string convert_steamid_32bit_to_64bit(ulong accountid)
        {
            var result = "765"+(accountid + 61197960265728).ToString();
            return result;
        }
        public static DotaItems FilterItems(DotaItems items)
        {
            //List<DotaItems> item = new List<DotaItems>();
            //foreach (var i in item)
            //{
                string[] strSplit = Regex.Split(items.name, "item_");
                string abc = strSplit[1].Replace("_", " ");
                TextInfo t = new CultureInfo("en-US", false).TextInfo;
                abc = t.ToTitleCase(abc);
              DotaItems item = new DotaItems() { name = abc, id = items.id, recipe=items.recipe, cost=items.cost, secret_shop=items.secret_shop, side_shop=items.side_shop };
            //}
            return item;
        }
        public static string FilterItemsByID(string itemid)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            if(itemid!="0")
            {
                string itemname = db.items.Where(x => x.id == itemid).FirstOrDefault().name.ToString();
                return itemname;
            }
            else
            {
                return "No Item Found";
            }
        }
        public static string FilterGameMode(string gamemode)
        {
            switch(gamemode)
            {
                default:
                    return "None";
                case "1":
                    return "All Pick";
                case "2":
                    return "Captain's Mode";
                case "3":
                    return "Random Draft";
                case "4":
                    return "Single Draft";
                case "5":
                    return "All Random";
                case "6":
                    return "Intro";
                case "7":
                    return "Diretide";
                case "8":
                    return "Reverse Captain's Mode";
                case "9":
                    return "The Greeviling";
                case "10":
                    return "Tutorial";
                case "11":
                    return "Mid Only";
                case "12":
                    return "Least Played";
                case "13":
                    return "New Player Pool";
                case "14":
                    return "Compendium Matchmaking";
                case "15":
                    return "Co-op vs Bots";
                case "16":
                    return "Captains Draft";
                case "18":
                    return "Ability Draft";
                case "20":
                    return "All Random Deathmatch";
                case "21":
                    return "1v1 Mid Only";
                case "22":
                    return "Ranked Matchmaking";
            }
        }
    }
}