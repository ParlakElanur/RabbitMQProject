using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQConsumer.Db
{
    public class DbPostgresContext:DbContext
    {
        public DbSet<Customer> Customer { get; set; }

        private const string connection = @"User Id=postgres; Password=admn; Server=localhost; Port=5432; Database=Customer_DB;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connection);

        }
    }
}
