using SteamAPIWebApplication.CommonClasses;
using SteamAPIWebApplication.Models;
using SteamAPIWebApplication.Models.BasicContents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SteamAPIWebApplication.Controllers
{
    public class DotaItemsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: DotaItems
        public ActionResult Index()
        {
            List<DotaItems> items = new List<DotaItems>();
            if(db.items.ToList().Count()<=0)
            {
                items = clsCommon.GetIngameItems();
                db.items.AddRange(items);
                db.SaveChanges();
            }
            else
            {
                items = db.items.ToList();
            }
            return View(items);
        }
    }
}