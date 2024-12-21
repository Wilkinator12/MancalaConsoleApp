using ConsoleLibrary.Common.Models;
using ConsoleDrawingLibrary.Models.Base;

namespace ConsoleDrawingLibrary.Extensions
{
    public static class IFormattableConsoleDrawingExtensions
    {
        public static IFormattableConsoleDrawing AddBorder(this IFormattableConsoleDrawing element,
            DynamicChar topBorderChar,
            DynamicChar rightBorderChar,
            DynamicChar bottomBorderChar,
            DynamicChar leftBorderChar)
        {
            element.TopBorderChar = topBorderChar;
            element.RightBorderChar = rightBorderChar;
            element.BottomBorderChar = bottomBorderChar;
            element.LeftBorderChar = leftBorderChar;

            return element;
        }

        public static IFormattableConsoleDrawing AddBorder(this IFormattableConsoleDrawing element, DynamicChar borderChar)
        {
            return element.AddBorder(borderChar, borderChar, borderChar, borderChar);
        }

        public static IFormattableConsoleDrawing AddFill(this IFormattableConsoleDrawing element, DynamicChar fillChar)
        {
            element.FillChar = fillChar;

            return element;
        }



        public static IFormattableConsoleDrawing AddBorder(this IFormattableConsoleDrawing element,
            Func<char> topBorderCharDelegate,
            Func<char> rightBorderCharDelegate,
            Func<char> bottomBorderCharDelegate,
            Func<char> leftBorderCharDelegate)
        {
            return element.AddBorder(
                new DynamicChar(topBorderCharDelegate),
                new DynamicChar(rightBorderCharDelegate),
                new DynamicChar(bottomBorderCharDelegate),
                new DynamicChar(leftBorderCharDelegate));
        }

        public static IFormattableConsoleDrawing AddBorder(this IFormattableConsoleDrawing element,
            char topBorderChar,
            char rightBorderChar,
            char bottomBorderChar,
            char leftBorderChar)
        {
            return element.AddBorder(
                new DynamicChar(topBorderChar),
                new DynamicChar(rightBorderChar),
                new DynamicChar(bottomBorderChar),
                new DynamicChar(leftBorderChar));
        }

        public static IFormattableConsoleDrawing AddBorder(this IFormattableConsoleDrawing element, Func<char> borderCharDelegate)

            => element.AddBorder(borderCharDelegate);


        public static IFormattableConsoleDrawing AddBorder(this IFormattableConsoleDrawing element, char borderChar)

            => element.AddBorder(new DynamicChar(borderChar));


        public static IFormattableConsoleDrawing AddFill(this IFormattableConsoleDrawing element, Func<char> fillCharDelegate)

            => element.AddFill(new DynamicChar(fillCharDelegate));


        public static IFormattableConsoleDrawing AddFill(this IFormattableConsoleDrawing element, char fillChar)

            => element.AddFill(new DynamicChar(fillChar));
    }
}
