using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQPublisher.Db
{
    class DbEntities:DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-I8GUAM4; Database=CustomerDB; Trusted_Connection=True;");
        }
    }
}
