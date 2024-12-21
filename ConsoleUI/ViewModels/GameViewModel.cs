using ConsoleUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.ViewModels
{
    public class GameViewModel
    {
        public int Id { get; set; }
        public List<GamePlayerViewModel> GamePlayers { get; set; } = new List<GamePlayerViewModel>();
        public int CurrentPlayerTurnIndex { get; set; }
        public DateTime StartDate { get; set; }

        public string TwoPlayerDisplayText => $"{GamePlayers[0]} vs. {GamePlayers[1]} - {StartDate.ToShortDateString()}";

        public override string ToString() => TwoPlayerDisplayText;
    }
}
