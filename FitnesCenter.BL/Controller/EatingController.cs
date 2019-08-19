using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using FitnesCenter.BL.Model;

namespace FitnesCenter.BL.Controller
{
    public class EatingController : ControllerBase
    {
        //private Method
        private const string FOODS_FILE_NAME = "foods.dat";
        private const string EATING_FILE_NAME = "eating.dat";

        private readonly User user;

        public List<Food> Foods { get; }
        public Eating Eating { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException($"variable {user} can't be empty", nameof(user));

            Foods = GetFoodsData();
            Eating = GetEating();
        }

        public bool Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);

            if (product == null) // request all food details
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
            return false;
        }
            private Eating GetEating()
        {
            return Load<Eating>(EATING_FILE_NAME) ?? new Eating(user);
        }

        private List<Food> GetFoodsData()
        {
            return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();
        }

        private void Save()
        {
            Save(FOODS_FILE_NAME, Foods);
            Save(EATING_FILE_NAME, Eating);
        }
    }
}
