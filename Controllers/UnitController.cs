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
    [Route("api/Unit")]
    public class UnitController : ControllerBase
    {
        private readonly ILogger<UnitController> _logger;
        private readonly HeroDBContext _context;

        public UnitController(ILogger<UnitController> logger, HeroDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpDelete("{unitId}")]
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
        [HttpPut("IncreasedUnitSize/heroId={heroId}&unitId={unitId}&unitSize={unitSize}")]
        public async Task<IActionResult> IncreasedUnitSize(int heroId, int unitId, int unitSize)
        {
            var unitItem = await _context.unitList.FindAsync(unitId);
            unitItem.sizeUp(unitSize);

            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPut("DecreasedUnitSize/heroId={heroId}&unitId={unitId}&unitSize={unitSize}")]
        public async Task<IActionResult> DecreasedUnitSize(int heroId, int unitId, int unitSize)
        {
            var unitItem = await _context.unitList.FindAsync(unitId);
            unitItem.sizeDown(unitSize);

            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}