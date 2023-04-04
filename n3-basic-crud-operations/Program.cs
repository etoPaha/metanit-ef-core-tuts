using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace n3_basic_crud_operations
{
    /// <summary>
    /// Пример CRUD операция в EntityFramework Core
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            CreateOperation();
            ReadOperation();
            UpdateOperation();
            DeleteOperation();

            Console.ReadLine();
        }
        
        /// <summary>
        /// Операция создания
        /// </summary>
        private static void CreateOperation()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user1 = new User { Name = "Tom", Age = 33 };
                User user2 = new User { Name = "Alice", Age = 26 };
                User user3 = new User { Name = "Paha", Age = 30 };
                User user4 = new User { Name = "Vika", Age = 30 };
                
                // Добавление пользователей
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.Users.Add(user3);
                db.Users.Add(user4);

                db.SaveChanges(); // Сохраняем изменения
            }
        }

        /// <summary>
        /// Операция чтения
        /// </summary>
        private static void ReadOperation()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.ToList();

                Console.WriteLine("Данные после добавления");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id} {u.Name} - {u.Age}");
                }
            }
        }

        /// <summary>
        /// Операция редактирования
        /// </summary>
        private static void UpdateOperation()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var user = db.Users.FirstOrDefault();
                if (user != null)
                {
                    user.Name = "Bob";
                    user.Age = 44;

                    // Обновляем объект                    
                    db.Users.Update(user);
                    db.SaveChanges();
                }
                
                Console.WriteLine("\nДанные после редактирования");
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id} {u.Name} - {u.Age}");
                }
            }
        }

        /// <summary>
        /// Операция удаления
        /// </summary>
        private static void DeleteOperation()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = db.Users.FirstOrDefault();
                if (user != null)
                {
                    // Удаляем объект
                    db.Users.Remove(user);
                    db.SaveChanges();
                }

                Console.WriteLine("\nДанные после удаления:");
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id} {u.Name} - {u.Age}");
                }
            }
        }
    }
}