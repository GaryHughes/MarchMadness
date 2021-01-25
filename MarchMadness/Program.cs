using System;

namespace MarchMadness
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = (args.Length > 1) ? args[1] : "Teams.csv";

            var bracket = new Bracket();
            bracket.LoadTeams(filename);

            while (!bracket.IsComplete())
            {
                bracket.CreateNextRound();
                Console.WriteLine($"Round #{bracket.RoundNumber}");
                Console.WriteLine("--------");

                var lastRound = bracket.LastRound ?? throw new Exception("No last round defined.");
                foreach (var game in bracket.LastRound.Games)
                {
                    game.Resolve(ChooseAtRandom(game.HomeTeam, game.AwayTeam));
                    Console.WriteLine(game.ToString());
                }

                Console.WriteLine();
            }

            var champion = bracket.FindChampion() ?? throw new Exception("No champion found");
            Console.WriteLine($"Champion is: {champion.Name}");
            Console.WriteLine();

            Console.WriteLine("Path to Victory: ");
            foreach (var game in bracket.ListGames(champion))
            {
                Console.WriteLine($"    Defeated {game.Loser?.Name}");
            }
        }

        public static T ChooseAtRandom<T>(params T[] elements)
        {
            var random = new Random();
            var index = random.Next() % elements.Length;
            return elements[index];
        }
    }
}
