using ConsoleLibrary.Common.Extensions;
using ConsoleUI.Configuration;
using ConsoleUI.Prompts;
using ConsoleUI.ViewModels.Mappers;
using MancalaLibrary.DataAccess.Repositories;

namespace ConsoleUI.Workflows
{
    public class LoadTwoPlayerGameWorkflow
    {
        private readonly GameRepository _gameRepository = new GameRepository(DbConfiguration.GetConnectionString());


        public void Run()
        {
            "Load Two Player Game".PrintAsTitle();


            var allGames = _gameRepository.ReadAll().ToViewModel();


            if (allGames.Any() == true)
            {
                var selectedGame = "Please select a game to load".AsGameSelectPrompt(allGames);

                Console.Clear();

                new TwoPlayerGameWorkflow(selectedGame.ToModel()).RunGame();
            }
            else
            {
                Console.WriteLine("There are no games to load.");
                Console.WriteLine();

                Console.WriteLine("press any key to return...");
                Console.ReadKey();
            }
        }
    }
}
