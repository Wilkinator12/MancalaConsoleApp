using MancalaLibrary.Logic.Common.Analyzers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.ViewModels.Mappers
{
    public static class GameResultMapper
    {
        public static GameResultViewModel ToViewModel(this GameResultModel model)
        {
            return new GameResultViewModel()
            {
                Winners = model.FirstPlacePlayers.ToViewModel()
            };
        }
    }
}
