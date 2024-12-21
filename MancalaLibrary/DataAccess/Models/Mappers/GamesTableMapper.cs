using MancalaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MancalaLibrary.DataAccess.Models.Mappers
{
    public static class GamesTableMapper
    {
        public static GameModel ToGameModel(this GamesTableModel gamesTableModel)
        {
            var gameModel = new GameModel()
            {
                Id = gamesTableModel.Id,
                CurrentPlayerTurnIndex = gamesTableModel.CurrentPlayerTurnIndex,
                StartDate = DateTime.Parse(gamesTableModel.StartDate)
            };

            return gameModel;
        }

        public static List<GameModel> ToGameModel(this List<GamesTableModel> gamesTableModels)
        {
            var gameModels = new List<GameModel>();

            foreach (var gameTableModel in gamesTableModels)
            {
                gameModels.Add(gameTableModel.ToGameModel());
            }

            return gameModels;
        }
    }
}
