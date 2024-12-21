using ConsoleLibrary.Common.Models;
using ConsoleDrawingLibrary.Models;
using ConsoleDrawingLibrary.Models.Base;

namespace ConsoleDrawingLibrary.Extensions
{
    public static class IConsoleDrawingExtensions
    {
        public static IConsoleDrawing AddReplacementChar(this IConsoleDrawing drawing, Func<char> dynamicCharDelegate, ConsoleCoordinates coordinates)

            => drawing.AddReplacementChar(new DynamicChar(dynamicCharDelegate), coordinates);


        public static IConsoleDrawing AddReplacementChar(this IConsoleDrawing drawing, char replacementChar, ConsoleCoordinates coordinates)

            => drawing.AddReplacementChar(new DynamicChar(replacementChar), coordinates);


        public static IConsoleDrawing AddReplacementChar(this IConsoleDrawing element, Func<char> dynamicCharDelegate, int xCoordinate, int yCoordinate)

            => element.AddReplacementChar(new DynamicChar(dynamicCharDelegate), new ConsoleCoordinates { X = xCoordinate, Y = yCoordinate });


        public static IConsoleDrawing AddReplacementChar(this IConsoleDrawing element, char staticChar, int xCoordinate, int yCoordinate)

            => element.AddReplacementChar(new DynamicChar(staticChar), new ConsoleCoordinates { X = xCoordinate, Y = yCoordinate });
    }
}
