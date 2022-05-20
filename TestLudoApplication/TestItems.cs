using LudoApplication.GameItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLudoApplication
{
    [TestClass]
    public class TestItems
    {
        readonly Die d = new(6);

        [TestMethod]
        public void TestRollDie()
        {
            int roll = d.Roll();
            Assert.IsTrue(roll <= 6 && roll > 0);
        }
    }
}
