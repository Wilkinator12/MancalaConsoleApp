using ConsoleLibrary.Common.Models;
using ConsoleUI.Board.Validation;
using ConsoleUI.Board.Models;
using ConsoleDrawingLibrary.Extensions;
using ConsoleDrawingLibrary.Models;
using ConsoleDrawingLibrary.Models.Base;
using ConsoleUI.Models;
using MancalaLibrary.Models;

namespace ConsoleUI.Board.Builders
{
    public class CupDrawingBuilder
    {
        private readonly MancalaBoardDrawingProperties _boardProperties;


        public CupDrawingBuilder(MancalaBoardDrawingProperties boardProperties)
        {
            _boardProperties = boardProperties;
        }



        public IConsoleDrawing Build(CupViewModel cup)
        {
            var cupProperties = GetCupDrawingProperties(cup);

            new CupDrawingValidator().ValidateForDrawing(cupProperties);



            var output = new FormattableConsoleDrawing { Length = cupProperties.Length, Width = cupProperties.Width };

            var seedCountCoordinates = new ConsoleCoordinates { X = output.Width / 2, Y = output.Length / 2 };

            output
                .AddBorder(cupProperties.BorderChar)
                .AddDisplayText(cup.SeedCount, seedCountCoordinates);



            if (cup.IsHighlighted == true)
            {
                var highlightCharCoordinates = new ConsoleCoordinates { X = seedCountCoordinates.X, Y = seedCountCoordinates.Y + 1 };

                output.AddReplacementChar(new DynamicChar(cupProperties.HighlightChar), highlightCharCoordinates);
            }



            return output;
        }

        private CupDrawingProperties GetCupDrawingProperties(CupViewModel cup)
        {
            var cupProperties = new CupDrawingProperties();


            switch (cup.CupType)
            {
                case CupType.Store:
                    cupProperties.Length = _boardProperties.LengthOfStores;
                    cupProperties.Width = _boardProperties.WidthOfStores;
                    cupProperties.BorderChar = _boardProperties.StoreBorderChar;
                    cupProperties.HighlightChar = _boardProperties.StoreHighlightChar;
                    break;

                case CupType.Pit:
                    cupProperties.Length = _boardProperties.LengthOfPits;
                    cupProperties.Width = _boardProperties.WidthOfPits;
                    cupProperties.BorderChar = _boardProperties.PitBorderChar;
                    cupProperties.HighlightChar = _boardProperties.PitHighlightChar;
                    break;

                default:
                    throw new NotImplementedException();
            }


            return cupProperties;
        }
    }
}
