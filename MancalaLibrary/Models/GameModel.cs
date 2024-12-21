using System;
using System.Collections.Generic;

namespace MancalaLibrary.Models
{
    public class GameModel
    {
        public int Id { get; set; }
        public List<GamePlayerModel> GamePlayers { get; set; } = new List<GamePlayerModel>();
        public int CurrentPlayerTurnIndex { get; set; }
        public DateTime StartDate { get; set; }


        public GamePlayerModel ActivePlayer => GamePlayers[CurrentPlayerTurnIndex];
    }
}
