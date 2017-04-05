using SteamAPIWebApplication.Models;
using SteamAPIWebApplication.Models.SteamNews;
using SteamAPIWebApplication.ViewModels;
using SteamKit2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SteamAPIWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //SteamUserProfile userProfile = new SteamUserProfile();
            //string steamid = SteamUserProfile.steamid;
            //string userName = SteamUserProfile.UserName;
            List<SteamNews> news = new List<SteamNews>();
            SteamHomeViewModel vmNews = new SteamHomeViewModel();
            using (dynamic steamNews = WebAPI.GetInterface("ISteamNews"))
            {
                KeyValue newsValue = steamNews.GetNewsForApp(appid: "570",count:7);
                foreach (KeyValue n in newsValue["newsitems"]["newsitem"].Children)
                {
                    news.Add(

                        new SteamNews
                        {
                            gid = Convert.ToInt64(n["gid"].Value.ToString()),
                            title = n["title"].Value.ToString(),
                            url = n["url"].Value.ToString(),
                            is_external_url = n["is_external_url"].Value.ToString(),
                            author = n["author"].Value.ToString(),
                            contents = n["contents"].Value.ToString(),
                            feedlabel = n["feedlabel"].Value.ToString(),
                            date = n["date"].Value.ToString(),
                            feedname = n["feedname"].Value.ToString()
                        }
                    );
                }
                vmNews.steamNews = news;
            }
            return View(vmNews);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}