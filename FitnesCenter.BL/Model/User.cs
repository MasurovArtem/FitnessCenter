using System;

namespace FitnesCenter.BL.Model
{
    public class User
    {
        public string Name { get; } // Setter не делаю, для того что бы нельзя было поменять имя пользователя
        public Gender Gender { get; }

        public DateTime BirthDate { get; }

        public double Weight { get; set; }

        public double Height { get; set; }
        
        public User(string name, 
                    Gender gender, 
                    DateTime birthDate, 
                    double weight, 
                    double height)
        {
            #region checkInputParameters
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name gender can't be empty or null.", nameof(name));
            }
            if (Gender == null)
            {
                throw new ArgumentNullException("Gender can't be empty.", nameof(gender));
            }
            if (birthDate < DateTime.Parse("01.01.1900") ||  birthDate >= DateTime.Now) //TODO : mayby need its write like this - "DateTime.Parse("1900/01/01")" 
            {
                throw new ArgumentException("Impossible date of birth.", nameof(birthDate));
            }
            if(Weight <= 0)
            {
                throw new ArgumentException("Weight can't be less than or equal to zero.", nameof(weight));
            }
            if(Height <= 0)
            {
                throw new ArgumentException("Height can't be less than or equal to zero.", nameof(height));
            }

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
            #endregion
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
