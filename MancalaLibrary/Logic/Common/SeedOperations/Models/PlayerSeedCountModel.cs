using MancalaLibrary.Models;

namespace MancalaLibrary.Logic.Common.SeedOperations.Models
{
    public class PlayerSeedCountModel
    {
        public GamePlayerModel Player { get; set; }
        public int TotalPitSeedCount { get; set; }
        public int StoreSeedCount { get; set; }
        public int TotalSeedCount => TotalPitSeedCount + StoreSeedCount;
    }
}
