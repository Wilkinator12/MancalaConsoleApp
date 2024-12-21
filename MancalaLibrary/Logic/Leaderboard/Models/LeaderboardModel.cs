using System;
using System.Text;

namespace MancalaLibrary.Logic.Leaderboard.Models
{
    public class LeaderboardModel
    {
        public LeaderboardPlaceModel FirstPlace { get; set; }
        public LeaderboardPlaceModel SecondPlace { get; set; }
        public LeaderboardPlaceModel ThirdPlace { get; set; }
    }
}
