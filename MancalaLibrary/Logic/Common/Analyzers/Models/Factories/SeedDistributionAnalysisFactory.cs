namespace MancalaLibrary.Logic.Common.Analyzers.Models.Factories
{
    public static class SeedDistributionAnalysisFactory
    {
        public static SeedDistributionAnalysisModel Create()
        {
            return new SeedDistributionAnalysisModel()
            {
                Status = SeedDistributionStatus.NoSeedsDistributed,
                Result = SeedDistributionResult.NoResult
            };
        }
    }
}
