using SteamAPIWebApplication.Models.BasicContents;
using SteamKit2;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    items.Add(i);
                }
                return items;
            }
        }
    }
}