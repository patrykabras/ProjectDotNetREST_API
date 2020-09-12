using System.Collections.Generic;
using CryptaEcillas.Models;

namespace CryptaEcillas.Data
{
    public class MockUnitType
    {
        public IEnumerable<Unit> getUnitsType()
        {
            var units = new List<Unit>
            {
                new Unit{
                id = 1,
                size = 10,
                name = "Rustic",
                race = "Human",
                hp = 10,
                mana = 0,
                dmg = 1
                },
                new Unit{
                id = 2,
                size = 10,
                name = "Knight",
                race = "Human",
                hp = 70,
                mana = 0,
                dmg = 1
                },
                new Unit{
                id = 3,
                size = 10,
                name = "Archer",
                race = "Human",
                hp = 20,
                mana = 0,
                dmg = 5
                },
                new Unit{
                id = 4,
                size = 10,
                name = "Crusader",
                race = "Human",
                hp = 50,
                mana = 0,
                dmg = 5
                },
            };
            return units;
        }
        public Unit getUnitTypeById(int id)
        {
            List<Unit> list = (List<Unit>) getUnitsType();

            return list.Find(u => u.id == id);
        }
    }
}