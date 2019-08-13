using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace FitnesCenter.BL.Model
{
    [Serializable]
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

        public Food(string name) : this(name, 0, 0, 0, 0)
        {
            // Check is in another constructor
            Name = name;
            
        }
        public Food(string name, double calories, double proteins, double fats, double carbohydrats)
        {
            #region CheckParameters
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException($"variable {name} can't be empty or null.", nameof(name));
            }
            if (calories < 0)
            {
                throw new ArgumentException($"variable {calories} can't be greater than zero.", nameof(calories));
            }
            if (proteins < 0)
            {
                throw new ArgumentException($"variable {proteins} can't be greater than zero.", nameof(proteins));
            }
            if (fats < 0)
            {
                throw new ArgumentException($"variable {fats} can't be greater than zero.", nameof(fats));
            }
            if (carbohydrats < 0)
            {
                throw new ArgumentException($"variable {carbohydrats} can't be greater than zero.", nameof(carbohydrats));
            }
            #endregion
            Name = name;
            Calorie = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrats = carbohydrats / 100.0;
        }

    }
}
