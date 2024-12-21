using ConsoleUI.Models;
using MancalaLibrary.Logic.Common.SeedOperations;
using MancalaLibrary.Logic.TwoPlayerGames.TurnOperations.Models;

namespace ConsoleUI.ViewModels.Mappers
{
    public static class TwoPlayerTurnMapper
    {
        public static TwoPlayerTurnViewModel ToViewModel(this TwoPlayerTurnModel model)
        {
            var output = new TwoPlayerTurnViewModel()
            {
                Game = model.Game.ToViewModel(),
                ActivePlayer = model.ActivePlayer.ToViewModel(),
                OpposingPlayer = model.OpposingPlayer.ToViewModel()
            };


            int activePlayerNumber = model.Game.GamePlayers.IndexOf(model.ActivePlayer) + 1;
            int opposingPlayerNumber = model.Game.GamePlayers.IndexOf(model.OpposingPlayer) + 1;

            output.PlayerTurnNumbers.Add(output.ActivePlayer, activePlayerNumber);
            output.PlayerTurnNumbers.Add(output.OpposingPlayer, opposingPlayerNumber);

            return output;
        }

        public static TwoPlayerTurnModel ToModel(this TwoPlayerTurnViewModel viewModel)
        {
            var output = new TwoPlayerTurnModel()
            {
                Game = viewModel.Game.ToModel(),
                ActivePlayer = viewModel.ActivePlayer.ToModel(),
                OpposingPlayer = viewModel.OpposingPlayer.ToModel()
            };

            return output;
        }
    }
}
