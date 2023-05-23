using InterviewTest.Models;
using InterviewTest.Repositories.Wrappers;
using InterviewTest.ValidationFilters;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonRepositoryWrapper _repositoryWrapper;

        public PeopleController(IPersonRepositoryWrapper repositoryWrapper)

        {
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> Get(string? filter)
        {
            var result = !string.IsNullOrEmpty(filter) ?
                await _repositoryWrapper.SearchAsync(p => p.LastName.ToLower().Contains(filter.ToLower()) || p.FirstName.ToLower().Contains(filter.ToLower()))
                :
                await _repositoryWrapper.GetAllAsync();
            return result.ToList();
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationModelAttribute))]
        public async Task<ActionResult> Create([FromBody]Person person)
        {
            var result = await _repositoryWrapper.CreateAsync(person);
            return Ok(result);
        }

        [HttpPatch]
        [ServiceFilter(typeof(ValidationModelAttribute))]
        public async Task<ActionResult> Patch([FromBody] Person person)
        {
            var result = await _repositoryWrapper.UpdateAsync(person);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> Patch(long id)
        {
            var result = await _repositoryWrapper.RemoveAsync(id);
            return Ok(result);
        }
    }
}
