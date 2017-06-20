using SteamAPIWebApplication.CommonClasses;
using SteamAPIWebApplication.Models.SteamNews;
using SteamAPIWebApplication.ViewModels;
using SteamAPIWebApplication.Models;
using SteamKit2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SteamAPIWebApplication.Controllers
{
    public class SteamVanityUserNameController : Controller
    {
        // GET: SteamVanityUserName
        public ActionResult Index()
        {
            SteamFriendsViewModel vwFriendsUser = new SteamFriendsViewModel();
            SteamVanityUserName svUserName = new SteamVanityUserName();
            List<SteamFriendsAPI> svFriends = new List<SteamFriendsAPI>();
            SteamPublicPersonalInfo svPersonalInfo = new SteamPublicPersonalInfo();
            List<SteamPublicPersonalInfo> svFriendsInfo = new List<SteamPublicPersonalInfo>();
            using (dynamic steamVanity = WebAPI.GetInterface("ISteamUser", "0E265171A60CF4F5263E677CEA8CE2B7"))
            {

                //KeyValue kvVanity = steamVanity.ResolveVanityURL(vanityurl: svUser.vanityUserName.VanityUserName);
                //foreach (var k in kvVanity.Children)
                //{
                //    //svUserName.Add(new SteamVanityUserName { SteamId = k.Value.ToString() });
                //    if (k.Name.ToString().ToLower() == "steamid")
                //        svUserName.SteamId = k.Value.ToString();
                //}
                KeyValue kvFriends = steamVanity.GetFriendList(steamid: SteamUserProfile.steamid, relationship: "all");
                foreach (KeyValue k in kvFriends["friends"].Children)
                {
                    SteamFriendsAPI friends = new SteamFriendsAPI()
                    {
                        steamid = k["steamid"].Value.ToString(),
                        relationship = k["relationship"].Value.ToString(),
                        //friendsince = k["friend_since"].ToString(),
                        friend_since = clsCommon.ConvertUnixDateToDateTime(Convert.ToDouble(k["friend_since"].Value.ToString())).ToString("dd-MMM-yyyy")
                    };
                    svFriends.Add(friends);

                }
                KeyValue kvProfile = steamVanity.GetPlayerSummaries(steamids: SteamUserProfile.steamid);
                foreach (KeyValue k in kvProfile["players"]["player"].Children)
                {
                    svPersonalInfo.personaname = k["personaname"].Value.ToString();
                    svPersonalInfo.personastate = clsCommon.FilterPersonalState(k["personastate"].Value.ToString());
                    svPersonalInfo.profileurl = k["profileurl"].Value.ToString();
                    svPersonalInfo.profilestate = k["profilestate"].Value.ToString();
                    svPersonalInfo.avatar = k["avatar"].Value.ToString();
                    svPersonalInfo.avatarfull = k["avatarfull"].Value.ToString();
                    svPersonalInfo.avatarmedium = k["avatarmedium"].Value.ToString();
                    svPersonalInfo.communityvisibilitystate = k["communityvisibilitystate"].Value.ToString();
                    svPersonalInfo.lastlogoff = k["lastlogoff"].Value.ToString();
                    svPersonalInfo.steamid = k["steamid"].Value.ToString();
                }
                for (int i = 0; i < svFriends.Count; i++)
                {
                    KeyValue kvFriendsProfile = steamVanity.GetPlayerSummaries(steamids: svFriends[i].steamid);
                    foreach (KeyValue kProf in kvFriendsProfile["players"]["player"].Children)
                    {
                        SteamPublicPersonalInfo kFriends = new SteamPublicPersonalInfo()
                        {
                            personaname = kProf["personaname"].Value.ToString(),
                            personastate = kProf["personastate"].Value.ToString(),
                            profileurl = kProf["profileurl"].Value.ToString(),
                            //profilestate = kProf["profilestate"].Value.ToString()??"",
                            avatar = kProf["avatar"].Value.ToString(),
                            avatarfull = kProf["avatarfull"].Value.ToString(),
                            avatarmedium = kProf["avatarmedium"].Value.ToString(),
                            communityvisibilitystate = kProf["communityvisibilitystate"].Value.ToString(),
                            lastlogoff = kProf["lastlogoff"].Value.ToString(),
                            steamid = kProf["steamid"].Value.ToString(),
                        };
                        svFriendsInfo.Add(kFriends);
                    }
                }
                vwFriendsUser.vanityUserName = svUserName;
                vwFriendsUser.FriendsList = svFriends;
                vwFriendsUser.svPersonalInfo = svPersonalInfo;
                vwFriendsUser.svFriendsInfo = svFriendsInfo;
            }

            return View(vwFriendsUser);
        }
    }
}