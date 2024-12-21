using ConsoleLibrary.Menus.Extensions;
using ConsoleLibrary.Menus.Models;
using ConsoleUI.Menus.ViewModels;

namespace ConsoleUI.Menus
{
    public class ManagePlayersMenu : ConsoleMenu
    {
        private readonly ManagePlayersMenuViewModel _viewModel = new ManagePlayersMenuViewModel();

        public ManagePlayersMenu()
        {
            BuildMenu();
        }

        private void BuildMenu()
        {
            this.NewTitle("Manage Players")
                .AddOption("View Players", _viewModel.ViewPlayers.Run)
                .AddOption("Add New Player", _viewModel.AddNewPlayer.Run)
                .AddOption("Remove Existing Player", _viewModel.RemoveExistingPlayer.Run);
        }
    }
}
