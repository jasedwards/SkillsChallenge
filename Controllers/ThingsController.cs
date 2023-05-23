using InterviewTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InterviewTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThingsController : ControllerBase
    {
      

        private readonly ILogger<ThingsController> _logger;
        private readonly ThingContext _context;

        public ThingsController(ILogger<ThingsController> logger, ThingContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Thing>>> Get(string? filter)
        {
            if (!string.IsNullOrEmpty(filter))
            {
                return await _context.Set<Thing>().Where(p => p.Name.ToLower().Contains(filter.ToLower()) || p.Description.ToLower().Contains(filter.ToLower())).ToListAsync();
            }

            return await _context.Set<Thing>().ToListAsync();
        }
    }
}
