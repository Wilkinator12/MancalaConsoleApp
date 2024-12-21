namespace MancalaLibrary.DataAccess.Models
{
    public class GamePlayerPitsTableModel
    {
        public int Id { get; set; }
        public int GamePlayerId { get; set; }
        public int PositionIndex { get; set; }
        public int SeedCount { get; set; }
    }
}
