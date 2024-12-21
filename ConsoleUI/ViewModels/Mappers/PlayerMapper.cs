using ConsoleUI.Models;
using MancalaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.ViewModels.Mappers
{
    public static class PlayerMapper
    {
        public static PlayerViewModel ToViewModel(this PlayerModel model)
        {
            var output = new PlayerViewModel()
            {
                Id = model.Id,
                PlayerName = model.PlayerName,
                WinCount = model.WinCount
            };

            return output;
        }

        public static PlayerModel ToModel(this PlayerViewModel viewModel)
        {
            var output = new PlayerModel()
            {
                Id = viewModel.Id,
                PlayerName = viewModel.PlayerName,
                WinCount = viewModel.WinCount
            };

            return output;
        }

        public static List<PlayerViewModel> ToViewModel(this List<PlayerModel> models)
        {
            var output = new List<PlayerViewModel>();


            foreach (var model in models)
            {
                output.Add(model.ToViewModel());    
            }


            return output;
        }

        public static List<PlayerModel> ToModel(this List<PlayerViewModel> viewModels)
        {
            var output = new List<PlayerModel>();


            foreach (var viewModel in viewModels)
            {
                output.Add(viewModel.ToModel());
            }


            return output;
        }
    }
}
