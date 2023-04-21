using Microsoft.EntityFrameworkCore;

using PersonsSite.Models;

namespace PersonsSite
{
    public class PersonsContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public PersonsContext() : base()
        {
        }

        public PersonsContext(DbContextOptions<PersonsContext> options)
            : base(options)
        {
        }
    }
}