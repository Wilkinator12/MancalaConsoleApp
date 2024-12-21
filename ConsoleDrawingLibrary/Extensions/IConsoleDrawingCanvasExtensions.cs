using ConsoleDrawingLibrary.Models;
using ConsoleDrawingLibrary.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDrawingLibrary.Extensions
{
    public static class IConsoleDrawingCanvasExtensions
    {
        public static IConsoleCanvasBase AddDrawing(this ConsoleCanvas canvas, IConsoleDrawing drawing, int xCoordinate, int yCoordinate)
        {
            canvas.AddDrawing(drawing, new ConsoleCoordinates { X = xCoordinate, Y = yCoordinate });

            return canvas;
        }
    }
}
