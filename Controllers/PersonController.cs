using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SipayApi.Validators;
using SipayApi.Models;

namespace SipayApi.Controllers
{
    [ApiController]
    [Route("sipy/api/[controller]")]
     public class PersonController : ControllerBase
    {
        private readonly IValidator<Person> _validator;

        public PersonController(IValidator<Person> validator)
        {
            _validator = validator;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            var validationResult = _validator.Validate(person);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            return Ok(person);
        }
    }
}
