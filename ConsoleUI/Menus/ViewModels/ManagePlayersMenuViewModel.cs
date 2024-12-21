using ConsoleUI.Workflows;

namespace ConsoleUI.Menus.ViewModels
{
    public class ManagePlayersMenuViewModel
    {
        public ViewPlayersWorkflow ViewPlayers { get; set; } = new ViewPlayersWorkflow();
        public AddNewPlayerWorkflow AddNewPlayer { get; set; } = new AddNewPlayerWorkflow();
        public RemoveExistingPlayerWorkflow RemoveExistingPlayer { get; set; } = new RemoveExistingPlayerWorkflow();
    }
}
