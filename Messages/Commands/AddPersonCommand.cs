using MediatR;
using PeopleApi.Models;
using System.ComponentModel.DataAnnotations;

namespace PeopleApi.Messages.Commands
{
    public class AddPersonCommand : IRequest<Person>
    {        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Zip { get; set; }
    }
}
