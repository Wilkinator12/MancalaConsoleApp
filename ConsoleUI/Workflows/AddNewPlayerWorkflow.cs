using ConsoleLibrary.Common.Extensions;
using ConsoleLibrary.Prompts.CommonPrompts.Extensions;
using ConsoleUI.Configuration;
using MancalaLibrary.DataAccess.Repositories;
using MancalaLibrary.Models;

namespace ConsoleUI.Workflows
{
    public class AddNewPlayerWorkflow
    {
        private readonly PlayerRepository _playerRepository = new PlayerRepository(DbConfiguration.GetConnectionString());

        public void Run()
        {
            "Add New Player".PrintAsTitle();


            var playerName = "Please enter the player name".AsStringPrompt();

            var newPlayer = new PlayerModel()
            {
                PlayerName = playerName
            };

            _playerRepository.Upsert(newPlayer);


            Console.WriteLine($"{playerName} was added.");
            Console.WriteLine();

            Console.WriteLine("press any key to return...");
            Console.ReadKey();
        }
    }
}
