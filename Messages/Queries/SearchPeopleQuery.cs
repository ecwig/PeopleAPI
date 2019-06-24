using MediatR;
using PeopleApi.Models;
using System.Collections.Generic;

namespace PeopleApi.Messages.Queries
{
    public class SearchPeopleQuery : IRequest<List<Person>>
    {
        public Person Criteria { get; set; }
    }
}