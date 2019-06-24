using MediatR;
using PeopleApi.Models;
using System.ComponentModel.DataAnnotations;

namespace PeopleApi.Messages.Queries
{
    public class GetPersonQuery : IRequest<Person>
    {
        [Required]
        public long Id { get; set; }
    }
}
