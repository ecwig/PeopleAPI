using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PeopleApi.Messages.Queries;
using PeopleApi.Models;

namespace PeopleApi.Handlers.Queries
{
    public class GetPersonHandler : IRequestHandler<GetPersonQuery, Person>
    {
        public Task<Person> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}