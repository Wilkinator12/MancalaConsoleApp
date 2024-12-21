using System;
using System.Collections.Generic;
using System.Text;

namespace MancalaLibrary.Models.Factories
{
    public class GameFactory
    {
        public GameModel Create(List<PlayerModel> players)
        {
            return new GameModel 
            { 
                GamePlayers = new GamePlayerFactory().Create(players),
                StartDate = DateTime.Now 
            };
        }
    }
}
