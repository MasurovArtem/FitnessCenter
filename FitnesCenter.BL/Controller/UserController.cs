using FitnesCenter.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnesCenter.BL.Controller
{
    /// <summary>
    /// User Controller
    /// </summary>
    public class UserController
    {
        public List<User> Users { get; } // It's not Safe
        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Name gender can't be empty or null.", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }
        public void Save() // It's necessary to indicate what we serialize 
        {
            //Serialize User
            //Encrypt file
            var binFormatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(fs, Users);
            }
        }
        private List<User> GetUsersData()
        {
            var binFormatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && binFormatter.Deserialize(fs) is List<User>users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
            }
        }

        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            #region checkInputParameters
            if (string.IsNullOrWhiteSpace(genderName))
            {
                throw new ArgumentNullException("Name gender can't be empty or null.", nameof(genderName));
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
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }
    }
}
