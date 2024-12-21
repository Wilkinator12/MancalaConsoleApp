using ConsoleLibrary.Menus.Models;
using ConsoleUI.Workflows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Menus.ViewModels
{
    public class MainMenuViewModel
    {
        public ConsoleMenu ManagePlayersMenu { get; set; } = new ManagePlayersMenu();
        public NewTwoPlayerGameWorkflow NewTwoPlayerGame { get; set; } = new NewTwoPlayerGameWorkflow();
        public LoadTwoPlayerGameWorkflow LoadTwoPlayerGame { get; set; } = new LoadTwoPlayerGameWorkflow();
        public LeaderboardWorkflow Leaderboard { get; set; } = new LeaderboardWorkflow();
    }
}
