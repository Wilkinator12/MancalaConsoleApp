using MancalaLibrary.DataAccess.Repositories;
using MancalaLibrary.Logic.Leaderboard.Helpers;
using MancalaLibrary.Logic.Leaderboard.Models;
using System;
using System.Text;

namespace MancalaLibrary.Logic.Leaderboard.Generators
{
    public class LeaderboardGenerator
    {
        private readonly PlayerRepository _playerRepository;

        private readonly PlayerWinCounter _playerWinCounter = new PlayerWinCounter();


        public LeaderboardGenerator(string connectionString)
        {
            _playerRepository = new PlayerRepository(connectionString);
        }


        public LeaderboardModel GetLeaderboard()
        {
            // Get first place
            var allPlayers = _playerRepository.ReadAll();
            var firstPlaceWinners = _playerWinCounter.GetPlayersWithHighestWinCount(allPlayers, out int firstPlaceWinCount);


            // Get second place
            foreach (var player in firstPlaceWinners)
            {
                allPlayers.Remove(player);
            }

            var secondPlaceWinners = _playerWinCounter.GetPlayersWithHighestWinCount(allPlayers, out int secondPlaceWinCount);


            // Get third place
            foreach (var player in secondPlaceWinners)
            {
                allPlayers.Remove(player);
            }

            var thirdPlaceWinners = _playerWinCounter.GetPlayersWithHighestWinCount(allPlayers, out int thirdPlaceWinCount);


            return new LeaderboardModel()
            {
                FirstPlace = new LeaderboardPlaceModel { Place = 1, PlacedPlayers = firstPlaceWinners, WinCount = firstPlaceWinCount },
                SecondPlace = new LeaderboardPlaceModel { Place = 2, PlacedPlayers = secondPlaceWinners, WinCount = secondPlaceWinCount },
                ThirdPlace = new LeaderboardPlaceModel { Place = 3, PlacedPlayers = thirdPlaceWinners, WinCount = thirdPlaceWinCount },
            };
        }
    }
}
