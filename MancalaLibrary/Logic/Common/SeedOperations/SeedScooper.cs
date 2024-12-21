using MancalaLibrary.Models;

namespace MancalaLibrary.Logic.Common.SeedOperations
{
    public class SeedScooper
    {
        public int SeedCount { get; set; }


        public void ScoopSeeds(CupModel cup)
        {
            SeedCount += cup.SeedCount;
            cup.SeedCount = 0;
        }


        public void DropSeed(CupModel cup)
        {
            SeedCount--;
            cup.SeedCount++;
        }

        public void DumpAllSeeds(CupModel cup)
        {
            cup.SeedCount += SeedCount;
            SeedCount = 0;
        }

    }
}
