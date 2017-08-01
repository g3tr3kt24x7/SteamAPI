using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamAPIWebApplication.Models.SteamMatchDetailsAPI
{
    public class SteamMatchDetailByID
    {
        public string id { get; set; }
        public string accountid { get; set; }
        public string player_slot { get; set; }
        public string hero_id { get; set; }
        public string hero_image { get; set; }
        public string item_0 { get; set; }
        //ID of the top-left inventory item.
        public string item_1 { get; set; }
        //ID of the top-center inventory item.
        public string item_2 { get; set; }
        //ID of the top-right inventory item.
        public string item_3 { get; set; }
        //ID of the bottom-left inventory item.
        public string item_4 { get; set; }
        //ID of the bottom-center inventory item.
        public string item_5 { get; set; }
        //ID of the bottom-right inventory item.
        public string kills { get; set; }
        //The amount of kills attributed to this player.
        public string deaths { get; set; }
        //The amount of times this player died during the match.
        public string assists { get; set; }
        //The amount of assists attributed to this player.
        public string gold { get; set; }
        //The amount of gold the player had remaining at the end of the match.
        public string last_hits { get; set; }
        //The amount of last-hits the player got during the match.
        public string denies { get; set; }
        //The amount of denies the player got during the match.
        public string gold_per_min { get; set; }
        //The player's overall gold/minute.
        public string xp_per_min { get; set; }
        //The player's overall experience/minute.
        public string gold_spent { get; set; }
        //The amount of gold the player spent during the match.
        public string hero_damage { get; set; }
        //The amount of damage the player dealt to heroes.
        public string tower_damage { get; set; }
        //The amount of damage the player dealt to towers.
        public string hero_healing { get; set; }
        //The amount of health the player had healed on heroes.
        public string level { get; set; }
        //The player's level at match end.
        public string radiant_win { get; set; }
        //Dictates the winner of the match, true for radiant; false for dire.
        public string duration { get; set; }
        //      The length of the match, in seconds since the match began.
        public string start_time { get; set; }
        //Unix timestamp of when the match began.
        public string match_id { get; set; }
        //The matches unique ID.
        public string match_seq_num { get; set; }
        //A 'sequence number', representing the order in which matches were recorded.
        public string tower_status_radiant { get; set; }
        //See #Tower Status below.
        public string tower_status_dire { get; set; }
        //See #Tower Status below.
        public string barracks_status_radiant { get; set; }
        //See #Barracks Status below.
        public string barracks_status_dire { get; set; }
        //See #Barracks Status below.
        public string cluster { get; set; }
        //       The server cluster the match was played upon.Used for downloading replays of matches.
        public string first_blood_time { get; set; }
        //     The time in seconds since the match began when first-blood occurred.
        public string flags { get; set; }
        public string engine { get; set; }
        //0 - Source 1
        //1 - Source 2
        public string radiant_score { get; set; }
        public string dire_score { get; set; }
        public string game_mode { get; set; }
        //0 - None
        //1 - All Pick
        //2 - Captain's Mode
        //3 - Random Draft
        //4 - Single Draft
        //5 - All Random
        //6 - Intro
        //7 - Diretide
        //8 - Reverse Captain's Mode
        //9 - The Greeviling
        //10 - Tutorial
        //11 - Mid Only
        //12 - Least Played
        //13 - New Player Pool
        //14 - Compendium Matchmaking
        //15 - Co-op vs Bots
        //16 - Captains Draft
        //18 - Ability Draft
        //20 - All Random Deathmatch
        //21 - 1v1 Mid Only
        //22 - Ranked Matchmaking
        //picks_bans
        //A list of the picks and bans in the match, if the game mode is Captains Mode.
        //is_pick
        //Whether this entry is a pick (true) or a ban(false).
        //hero_id
        //The hero's unique ID. A list of hero IDs can be found via the GetHeroes method.
        //team
        //The team who chose the pick or ban; 0 for Radiant, 1 for Dire.
        //order
        //The order of which the picks and bans were selected; 0-19.
        public string lobby_type { get; set; }
        //-1 - Invalid
        //0 - Public matchmaking
        //1 - Practise
        //2 - Tournament
        //3 - Tutorial
        //4 - Co-op with bots.
        //5 - Team match
        //6 - Solo Queue
        //7 - Ranked
        //8 - 1v1 Mid
        //        ability_upgrades
        //        A list detailing a player's ability upgrades.
        //ability
        //ID of the ability upgraded.
        //time
        //Time since match start that the ability was upgraded.
        //level
        //The level of the player at time of upgrading.
        //additional_units
        //Additional playable units owned by the player.
        //unitname
        //The name of the unit
        //item_0
        //ID of the top-left inventory item.
        //item_1
        //ID of the top-center inventory item.
        //item_2
        //ID of the top-right inventory item.
        //item_3
        //ID of the bottom-left inventory item.
        //item_4
        //ID of the bottom-center inventory item.
        //item_5
        //ID of the bottom-right inventory item.
        public string leaver_status { get; set; }
        //0 - NONE - finished match, no abandon.
        //1 - DISCONNECTED - player DC, no abandon.
        //2 - DISCONNECTED_TOO_LONG - player DC > 5min, abandoned.
        //3 - ABANDONED - player DC, clicked leave, abandoned.
        //4 - AFK - player AFK, abandoned.
        //5 - NEVER_CONNECTED - player never connected, no abandon.
        //6 - NEVER_CONNECTED_TOO_LONG - player took too long to connect, no abandon.
        public string backpack_0 { get; set; }
        public string backpack_1 { get; set; }
        public string backpack_2 { get; set; }

    }
}