using ConsoleLibrary.Prompts.CommonPrompts.Extensions;
using ConsoleUI.Configuration;
using ConsoleUI.Displays.Factories;
using ConsoleUI.ViewModels.Mappers;
using MancalaLibrary.DataAccess.Repositories;
using MancalaLibrary.Logic.Common.Analyzers;
using MancalaLibrary.Logic.Common.Analyzers.Models;
using MancalaLibrary.Logic.Common.Analyzers.Models.Factories;
using MancalaLibrary.Logic.Common.Board.Models.Factories;
using MancalaLibrary.Logic.Common.CupOperations;
using MancalaLibrary.Logic.Common.EndGameOperations;
using MancalaLibrary.Logic.Common.SeedOperations;
using MancalaLibrary.Logic.Common.TurnOperations;
using MancalaLibrary.Logic.TwoPlayerGames.SeedOperations;
using MancalaLibrary.Logic.TwoPlayerGames.TurnOperations.Models;
using MancalaLibrary.Logic.TwoPlayerGames.TurnOperations.Models.Factories;
using MancalaLibrary.Models;

namespace ConsoleUI.Workflows
{
    public class TwoPlayerGameWorkflow
    {
        private readonly GameModel _game;
        private readonly CupActivator _cupActivator;
        private readonly GameRepository _gameRepository = new GameRepository(DbConfiguration.GetConnectionString());


        public TwoPlayerGameWorkflow(GameModel game)
        {
            _game = game;
            _cupActivator = new CupActivator(BoardFactory.Create(_game));
        }


        public void RunGame()
        {
            var playerTurn = TwoPlayerTurnFactory.Create(_game);


            var gameResult = new GameResultModel();

            while (gameResult.FirstPlacePlayers.Any() == false)
            {
                var selectedPit = RunPitSelection(playerTurn);


                var pitLandedIn = RunSeedDistribution(playerTurn, selectedPit, out SeedDistributionAnalysisModel seedDistributionAnalysis);


                if (seedDistributionAnalysis.Result == SeedDistributionResult.LandedInOwnEmptyPit)
                {
                    RunSeedStealingAttempt(playerTurn, pitLandedIn);
                }


                gameResult = new GameResultAnalyzer(_game).Analyze();

                if (gameResult.FirstPlacePlayers.Any() == false && seedDistributionAnalysis.Result == SeedDistributionResult.LandedInStore)
                {
                    RunGoAgain(playerTurn);
                }
                else
                {
                    RunEndOfTurn(playerTurn);

                    if (gameResult.FirstPlacePlayers.Any() == false)
                    {
                        new PlayerTurnSwitcher(_game).SwitchToNextPlayer();
                        playerTurn = TwoPlayerTurnFactory.Create(_game);
                    }
                }


                _gameRepository.Upsert(_game);


                _cupActivator.DeactivateAll();
            }


            RunEndOfGame(playerTurn, gameResult);
        }

        private CupModel RunPitSelection(TwoPlayerTurnModel playerTurn)
        {
            CupModel output = new CupModel();


            GameDisplayFactory
                .GetInitialTurnDisplay(playerTurn.ToViewModel())
                .Print();


            var pitSelectionStatus = PitSelectionStatus.SelectingPit;

            while (pitSelectionStatus != PitSelectionStatus.ValidPitSelected)
            {
                int pitCount =
                    new GamePropertyAnalyzer()
                    .Analyze(_game)
                    .PitCount;

                var selectedPitNumber = "Please select a pit to distribute it's seeds".AsIntPrompt(1, pitCount, true);
                output = playerTurn.ActivePlayer.Pits[selectedPitNumber - 1];


                pitSelectionStatus = new PitSelectionAnalyzer().Analyze(output);

                if (pitSelectionStatus == PitSelectionStatus.EmptyPitSelected)
                {
                    Console.WriteLine($"Pit #{selectedPitNumber} has no seeds to distribute!");
                    Console.WriteLine();
                }
            }


            Console.Clear();


            _cupActivator.ActivateExclusive(new List<CupModel> { output });

            return output;
        }

        private CupModel RunSeedDistribution(TwoPlayerTurnModel playerTurn, CupModel selectedPit, out SeedDistributionAnalysisModel seedDistributionAnalysis)
        {
            var seedDistributor = new SeedDistributor(_game, selectedPit);


            seedDistributionAnalysis = SeedDistributionAnalysisFactory.Create();

            while (seedDistributionAnalysis.Status != SeedDistributionStatus.SeedsDistributed)
            {
                GameDisplayFactory
                    .GetSeedDistributionDisplay(playerTurn.ToViewModel(), seedDistributor.SeedDistribution.Scooper.SeedCount)
                    .Print();

                Console.WriteLine("press any key to distribute...");
                Console.ReadKey();


                seedDistributionAnalysis = seedDistributor.DistributeNextSeed();


                _cupActivator.ActivateExclusive(new List<CupModel> { seedDistributor.SeedDistribution.LastCupDistributedTo });


                Console.Clear();
            }


            return seedDistributor.SeedDistribution.LastCupDistributedTo;
        }

        private void RunSeedStealingAttempt(TwoPlayerTurnModel playerTurn, CupModel pitLandedIn)
        {
            var seedStealer = new TwoPlayerSeedStealer(playerTurn);

            if (seedStealer.PlayerCanSteal(pitLandedIn))
            {
                GameDisplayFactory
                    .GetStealingSeedsDisplay(playerTurn.ToViewModel())
                    .Print();

                Console.WriteLine("press any key to steal...");
                Console.ReadKey();

                Console.Clear();


                var stolenSeedInfo = seedStealer.StealSeeds(pitLandedIn);

                _cupActivator.ActivateExclusive(new List<CupModel>
                {
                    stolenSeedInfo.PitLandedIn,
                    stolenSeedInfo.PitStolenFrom,
                    stolenSeedInfo.StoreDepositedIn
                });
            }
        }

        private void RunGoAgain(TwoPlayerTurnModel playerTurn)
        {
            GameDisplayFactory
                .GetGoAgainDisplay(playerTurn.ToViewModel())
                .Print();

            Console.WriteLine("press any key to go again...");
            Console.ReadKey();


            Console.Clear();
        }

        private void RunEndOfTurn(TwoPlayerTurnModel playerTurn)
        {
            GameDisplayFactory
                .GetEndOfTurnDisplay(playerTurn.ToViewModel())
                .Print();

            Console.WriteLine("press any key to end your turn...");
            Console.ReadKey();


            Console.Clear();
        }

        private void RunEndOfGame(TwoPlayerTurnModel playerTurn, GameResultModel gameResult)
        {
            new PlayerWinApplier(DbConfiguration.GetConnectionString())
                .ApplyWins(gameResult);

            _gameRepository.Delete(_game.Id);


            new SeedSower(_game).SowAllSeeds();
            _cupActivator.ActivateExclusive(new List<CupModel> { playerTurn.ActivePlayer.Store, playerTurn.OpposingPlayer.Store });


            GameDisplayFactory
                .GetEndOfGameDisplay(playerTurn.ToViewModel(), gameResult.ToViewModel())
                .Print();

            Console.WriteLine("press any key to end the game...");
            Console.ReadKey();
        }
    }
}
