using MancalaLibrary.Models;
using System;
using System.Text;

namespace MancalaLibrary.Logic.TwoPlayerGames.TurnOperations.Models
{
    public class TwoPlayerTurnModel
    {
        public GameModel Game { get; set; }

        public GamePlayerModel ActivePlayer { get; set; }
        public GamePlayerModel OpposingPlayer { get; set; }
    }
}
