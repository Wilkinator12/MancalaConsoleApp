namespace MancalaLibrary.Logic.Common.Analyzers.Models.Factories
{
    public static class PlayerTurnAnalysisFactory
    {
        public static PlayerTurnAnalysisModel Create()
        {
            return new PlayerTurnAnalysisModel()
            {
                TurnStatus = PlayerTurnStatus.InProgress,
                PitSelectionStatus = PitSelectionStatus.SelectingPit,
                SeedDistributionAnalysis = SeedDistributionAnalysisFactory.Create()
            };
        }
    }
}
