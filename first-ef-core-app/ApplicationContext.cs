using Microsoft.EntityFrameworkCore;

namespace first_ef_core_app
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLExpress;AttachDbFilename=C:\testDataBases\first_ef_core_app.mdf;Database=first_ef_core_app;Trusted_Connection=Yes;");
            
        }
    }
}