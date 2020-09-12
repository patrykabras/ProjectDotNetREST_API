using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CryptaEcillas.Models
{
    public class HeroDBContext : DbContext
    {
        public DbSet<Hero> heroList { get; set; }
        public DbSet<Unit> unitList { get; set; }

        public HeroDBContext(DbContextOptions<HeroDBContext> options) : base(options)
        {
            // loadFirstData();
            // this.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>()
            .HasMany(p => p.units)
            .WithOne();
        }
        public List<Hero> GetHeroes() => heroList.Include(c => c.units).ToList();
        public Hero getHeroById(int id)
        {
            return GetHeroes().Find(h => h.heroId == id);
        }
        public void addHero(Hero hero)
        {
            heroList.Add(hero);
            this.SaveChanges();
            return;
        }

        public bool checkIfHeroHaveUnitByName(string name)
        {
            return GetHeroes().Exists(u => u.name == name);
        }
        private void loadFirstData()
        {
            Hero temp = new Hero
            {
                heroId = 0,
                name = "Heronim",
                race = "Human",
                hp = 100,
                mana = 100,
                dmg = 10,
            };
            List<Unit> tempList = new List<Unit>();
            tempList.Add(new Unit
            {
                id = 0,
                size = 10,
                name = "Archer",
                race = "Human",
                hp = 10,
                mana = 0,
                dmg = 5,
            });
            tempList.Add(new Unit
            {
                id = 0,
                size = 10,
                name = "Knight",
                race = "Human",
                hp = 20,
                mana = 0,
                dmg = 2,
            });
            temp.units = tempList;

            heroList.Add(temp);
        }
    }
}