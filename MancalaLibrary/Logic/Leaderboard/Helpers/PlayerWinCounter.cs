using MancalaLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace MancalaLibrary.Logic.Leaderboard.Helpers
{
    public class PlayerWinCounter
    {
        public List<PlayerModel> GetPlayersWithHighestWinCount(List<PlayerModel> players, out int winCount)
        {
            var output = new List<PlayerModel>();

            winCount = 0;


            if (players.Any() == true)
            {
                List<int> winCounts = players.Select(p => p.WinCount).ToList();

                int highestWinCount = winCounts.Max();
                winCount = highestWinCount;

                output = players.Where(p => p.WinCount == highestWinCount).ToList();
            }


            return output;
        }
    }
}
