using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleApi.Models;

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
        private readonly PersonContext _context;

        /// <summary>
        /// Constructor that seeds test data if none exists
        /// </summary>
        public PeopleController(PersonContext context)
        {
            _context = context;

            if (_context.People.Count() == 0)
            {
                // Create a new Person if collection is empty so that a person always exists
                _context.People.Add(
                    new Person 
                    { 
                        FirstName = "Bobby", 
                        LastName = "Boucher",  
                        Address = "123 Mud Dog Blvd",
                        City = "South Central",
                        State = "Louisiana",
                        Zip = "71111"
                    });
                _context.SaveChanges();
            }
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
            var person = await _context.People.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            _context.People.Remove(person);
            await _context.SaveChangesAsync();

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
        public async Task<ActionResult<IEnumerable<Person>>> Get() => await _context.People.ToListAsync();

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
            var person = await _context.People.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
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
            _context.People.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = person.Id }, person);
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

            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}