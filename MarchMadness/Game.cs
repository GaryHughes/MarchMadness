
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

        public int RoundNumber { get; }
        public Team HomeTeam { get; }
        public Team AwayTeam { get; }
        public Team? Winner { get; private set; }

        public bool IsComplete => (Winner != null);
    }
}