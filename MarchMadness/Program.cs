using System;

namespace MarchMadness
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                var filename = (args.Length > 0) ? args[0] : "Teams.csv";

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
                        game.Resolve(ChooseWinner(game));
                        Console.WriteLine($"\t({game.Winner?.Name})");
                    }

                    Console.WriteLine();
                }

                var champion = bracket.FindChampion() ?? throw new Exception("No champion found");
                Console.WriteLine($"Champion is: {champion.Name}");
                Console.WriteLine();

                Console.WriteLine("Path to Victory: ");
                foreach (var game in bracket.ListGames(champion))
                {
                    Console.WriteLine($"  Round {game.RoundNumber}: defeated {game.Loser?.Name}");
                }

                return 0;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"ERROR: {exception.Message}");
                return 1;
            }
        }

        public static Team ChooseWinner(Game game)
        {
            Console.Write($"  {game,-40} (H)ome, (A)way, (R)andom? ");
            var key = Console.ReadKey();

            switch (key.KeyChar)
            {
                case 'H':
                case 'h':
                    return game.HomeTeam;

                case 'A':
                case 'a':
                    return game.AwayTeam;

                default:
                    return ChooseAtRandom(game.HomeTeam, game.AwayTeam);
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
