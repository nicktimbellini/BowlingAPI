using BowlingAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingAPI.Data
{
    public class BowlerRepository : IBowlerRepository
    {
        private readonly BowlingContext _context;

        public BowlerRepository(BowlingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Bowler>> GetBowlers()
        {
            return await _context.Bowlers
                .Include(b => b.Team)
                .Where(b => b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks")
                .ToListAsync();
        }
    }
}
