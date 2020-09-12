using System.Collections.Generic;
using System.Threading.Tasks;
using CryptaEcillas.Data;
using CryptaEcillas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CryptaEcillas.Controllers
{
    [ApiController]
    [Route("api/MockUnitType")]
    public class MockUnitTypeController : ControllerBase
    {
        private readonly MockUnitType _context;
        private readonly ILogger<MockUnitTypeController> _logger;

        
        public MockUnitTypeController(ILogger<MockUnitTypeController> logger, MockUnitType context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Unit> unitTypes = (List<Unit>)_context.getUnitsType();
            return Ok(unitTypes);
        }
        
    }
}