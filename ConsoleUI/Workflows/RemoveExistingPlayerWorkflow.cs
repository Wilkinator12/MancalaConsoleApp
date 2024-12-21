using ConsoleLibrary.Common.Extensions;
using ConsoleLibrary.Prompts.CommonPrompts.Extensions;
using ConsoleUI.Configuration;
using ConsoleUI.Prompts;
using ConsoleUI.ViewModels.Mappers;
using MancalaLibrary.DataAccess.Repositories;

namespace ConsoleUI.Workflows
{
    public class RemoveExistingPlayerWorkflow
    {
        private readonly PlayerRepository _playerRepository = new PlayerRepository(DbConfiguration.GetConnectionString());


        public void Run()
        {
            var allPlayers = _playerRepository.ReadAll();

            if (allPlayers.Any() == true)
            {
                bool playerHasApproveSelection = false;

                while (playerHasApproveSelection == false)
                {
                    "Remove Existing Player".PrintAsTitle();

                    var selectedPlayer = "Please select the player to remove".AsPlayerSelectPrompt(allPlayers.ToViewModel());
                    Console.WriteLine();


                    var response = $"Are you sure you want to remove {selectedPlayer.PlayerName} (y / n)".AsStringPrompt(new List<string> { "y", "n" });

                    if (response == "y")
                    {
                        playerHasApproveSelection = true;


                        if (_playerRepository.Delete(selectedPlayer.Id))
                        {
                            Console.WriteLine($"{selectedPlayer} was removed.");
                        }
                        else
                        {
                            Console.WriteLine($"Can't remove {selectedPlayer}");
                        }


                        Console.WriteLine();
                        Console.WriteLine("press any key to return...");
                        Console.ReadKey();
                    }
                }
            }
            else
            {
                "Remove Existing Player".PrintAsTitle();

                Console.WriteLine("There no players to remove.");
                Console.WriteLine();

                Console.WriteLine("press any key to return...");
                Console.ReadKey();
            }
        }
    }
}
