using System.Collections.Generic;
using System.Threading.Tasks;
using CryptaEcillas.Data;
using CryptaEcillas.Logic;
using CryptaEcillas.Models;
// using CryptaEcillas.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CryptaEcillas.Controllers
{
    [ApiController]
    [Route("api/HeroBattle")]
    public class HeroBattleController : ControllerBase
    {
        private readonly ILogger<HeroBattleController> _logger;
        private readonly HeroDBContext _context;

        public HeroBattleController(ILogger<HeroBattleController> logger, HeroDBContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        [HttpGet("{id1}&{id2}")]
        public List<BattleLog> StartFight(int id1, int id2)
        {
            Hero hero1 = _context.getHeroById(id1);
            Hero hero2 = _context.getHeroById(id2);

            BattleLogic battleLogic = new BattleLogic(); 

            return battleLogic.startBattle(hero1, hero2);
        }
    }
}