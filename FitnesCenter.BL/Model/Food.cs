using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace FitnesCenter.BL.Model
{
    public class Food
    {
        public string Name { get; }
        public double Proteins { get; }
        public double Fats { get; }
        public double Carbohydrats { get; }
        public double Calorie { get; }

        private double ProteinsOneGramm => Proteins / 100; // It's property return value
        private double FatsOneGramm => Fats / 100; // It's property return value
        private double CarbohydratsOneGramm => Carbohydrats / 100; // It's property return value
        private double CalorieOneGramm => Calorie / 100; // It's property return value

        public Food(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException($"variable {name} can't be empty or null.", nameof(name));
            }
        }

    }
}
