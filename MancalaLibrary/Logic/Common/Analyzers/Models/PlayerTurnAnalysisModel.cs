namespace MancalaLibrary.Logic.Common.Analyzers.Models
{
    public class PlayerTurnAnalysisModel
    {
        public PlayerTurnStatus TurnStatus { get; set; }
        public PitSelectionStatus PitSelectionStatus { get; set; }
        public SeedDistributionAnalysisModel SeedDistributionAnalysis { get; set; }
    }
}
