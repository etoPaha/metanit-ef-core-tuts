using System;
using System.Linq;

namespace n2_use_exist_db
{
    class Program
    {
        static void Main(string[] args)
        {
            using (AppContext db = new AppContext())
            {
                // получаем объекты из БД и выводим на консоль
                var users = db.Users.ToList();

                Console.WriteLine("Список объектов");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id} {u.Name} - {u.Age}");
                }
            }
            
            Console.ReadKey();
        }
    }
}