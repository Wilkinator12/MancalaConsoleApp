using MancalaLibrary.Logic.Common.Analyzers;
using MancalaLibrary.Logic.Common.Analyzers.Models;
using MancalaLibrary.Logic.Common.CupOperations;
using MancalaLibrary.Logic.Common.SeedOperations.Models;
using MancalaLibrary.Models;

namespace MancalaLibrary.Logic.Common.SeedOperations
{
    public class SeedDistributor
    {
        private readonly CupCycler _cycler;
        private readonly SeedDistributionAnalyzer _analyzer;


        public SeedDistributionModel SeedDistribution { get; set; }


        public SeedDistributor(GameModel game, CupModel selectedPit)
        {
            SeedDistribution = new SeedDistributionModel() 
            {
                OriginalCup = selectedPit,
                Scooper = new SeedScooper()
            };

            SeedDistribution.Scooper.ScoopSeeds(selectedPit);


            _cycler = new CupCycler(game);
            _analyzer = new SeedDistributionAnalyzer(game, SeedDistribution);


            _cycler.SetCurrentCup(SeedDistribution.OriginalCup);
        }


        public SeedDistributionAnalysisModel DistributeNextSeed()
        {
            var output = _analyzer.Analyze();

            if (output.Status != SeedDistributionStatus.SeedsDistributed)
            {
                var nextCup = _cycler.CycleNext();

                SeedDistribution.Scooper.DropSeed(nextCup);
                SeedDistribution.CupsDistributedTo.Add(nextCup);

                output = _analyzer.Analyze();


                if (output.Status == SeedDistributionStatus.SeedsDistributed)
                {
                    SeedDistribution.FinalCup = nextCup;
                }
            }

            return output;
        }
    }
}
