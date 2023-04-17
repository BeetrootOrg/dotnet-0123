using AspNetTest.Models;

using Microsoft.EntityFrameworkCore;

namespace AspNetTest.Database
{
    public class PersonsContext : DbContext
    {
        public DbSet<Person>? Persons { get; init; }

        public PersonsContext() : base()
        {
        }

        public PersonsContext(DbContextOptions<PersonsContext> options) : base(options)
        {
        }
    }
}