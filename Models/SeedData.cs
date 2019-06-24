using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace PeopleApi.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PersonContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PersonContext>>()))
            {
                //See if the db has been seeded
                if (context.People.Any())
                {
                    return; // DB has been seeded
                }

                context.People.AddRange(
                    new Person
                    {
                        FirstName = "Bobby",
                        LastName = "Boucher",
                        Address = "1 Mud Dog Way",
                        City = "South Central",
                        State = "LA",
                        Zip = "70501" 
                    },

                    new Person
                    {
                        FirstName = "Oscar",
                        LastName = "Grouch",
                        Address = "123 Sesame St",
                        City = "New York",
                        State = "NY",
                        Zip = "10128"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
