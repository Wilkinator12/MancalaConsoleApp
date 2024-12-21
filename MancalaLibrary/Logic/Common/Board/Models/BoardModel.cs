using MancalaLibrary.Models;
using System.Collections.Generic;

namespace MancalaLibrary.Logic.Common.Board.Models
{
    public class BoardModel
    {
        public List<GamePlayerModel> Players { get; set; } = new List<GamePlayerModel>();
        public List<CupModel> CupPath { get; set; } = new List<CupModel>();
    }
}
