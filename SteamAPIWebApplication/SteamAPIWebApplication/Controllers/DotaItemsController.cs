using SteamAPIWebApplication.CommonClasses;
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
        // GET: DotaItems
        public ActionResult Index()
        {
            List<DotaItems> items = clsCommon.GetIngameItems();
            return View(items);
        }
    }
}