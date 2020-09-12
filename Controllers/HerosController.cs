using System.Collections.Generic;
using System.Threading.Tasks;
using CryptaEcillas.Data;
using CryptaEcillas.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CryptaEcillas.Controllers
{
    [ApiController]
    [Route("api/Hero")]
    public class HerosController : ControllerBase
    {
        private readonly ILogger<HerosController> _logger;
        private readonly HeroDBContext _context;

        public HerosController(ILogger<HerosController> logger, HeroDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllHeroes()
        {
            List<Hero> users = _context.GetHeroes();
            return Ok(users);
        }
        [HttpPost]
        public IActionResult AddHero([FromBody] Hero hero)
        {
            _logger.LogInformation("Add Hero for HeroID: {}", hero.heroId);
            _context.addHero(hero);
            return Ok(hero);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hero>> DeleteHero(int id)
        {
            var todoItem = await _context.heroList.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.heroList.Remove(todoItem);
            await _context.SaveChangesAsync();

            return todoItem;
        }


        [HttpDelete("deleteUnitFromHero/unit={unitId}")]
        public async Task<ActionResult<Unit>> deleteUnitFromHero(int unitId)
        {
            var unitItem = await _context.unitList.FindAsync(unitId);
            if (unitItem == null)
            {
                return NotFound();
            }

            _context.unitList.Remove(unitItem);
            await _context.SaveChangesAsync();

            return unitItem;
        }
        [HttpPut("addUnitToHero/{id}")]
        public async Task<IActionResult> addUnitToHero(int id,Unit unit){
            var heroItem = await _context.heroList.FindAsync(id);
            List<Unit> heroUnits = new List<Unit>();

            heroUnits.Add(new Unit
            {
                size = unit.size,
                name = unit.name,
                race = unit.race,
                hp = unit.hp,
                mana = unit.mana,
                dmg = unit.dmg
            });
            heroItem.units = heroUnits;

            await _context.SaveChangesAsync();
            
            return NoContent();
        }
        
    }
}