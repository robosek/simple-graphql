using FirstGraphQL.Services;
using Microsoft.AspNetCore.Mvc;

namespace FirstGraphQL.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok(_personService.Get());
        }
    }
}