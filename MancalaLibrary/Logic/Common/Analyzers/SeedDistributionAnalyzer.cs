using MancalaLibrary.Logic.Common.Analyzers.Models;
using MancalaLibrary.Logic.Common.SeedOperations.Models;
using MancalaLibrary.Models;
using System.Linq;

namespace MancalaLibrary.Logic.Common.Analyzers
{
    public class SeedDistributionAnalyzer
    {
        private readonly GameModel _game;
        private readonly SeedDistributionModel _seedDistribution;


        public SeedDistributionAnalyzer(GameModel game, SeedDistributionModel seedDistribution)
        {
            _game = game;
            _seedDistribution = seedDistribution;
        }


        public SeedDistributionAnalysisModel Analyze()
        {
            var output = new SeedDistributionAnalysisModel();


            if (_seedDistribution.Scooper.SeedCount == 0)
            {
                output = AnalyzeForAnEmptySeedCount();
            }
            else if (_seedDistribution.CupsDistributedTo.Any() == true)
            {
                output.Status = SeedDistributionStatus.DistributingSeeds;
                output.Result = SeedDistributionResult.NoResult;
            }
            else
            {
                output.Status = SeedDistributionStatus.NoSeedsDistributed;
                output.Result = SeedDistributionResult.NoResult;
            }

            return output;
        }

        private SeedDistributionAnalysisModel AnalyzeForAnEmptySeedCount()
        {
            var output = new SeedDistributionAnalysisModel();


            output.Status = SeedDistributionStatus.SeedsDistributed;


            var finalCup = _seedDistribution.CupsDistributedTo.LastOrDefault();

            if (finalCup != null && GameLogic.CupBelongsToActivePlayer(_game, finalCup))
            {
                if (finalCup == _game.ActivePlayer.Store)
                {
                    output.Result = SeedDistributionResult.LandedInStore;
                }
                else if (finalCup.SeedCount == 1)
                {
                    output.Result = SeedDistributionResult.LandedInOwnEmptyPit;
                }
                else
                {
                    output.Result = SeedDistributionResult.LandedNowhereSignificant;
                }
            }
            else
            {
                output.Result = SeedDistributionResult.LandedNowhereSignificant;
            }


            return output;
        }
    }
}
