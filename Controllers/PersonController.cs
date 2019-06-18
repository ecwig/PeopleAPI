using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleApi.Models;

namespace PeopleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PersonContext _context;

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

        // DELETE: api/People/5
        [HttpDelete("{id}")]
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

        //GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> Get() => await _context.People.ToListAsync();

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> Get(long id)
        {
            var person = await _context.People.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        // POST: api/People
        [HttpPost]
        public async Task<ActionResult<Person>> Post(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = person.Id }, person);
        }

        // PUT: api/People/5
        [HttpPut("{id}")]
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