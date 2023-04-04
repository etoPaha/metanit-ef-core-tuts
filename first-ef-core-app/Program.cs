using System;
using System.Linq;

namespace first_ef_core_app
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // Создаем два объекта
                User user1 = new User { Name = "Tom", Age = 33 };
                User user2 = new User { Name = "Alice", Age = 26 };
                User user3 = new User { Name = "Pavel", Age = 33 };

                // Добавляем их в БД
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.Users.Add(user3);

                db.SaveChanges(); // Сохраняем

                Console.WriteLine("Объекты успешно сохранены");

                var users = db.Users.ToList();
                
                Console.WriteLine("Список объектов:");
                foreach (User user in users)
                {
                    Console.WriteLine($"{user.Id} {user.Name} - {user.Age}");
                }
            }
            
            Console.ReadLine();
        }
    }
}