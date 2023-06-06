using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using OldTechApp.DataBase;
using OldTechApp.Extesions;
using OldTechApp.Models;

namespace OldTechApp.ConsoleActions
{
    public static class MainMenu
    {
        public static void Show()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nДобро пожаловать в консоль управления жителями убежища." +
                              "\nРазработано компанией VaultTec(c)" +
                              "\nВыберите действие:");
            Console.WriteLine("[1] Показать список текущих жителей убежища");
            Console.WriteLine("[2] Добавить нового жителя");
            Console.WriteLine("[3] Изменить имя жителя");
            Console.WriteLine("[4] Удалить жителя");
            Console.WriteLine("[5] Выход");
            Console.WriteLine("\n[6] ;%№;%№SOZDAT_COLLIZIU@#[:D][D:]");

            
            var input = Console.ReadLine();
            switch (input)
            {
                case "1": 
                    PrintDwellersList();
                    WaitAnyKeyPress();
                    break;
                case "2": 
                    Add();
                    WaitAnyKeyPress();
                    break;
                case "3": 
                    ChangeName();
                    WaitAnyKeyPress();
                    break;
                case "4": 
                    Delete();
                    WaitAnyKeyPress();
                    break;
                case "5": Environment.Exit(0);
                    break;
                case "6":
                    CreateCollision();
                    WaitAnyKeyPress();
                    break;
                default: Console.WriteLine("Указана несуществующая опция!");
                    Show();
                    break;
            }
        }

        private static void CreateCollision()
        {
            Dweller dweller; 
            using (DatabaseContext db = new DatabaseContext())
            {
                dweller = db.Dwellers.First();
            }

            if (dweller == null)
            {
                Console.WriteLine("Жителей нет, пошалить не удасться!");
                return;
            }
            else
            {
                Console.WriteLine($"Меняем жителя [{dweller.Id}] {dweller.Name}");
            }

            try
            {
                var dweller2 = dweller.DeepClone();
                dweller2.Name = "0 b P E 4 E H H bI I/I";
                
                using (DatabaseContext db = new DatabaseContext())
                {
                    dweller.Name = "H E H A 3 bI B @ E M bI I/I";
                    db.Entry(dweller).State = EntityState.Modified;
                    db.SaveChanges();
                }
            
                using (DatabaseContext db = new DatabaseContext())
                {
                    dweller2.Name = "0 b P E 4 E H H bI I/I";
                    db.Entry(dweller2).State = EntityState.Modified;
                    db.SaveChanges();
                }
                
                Console.WriteLine($"Шалость удалась, проверь список! :D");
            }
            catch (DbUpdateConcurrencyException e)
            {
                Console.WriteLine($"Данные уже изменены, не вышло ничего сделать, ХАКЕРМЕН! D:");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Пошалить не удалось, ОШИБКА! {e.Message} D:");
            }
            
        }
        
        private static void PrintDwellersList()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var dwellers = db.Dwellers;
                foreach (Dweller dweller in dwellers)
                {
                    Console.WriteLine("[{0}] {1} Возраст: {2}", dweller.Id, dweller.Name, dweller.Age);
                }
            }
        }

        private static void Add()
        {
            Console.WriteLine("Укажите имя:");
            var name = Console.ReadLine();

            Console.WriteLine("Укажите возраст:");
            var input = Console.ReadLine();
            int age;
            if (!int.TryParse(input, out age))
            {
                Console.WriteLine("Введено не число!");
                return;
            }
            
            var newDweller = new Dweller()
            {
                Name = name,
                Age = age,
            };

            using(DatabaseContext db = new DatabaseContext())
            {
                db.Dwellers.Add(newDweller);
                db.SaveChanges();
                Console.WriteLine("Житель успешно добавлен");
            }
        }

        private static void ChangeName()
        {
            Console.WriteLine("\n +++ Жители убежища +++");
            PrintDwellersList();
            
            Console.WriteLine("\n +++ Введите [идентификатор] жителя для которого хотите сменить имя +++");
            var input = Console.ReadLine();
            
            int id;
            if (int.TryParse(input, out id))
            {
                TryChangeDwellersName(id);
            }
            else
            {
                Console.WriteLine("Введено не число!");
            }
        }

        private static void TryChangeDwellersName(int id)
        {
            using(DatabaseContext db = new DatabaseContext())
            {
                var dweller = db.Dwellers.Find(id);
                if (dweller == null)
                {
                    Console.WriteLine($"\n +++ Житель с [идентификатором] = {id} не найден! Возврат в главное меню +++");
                    WaitAnyKeyPress();
                }
                
                Console.WriteLine($"Укажите новое имя для [{dweller.Id}] {dweller.Name} :");
                var name = Console.ReadLine();
                dweller.Name = name;
                db.SaveChanges();
                Console.WriteLine("Имя жителя изменено!");
            }
        }
        
        private static void Delete()
        {
            Console.WriteLine("\n +++ Жители убежища +++");
            PrintDwellersList();
            
            Console.WriteLine("\n +++ Введите [идентификатор] жителя для которого хотите удалить +++");
            var input = Console.ReadLine();
            
            int id;
            if (int.TryParse(input, out id))
            {
                TryDeleteDweller(id);
            }
            else
            {
                Console.WriteLine("Введено не число!");
            }
        }
        
        private static void TryDeleteDweller(int id)
        {
            using(DatabaseContext db = new DatabaseContext())
            {
                var dweller = db.Dwellers.Find(id);
                if (dweller == null)
                {
                    Console.WriteLine($"\n +++ Житель с [идентификатором] = {id} не найден! Возврат в главное меню +++");
                    WaitAnyKeyPress();
                }

                db.Dwellers.Remove(dweller);
                db.SaveChanges();
                Console.WriteLine("Житель удален");
            }
        }
        
        private static void WaitAnyKeyPress()
        {
            Console.WriteLine("\n");
            Console.ReadKey();
            Show();
        }
    }
}