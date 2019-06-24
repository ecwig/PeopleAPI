using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using PeopleApi.Models;
using MediatR;
using PeopleApi.Messages.Commands;
using PeopleApi.Messages.Queries;

namespace PeopleApi.Controllers
{
    /// <summary>
    /// Controller used to perform CRUD operations on people.
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor that seeds test data if none exists
        /// </summary>
        public PeopleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Deletes a Person.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /People/1
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>The requested Person</returns>
        /// <response code="204">Indicates that the person was deleted</response>
        /// <response code="404">If the person being deleted doesn't exist</response>    
        [HttpDelete("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<IActionResult> Delete(long id)
        {
            var person = await _mediator.Send(new DeletePersonCommand { });

            if (person == null)
            {
                return NotFound();
            }           

            return NoContent();
        }

        /// <summary>
        /// Gets a list of people.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /People
        ///
        /// </remarks>
        /// <returns>The requested people</returns>
        /// <response code="200">Returns the people requested</response>  
        /// <response code="404">If no people exist</response> 
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<IList<Person>>> Get()
        {
            return Ok(await _mediator.Send(new GetPeopleQuery()));
        }

        /// <summary>
        /// Gets a Person.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /People/1
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>The requested Person</returns>
        /// <response code="200">Returns the person requested</response>
        /// <response code="404">If the person being requested doesn't exist</response>          
        [HttpGet("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<Person>> Get(long id)
        {
            var person = await _mediator.Send(new GetPersonQuery { Id = id });

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        /// <summary>
        /// Creates a Person.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /People
        ///     {
        ///        "FirstName": "Big",
        ///        "LastName": "Bird",
        ///        "Address": "123 Sesame St",
        ///        "City": "New York City",
        ///        "State": "New York",
        ///        "Zip": "10128"
        ///     }
        ///
        /// </remarks>
        /// <param name="person"></param>
        /// <returns>A newly created Person</returns>
        /// <response code="201">Returns the newly created person</response>
        /// <response code="400">The person param is null</response>  
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult<Person>> Post(Person person)
        {
            var result = await _mediator.Send(
                new AddPersonCommand
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Address = person.Address,
                    City = person.City,
                    State = person.State,
                    Zip = person.Zip
                });
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        /// <summary>
        /// Updates a Person.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /People/1
        ///     {
        ///        "FirstName": "Big",
        ///        "LastName": "Bird",
        ///        "Address": "123 Sesame St",
        ///        "City": "New York City",
        ///        "State": "New York",
        ///        "Zip": "10128"
        ///     }
        ///
        /// </remarks>        
        /// <param name="id"></param>
        /// <param name="person"></param>
        /// <returns>An updated Person</returns>
        /// <response code="204">Indicates that the person was updated</response>
        /// <response code="400">The person being updated does not exist</response> 
        [HttpPut("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<IActionResult> Put(long id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(new UpdatePersonCommand { });
            return NoContent();
        }
                
        /*[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Find))]
        public async Task<IActionResult> Find(Person criteria)
        {
            return Ok(await _mediator.Send(new SearchPeopleQuery { Criteria = criteria }));
        }*/
    }
}