using System.Collections.Generic;
using CryptaEcillas.Models;

namespace CryptaEcillas.Data
{
    public class MockStructureEnum
    {
        public IEnumerable<Structure> getStructureEnum()
        {
            var structures = new List<Structure>
            {
                new Structure{
                id = 1,
                name = "Fort",
                race = "Human",
                cost = 100
                },
                new Structure{
                id = 2,
                name = "Village Hall",
                race = "Human",
                cost = 100
                },
                new Structure{
                id = 3,
                name = "Wall",
                race = "Human",
                cost = 100
                }
            };
            return structures;
        }
        public Structure GetStructureBytId(int id){
            List<Structure> list = (List<Structure>)getStructureEnum();

            return list.Find(s => s.id == id);
        }
    }
}