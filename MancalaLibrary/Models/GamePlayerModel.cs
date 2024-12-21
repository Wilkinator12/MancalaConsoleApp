using System.Collections.Generic;

namespace MancalaLibrary.Models
{
    public class GamePlayerModel
    {
        public int Id { get; set; }
        public PlayerModel PlayerInfo { get; set; }
        public CupModel Store { get; set; } = new CupModel { CupType = CupType.Store };
        public List<CupModel> Pits { get; set; } = new List<CupModel>();
    }
}
