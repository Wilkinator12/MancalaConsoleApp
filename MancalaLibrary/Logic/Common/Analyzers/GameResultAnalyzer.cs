using MancalaLibrary.Logic.Common.Analyzers.Models;
using MancalaLibrary.Logic.Common.SeedOperations;
using MancalaLibrary.Models;
using System;
using System.Linq;

namespace MancalaLibrary.Logic.Common.Analyzers
{
    public class GameResultAnalyzer
    {
        private readonly GameModel _game;


        private readonly SeedCounter _seedCounter = new SeedCounter();


        public GameResultAnalyzer(GameModel game)
        {
            _game = game;
        }


        public GameResultModel Analyze()
        {
            var output = new GameResultModel();


            if (GameIsOver())
            {
                var highestSeedCounts = _seedCounter.GetHighestSeedCounts(_game);

                output.FirstPlacePlayers = highestSeedCounts.Select(sc => sc.Player).ToList();
            }


            return output;
        }

        private bool GameIsOver() => _seedCounter.AnyPlayerHasNoPitSeeds(_game) == true;
    }
}
