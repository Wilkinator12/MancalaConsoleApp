using MancalaLibrary.Logic.Common.SeedOperations.Models;
using MancalaLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace MancalaLibrary.Logic.Common.SeedOperations
{
    public class SeedCounter
    {
        public PlayerSeedCountModel CountPlayerSeeds(GamePlayerModel player)
        {
            var output = new PlayerSeedCountModel()
            {
                Player = player,
                StoreSeedCount = player.Store.SeedCount
            };


            int totalPitSeedCount = 0;

            foreach (var pit in player.Pits)
            {
                totalPitSeedCount += pit.SeedCount;
            }

            output.TotalPitSeedCount = totalPitSeedCount;


            return output;
        }

        public List<PlayerSeedCountModel> CountAllPlayerSeeds(GameModel game)
        {
            var output = new List<PlayerSeedCountModel>();


            foreach (var player in game.GamePlayers)
            {
                var newSeedCount = CountPlayerSeeds(player);

                output.Add(newSeedCount);
            }


            return output;
        }

        public List<PlayerSeedCountModel> GetHighestSeedCounts(GameModel game)
        {
            var allSeedCounts = CountAllPlayerSeeds(game);

            var allTotalSeedCounts = allSeedCounts.Select(sc => sc.TotalSeedCount).ToList();

            int hightestCount = allTotalSeedCounts.Max();



            return allSeedCounts.Where(sc => sc.TotalSeedCount == hightestCount).ToList();
        }

        public bool AnyPlayerHasNoPitSeeds(GameModel game) => CountAllPlayerSeeds(game).Any(sc => sc.TotalPitSeedCount == 0);
    }
}
