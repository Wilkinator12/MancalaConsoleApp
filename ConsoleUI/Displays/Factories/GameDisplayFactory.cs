using ConsoleUI.Board.Builders;
using ConsoleDrawingLibrary.Models.Base;
using ConsoleUI.ViewModels;
using ConsoleUI.ViewModels.Mappers;
using MancalaLibrary.Logic.Common.Analyzers.Models;
using MancalaLibrary.Logic.TwoPlayerGames;
using MancalaLibrary.Logic.TwoPlayerGames.TurnOperations.Models.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Displays.Factories
{
    public static class GameDisplayFactory
    {
        public static GameDisplay GetInitialTurnDisplay(TwoPlayerTurnViewModel playerTurn) => new GameDisplay()
        {
            Title = GetTitle(),
            TurnMessage = GetTurnMessage(playerTurn),
            Board = GetBoard(playerTurn),
            EventMessage = ""
        };

        public static GameDisplay GetSeedDistributionDisplay(TwoPlayerTurnViewModel playerTurn, int remainingSeeds) => new GameDisplay()
        {
            Title = GetTitle(),
            TurnMessage = GetTurnMessage(playerTurn),
            Board = GetBoard(playerTurn),
            EventMessage = $"Seeds to distribute: {remainingSeeds}"
        };

        public static GameDisplay GetStealingSeedsDisplay(TwoPlayerTurnViewModel playerTurn) => new GameDisplay()
        {
            Title = GetTitle(),
            TurnMessage = GetTurnMessage(playerTurn),
            Board = GetBoard(playerTurn),
            EventMessage = $"{playerTurn.ActivePlayer} steals {playerTurn.OpposingPlayer}'s seeds!"
        };

        public static GameDisplay GetGoAgainDisplay(TwoPlayerTurnViewModel playerTurn) => new GameDisplay()
        {
            Title = GetTitle(),
            TurnMessage = GetTurnMessage(playerTurn),
            Board = GetBoard(playerTurn),
            EventMessage = $"{playerTurn.ActivePlayer} gets to go again!"
        };

        public static GameDisplay GetEndOfTurnDisplay(TwoPlayerTurnViewModel playerTurn) => new GameDisplay()
        {
            Title = GetTitle(),
            TurnMessage = GetTurnMessage(playerTurn),
            Board = GetBoard(playerTurn),
            EventMessage = $"{GetActivePlayerName(playerTurn)}'s turn has ended."
        };

        public static GameDisplay GetEndOfGameDisplay(TwoPlayerTurnViewModel playerTurn, GameResultViewModel gameResult) => new GameDisplay()
        {
            Title = GetTitle(),
            TurnMessage = "Game Over",
            Board = GetBoard(playerTurn),
            EventMessage = GetWinMessage(gameResult)
        };



        public static string GetWinMessage(GameResultViewModel gameResult)
        {
            string winMessage = "";

            if (gameResult.Winners.Count == 1)
            {
                var winner = gameResult.Winners.First();

                winMessage = $"{winner.PlayerInfo.PlayerName} won!";
            }
            else if (gameResult.Winners.Count > 1)
            {
                foreach (var winner in gameResult.Winners)
                {
                    if (winMessage != string.Empty) winMessage += " and ";
                    winMessage += winner.PlayerInfo.PlayerName;
                }

                winMessage += " tied.";
            }

            return winMessage;
        }



        private static string GetTitle() => "Mancala - Sow Your Seeds!";
        private static string GetTurnMessage(TwoPlayerTurnViewModel playerTurn) => $"{playerTurn.ActivePlayer}'s turn";
        private static IConsoleDrawing GetBoard(TwoPlayerTurnViewModel playerTurn)
        {
            return new TwoPlayerMancalaBoardDrawingBuilder(playerTurn).Build();
        }


        private static string GetActivePlayerName(TwoPlayerTurnViewModel playerTurn) => playerTurn.ActivePlayer.PlayerInfo.PlayerName;
        private static string GetOpposingPlayerName(TwoPlayerTurnViewModel playerTurn) => playerTurn.OpposingPlayer.PlayerInfo.PlayerName;
    }
}
