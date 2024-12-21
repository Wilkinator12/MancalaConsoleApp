using MancalaLibrary.Logic.Leaderboard.Models;

namespace ConsoleUI.ViewModels.Mappers
{
    public static class LeaderboardPlaceMapper
    {
        public static LeaderboardPlaceViewModel ToViewModel(this LeaderboardPlaceModel model)
        {
            return new LeaderboardPlaceViewModel()
            {
                Place = model.Place,
                PlacedPlayers = model.PlacedPlayers.ToViewModel(),
                WinCount = model.WinCount
            };
        }

        public static LeaderboardPlaceModel ToModel(this LeaderboardPlaceViewModel viewModel)
        {
            return new LeaderboardPlaceModel()
            {
                Place = viewModel.Place,
                PlacedPlayers = viewModel.PlacedPlayers.ToModel(),
                WinCount = viewModel.WinCount
            };
        }
    }
}
