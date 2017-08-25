using DotA2StatsParser.Model.Dotabuff.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotA2StatsParser.Model.Dotabuff;

namespace SteamAPIWebApplication.Dota2Parser
{
    public class ParseHeroes : IHero
    {
        public IEnumerable<IAbility> Abilities
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IHeroAttributes Attributes
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<Versus> BestVersus
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Heroes HeroEnum
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public byte[] Image
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<ILanePresence> LanePresence
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<AbilityBuild> MostPopularAbilityBuild
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<IItem> MostUsedItems
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IPopularity Popularity
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Reference
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<Roles> Roles
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IWinRate WinRate
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<Versus> WorstVersus
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        string IHero.Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}