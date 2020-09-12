using System.Collections.Generic;

namespace CryptaEcillas.Models
{
    public class BattleLog
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<Hero> heroStats { get; set; }
        public BattleLog(int id, string name, string description, List<Hero> herolist)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.heroStats = herolist;
        }
    }
}