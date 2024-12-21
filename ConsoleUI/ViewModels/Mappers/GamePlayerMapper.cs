using ConsoleUI.Models;
using MancalaLibrary.Models;
using System.Reflection;

namespace ConsoleUI.ViewModels.Mappers
{
    public static class GamePlayerMapper
    {
        public static GamePlayerViewModel ToViewModel(this GamePlayerModel model)
        {
            var output = new GamePlayerViewModel()
            {
                Id = model.Id,
                PlayerInfo = model.PlayerInfo.ToViewModel()
            };
            output.Store = model.Store.ToViewModel();
            output.Pits = model.Pits.ToViewModel();

            return output;
        }

        public static GamePlayerModel ToModel(this GamePlayerViewModel viewModel)
        {
            var output = new GamePlayerModel()
            {
                Id = viewModel.Id,
                PlayerInfo = viewModel.PlayerInfo.ToModel()
            };

            output.Store = viewModel.Store.ToModel();
            output.Pits = viewModel.Pits.ToModel();

            return output;
        }

        public static List<GamePlayerViewModel> ToViewModel(this List<GamePlayerModel> models)
        {
            var output = new List<GamePlayerViewModel>();

            foreach (var model in models)
            {
                var viewModel = model.ToViewModel();

                output.Add(viewModel);
            }

            return output;
        }

        public static List<GamePlayerModel> ToModel(this List<GamePlayerViewModel> viewModels)
        {
            var output = new List<GamePlayerModel>();

            foreach (var viewModel in viewModels)
            {
                var model = viewModel.ToModel();

                output.Add(model);
            }

            return output;
        }
    }
}
