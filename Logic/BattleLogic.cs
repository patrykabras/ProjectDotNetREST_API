using System;
using System.Collections.Generic;
using CryptaEcillas.Data;
using CryptaEcillas.Models;

namespace CryptaEcillas.Logic
{
    public class BattleLogic
    {
        private double hpDoneNow;
        private int unitSizeDownNow;

        public List<BattleLog> startBattle(Hero hero1, Hero hero2)
        {
            Hero heroFirst = hero1;
            Hero heroSecound = hero2;
            List<BattleLog> fightLogList = new List<BattleLog>();
            List<string> fightLog = new List<string>();
            Random randome = new Random();

            List<int> listOfUnitsIdFromHero1 = new List<int>();
            List<int> listOfUnitsIdFromHero2 = new List<int>();

            foreach (Unit u in hero1.units)
            {
                listOfUnitsIdFromHero1.Add(u.id);
            }
            foreach (Unit u in hero2.units)
            {
                listOfUnitsIdFromHero2.Add(u.id);
            }

            listOfUnitsIdFromHero1 = ShuffleUnit(listOfUnitsIdFromHero1);
            listOfUnitsIdFromHero2 = ShuffleUnit(listOfUnitsIdFromHero2);

            bool isHero1HaveAliveUnits = true;
            bool isHero2HaveAliveUnits = true;
            bool gameOver = false;
            int heroNow = randome.Next(2);
            int hero1unitNow = 0;
            int hero2unitNow = 0;
            int round = 0;
            string description = "";
            Hero temp1hero = hero1;
            Hero temp2hero = hero2;
            while (!gameOver)
            {
                round++;
                description = "";
                int hero1UnitCount = hero1.units.Count;
                int hero2UnitCount = hero2.units.Count;
                if (heroNow == 0)
                {//Units From Hero1 Attack
                    heroNow = 1;

                    int deffUnitID = listOfUnitsIdFromHero2[randome.Next(listOfUnitsIdFromHero2.Count)];
                    int attackUnitId = listOfUnitsIdFromHero1[hero1unitNow];

                    Unit unitAttack = hero1.units.Find(u => u.id == attackUnitId);

                    Unit unitDeff = hero2.units.Find(u => u.id == deffUnitID);

                    unitDeff = unitFight(unitAttack, unitDeff);

                    description = "#"+ hero1.heroId +" " +hero1.name + " : #" + unitAttack.id + " " + unitAttack.name + "  ATTACKED #"+ hero2.heroId + " " + hero2.name + " : #" + unitDeff.id + " " + unitDeff.name + " | DONE -" + unitSizeDownNow + " size AND -" + hpDoneNow + "hp";

                    if (unitDeff.size == 0)
                    {
                        hero2.units.Remove(hero2.units.Find(u => u.id == deffUnitID));
                        listOfUnitsIdFromHero2.Remove(deffUnitID);
                    }
                    else
                    {
                        hero2.units.Find(u => u.id == deffUnitID).size = unitDeff.size;
                        hero2.units.Find(u => u.id == deffUnitID).hp = unitDeff.hp;
                    }

                    List<Unit> tempUnitListForHero = new List<Unit>();

                    foreach (Unit u in hero2.units)
                    {
                        tempUnitListForHero.Add(new Unit
                        {
                            id = u.id,
                            size = u.size,
                            name = u.name,
                            race = u.race,
                            hp = u.hp,
                            mana = u.mana,
                            dmg = u.dmg,
                            range = u.range
                        });
                    }
                    heroSecound = new Hero
                    {
                        heroId = hero2.heroId,
                        name = hero2.name,
                        race = hero2.race,
                        hp = hero2.hp,
                        mana = hero2.mana,
                        dmg = hero2.dmg,
                        units = tempUnitListForHero
                    };
                    List<Unit> tempUnitListForHero1 = new List<Unit>();

                    foreach (Unit u in hero1.units)
                    {
                        tempUnitListForHero1.Add(new Unit
                        {
                            id = u.id,
                            size = u.size,
                            name = u.name,
                            race = u.race,
                            hp = u.hp,
                            mana = u.mana,
                            dmg = u.dmg,
                            range = u.range
                        });
                    }
                    heroFirst = new Hero
                    {
                        heroId = hero1.heroId,
                        name = hero1.name,
                        race = hero1.race,
                        hp = hero1.hp,
                        mana = hero1.mana,
                        dmg = hero1.dmg,
                        units = tempUnitListForHero1
                    };

                    hero1unitNow++;
                }
                else
                {//Units From Hero2 Attack
                    heroNow = 0;


                    int deffUnitID = listOfUnitsIdFromHero1[randome.Next(listOfUnitsIdFromHero1.Count)];
                    int attackUnitId = listOfUnitsIdFromHero2[hero2unitNow];

                    Unit unitAttack = hero2.units.Find(u => u.id == attackUnitId);

                    Unit unitDeff = hero1.units.Find(u => u.id == deffUnitID);

                    unitDeff = unitFight(unitAttack, unitDeff);

                    description = "#"+ hero2.heroId +" " +hero2.name + " : #" + unitAttack.id + " " + unitAttack.name + "  ATTACKED #"+ hero1.heroId + " " + hero1.name + " : #" + unitDeff.id + " " + unitDeff.name + " | DONE -" + unitSizeDownNow + " size AND -" + hpDoneNow + "hp";

                    if (unitDeff.size == 0)
                    {
                        hero1.units.Remove(hero1.units.Find(u => u.id == deffUnitID));
                        listOfUnitsIdFromHero1.Remove(deffUnitID);
                    }
                    else
                    {
                        hero1.units.Find(u => u.id == deffUnitID).size = unitDeff.size;
                        hero1.units.Find(u => u.id == deffUnitID).hp = unitDeff.hp;
                    }

                    List<Unit> tempUnitListForHero = new List<Unit>();

                    foreach (Unit u in hero1.units)
                    {
                        tempUnitListForHero.Add(new Unit
                        {
                            id = u.id,
                            size = u.size,
                            name = u.name,
                            race = u.race,
                            hp = u.hp,
                            mana = u.mana,
                            dmg = u.dmg,
                            range = u.range
                        });
                    }
                    heroFirst = new Hero
                    {
                        heroId = hero1.heroId,
                        name = hero1.name,
                        race = hero1.race,
                        hp = hero1.hp,
                        mana = hero1.mana,
                        dmg = hero1.dmg,
                        units = tempUnitListForHero
                    };

                    List<Unit> tempUnitListForHero2 = new List<Unit>();

                    foreach (Unit u in hero2.units)
                    {
                        tempUnitListForHero2.Add(new Unit
                        {
                            id = u.id,
                            size = u.size,
                            name = u.name,
                            race = u.race,
                            hp = u.hp,
                            mana = u.mana,
                            dmg = u.dmg,
                            range = u.range
                        });
                    }
                    heroSecound = new Hero
                    {
                        heroId = hero2.heroId,
                        name = hero2.name,
                        race = hero2.race,
                        hp = hero2.hp,
                        mana = hero2.mana,
                        dmg = hero2.dmg,
                        units = tempUnitListForHero2
                    };
                    hero2unitNow++;
                }

                List<Hero> tempListHero = new List<Hero>();

                tempListHero.Clear();
                tempListHero.Add(heroFirst);
                tempListHero.Add(heroSecound);
                fightLogList.Add(new BattleLog(round, "Round: " + round, description, tempListHero));


                if (hero1unitNow >= listOfUnitsIdFromHero1.Count)
                {
                    hero1unitNow = 0;
                }
                if (hero2unitNow >= listOfUnitsIdFromHero2.Count)
                {
                    hero2unitNow = 0;
                }

                isHero1HaveAliveUnits = checkIfHeroHaveAliveUnits(hero1);
                isHero2HaveAliveUnits = checkIfHeroHaveAliveUnits(hero2);
                if ((isHero1HaveAliveUnits && !isHero2HaveAliveUnits) || (!isHero1HaveAliveUnits && isHero2HaveAliveUnits))
                {
                    gameOver = true;
                }

            }

            return fightLogList;
        }

        private Unit unitFight(Unit unitAttack, Unit unitDeff)
        {
            unitSizeDownNow = 0;
            hpDoneNow = 0;
            MockUnitType unitEnum = new MockUnitType();
            List<Unit> unitList = (List<Unit>)unitEnum.getUnitsType();
            double totalMaxHP = unitList.Find(u => u.name == unitDeff.name).hp;
            for (int i = 0; i < unitAttack.size; i++)
            {
                if (unitDeff.hp - unitAttack.dmg <= 0)
                {
                    double hpLeft = unitAttack.dmg - unitDeff.hp;
                    unitDeff.sizeDown(1);
                    unitSizeDownNow++;
                    unitDeff.hp = totalMaxHP - hpLeft;
                }
                else
                {
                    unitDeff.hp = unitDeff.hp - unitAttack.dmg;
                }
            }
            hpDoneNow = totalMaxHP - unitDeff.hp;
            return unitDeff;
        }

        private bool checkIfHeroHaveAliveUnits(Hero hero)
        {
            bool isAlive = true;
            if (hero.units.Count == 0) isAlive = false;
            return isAlive;
        }
        private List<int> ShuffleUnit(List<int> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }
    }
}