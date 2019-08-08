using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnesCenter.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesCenter.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SaveTest()
        {
            //Arrange - parameters
            var user = Guid.NewGuid().ToString();
            //Act - action, calling something
            var controler = new UserController(user);
            //Assert - the answer that was expected
            Assert.AreEqual(user, controler.CurrentUser.Name);

        }

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //Arrange - parameters
            var user = Guid.NewGuid().ToString();
            var gender = "male";
            var birthDate = DateTime.Now.AddYears(-18);
            var width = 90;
            var height = 180;
            var controler = new UserController(user);
            //Act - action, calling something
            controler.SetNewUserData(gender, birthDate, width, height);

            var controler_second = new UserController(user);

            //Assert - the answer that was expected
            Assert.AreEqual(user, controler_second.CurrentUser.Name);
            Assert.AreEqual(gender, controler_second.CurrentUser.Gender.Name);
            Assert.AreEqual(birthDate, controler_second.CurrentUser.BirthDate);
            Assert.AreEqual(width, controler_second.CurrentUser.Weight);
            Assert.AreEqual(height, controler_second.CurrentUser.Height);

        }
    }
}