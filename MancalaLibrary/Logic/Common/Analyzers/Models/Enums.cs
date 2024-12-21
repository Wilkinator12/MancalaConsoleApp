using System;
using System.Collections.Generic;
using System.Text;

namespace MancalaLibrary.Logic.Common.Analyzers.Models
{
    public enum PlayerTurnStatus
    {
        InProgress,
        Ended
    }

    public enum PitSelectionStatus
    {
        SelectingPit,
        EmptyPitSelected,
        ValidPitSelected
    }

    public enum SeedDistributionStatus
    {
        NoSeedsDistributed,
        DistributingSeeds,
        SeedsDistributed
    }

    public enum SeedDistributionResult
    {
        NoResult,
        LandedInStore,
        LandedInOwnEmptyPit,
        LandedNowhereSignificant
    }
}
