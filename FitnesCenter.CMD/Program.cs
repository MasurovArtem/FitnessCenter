using FitnesCenter.BL.Controller;
using FitnesCenter.BL.Model;
using System;
namespace FitnesCenter.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wselcome to fitnes center \n");

            Console.Write("Enter name: ");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.Write("Enter gender : ");
                var gender = Console.ReadLine();

                var birthDate = ParseDateTime();

                var weight = ParseDouble("weight");

                var height = ParseDouble("height");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);

        }
        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Enter date birth (dd.MM.yyyy) : ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                Console.WriteLine("Incorect format date time");
            }
            return birthDate;
        }
        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Enter {name}: ");
                double value;
                if (double.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }
                Console.WriteLine($"Incorect format: {name}");
            }
        }
    }
}
