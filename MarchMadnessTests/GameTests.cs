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

        [TestMethod]
        public void TestToString()
        {
            var team1 = new Team("UCLA", 23, "West");
            var team2 = new Team("Boston", 5, "North");
            var game = new Game(1, team1, team2);

            var unresolved = game.ToString();

            game.Resolve(team1);
            var homeWon = game.ToString();

            game.Resolve(team2);
            var awayWon = game.ToString();

            Assert.AreEqual("UCLA vs Boston", unresolved);
            Assert.AreEqual("UCLA vs Boston (UCLA)", homeWon);
            Assert.AreEqual("UCLA vs Boston (Boston)", awayWon);
        }
    }
}
