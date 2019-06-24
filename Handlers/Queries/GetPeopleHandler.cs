using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PeopleApi.Messages.Queries;
using PeopleApi.Models;

namespace PeopleApi.Handlers.Queries
{
    public class GetPeopleHandler : IRequestHandler<GetPeopleQuery, IList<Person>>
    {
        public Task<IList<Person>> Handle(GetPeopleQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}