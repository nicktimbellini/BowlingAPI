using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BowlingAPI.Data;
using BowlingAPI.Models;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BowlersController : ControllerBase
    {
        private readonly BowlingContext _context;

        public BowlersController(BowlingContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetBowlers()
        {
            var filteredBowlers = await _context.Bowlers
                .Include(b => b.Team)
                .Where(b => b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks")
                .Select(b => new
                {
                    b.BowlerFirstName,
                    b.BowlerMiddleInit,
                    b.BowlerLastName,
                    TeamName = b.Team.TeamName,
                    b.BowlerAddress,
                    b.BowlerCity,
                    b.BowlerState,
                    b.BowlerZip,
                    b.BowlerPhoneNumber
                })
                .ToListAsync();

            return Ok(filteredBowlers);
        }
    }
}
