using System.Collections.Generic;
using System.Threading.Tasks;
using CryptaEcillas.Data;
using CryptaEcillas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CryptaEcillas.Controllers
{
    [ApiController]
    [Route("api/TestController")]
    public class TestController : ControllerBase
    {
        private readonly HeroDBContext _context;
        private readonly ILogger<TestController> _logger;

        
        public TestController(ILogger<TestController> logger, HeroDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Hero> users = _context.GetHeroes();
            return Ok(users);
        }
        [HttpPut("DoDmg/{id}&{id2}")]
        public async Task<IActionResult> DoDmg(int id,int id2)
        {
            var heroItem = await _context.heroList.FindAsync(id);
            var unitItem = await _context.unitList.FindAsync(id2);
            if (heroItem == null)
            {
                return NotFound();
            }
            heroItem.takeDamage(5);
            unitItem.takeDamage(1);

            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPut("SizeUp/{id}&{size}")]
        public async Task<IActionResult> UpdateHeroItem(int id,int size)
        {
 
            var unitItem = await _context.unitList.FindAsync(id);

            unitItem.sizeUp(size);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        
    }
}