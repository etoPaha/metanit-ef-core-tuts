using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace n4_db_connection_conf
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            var options = optionsBuilder
                .UseSqlServer(@"Server=.\SQLExpress;Database=helloappdb;Trusted_Connection=True;")
                .Options;

            using (ApplicationContext db = new ApplicationContext(options))
            {
                var users = db.Users.ToList();

                foreach (User u in users)
                    Console.WriteLine($"{u.Id} {u.Name} - {u.Age}");
            }
            
            Console.ReadLine();
        }
    }
}