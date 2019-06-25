using MediatR;
using Microsoft.AspNetCore.Mvc;
using PeopleApi.Models;
using System.Collections.Generic;

namespace PeopleApi.Messages.Queries
{
    public class SearchPeopleQuery : IRequest<List<Person>>
    {
        [FromQuery]
        public string FirstName { get; set; }

        [FromQuery]
        public string LastName { get; set; }

        [FromQuery]
        public string Address { get; set; }

        [FromQuery]
        public string City { get; set; }

        [FromQuery]
        public string State { get; set; }

        [FromQuery]
        public string Zip { get; set; }
    }
}