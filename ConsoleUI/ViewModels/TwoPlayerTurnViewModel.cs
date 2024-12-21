using ConsoleUI.Models;
using MancalaLibrary.Logic.Common.Analyzers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.ViewModels
{
    public class TwoPlayerTurnViewModel
    {
        public GameViewModel Game { get; set; } = null!;
        public GamePlayerViewModel ActivePlayer { get; set; } = null!;
        public GamePlayerViewModel OpposingPlayer { get; set; } = null!;
        public Dictionary<GamePlayerViewModel, int> PlayerTurnNumbers { get; set; } = new Dictionary<GamePlayerViewModel, int>();
    }
}
