namespace ConsoleDrawingLibrary.Models.Base
{
    public interface IConsoleCanvas : IConsoleCanvasBase
    {
        bool ResizeToFit { get; set; }

        void AddDrawing(IConsoleDrawing drawing, ConsoleCoordinates coordinates);
        void RemoveDrawing(IConsoleDrawing drawing);
    }
}
