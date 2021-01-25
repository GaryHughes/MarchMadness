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


        [TestMethod]
        public void TestEquality()
        {
            var team = new Team("UCLA", 23, "West");
            var same = new Team("UCLA", 23, "West");
            var different = new Team("UCLA", 24, "West");

            Assert.IsTrue(team == same);
            Assert.IsTrue(same == team);
            Assert.IsTrue(team.Equals(same));
            Assert.IsTrue(same.Equals(team));

            Assert.IsFalse(team == different);
            Assert.IsFalse(different == team);
            Assert.IsFalse(team.Equals(different));
            Assert.IsFalse(different.Equals(team));
        }
    }
}
