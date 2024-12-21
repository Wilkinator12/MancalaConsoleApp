using MancalaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MancalaLibrary.Logic.TwoPlayerGames
{
    public class TwoPlayerGameLogic
    {
        public static GamePlayerModel GetActivePlayer(GameModel game)
        {
            return game.GamePlayers[game.CurrentPlayerTurnIndex];
        }

        public static GamePlayerModel GetOpposingPlayer(GameModel game)
        {
            return game.GamePlayers[GetOpposingPlayerTurnIndex(game)];
        }

        public static int GetOpposingPlayerTurnIndex(GameModel game)
        {
            switch (game.CurrentPlayerTurnIndex)
            {
                case 0:
                    return 1;
                case 1:
                    return 0;
                default:
                    throw new ArgumentException($"A two player game should not have a CurrentPlayerTurnIndex of {game.CurrentPlayerTurnIndex}");
            }
        }
    }
}
