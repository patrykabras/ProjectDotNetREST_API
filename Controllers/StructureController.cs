using System.Collections.Generic;
using System.Threading.Tasks;
using CryptaEcillas.Data;
using CryptaEcillas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CryptaEcillas.Controllers
{
    [ApiController]
    [Route("api/Structure")]
    public class StructureController : ControllerBase
    {
        private readonly MockStructureEnum _context;
        private readonly ILogger<StructureController> _logger;

        
        public StructureController(ILogger<StructureController> logger, MockStructureEnum context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var structures = _context.getStructureEnum();
            return Ok(structures);
        }

    }
}