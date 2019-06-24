using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using PeopleApi.Messages.Queries;
using PeopleApi.Models;

namespace PeopleApi.Handlers.Queries
{
    public class GetPeopleHandler : IRequestHandler<GetPeopleQuery, List<Person>>
    {
        private readonly IDbConnection _dbConnection;

        public GetPeopleHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Task<List<Person>> Handle(GetPeopleQuery request, CancellationToken cancellationToken)
        {
            var people = _dbConnection.Query<Person>(@"
                SELECT 
                    Id,
                    FirstName,
                    LastName,
                    Address,
                    City,
                    State,
                    Zip
                FROM People").ToList();

            return Task.FromResult(people);
        }
    }
}