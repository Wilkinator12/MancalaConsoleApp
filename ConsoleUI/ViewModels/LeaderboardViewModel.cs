using MancalaLibrary.Logic.Leaderboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.ViewModels
{
    public class LeaderboardViewModel
    {
        public LeaderboardPlaceViewModel FirstPlace { get; set; } = null!;
        public LeaderboardPlaceViewModel SecondPlace { get; set; } = null!;
        public LeaderboardPlaceViewModel ThirdPlace { get; set; } = null!;
    }
}
