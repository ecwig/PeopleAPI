using MediatR;
using PeopleApi.Messages.Queries;
using PeopleApi.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PeopleApi.Handlers.Queries
{
    public class SearchPersonHandler : IRequestHandler<SearchPeopleQuery, List<Person>>
    {
        public Task<List<Person>> Handle(SearchPeopleQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}