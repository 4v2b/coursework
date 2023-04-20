using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionAggregator.Logic.Context;

namespace PromotionAggregator.Tests.Tests
{
    [TestClass]
    public class ContextTest
    {
        [TestMethod]
        public void Instance_Return_Same_Context_Instances()
        {
            Context context1 = Context.Instance;
            Context context2 = Context.Instance;

            Assert.AreEqual(context1, context2);
        }


        [TestMethod]
        public void SaveAll_Returns_True_When_Searilization_Is_Successful()
        {
            //Arrange
            Context context = Context.Instance;
            bool result;

            //Act
            result = context.SaveAll();

            //Assert
            Assert.IsTrue(result);
        }

    }
}
