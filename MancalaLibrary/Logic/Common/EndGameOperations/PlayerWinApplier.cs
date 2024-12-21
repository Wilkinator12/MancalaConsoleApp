using MancalaLibrary.DataAccess.Repositories;
using MancalaLibrary.Logic.Common.Analyzers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MancalaLibrary.Logic.Common.EndGameOperations
{
    public class PlayerWinApplier
    {
        private readonly PlayerRepository _playerRepository;


        public PlayerWinApplier(string connectionString)
        {
            _playerRepository = new PlayerRepository(connectionString);
        }


        public void ApplyWins(GameResultModel gameResult)
        {
            if (gameResult.FirstPlacePlayers.Count == 1)
            {
                var winner = gameResult.FirstPlacePlayers.First().PlayerInfo;

                winner.WinCount++;
                _playerRepository.Upsert(winner);
            }
        }
    }
}
