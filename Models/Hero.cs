using System.Collections.Generic;

namespace CryptaEcillas.Models
{
    public class Hero
    {
        public int heroId { get; set; }
        public string name { get; set; }
        public string race { get; set; }
        public double hp { get; set; }
        public double mana { get; set; }
        public double dmg { get; set; }
        public List<Unit> units { get; set;}
        public void takeDamage(double dmg)
        {   
            this.hp -= dmg;
        }
        public Unit getUnitById(int id) 
        {
            Unit temp = units.Find(x => x.id == id);
            return temp;
        }
    }
}