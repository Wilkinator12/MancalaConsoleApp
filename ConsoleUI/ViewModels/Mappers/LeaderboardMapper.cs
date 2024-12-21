using MancalaLibrary.Logic.Leaderboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.ViewModels.Mappers
{
    public static class LeaderboardMapper
    {
        public static LeaderboardViewModel ToViewModel(this LeaderboardModel model)
        {
            return new LeaderboardViewModel()
            {
                FirstPlace = model.FirstPlace.ToViewModel(),
                SecondPlace = model.SecondPlace.ToViewModel(),
                ThirdPlace = model.ThirdPlace.ToViewModel()
            };
        }

        public static LeaderboardModel ToViewModel(this LeaderboardViewModel viewModel)
        {
            return new LeaderboardModel()
            {
                FirstPlace = viewModel.FirstPlace.ToModel(),
                SecondPlace = viewModel.SecondPlace.ToModel(),
                ThirdPlace = viewModel.ThirdPlace.ToModel()
            };
        }
    }
}
