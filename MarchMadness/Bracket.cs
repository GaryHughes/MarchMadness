using System;
using System.Collections.Generic;
using System.Linq;

namespace MarchMadness
{
    public class Bracket
    {
        public Bracket()
        {
            Teams = new Dictionary<string, Team>();
            Rounds = new List<Round>();
        }

        public void AddTeam(string name, int seed, string region)
        {
            Teams[name] = new Team(name, seed, region);
        }

        public void CreateNextRound()
        {
            var round = new Round(RoundNumber + 1);

            var remainingTeams = ListRemainingTeams();
            var teamsByRegion = remainingTeams.GroupBy(team => team.Region);
            if (IsPlayoffRound(teamsByRegion))
            {
                // Playoff round, teams play only within their region.
                foreach (var teams in teamsByRegion)
                {
                    CreateGames(round, teams.OrderBy(team => team.Seed));
                }
            }
            else
            {
                // Finals Round, teams play across all regions.
                CreateGames(round, remainingTeams);
            }

            Rounds.Add(round);
        }

        private bool IsPlayoffRound(IEnumerable<IGrouping<string, Team>> teamsByRegion)
        {
            return teamsByRegion.Any(teams => teams.Count() > 1);
        }

        public IEnumerable<Team> ListRemainingTeams()
        {
            if (LastRound == null)
            {
                return AllTeams;
            }

            return LastRound.Games.Select(game => game.Winner ?? throw new Exception($"No winner for game {game}"));
        }

        public bool IsComplete()
        {
            if (LastRound == null || LastRound.Games.Any(game => !game.IsComplete))
            {
                return false;
            }

            return ListRemainingTeams().Count() == 1;
        }

        public Team? FindChampion()
        {
            if (!IsComplete())
            {
                return null;
            }

            return ListRemainingTeams().First();
        }

        public List<Game> ListGames(Team team)
        {
            var games = new List<Game>();
            foreach (var round in Rounds)
            {
                games.AddRange(round.Games.Where(game => game.HomeTeam == team || game.AwayTeam == team));
            }

            return games;
        }

        private void CreateGames(Round round, IEnumerable<Team> teams)
        {
            var teamsToPlay = teams.ToHashSet();
            while (teamsToPlay.Any())
            {
                var homeTeam = teamsToPlay.First();
                var awayTeam = teamsToPlay.Last();

                round.AddGame(homeTeam, awayTeam);

                teamsToPlay.Remove(homeTeam);
                teamsToPlay.Remove(awayTeam);
            }
        }

        public Dictionary<string, Team> Teams { get; }
        public HashSet<Team> AllTeams => Teams.Values.ToHashSet();

        public List<Round> Rounds { get; }
        public Round? LastRound => Rounds.LastOrDefault();
        public int RoundNumber => Rounds.Count();
    }
}