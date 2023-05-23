using InterviewTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InterviewTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
       private readonly PlaceContext _context;

        private readonly ILogger<PlacesController> _logger;

        public PlacesController(ILogger<PlacesController> logger, PlaceContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Place>>> Get(string? filter)
        {
            if (!string.IsNullOrEmpty(filter))
            {
                return await _context.Set<Place>().Where(p => p.Name.ToLower().Contains(filter.ToLower()) || p.City.ToLower().Contains(filter.ToLower()) || p.State.ToLower().Contains(filter.ToLower())).ToListAsync();
            }

            return await _context.Set<Place>().ToListAsync();
        }
    }
}
