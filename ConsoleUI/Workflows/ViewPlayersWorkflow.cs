using ConsoleLibrary.Common.Extensions;
using ConsoleUI.Configuration;
using ConsoleUI.ViewModels.Mappers;
using MancalaLibrary.DataAccess.Repositories;

namespace ConsoleUI.Workflows
{
    public class ViewPlayersWorkflow
    {
        private readonly PlayerRepository _playerRepository = new PlayerRepository(DbConfiguration.GetConnectionString());


        public void Run()
        {
            "View Players".PrintAsTitle();


            var allPlayers = _playerRepository.ReadAll().ToViewModel();

            if (allPlayers.Any() == true)
            {
                allPlayers.PrintAsNumberedList();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("There are no players to view.");
                Console.WriteLine();
            }


            Console.WriteLine("press any key to return...");
            Console.ReadKey();
        }
    }
}
