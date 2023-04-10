using System;
using Microsoft.EntityFrameworkCore;

namespace n5_log_operations
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLExpress;Database=helloappdb;Trusted_Connection=true;");
            optionsBuilder.LogTo(Console.WriteLine);
        }
    }
}