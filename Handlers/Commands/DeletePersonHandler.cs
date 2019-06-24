using MediatR;
using PeopleApi.Messages.Commands;
using PeopleApi.Models;
using System.Threading;
using System.Threading.Tasks;

namespace PeopleApi.Handlers.Command
{
    public class DeletePersonHandler : IRequestHandler<DeletePersonCommand, Person>
    {
        public Task<Person> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}