using FitnesCenter.BL.Controller;
using FitnesCenter.BL.Model;
using System;
namespace FitnesCenter.CMD
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to fitnes center \n");

            Console.Write("Enter name: ");
            var name = Console.ReadLine();

            Console.Write("Enter gender: ");
            var gender = Console.ReadLine();

            Console.Write("Enter date birth : ");
            var dateBirth = DateTime.Parse(Console.ReadLine());

            Console.Write("weight : ");
            var weight = Double.Parse(Console.ReadLine());

            Console.Write("height : ");
            var height = Double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, dateBirth, weight, height);
            userController.Save(); //TODO: GENDER EMPTY
        } 
    }
}
