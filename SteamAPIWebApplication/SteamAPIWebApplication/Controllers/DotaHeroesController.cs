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
            List<DotaHeroes> heroes = FilterHeroName(clsCommon.GetHeroes(0));
            if(db.heroes.ToList().Count() <= 0)
            {
                db.heroes.AddRange(heroes);
                db.SaveChanges();
            }
            return View(heroes);
        }
        public List<DotaHeroes> FilterHeroName(List<DotaHeroes> heroes)
        {
            List<DotaHeroes> hero = new List<DotaHeroes>();
            foreach(var h in heroes)
            {
                string[] strSplit = Regex.Split(h.name, "npc_dota_hero_");
                string abc = strSplit[1].Replace("_", " ");
                TextInfo t = new CultureInfo("en-US", false).TextInfo;
                abc = t.ToTitleCase(abc);
                hero.Add(new DotaHeroes() { name = abc, id = h.id });
            }
            return hero;
            
        }
    }
}