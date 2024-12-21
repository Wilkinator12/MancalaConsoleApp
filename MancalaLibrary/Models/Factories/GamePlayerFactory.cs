using MancalaLibrary.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace MancalaLibrary.Models.Factories
{
    public class GamePlayerFactory
    {
        public GamePlayerModel Create(PlayerModel player)
        {
            var output = new GamePlayerModel { PlayerInfo = player };

            for (int i = 0; i < GameConstants.DefaultNumberOfPits; i++)
            {
                var newPit = new CupModel()
                {
                    CupType = CupType.Pit,
                    SeedCount = GameConstants.DefaultPitSeedCount
                };

                output.Pits.Add(newPit);
            }

            return output;
        }

        public List<GamePlayerModel> Create(List<PlayerModel> players)
        {
            var output = new List<GamePlayerModel>();

            foreach (var player in players)
            {
                var newGamePlayer = Create(player);

                output.Add(newGamePlayer);
            }

            return output;
        }
    }
}
