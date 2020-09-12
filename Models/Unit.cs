using System.ComponentModel.DataAnnotations.Schema;

namespace CryptaEcillas.Models
{
    public class Unit
    {
        public int id { get; set; }
        public int size { get; set; }
        public string name { get; set; }
        public string race { get; set; }
        public double hp { get; set; }
        public double mana { get; set; }
        public double dmg { get; set; }
        public double range { get; set; }

        public void takeDamage(double dmg)
        {
            this.hp -= dmg;
        }
        public void sizeUp(int sizeOfArmy)
        {
            this.size += sizeOfArmy;
        }
        public void sizeDown(int sizeOfArmy)
        {
            if (!(this.size - sizeOfArmy < 0))
            {
                this.size -= sizeOfArmy;
            }
            else
            {
                this.size = 0;
            }
        }

        public string toStringCustom()
        {
            return "id: " + id + ", size: " + size +", name: " + name + ", race: " + race + ", hp: " + hp + ", mana: " + mana + ", dmg: " + dmg;
        }
    }
}