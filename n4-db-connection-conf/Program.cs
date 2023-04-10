using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace n4_db_connection_conf
{
    class Program
    {
        static void Main(string[] args)
        {
            UseAppsettingsFile_Example();
            
            Console.ReadLine();
        }

        private static void DbContextOptions_InConstructor_Example()
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
        }

        private static void UseAppsettingsFile_Example()
        {
            var builder = new ConfigurationBuilder();
            // Установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;
            
            AddUsers(options);

            using (ApplicationContext db = new ApplicationContext(options))
            {
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id} {u.Name} - {u.Age}");
                }
            }
        }

        private static void AddUsers(DbContextOptions<ApplicationContext> options)
        {
            using (ApplicationContext db = new ApplicationContext(options))
            {
                User user1 = new User { Name = "Max", Age = 5 };
                User user2 = new User { Name = "Vika", Age = 31 };
                User user3 = new User { Name = "Pasha", Age = 32 };

                db.Users.Add(user1);
                db.Users.Add(user2);
                db.Users.Add(user3);

                db.SaveChanges();
            }
        }
    }
}