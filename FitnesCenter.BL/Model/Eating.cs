using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesCenter.BL.Model
{
    [Serializable]
    public class Eating
    {
        /// <summary>
        /// What time is the meal?
        /// </summary>
        public DateTime Moment { get; }
        /// <summary>
        /// What kind of food is consumed?
        /// There should be a dictionary of products and the amount of products consumed
        ///
        /// !!!!! WARNING !!!!!! It isn't good to use a reference type as a key.
        /// 
        /// </summary>
        public Dictionary<Food, double> Foods { get; }
        /// <summary>
        /// Who eats food?
        /// </summary>
        public User User { get; }

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException($"variable {user} can't be null", nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }
        public void Add(Food food, double weight)
        {
            if (food == null)
            {
                throw new ArgumentNullException($"object {food} can't be null", nameof(food));
            }
            if (weight < 0)
            {
                throw new ArgumentException($"variable {weight} can't be greater than zero.", nameof(weight));
            }
            /// Сheck if such a product is in the product list

            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));
            if (product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                //Get our value and increase the number
                Foods[product] += weight;
            }
            
        }
    }
}
