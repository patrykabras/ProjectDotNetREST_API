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
    [Route("api/UnitToHero")]
    public class UnitToHeroController : ControllerBase
    {
        private readonly ILogger<UnitToHeroController> _logger;
        private readonly HeroDBContext _context;

        public UnitToHeroController(ILogger<UnitToHeroController> logger, HeroDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPut("AddUnitToHero/{heroId}&{unitTypeId}&{unitSize}")]
        public async Task<IActionResult> addUnitToHeroT(int heroId, int unitTypeId, int unitSize)
        {
            MockUnitType mockUnitType = new MockUnitType();
            Unit unitTemp = mockUnitType.getUnitTypeById(unitTypeId);
            var heroItem = await _context.heroList.FindAsync(heroId);

            List<Unit> heroUnits = new List<Unit>();
            heroUnits.Add(new Unit
            {
                size = unitSize,
                name = unitTemp.name,
                race = unitTemp.race,
                hp = unitTemp.hp,
                mana = unitTemp.mana,
                dmg = unitTemp.dmg,
                range = unitTemp.range
            });
            heroItem.units = heroUnits;

            await _context.SaveChangesAsync();

            return NoContent();
        }
        
    }
}