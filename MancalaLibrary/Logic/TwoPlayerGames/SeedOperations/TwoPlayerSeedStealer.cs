using MancalaLibrary.Logic.Common.SeedOperations;
using MancalaLibrary.Logic.Common.SeedOperations.Models;
using MancalaLibrary.Logic.TwoPlayerGames.Board;
using MancalaLibrary.Logic.TwoPlayerGames.TurnOperations.Models;
using MancalaLibrary.Models;
using System.Collections.Generic;
using System.Text;

namespace MancalaLibrary.Logic.TwoPlayerGames.SeedOperations
{
    public class TwoPlayerSeedStealer
    {
        private readonly TwoPlayerTurnModel _playerTurn;


        private readonly SeedScooper _scooper = new SeedScooper();


        public TwoPlayerSeedStealer(TwoPlayerTurnModel playerTurn)
        {
            _playerTurn = playerTurn;
        }


        public StolenSeedsModel StealSeeds(CupModel pitLandedIn)
        {
            var adjacentPit = new TwoPlayerBoardNavigator(_playerTurn.Game).GetAdjacentPit(pitLandedIn);


            var output = new StolenSeedsModel()
            {
                PitLandedIn = pitLandedIn,
                PitStolenFrom = adjacentPit,
                StoreDepositedIn = _playerTurn.ActivePlayer.Store
            };

            _scooper.ScoopSeeds(output.PitStolenFrom);
            output.NumberOfStolenSeeds = _scooper.SeedCount;

            _scooper.ScoopSeeds(pitLandedIn);
            output.TotalSowedSeeds = _scooper.SeedCount;

            _scooper.DumpAllSeeds(output.StoreDepositedIn);


            return output;
        }

        public bool PlayerCanSteal(CupModel pitLandedIn)
        {
            var adjacentPit = new TwoPlayerBoardNavigator(_playerTurn.Game).GetAdjacentPit(pitLandedIn);

            if (pitLandedIn.SeedCount == 1 && adjacentPit.SeedCount > 0) return true;

            return false;
        }
    }
}
