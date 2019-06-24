using MediatR;
using PeopleApi.Models;
using System.Collections.Generic;

namespace PeopleApi.Messages.Queries
{
    public class GetPeopleQuery : IRequest<IList<Person>> { }
}
