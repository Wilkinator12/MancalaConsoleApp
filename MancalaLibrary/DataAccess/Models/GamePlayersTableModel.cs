namespace MancalaLibrary.DataAccess.Models
{
    public class GamePlayersTableModel
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public int TurnIndex { get; set; }
    }
}
