using MancalaLibrary.Models;
using System.Collections.Generic;

namespace MancalaLibrary.Logic.Leaderboard.Models
{
    public class LeaderboardPlaceModel
    {
        public int Place { get; set; }
        public List<PlayerModel> PlacedPlayers { get; set; } = new List<PlayerModel>();
        public int WinCount { get; set; }
    }
}
