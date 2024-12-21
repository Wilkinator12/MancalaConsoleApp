using MancalaLibrary.Logic.Common.Board.Models;
using MancalaLibrary.Models;

namespace MancalaLibrary.Logic.Common.Board.Models.Factories
{
    public static class BoardFactory
    {
        public static BoardModel Create(GameModel game)
        {
            var output = new BoardModel();

            foreach (var gamePlayer in game.GamePlayers)
            {
                output.Players.Add(gamePlayer);
                AddCups(output, gamePlayer);
            }

            return output;
        }


        private static void AddCups(BoardModel board, GamePlayerModel gamePlayer)
        {
            AddPits(board, gamePlayer);
            board.CupPath.Add(gamePlayer.Store);
        }

        private static void AddPits(BoardModel output, GamePlayerModel gamePlayer)
        {
            foreach (var pit in gamePlayer.Pits)
            {
                output.CupPath.Add(pit);
            }
        }
    }
}
