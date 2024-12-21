using MancalaLibrary.Logic.Common.Analyzers.Models.Factories;
using MancalaLibrary.Logic.Common.SeedOperations;
using MancalaLibrary.Logic.Common.Validation;
using MancalaLibrary.Models;
using System;

namespace MancalaLibrary.Logic.TwoPlayerGames.TurnOperations.Models.Factories
{
    public static class TwoPlayerTurnFactory
    {
        public static TwoPlayerTurnModel Create(GameModel game)
        {
            if (GameValidation.ValidateNumberOfPlayers(game, 2) == false)
            {
                throw new ArgumentException("There must be exactly 2 players in a game to initiate it as a Two Player Game.");
            }

            var output = new TwoPlayerTurnModel()
            {
                Game = game,
                ActivePlayer = TwoPlayerGameLogic.GetActivePlayer(game),
                OpposingPlayer = TwoPlayerGameLogic.GetOpposingPlayer(game)
            };

            return output;
        }
    }
}
