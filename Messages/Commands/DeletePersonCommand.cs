using MediatR;
using PeopleApi.Models;
using System.ComponentModel.DataAnnotations;

namespace PeopleApi.Messages.Commands
{
    public class DeletePersonCommand : IRequest<Person>
    {
        [Required]
        public long Id { get; set; }
    }
}
