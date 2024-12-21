using MancalaLibrary.Logic.Common.Validation.Results;
using MancalaLibrary.Models;
using System.Linq;

namespace MancalaLibrary.Logic.Common.Validation
{
    public class PitValidation
    {
        public ValidationResult ValidatePitCountsMatch(GameModel game)
        {
            var pitCounts = game.GamePlayers.Select(gp => gp.Pits.Count);

            bool pitCountsMatch = game.GamePlayers.Any(gp => gp.Pits.Count == pitCounts.First());


            var message = "";

            if (pitCountsMatch)
            {
                message = "Pit counts match for all players.";
            }
            else
            {
                message = "Pit counts did not match for all players.";
            }

            return new ValidationResult()
            {
                PassedValidation = pitCountsMatch,
                Message = message
            };
        }
    }
}
