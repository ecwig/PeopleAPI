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
    /// Controller used to search operations on people.
    /// </summary>
    [Produces("application/json")]
    [Route("api/Person/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor that injects Mediator
        /// </summary>
        public SearchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Find))]
        public async Task<IActionResult> Find(Person criteria)
        {
            return Ok(await _mediator.Send(new SearchPeopleQuery { Criteria = criteria }));
        }
    }
}