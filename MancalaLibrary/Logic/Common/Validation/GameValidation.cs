using MancalaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MancalaLibrary.Logic.Common.Validation
{
    public static class GameValidation
    {
        public static bool ValidateSameNumberOfPits(GameModel game)
        {
            if (game.GamePlayers.Any() == false)
            {
                throw new ArgumentException("Cannout validate the number of pits for a game with no players.");
            }


            int firstPlayerPitCount = game.GamePlayers.First().Pits.Count();

            return game.GamePlayers.Any(gp => gp.Pits.Count != firstPlayerPitCount);
        }

        public static bool ValidateNumberOfPlayers(GameModel game, int numberOfPlayers)
        {
            return game.GamePlayers.Count == numberOfPlayers;
        }
    }
}
