using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarchMadness.Tests
{
    [TestClass]
    public class RoundTests
    {
        [TestMethod]
        public void TestDefaults()
        {
            var round = new Round(1);

            Assert.AreEqual(1, round.RoundNumber);
            Assert.AreEqual(0, round.Games.Count);
        }

        [TestMethod]
        public void TestAddGame()
        {
            var round = new Round(1);
            round.AddGame(new Team("UCLA", 23, "West"), new Team("Boston", 5, "North"));

            Assert.AreEqual(1, round.Games.Count);
            Assert.AreEqual(1, round.Games[0].RoundNumber);
            Assert.AreEqual("UCLA", round.Games[0].HomeTeam.Name);
            Assert.AreEqual("Boston", round.Games[0].AwayTeam.Name);
            Assert.AreEqual(null, round.Games[0].Winner);
        }
    }
}
