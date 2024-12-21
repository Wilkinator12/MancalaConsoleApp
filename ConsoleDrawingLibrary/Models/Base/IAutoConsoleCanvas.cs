namespace ConsoleDrawingLibrary.Models.Base
{
    public interface IAutoConsoleCanvas : IConsoleCanvasBase
    {
        void AddDrawing(IConsoleDrawing drawing);
        void RemoveDrawing(IConsoleDrawing drawing);
    }
}
