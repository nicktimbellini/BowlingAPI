using BowlingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BowlingAPI.Data
{
    public interface IBowlerRepository
    {
        Task<IEnumerable<Bowler>> GetBowlers();
    }
}
