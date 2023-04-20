using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromotionAggregator.Logic.Services;

namespace PromotionAggregator.Tests.Tests
{
    [TestClass]
    public class AuthenticationTest
    {
        [TestMethod]
        public void SignIn_Throws_ArgumentException_When_Email_Is_Invalid()
        {
            //Arrange
            string email = "email";
            string password = "password";

            //Act + Assert
            Assert.ThrowsException<ArgumentException>(() => Authentication.SignIn(email, password));

        }

        [TestMethod]
        public void SignIn_Throws_ArgumentException_When_Password_Is_Invalid()
        {
            //Arrange
            string email = GetEmail();
            string password = "password";
            Authentication.Register(email, password, password);
            

            //Act + Assert
            Assert.ThrowsException<ArgumentException>(() => Authentication.SignIn(email, "12345678"));

        }

        [TestMethod]
        public void SignIn_Returns_User_When_Both_Password_And_Email_Are_Valid()
        {
            //Arrange
            string email = GetEmail();
            string password = "password";
            Authentication.Register(email, password, password);
            User user;

            //Act
            user = Authentication.SignIn(email, password);

            //+ Assert
            Assert.IsNotNull(user);

        }

        [TestMethod]
        public void Register_Throws_ArgumentException_When_User_With_Same_Email_Exists()
        {
            //Arrange
            string email = GetEmail();
            string password = "password";
            Authentication.Register(email, password, password);

            //Act + Assert
            Assert.ThrowsException<ArgumentException>(()=>Authentication.Register(email, password, password));
        }

        [TestMethod]
        public void Register_Throws_ArgumentException_When_Passwords_Are_Not_Same()
        {
            //Arrange
            string email = GetEmail();
            string password1 = "password1";
            string password2 = "password2";

            //Act + Assert
            Assert.ThrowsException<ArgumentException>(
() => Authentication.Register(email, password1, password2));
        }

        [TestMethod]
        public void Register_Returns_User_When_Both_Password_And_Email_Are_Valid()
        {
            //Arrange
            string email = GetEmail();
            string password = "password";
           

            //Act
            User user = Authentication.Register(email, password, password);

            //Assert
            Assert.IsNotNull(user);
        }

        public string GetEmail()
        {
            return $"user{new Random().Next(10000)}@gmail.com";
        }
    }
}