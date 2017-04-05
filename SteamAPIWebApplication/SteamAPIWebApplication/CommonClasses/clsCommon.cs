using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamAPIWebApplication.CommonClasses
{
    public class clsCommon
    {
        public static DateTime ConvertUnixDateToDateTime(double unixDate)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            epoch = epoch.AddSeconds(unixDate).ToLocalTime();
            return epoch;
        }
    }
}