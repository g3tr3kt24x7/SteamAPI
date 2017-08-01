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
        //public List<DotaHeroes> FilterImagesForHeroes(List<DotaHeroes> heroes)
        //{
        //    List<DotaHeroes> hero = new List<DotaHeroes>();
        //    foreach (var h in heroes)
        //    {
        //        string[] strSplit = Regex.Split(h.name, "npc_dota_hero_");
        //        hero.Add(new DotaHeroes() { })
        //    }
        //}
    }
}