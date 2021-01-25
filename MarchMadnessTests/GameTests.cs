using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarchMadness.Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            var team1 = new Team("UCLA", 23, "West");
            var team2 = new Team("Boston", 5, "North");
            var game = new Game(1, team1, team2);

            Assert.AreEqual(1, game.RoundNumber, 1);
            Assert.AreEqual("UCLA", game.HomeTeam.Name);
            Assert.AreEqual("Boston", game.AwayTeam.Name);
            Assert.AreEqual(null, game.Winner);
            Assert.AreEqual(false, game.IsComplete);
        }

        [TestMethod]
        public void TestResolve()
        {
            var team1 = new Team("UCLA", 23, "West");
            var team2 = new Team("Boston", 5, "North");
            var game = new Game(1, team1, team2);

            game.Resolve(game.HomeTeam);

            Assert.AreEqual(1, game.RoundNumber, 1);
            Assert.AreEqual("UCLA", game.HomeTeam.Name);
            Assert.AreEqual("Boston", game.AwayTeam.Name);
            Assert.IsNotNull(game.Winner);
            Assert.AreEqual("UCLA", game.Winner?.Name);
            Assert.AreEqual(true, game.IsComplete);
        }
    }
}
