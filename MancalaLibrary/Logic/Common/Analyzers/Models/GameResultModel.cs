using MancalaLibrary.Models;
using System.Collections.Generic;

namespace MancalaLibrary.Logic.Common.Analyzers.Models
{
    public class GameResultModel
    {
        public List<GamePlayerModel> FirstPlacePlayers { get; set; } = new List<GamePlayerModel>();
    }
}
