using System;
using System.Diagnostics;
using OldTechApp.ConsoleActions;
using OldTechApp.DataBase;
using OldTechApp.Models;

namespace OldTechApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MainMenu.Show();
        }

        public void AddUsers()
        {
            using(DatabaseContext db = new DatabaseContext())
            {
                // создаем два объекта User
                Dweller user1 = new Dweller { Name = "Tom", Age = 33 };
                Dweller user2 = new Dweller { Name = "Sam", Age = 26 };
 
                // добавляем их в бд
                db.Dwellers.Add(user1);
                db.Dwellers.Add(user2);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");
 
                // получаем объекты из бд и выводим на консоль
                
                var users = db.Dwellers;
                Console.WriteLine("Список объектов:");
                foreach(Dweller u in users)
                {
                    Console.WriteLine("{0}.{1} - {2}", u.Id, u.Name, u.Age);
                }
            }
        }
    }
}