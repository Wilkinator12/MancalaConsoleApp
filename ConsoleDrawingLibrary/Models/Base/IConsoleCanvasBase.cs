using ConsoleDrawingLibrary.Models;

namespace ConsoleDrawingLibrary.Models.Base
{
    public interface IConsoleCanvasBase : IConsoleDrawing
    {
        List<IConsoleDrawing> Drawings { get; }
        Dictionary<IConsoleDrawing, ConsoleCoordinates> DrawingCoordinates { get; }
    }

    public class CanvasElementProperties
    {
        public ConsoleOrientation Orientation { get; set; }
        public ConsoleCoordinates Coordinates { get; set; }


        public CanvasElementProperties(ConsoleCoordinates coordinates) => Coordinates = coordinates;

        public CanvasElementProperties(int xCoordinate, int yCoordinate) => Coordinates = new ConsoleCoordinates(xCoordinate, yCoordinate);
    }
}
