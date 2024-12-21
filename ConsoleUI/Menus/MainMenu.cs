using ConsoleLibrary.Menus.Extensions;
using ConsoleLibrary.Menus.Models;
using ConsoleUI.Menus.ViewModels;

namespace ConsoleUI.Menus
{
    public class MainMenu : ConsoleMenu
    {
        private readonly MainMenuViewModel _viewModel = new MainMenuViewModel();

        public MainMenu()
        {
            BuildMenu();
        }

        private void BuildMenu()
        {
            this.NewTitle("Mancala - Main Menu")
                .AddOption("New Two Player Game", _viewModel.NewTwoPlayerGame.Run)
                .AddOption("Load Two Player Game", _viewModel.LoadTwoPlayerGame.Run)
                .AddOption("Leaderboard", _viewModel.Leaderboard.Run)
                .AddOption("Manage Players", _viewModel.ManagePlayersMenu.Run);
        }
    }
}
