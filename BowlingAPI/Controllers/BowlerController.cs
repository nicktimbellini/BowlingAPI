using Microsoft.AspNetCore.Mvc;
using BowlingAPI.Data;
using BowlingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BowlingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BowlersController : ControllerBase
    {
        private readonly IBowlerRepository _repository;

        public BowlersController(IBowlerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bowler>>> GetBowlers()
        {
            var bowlers = await _repository.GetBowlers();
            return Ok(bowlers);
        }
    }
}
