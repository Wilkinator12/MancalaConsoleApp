using MancalaLibrary.Logic.Common.Board.Models;
using MancalaLibrary.Logic.Common.Board.Models.Factories;
using MancalaLibrary.Logic.Common.Validation;
using MancalaLibrary.Models;
using System;

namespace MancalaLibrary.Logic.TwoPlayerGames.Board
{
    public class TwoPlayerBoardNavigator
    {
        private readonly BoardModel _board;


        public GamePlayerModel ActivePlayer { get; set; }
        public GamePlayerModel OpposingPlayer { get; set; }


        public TwoPlayerBoardNavigator(GameModel game)
        {
            if (GameValidation.ValidateNumberOfPlayers(game, 2) == false)
            {
                throw new ArgumentException("TwoPlayerBoardNavigator only works with Two Player games.");
            }
            if (GameValidation.ValidateSameNumberOfPits(game))
            {
                throw new ArgumentException("TwoPlayerBoardNavigator does not work with games of varying pit numbers.");
            }

            _board = BoardFactory.Create(game);
            ActivePlayer = TwoPlayerGameLogic.GetActivePlayer(game);
            OpposingPlayer = TwoPlayerGameLogic.GetOpposingPlayer(game);
        }

        public CupModel GetAdjacentPit(CupModel pit)
        {
            if (pit.CupType != CupType.Pit)
            {
                throw new ArgumentException("The CupModel must be of type 'CupType.Pit' to use the GetAdjacentPit method.");
            }


            var playerPitIndex = GetPlayerPitIndex(pit);

            int adjacentPlayerPitIndex = OpposingPlayer.Pits.Count - playerPitIndex - 1;


            return OpposingPlayer.Pits[adjacentPlayerPitIndex];
        }

        public int GetPlayerPitIndex(CupModel pit)
        {
            var output = ActivePlayer.Pits.IndexOf(pit);


            if (output == -1)
            {
                throw new ArgumentException("The pit did not appear on the active player's side of the board.");
            }


            return output;
        }
    }
}
