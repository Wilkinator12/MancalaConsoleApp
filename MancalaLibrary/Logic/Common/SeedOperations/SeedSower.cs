using MancalaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MancalaLibrary.Logic.Common.SeedOperations
{
    public class SeedSower
    {
        private readonly GameModel _game;


        private readonly SeedScooper _seedScooper = new SeedScooper();


        public SeedSower(GameModel game)
        {
            _game = game;
        }


        public void SowAllSeeds()
        {
            foreach (var gamePlayer in _game.GamePlayers)
            {
                SowPlayerSeeds(gamePlayer);
            }
        }

        public void SowPlayerSeeds(GamePlayerModel gamePlayer)
        {
            foreach (var pit in gamePlayer.Pits)
            {
                _seedScooper.ScoopSeeds(pit);
            }

            _seedScooper.DumpAllSeeds(gamePlayer.Store);
        }
    }
}
