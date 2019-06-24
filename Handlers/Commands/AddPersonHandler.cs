using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PeopleApi.Messages.Commands;
using PeopleApi.Models;

namespace PeopleApi.Handlers.Command
{
    public class AddPersonHandlerAsync : IRequestHandler<AddPersonCommand, Person>
    {
        public Task<Person> Handle(AddPersonCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}