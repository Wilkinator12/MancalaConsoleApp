using MancalaLibrary.Logic.Common.Analyzers.Models;
using MancalaLibrary.Models;

namespace MancalaLibrary.Logic.Common.Analyzers
{
    public class PitSelectionAnalyzer
    {
        public PitSelectionStatus Analyze(CupModel cup)
        {
            if (cup.SeedCount == 0)
            {
                return PitSelectionStatus.EmptyPitSelected;
            }
            else
            {
                return PitSelectionStatus.ValidPitSelected;
            }
        }
    }
}
