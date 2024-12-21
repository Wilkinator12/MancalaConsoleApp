using ConsoleLibrary.Common.Extensions;
using ConsoleUI.Configuration;
using ConsoleUI.ViewModels;
using ConsoleUI.ViewModels.Mappers;
using MancalaLibrary.Logic.Leaderboard.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Workflows
{
    public class LeaderboardWorkflow
    {
        public void Run()
        {
            var leaderboardGenerator = new LeaderboardGenerator(DbConfiguration.GetConnectionString());

            var leaderboard = leaderboardGenerator.GetLeaderboard().ToViewModel();


            "Leaderboard".PrintAsTitle();

            Console.WriteLine(leaderboard.FirstPlace);
            Console.WriteLine(leaderboard.SecondPlace);
            Console.WriteLine(leaderboard.ThirdPlace);
            Console.WriteLine();

            Console.WriteLine("press any key to return...");
            Console.ReadKey();
        }
    }
}
