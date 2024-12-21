using ConsoleUI.Board.Models;
using ConsoleDrawingLibrary.Models;
using ConsoleDrawingLibrary.Extensions;
using ConsoleDrawingLibrary.Models.Base;
using ConsoleUI.ViewModels.Mappers;
using ConsoleUI.Models;
using ConsoleDrawingLibrary.Helpers;
using ConsoleUI.ViewModels;

namespace ConsoleUI.Board.Builders
{
    public class TwoPlayerMancalaBoardDrawingBuilder
    {
        private readonly CupDrawingBuilder _cupDrawingBuilder;



        public MancalaBoardDrawingProperties BoardProperties { get; set; }
        public TwoPlayerTurnViewModel PlayerTurn { get; set; }


        public TwoPlayerMancalaBoardDrawingBuilder(TwoPlayerTurnViewModel playerTurn)
        {
            BoardProperties = new MancalaBoardDrawingProperties();
            PlayerTurn = playerTurn;

            _cupDrawingBuilder = new CupDrawingBuilder(BoardProperties);
        }


        public IConsoleDrawing Build()
        {
            var output = new ConsoleDrawingStack()
            {
                Spacing = BoardProperties.HorizontalCupSpacing
            };


            IConsoleDrawing activePlayerStoreDrawing = BuildPlayerStoreDrawing(PlayerTurn.PlayerTurnNumbers[PlayerTurn.ActivePlayer],
                                                                               PlayerTurn.ActivePlayer,
                                                                               false);
            IConsoleDrawing opposingPlayerStoreDrawing = BuildPlayerStoreDrawing(PlayerTurn.PlayerTurnNumbers[PlayerTurn.OpposingPlayer],
                                                                                 PlayerTurn.OpposingPlayer,
                                                                                 true);
            IConsoleDrawing completePitsDrawing = BuildCompletePitsDrawing();


            output.AddDrawing(opposingPlayerStoreDrawing);
            output.AddDrawing(completePitsDrawing);
            output.AddDrawing(activePlayerStoreDrawing);


            // FUDGING it to line the cups up with the addition of the opponents StoreIndicator
            //output.DrawingCoordinates[completePitsDrawing].Y++;
            output.DrawingCoordinates[activePlayerStoreDrawing].Y++;


            output.Render();
            return output;
        }



        private IConsoleDrawing BuildCompletePitsDrawing()
        {
            var output = new ConsoleDrawingStack()
            {
                Orientation = ConsoleOrientation.Vertical,
                Spacing = BoardProperties.VerticalPitRowSpacing
            };


            // Get the each individual Pit Drawing
            List<IConsoleDrawing> activePlayerPitDrawings = BuildPlayerPitDrawings(PlayerTurn.ActivePlayer, false);
            List<IConsoleDrawing> opposingPlayerPitDrawings = BuildPlayerPitDrawings(PlayerTurn.OpposingPlayer, true);

            opposingPlayerPitDrawings.Reverse(); // Since they will display in reverse order


            // Get each player's row as a Drawing
            IConsoleDrawing activePlayerPitRowDrawings = BuildPlayerPitRowDrawing(activePlayerPitDrawings);
            IConsoleDrawing opposingPlayerPitRowDrawings = BuildPlayerPitRowDrawing(opposingPlayerPitDrawings);


            output.AddDrawing(opposingPlayerPitRowDrawings);
            output.AddDrawing(activePlayerPitRowDrawings);

            output.Render();
            return output;
        }

        private IConsoleDrawing BuildPlayerPitRowDrawing(List<IConsoleDrawing> playerPitDrawings)
        {
            var output = new ConsoleDrawingStack()
            {
                Spacing = BoardProperties.HorizontalCupSpacing
            };

            foreach (var drawing in playerPitDrawings)
            {
                output.AddDrawing(drawing);
            }

            output.Render();
            return output;
        }

        private List<IConsoleDrawing> BuildPlayerPitDrawings(GamePlayerViewModel gamePlayer, bool isOpposingPlayer)
        {
            var output = new List<IConsoleDrawing>();

            for (int i = 0; i < gamePlayer.Pits.Count; i++)
            {
                var currentPit = gamePlayer.Pits[i];

                var pitDrawing = BuildPlayerPitDrawing(currentPit, i + 1, isOpposingPlayer);

                output.Add(pitDrawing);
            }

            return output;
        }

        private IConsoleDrawing BuildPlayerPitDrawing(CupViewModel pit, int pitNumber, bool isOpposingPlayer)
        {
            var output = new ConsoleCanvas()
            {
                ResizeToFit = true
            };


            var yCoordinate = 0;

            if (isOpposingPlayer == true)
            {
                yCoordinate = 1;
            }


            // Add the drawing of the Pit
            var cupDrawing = _cupDrawingBuilder.Build(pit);
            output.AddDrawing(cupDrawing, new ConsoleCoordinates { Y = yCoordinate });


            // Add the Pit Number
            var xCoordinate = cupDrawing.Width / 2;
            yCoordinate = cupDrawing.Length;

            if (isOpposingPlayer == true)
            {
                yCoordinate = 0;
            }

            output.AddReplacementChar(pitNumber.ToString()[0], xCoordinate, yCoordinate);

            output.Render();
            return output;
        }

        private IConsoleDrawing BuildPlayerStoreDrawing(int playerNumber, GamePlayerViewModel gamePlayer, bool isOpposingPlayer)
        {
            var output = new ConsoleCanvas()
            {
                ResizeToFit = true
            };


            var yCoordinate = 0;

            if (isOpposingPlayer == true)
            {
                yCoordinate = 1;
            }


            // Add the drawing of the Store Cup
            var cupDrawing = _cupDrawingBuilder.Build(gamePlayer.Store);
            output.AddDrawing(cupDrawing, new ConsoleCoordinates { Y = yCoordinate });


            // Add the Store Player Indicator
            string displayText = $"P{playerNumber}: {gamePlayer.PlayerInfo.PlayerName[0]}";

            var xCoordinate = new CanvasCenteringCalculator(output).GetHorizontalCenter(displayText.Length);
            yCoordinate = cupDrawing.Length;

            if (isOpposingPlayer == true)
            {
                yCoordinate = 0;
            }


            
            output.AddDisplayText(
                displayText,
                new ConsoleCoordinates { X = xCoordinate, Y = yCoordinate });


            //output.AddReplacementChar(gamePlayer.PlayerInfo.PlayerName[0], xCoordinate, yCoordinate);

            output.Render();
            return output;
        }
    }
}
