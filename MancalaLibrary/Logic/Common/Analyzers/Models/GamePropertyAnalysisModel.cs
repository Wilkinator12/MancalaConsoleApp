using MancalaLibrary.Logic.Common.Validation;
using MancalaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MancalaLibrary.Logic.Common.Analyzers.Models
{
    public class GamePropertyAnalysisModel
    {
        public int PitCount { get; set; }
        public int NumberOfPlayers { get; set; }
    }


    public class GamePropertyAnalyzer
    {
        private readonly PitValidation _pitValidation = new PitValidation();


        public GamePropertyAnalysisModel Analyze(GameModel game) => new GamePropertyAnalysisModel()
        {
            PitCount = GetPitCount(game),
            NumberOfPlayers = GetNumberOfPlayers(game)
        };

        private int GetNumberOfPlayers(GameModel game) => game.GamePlayers.Count;

        private int GetPitCount(GameModel game)
        {
            var pitValidationResult = _pitValidation.ValidatePitCountsMatch(game);

            if (pitValidationResult.PassedValidation == false)
            {
                throw new ArgumentException(pitValidationResult.Message);
            }

            return game.GamePlayers.First().Pits.Count;
        }
    }
}
