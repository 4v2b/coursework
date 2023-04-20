using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionAggregator.Logic.Context;

namespace PromotionAggregator.Tests.Tests
{
    [TestClass]
    public class ContextTest
    {
        [TestMethod]
        public void Instance_returns_same_Context_instances()
        {
            //Arrange + Act
            Context context1 = Context.Instance;
            Context context2 = Context.Instance;

            //Assert
            Assert.AreEqual(context1, context2);
        }

        [TestMethod]
        public void SetCollections_initialize_lists_when_instance_created()
        {
            //Arrange + Act
            Context context = Context.Instance;

            //Assert
            Assert.IsNotNull(context.Promotions);
            Assert.IsNotNull(context.Shops);
            Assert.IsNotNull(context.Users);
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
