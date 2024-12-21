using MancalaLibrary.Logic.Common.SeedOperations;
using MancalaLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace MancalaLibrary.Logic.Common.SeedOperations.Models
{
    public class SeedDistributionModel
    {
        public SeedScooper Scooper { get; set; }

        public CupModel OriginalCup { get; set; }
        public List<CupModel> CupsDistributedTo { get; set; } = new List<CupModel>();
        public CupModel LastCupDistributedTo => CupsDistributedTo.LastOrDefault();
        public CupModel FinalCup { get; set; } = null;
    }
}
