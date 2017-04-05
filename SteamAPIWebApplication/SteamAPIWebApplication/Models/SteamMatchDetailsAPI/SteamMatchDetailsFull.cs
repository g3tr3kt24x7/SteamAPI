using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamAPIWebApplication.Models.SteamMatchDetailsAPI
{
    public class SteamMatchDetailsFull
    {
        #region Matches
        public string match_id { get; set; }
        public string match_seq_num { get; set; }
        public DateTime start_time { get; set; }
        //-1 - Invalid
        //0 - Public matchmaking
        //1 - Practise
        //2 - Tournament
        //3 - Tutorial
        //4 - Co-op with bots.
        //5 - Team match
        //6 - Solo Queue
        //7 - Ranked Matchmaking
        //8 - 1v1 Solo Mid
        public string lobby_type { get; set; }
        #endregion
    }
}