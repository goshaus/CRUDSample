using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Entities;
using System.Data.SqlClient;

namespace Domain.Context
{
    public class PersonContext : DbContext
    {
        public PersonContext() : base("name=PersonContext")
        { }

        public DbSet<Person> People { get; set; }
    }
}
