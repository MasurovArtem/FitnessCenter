using System;

namespace FitnesCenter.BL.Model
{
    [Serializable]
    public class User
    {
        public string Name { get; set; } 
        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }
        
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } } // аналог
      //public int Age => DateTime.Now.Year - BirthDate.Year;


        public User(string name, 
                    Gender gender, 
                    DateTime birthDate, 
                    double weight, 
                    double height)
        {
            #region checkInputParameters
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException($"variable { name } can't be empty or null.", nameof(name));
            }
            if (gender == null)
            {
                throw new ArgumentNullException($"variable {gender} can't be empty.", nameof(gender));
            }
            if (birthDate < DateTime.Parse("01.01.1900") ||  birthDate >= DateTime.Now) //TODO : mayby need its write like this - "DateTime.Parse("1900/01/01")" 
            {
                throw new ArgumentException("Impossible date of birth.", nameof(birthDate));
            }
            if(weight <= 0)
            {
                throw new ArgumentException($"variable {weight} can't be less than or equal to zero.", nameof(weight));
            }
            if(height <= 0)
            {
                throw new ArgumentException($"variable {weight} can't be less than or equal to zero.", nameof(height));
            }
            #endregion
            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
            
        }
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException($"variable {name} can't be empty or null.", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
