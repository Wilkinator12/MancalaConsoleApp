using ConsoleLibrary.Common.Extensions;
using ConsoleLibrary.Prompts.Base.Models;
using ConsoleUI.Configuration;
using ConsoleUI.Prompts;
using ConsoleUI.ViewModels.Mappers;
using MancalaLibrary.DataAccess.Repositories;
using MancalaLibrary.Models;
using MancalaLibrary.Models.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Workflows
{
    public class NewTwoPlayerGameWorkflow
    {
        private readonly GameRepository _gameRepository = new GameRepository(DbConfiguration.GetConnectionString());
        private readonly PlayerRepository _playerRepository = new PlayerRepository(DbConfiguration.GetConnectionString());


        public void Run()
        {
            "New Two Player Game".PrintAsTitle();


            var allPlayers = _playerRepository.ReadAll().ToViewModel();

            if (allPlayers.Count > 1)
            {
                // Get the players
                var playerOne = "Please select Player One".AsPlayerSelectPrompt(allPlayers);
                Console.WriteLine();

                allPlayers.Remove(playerOne);
                Console.WriteLine($"{playerOne} will be Player One");
                Console.WriteLine();


                var playerTwo = "Please select Player Two".AsPlayerSelectPrompt(allPlayers);
                Console.WriteLine();

                Console.WriteLine($"{playerTwo} will be Player Two");
                Console.WriteLine();


                Console.WriteLine("press any key to start the game...");
                Console.ReadKey();


                // Create the game
                var newGame = new GameFactory().Create(new List<PlayerModel> { playerOne.ToModel(), playerTwo.ToModel() });
                _gameRepository.Upsert(newGame);


                // Start the game
                Console.Clear();

                new TwoPlayerGameWorkflow(newGame).RunGame();
            }
            else
            {
                Console.WriteLine("There are no players saved.\nPlease save at least two to start a game");
                Console.WriteLine();

                Console.WriteLine("press any key to return...");
                Console.ReadKey();
            }
        }
    }
}
