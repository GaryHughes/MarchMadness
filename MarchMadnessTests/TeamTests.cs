using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarchMadness.Tests
{
    [TestClass]
    public class TeamTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            var team = new Team("UCLA", 23, "West");

            Assert.AreEqual("UCLA", team.Name);
            Assert.AreEqual(23, team.Seed);
            Assert.AreEqual("West", team.Region);
        }
    }
}
