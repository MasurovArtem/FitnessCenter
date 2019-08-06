using FitnesCenter.BL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnesCenter.BL.Controller
{
    /// <summary>
    /// User Controller
    /// </summary>
    public class UserController
    {
        public User User { get; } // In it I will write
        /// <summary>
        /// Deserialize
        /// </summary>
        /// <returns>User data</returns>
        public UserController()
        {
            var binFormatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (binFormatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
            }
            //TODO: Что делать если пользователя не прочитали
        }
        public UserController(string userName, string genderName, DateTime birthDate, double weight, double height)
        {
            #region checkInputParameters
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Name gender can't be empty or null.", nameof(userName));
            }
            if (string.IsNullOrWhiteSpace(genderName))
            {
                throw new ArgumentNullException("Gender can't be empty.", nameof(genderName));
            }
            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now) //TODO : mayby need its write like this - "DateTime.Parse("1900/01/01")" 
            {
                throw new ArgumentException("Impossible date of birth.", nameof(birthDate));
            }
            if (weight <= 0)
            {
                throw new ArgumentException("Weight can't be less than or equal to zero.", nameof(weight));
            }
            if (height <= 0)
            {
                throw new ArgumentException("Height can't be less than or equal to zero.", nameof(height));
            }
            #endregion
            var gender = new Gender(genderName);
            var user = new User(userName, gender, birthDate, weight, height);
            //New option
            //User = user ?? throw new ArgumentNullException("User can't be null.", nameof(user));
            //Old School
            if (user == null)
            {
                //Возможно, проверка не требуеться, лишняя... // мы все проверили зареанее!
                throw new ArgumentNullException("User can't be null.", nameof(user));
            }
            User = user;
        }
        /// <summary>
        /// Serialization
        /// </summary>
        /// <returns>True if recording success</returns>
        public void Save() // It's necessary to indicate what we serialize 
        {
            //Serialize User
            //Encrypt file
            var binFormatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(fs, User);
            }
        }
        
    }
}
