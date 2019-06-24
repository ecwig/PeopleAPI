using MediatR;
using PeopleApi.Messages.Commands;
using PeopleApi.Models;
using System.Threading;
using System.Threading.Tasks;

namespace PeopleApi.Handlers.Command
{
    public class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand, Person>
    {
        public Task<Person> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}