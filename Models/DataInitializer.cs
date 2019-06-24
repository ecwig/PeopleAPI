using Dapper;
using System.Data;
using System.Linq;

namespace PeopleApi.Models
{
    public class DataInitializer
    {
        private readonly IDbConnection _dbConnection;
        
        public DataInitializer(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void InitializeDatabase()
        {
            //If the dbo.Person table doesn't exist, create it
            var tableExistsQuery = @"SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Person'";
            var createTableQuery = @"CREATE TABLE dbo.Person (
                                        Id INT NOT NULL PRIMARY KEY, 
                                        FirstName VARCHAR(255) NOT NULL, 
                                        LastName VARCHAR(255) NOT NULL, 
                                        Address VARCHAR(255) NOT NULL, 
                                        City VARCHAR(255) NOT NULL, 
                                        State VARCHAR(255) NOT NULL, 
                                        Zip VARCHAR(255) NOT NULL
                                    );";

            if (!(_dbConnection.Query<int>(tableExistsQuery).FirstOrDefault() == 1)) _dbConnection.Execute(createTableQuery);

            //If no seed data exists, create it
            var seedDataExistsQuery = "SELECT COUNT(Id) FROM dbo.Person;";
            var createSeedData = @"INSERT INTO dbo.Person (FirstName, LastName, Address, City, State, Zip)
                VALUES 
                ('Bobby', 'Boucher', '1 Mud Dog Way', 'South Central', 'LA', '70501'),
                ('Oscar', 'Grouch', '123 Sesame St', 'New York', 'NY', '10128')";

            if (!(_dbConnection.Query<int>(seedDataExistsQuery).FirstOrDefault() > 0)) _dbConnection.Execute(createSeedData);
                       
        }
    }
}
