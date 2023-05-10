using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionAggregator.Logic.Models;

namespace PromotionAggregator.Tests.Tests
{
    [TestClass]
    public class CommentTest
    {

        [TestMethod]
        public void Text_Throws_Exception_When_String_Is_Null_Or_Empty()
        {
            //Assert
            string test = null;
            string userId = "1";
            DateTime date = DateTime.Now;


            //Act + Assert
            Assert.ThrowsException<ArgumentException>(() => new Comment(test, date, userId));
        }


        [TestMethod]
        public void Text_Set_Value_When_String_Is_Correct()
        {
            //Assert
            string test = "Some text";
            string userId = "1";
            DateTime date = DateTime.Now;
            Comment comment;
            string result;


            //Act
            comment = new Comment(test, date, userId);
            result = comment.Text;


            //Act + Assert
            Assert.AreEqual(test, result);
        }

        [TestMethod]
        public void UserId_Throws_Exception_When_String_Is_Null_Or_Empty()
        {
            //Assert
            string text = "Some text";
            string userId = null;
            DateTime date = DateTime.Now;


            //Act + Assert
            Assert.ThrowsException<ArgumentException>(() => new Comment(text, date, userId));
        }


        [TestMethod]
        public void UserId_set_value_when_string_is_correct()
        {
            //Assert
            string text = "Some text";
            string userId = "test id";
            DateTime date = DateTime.Now;
            Comment comment;
            string result;


            //Act
            comment = new Comment(text, date, userId);
            result = comment.Text;


            //Act + Assert
            Assert.AreEqual(text, result);
        }

    }
}
