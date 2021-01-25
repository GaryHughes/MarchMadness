
namespace MarchMadness
{
    public class Game
    {
        public Game(int roundNumber, Team homeTeam, Team awayTeam)
        {
            RoundNumber = roundNumber;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
        }

        public void Resolve(Team winner)
        {
            Winner = winner;
        }

        public override string ToString()
        {
            var description = $"{HomeTeam.Name} vs {AwayTeam.Name}";

            if (IsComplete)
            {
                description += $" ({Winner?.Name})";
            }

            return description;
        }

        public int RoundNumber { get; }
        public Team HomeTeam { get; }
        public Team AwayTeam { get; }
        public Team? Winner { get; private set; }

        public bool IsComplete => (Winner != null);
    }
}