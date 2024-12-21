using MancalaLibrary.Models;

namespace ConsoleUI.ViewModels.Mappers
{
    public static class GameMapper
    {
        public static GameViewModel ToViewModel(this GameModel model)
        {
            var output = new GameViewModel()
            {
                Id = model.Id,
                GamePlayers = model.GamePlayers.ToViewModel(),
                CurrentPlayerTurnIndex = model.CurrentPlayerTurnIndex,
                StartDate = model.StartDate
            };

            return output;
        }

        public static GameModel ToModel(this GameViewModel viewModel)
        {
            var output = new GameModel()
            {
                Id = viewModel.Id,
                GamePlayers = viewModel.GamePlayers.ToModel(),
                CurrentPlayerTurnIndex = viewModel.CurrentPlayerTurnIndex,
                StartDate = viewModel.StartDate
            };

            return output;
        }

        public static List<GameViewModel> ToViewModel(this List<GameModel> models)
        {
            var output = new List<GameViewModel>();

            foreach (var model in models)
            {
                output.Add(model.ToViewModel());
            }

            return output;
        }

        public static List<GameModel> ToViewModel(this List<GameViewModel> viewModels)
        {
            var output = new List<GameModel>();

            foreach (var viewModel in viewModels)
            {
                output.Add(viewModel.ToModel());
            }

            return output;
        }
    }
}
