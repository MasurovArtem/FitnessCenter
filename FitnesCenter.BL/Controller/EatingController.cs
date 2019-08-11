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
        private const string FOODS_FILE_NAME = "foods.dat";
        private const string EATING_FILE_NAME = "eating.dat";

        private readonly User user;

        public List<Food> Foods { get; }
        public Eating Eating { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException($"variable {user} can't be empty", nameof(user));

            Foods = GetFoodsData();
            Eating = GetEatingData();
        }

        public bool AddEat(string foodName, double weight)
        {
            if (string.IsNullOrWhiteSpace(foodName))
            {
                throw new ArgumentNullException($"variable {foodName} can't be empty or null.", nameof(foodName));
            }
            if(weight < 0)
            {
                throw new ArgumentException($"variable {weight} can't be greater than zero.", nameof(weight));
            }
            var food = Foods.SingleOrDefault(f => f.Name == foodName);
            var eating = new Eating(user)
            if (food != null) // request all food details
            {
                Eating.Add();
            }
        }

        private List<Eating> GetEatingData()
        {
            return Load<List<Eating>>(EATING_FILE_NAME) ?? new List<Eating>();
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
