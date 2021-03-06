using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace MarchMadness.Tests
{
    [TestClass]
    public class BracketTests
    {
        [TestInitialize]
        public void Inititalize()
        {
            if (File.Exists(TestFileName))
            {
                File.Delete(TestFileName);
            }
        }

        [TestCleanup]
        public void CleanUp()
        {
            if (File.Exists(TestFileName))
            {
                File.Delete(TestFileName);
            }
        }

        [TestMethod]
        public void TestInitialState()
        {
            var bracket = new Bracket();

            Assert.AreEqual(0, bracket.RoundNumber);
            Assert.AreEqual(0, bracket.Teams.Count);
            Assert.AreEqual(0, bracket.Rounds.Count);
            Assert.AreEqual(false, bracket.IsComplete());
        }

        [TestMethod]
        public void TestAddTeam()
        {
            var bracket = new Bracket();
            bracket.AddTeam("UCLA", 23, "West");

            Assert.AreEqual(0, bracket.RoundNumber);
            Assert.AreEqual(1, bracket.Teams.Count);
            Assert.AreEqual(0, bracket.Rounds.Count);
            Assert.AreEqual(false, bracket.IsComplete());

            var team = bracket.Teams.First().Value;
            Assert.AreEqual("UCLA", team.Name);
            Assert.AreEqual(23, team.Seed);
            Assert.AreEqual("West", team.Region);
        }

        [TestMethod]
        public void TestLoadTeams()
        {
            File.WriteAllText(TestFileName,
            "Name,Seed,Region\n" +
            "UCLA,1,West\n" +
            "USC,2,South\n" +
            "California,3,North\n");

            var bracket = new Bracket();
            bracket.LoadTeams(TestFileName);

            Assert.AreEqual(0, bracket.RoundNumber);
            Assert.AreEqual(3, bracket.Teams.Count);
            Assert.AreEqual(0, bracket.Rounds.Count);
            Assert.AreEqual(false, bracket.IsComplete());

            var teams = bracket.AllTeams.OrderBy(team => team.Seed).ToList();

            Assert.AreEqual("UCLA", teams[0].Name);
            Assert.AreEqual(1, teams[0].Seed);
            Assert.AreEqual("West", teams[0].Region);

            Assert.AreEqual("USC", teams[1].Name);
            Assert.AreEqual(2, teams[1].Seed);
            Assert.AreEqual("South", teams[1].Region);

            Assert.AreEqual("California", teams[2].Name);
            Assert.AreEqual(3, teams[2].Seed);
            Assert.AreEqual("North", teams[2].Region);
        }

        [TestMethod]
        public void TestLoadTeamsInvalidFilename()
        {
            var bracket = new Bracket();
            Assert.ThrowsException<FileNotFoundException>(() => bracket.LoadTeams("invalid.csv"));
        }

        [TestMethod]
        public void TestLoadTeamsInvalidFileContent()
        {
            File.WriteAllText(TestFileName,
            "Name,Seed,Region\n" +
            "UCLA\n" +
            "USC,2,South\n" +
            "California,3,North\n");

            var bracket = new Bracket();
            Assert.ThrowsException<Exception>(() => bracket.LoadTeams(TestFileName));
        }

        [TestMethod]
        public void TestRound1()
        {
            var bracket = new Bracket();
            bracket.AddTeam("UCLA", 1, "West");
            bracket.AddTeam("USC", 2, "West");
            bracket.AddTeam("California", 3, "West");
            bracket.AddTeam("UNLV", 4, "West");
            bracket.AddTeam("Missouri", 5, "South");
            bracket.AddTeam("Florida", 6, "South");
            bracket.AddTeam("Houston", 7, "South");
            bracket.AddTeam("Tennessee", 8, "South");

            bracket.CreateNextRound();

            Assert.AreEqual(1, bracket.RoundNumber);
            Assert.AreEqual(8, bracket.Teams.Count);
            Assert.AreEqual(1, bracket.Rounds.Count);
            Assert.AreEqual(false, bracket.IsComplete());
            Assert.AreEqual(null, bracket.FindChampion());

            var round = bracket.Rounds[0];
            Assert.AreEqual(4, round.Games.Count);

            Assert.AreEqual("UCLA", round.Games[0].HomeTeam.Name);
            Assert.AreEqual("UNLV", round.Games[0].AwayTeam.Name);
            Assert.AreEqual(null, round.Games[0].Winner);

            Assert.AreEqual("USC", round.Games[1].HomeTeam.Name);
            Assert.AreEqual("California", round.Games[1].AwayTeam.Name);
            Assert.AreEqual(null, round.Games[1].Winner);

            Assert.AreEqual("Missouri", round.Games[2].HomeTeam.Name);
            Assert.AreEqual("Tennessee", round.Games[2].AwayTeam.Name);
            Assert.AreEqual(null, round.Games[2].Winner);

            Assert.AreEqual("Florida", round.Games[3].HomeTeam.Name);
            Assert.AreEqual("Houston", round.Games[3].AwayTeam.Name);
            Assert.AreEqual(null, round.Games[3].Winner);
        }

        [TestMethod]
        public void TestRound2()
        {
            var bracket = new Bracket();
            bracket.AddTeam("UCLA", 1, "West");
            bracket.AddTeam("USC", 2, "West");
            bracket.AddTeam("California", 3, "West");
            bracket.AddTeam("UNLV", 4, "West");
            bracket.AddTeam("Missouri", 5, "South");
            bracket.AddTeam("Florida", 6, "South");
            bracket.AddTeam("Houston", 7, "South");
            bracket.AddTeam("Tennessee", 8, "South");

            bracket.CreateNextRound();
            bracket.Rounds[0].Games[0].Resolve(bracket.Teams["UCLA"]);
            bracket.Rounds[0].Games[1].Resolve(bracket.Teams["California"]);
            bracket.Rounds[0].Games[2].Resolve(bracket.Teams["Missouri"]);
            bracket.Rounds[0].Games[3].Resolve(bracket.Teams["Houston"]);

            bracket.CreateNextRound();

            Assert.AreEqual(2, bracket.RoundNumber);
            Assert.AreEqual(8, bracket.Teams.Count);
            Assert.AreEqual(2, bracket.Rounds.Count);
            Assert.AreEqual(false, bracket.IsComplete());
            Assert.AreEqual(null, bracket.FindChampion());

            var round = bracket.Rounds[1];
            Assert.AreEqual(2, round.Games.Count);

            Assert.AreEqual("UCLA", round.Games[0].HomeTeam.Name);
            Assert.AreEqual("California", round.Games[0].AwayTeam.Name);
            Assert.AreEqual(null, round.Games[0].Winner);

            Assert.AreEqual("Missouri", round.Games[1].HomeTeam.Name);
            Assert.AreEqual("Houston", round.Games[1].AwayTeam.Name);
            Assert.AreEqual(null, round.Games[1].Winner);
        }

        [TestMethod]
        public void TestFinalsRound1()
        {
            var bracket = new Bracket();
            bracket.AddTeam("UCLA", 1, "West");
            bracket.AddTeam("USC", 2, "West");
            bracket.AddTeam("California", 3, "West");
            bracket.AddTeam("UNLV", 4, "West");
            bracket.AddTeam("Missouri", 5, "South");
            bracket.AddTeam("Florida", 6, "South");
            bracket.AddTeam("Houston", 7, "South");
            bracket.AddTeam("Tennessee", 8, "South");

            bracket.CreateNextRound();
            bracket.Rounds[0].Games[0].Resolve(bracket.Teams["UCLA"]);
            bracket.Rounds[0].Games[1].Resolve(bracket.Teams["California"]);
            bracket.Rounds[0].Games[2].Resolve(bracket.Teams["Missouri"]);
            bracket.Rounds[0].Games[3].Resolve(bracket.Teams["Houston"]);

            bracket.CreateNextRound();
            bracket.Rounds[1].Games[0].Resolve(bracket.Teams["UCLA"]);
            bracket.Rounds[1].Games[1].Resolve(bracket.Teams["Houston"]);

            bracket.CreateNextRound();

            Assert.AreEqual(3, bracket.RoundNumber);
            Assert.AreEqual(8, bracket.Teams.Count);
            Assert.AreEqual(3, bracket.Rounds.Count);
            Assert.AreEqual(false, bracket.IsComplete());
            Assert.AreEqual(null, bracket.FindChampion());

            var round = bracket.Rounds[2];
            Assert.AreEqual(1, round.Games.Count);

            Assert.AreEqual("UCLA", round.Games[0].HomeTeam.Name);
            Assert.AreEqual("Houston", round.Games[0].AwayTeam.Name);
            Assert.AreEqual(null, round.Games[0].Winner);
        }

        [TestMethod]
        public void TestFinalsRound2()
        {
            var bracket = new Bracket();
            bracket.AddTeam("UCLA", 1, "North");
            bracket.AddTeam("USC", 2, "North");
            bracket.AddTeam("California", 3, "West");
            bracket.AddTeam("UNLV", 4, "West");
            bracket.AddTeam("Missouri", 5, "South");
            bracket.AddTeam("Florida", 6, "South");
            bracket.AddTeam("Houston", 7, "East");
            bracket.AddTeam("Tennessee", 8, "East");

            bracket.CreateNextRound();
            bracket.Rounds[0].Games[0].Resolve(bracket.Teams["UCLA"]);
            bracket.Rounds[0].Games[1].Resolve(bracket.Teams["California"]);
            bracket.Rounds[0].Games[2].Resolve(bracket.Teams["Missouri"]);
            bracket.Rounds[0].Games[3].Resolve(bracket.Teams["Houston"]);

            bracket.CreateNextRound();
            bracket.Rounds[1].Games[0].Resolve(bracket.Teams["UCLA"]);
            bracket.Rounds[1].Games[1].Resolve(bracket.Teams["Missouri"]);

            bracket.CreateNextRound();

            Assert.AreEqual(3, bracket.RoundNumber);
            Assert.AreEqual(8, bracket.Teams.Count);
            Assert.AreEqual(3, bracket.Rounds.Count);
            Assert.AreEqual(false, bracket.IsComplete());
            Assert.AreEqual(null, bracket.FindChampion());

            var round = bracket.Rounds[2];
            Assert.AreEqual(1, round.Games.Count);

            Assert.AreEqual("UCLA", round.Games[0].HomeTeam.Name);
            Assert.AreEqual("Missouri", round.Games[0].AwayTeam.Name);
            Assert.AreEqual(null, round.Games[0].Winner);
        }

        [TestMethod]
        public void TestComplete()
        {
            var bracket = new Bracket();
            bracket.AddTeam("UCLA", 1, "North");
            bracket.AddTeam("USC", 2, "North");
            bracket.AddTeam("California", 3, "West");
            bracket.AddTeam("UNLV", 4, "West");
            bracket.AddTeam("Missouri", 5, "South");
            bracket.AddTeam("Florida", 6, "South");
            bracket.AddTeam("Houston", 7, "East");
            bracket.AddTeam("Tennessee", 8, "East");

            bracket.CreateNextRound();
            bracket.Rounds[0].Games[0].Resolve(bracket.Teams["UCLA"]);
            bracket.Rounds[0].Games[1].Resolve(bracket.Teams["California"]);
            bracket.Rounds[0].Games[2].Resolve(bracket.Teams["Missouri"]);
            bracket.Rounds[0].Games[3].Resolve(bracket.Teams["Houston"]);

            bracket.CreateNextRound();
            bracket.Rounds[1].Games[0].Resolve(bracket.Teams["UCLA"]);
            bracket.Rounds[1].Games[1].Resolve(bracket.Teams["Missouri"]);

            bracket.CreateNextRound();
            bracket.Rounds[2].Games[0].Resolve(bracket.Teams["Missouri"]);

            Assert.AreEqual(3, bracket.RoundNumber);
            Assert.AreEqual(8, bracket.Teams.Count);
            Assert.AreEqual(3, bracket.Rounds.Count);
            Assert.AreEqual(true, bracket.IsComplete());
            Assert.AreEqual(bracket.Teams["Missouri"], bracket.FindChampion());

            var games = bracket.ListGames(bracket.Teams["Missouri"]);
            Assert.AreEqual(3, games.Count);

            Assert.AreEqual(1, games[0].RoundNumber);
            Assert.AreEqual("Missouri", games[0].Winner?.Name);
            Assert.AreEqual("Florida", games[0].Loser?.Name);

            Assert.AreEqual(2, games[1].RoundNumber);
            Assert.AreEqual("Missouri", games[1].Winner?.Name);
            Assert.AreEqual("California", games[1].Loser?.Name);

            Assert.AreEqual(3, games[2].RoundNumber);
            Assert.AreEqual("Missouri", games[2].Winner?.Name);
            Assert.AreEqual("UCLA", games[2].Loser?.Name);
        }

        [TestMethod]
        public void TestUnevenTeams()
        {
            var bracket = new Bracket();
            bracket.AddTeam("UCLA", 1, "North");
            bracket.AddTeam("USC", 2, "North");
            bracket.AddTeam("California", 3, "West");
            bracket.AddTeam("UNLV", 4, "West");
            bracket.AddTeam("Missouri", 5, "West");

            Assert.ThrowsException<Exception>(() => bracket.CreateNextRound());
        }

        [TestMethod]
        public void TestUnevenTeamsPerRegion()
        {
            var bracket = new Bracket();
            bracket.AddTeam("UCLA", 1, "North");
            bracket.AddTeam("USC", 2, "South");
            bracket.AddTeam("California", 3, "West");

            Assert.ThrowsException<Exception>(() => bracket.CreateNextRound());
        }

        [TestMethod]
        public void TestMismatchedRegions()
        {
            var bracket = new Bracket();
            bracket.AddTeam("UCLA", 1, "North");
            bracket.AddTeam("USC", 2, "North");
            bracket.AddTeam("California", 3, "West");
            bracket.AddTeam("UNLV", 4, "West");
            bracket.AddTeam("Missouri", 5, "West");
            bracket.AddTeam("Florida", 6, "West");

            Assert.ThrowsException<Exception>(() => bracket.CreateNextRound());
        }

        [TestMethod]
        public void TestCreateNextRoundBeforeComplete()
        {
            var bracket = new Bracket();
            bracket.AddTeam("UCLA", 1, "North");
            bracket.AddTeam("USC", 2, "North");
            bracket.AddTeam("California", 3, "West");
            bracket.AddTeam("UNLV", 4, "West");

            bracket.CreateNextRound();
            bracket.Rounds[0].Games[0].Resolve(bracket.Teams["USC"]);
            // California vs UNLV is still unresolved.

            Assert.ThrowsException<Exception>(() => bracket.CreateNextRound());
        }

        private const string TestFileName = "TestTeams.csv";
    }
}
