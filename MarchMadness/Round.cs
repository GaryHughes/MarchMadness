using System;
using System.Collections.Generic;

namespace MarchMadness
{
    public class Round
    {
        public Round(int roundNumber)
        {
            RoundNumber = roundNumber;
            Games = new List<Game>();
        }

        public void AddGame(Team homeTeam, Team awayTeam)
        {
            Games.Add(new Game(RoundNumber, homeTeam, awayTeam));
        }

        public int RoundNumber { get; }
        public List<Game> Games { get; }
    }
}