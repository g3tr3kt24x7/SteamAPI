using SteamAPIWebApplication.CommonClasses;
using SteamAPIWebApplication.Models;
using SteamAPIWebApplication.Models.BasicContents;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using DotA2StatsParser.Model.Dotabuff;
using Microsoft.AspNet.Identity;
using DotA2StatsParser.Model.HealthCheck.Interfaces;
using DotA2StatsParser.Model.Dotabuff.Interfaces;
using DotA2StatsParser.Model.Yasp.Interfaces;

using SteamKit2;
using PagedList;

namespace SteamAPIWebApplication.Controllers
{
    public class DotaHeroesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: DotaHeroes
        public ActionResult Index()
        {
            List<DotaHeroes> heroes = new List<DotaHeroes>();
            if (db.heroes.ToList().Count() <= 0)
            {
                heroes = FilterHeroName(clsCommon.GetHeroes(0));
                db.heroes.AddRange(heroes);
                db.SaveChanges();
            }
            else
            {
                heroes = db.heroes.ToList();
            }
            //test();
            return View(heroes);
        }
        public List<DotaHeroes> FilterHeroName(List<DotaHeroes> heroes)
        {
            List<DotaHeroes> hero = new List<DotaHeroes>();
            foreach (var h in heroes)
            {
                string[] strSplit = Regex.Split(h.name, "npc_dota_hero_");
                string abc = strSplit[1].Replace("_", " ");
                TextInfo t = new CultureInfo("en-US", false).TextInfo;
                abc = t.ToTitleCase(abc);
                hero.Add(new DotaHeroes() { name = abc, id = h.id, hero_image_sb=strSplit[1].ToString()+"_sb.png",hero_image_full=strSplit[1]+"_full.png",hero_image_lg=strSplit[1]+"_lg.png",hero_image_vert=strSplit[1]+"_vert.jpg",localized_name=h.localized_name });
            }
            return hero;

        }
        //[ChildActionOnly]
        public ActionResult HeroDesc(string heroid)
        {
            DotaHeroes hero = db.heroes.Where(x=>x.id==heroid).FirstOrDefault();
            return View(hero);
        }
        //public List<DotaHeroes> FilterImagesForHeroes(List<DotaHeroes> heroes)
        //{
        //    List<DotaHeroes> hero = new List<DotaHeroes>();
        //    foreach (var h in heroes)
        //    {
        //        string[] strSplit = Regex.Split(h.name, "npc_dota_hero_");
        //        hero.Add(new DotaHeroes() { })
        //    }
        //}
        public void test()
        {
            //DotaGCHandler dota;
            //SteamClient client = new SteamClient();
            //DotaGCHandler.Bootstrap(client);
            //dota = client.GetHandler<DotaGCHandler>();

            //// ... later when Steam is connected
            //dota.Start();
            using (DotA2StatsParser.Dataparser dataparser = new DotA2StatsParser.Dataparser())
            {
                IHealthCheckResult result = dataparser.PerformHealthCheck();

                if (result.IsDotabuffAvailable)
                {
                    IHero trollWarlord = dataparser.GetHeroPageData(Heroes.TrollWarlord);
                    IItem helmOfTheDominator = dataparser.GetItemPageData(Items.HelmOfTheDominator);
                    IPlayer player1 = dataparser.GetPlayerPageDataBySteamId(User.Identity.GetUserId());

                    IEnumerable<IMatchExtended> matchList = dataparser.GetPlayerMatchesPageData(player1.Id, new PlayerMatchesOptions() { Duration = Durations.Between20And30 });
                }

                if (result.IsYaspAvailable)
                {
                    //IEnumerable<IWordCloud> playerWordCount = dataparser.GetWordCloud("106863163");
                }
            }

        }
    }
}