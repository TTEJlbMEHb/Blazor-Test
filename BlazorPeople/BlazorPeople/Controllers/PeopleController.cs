using BlazorPeople.Domain.Entity;
using BlazorPeople.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlazorPeople.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PeopleController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPeople()
        {
            var responce = await _personService.GetPeople();
            return Ok(responce);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            var responce = await _personService.GetPerson(id);
            return Ok(responce);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson(Person person)
        {
            var responce = await _personService.CreatePerson(person);
            return Ok(responce);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePerson(Person person)
        {
            var responce = await _personService.UpdatePerson(person);
            return Ok(responce);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var responce = await _personService.DeletePerson(id);
            return Ok(responce);
        }
    }
}
