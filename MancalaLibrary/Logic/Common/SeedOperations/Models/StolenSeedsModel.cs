using MancalaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MancalaLibrary.Logic.Common.SeedOperations.Models
{
    public class StolenSeedsModel
    {
        public CupModel PitLandedIn { get; set; }
        public CupModel PitStolenFrom { get; set; }
        public CupModel StoreDepositedIn { get; set; }
        public int NumberOfStolenSeeds { get; set; }
        public int TotalSowedSeeds { get; set; }
    }
}
