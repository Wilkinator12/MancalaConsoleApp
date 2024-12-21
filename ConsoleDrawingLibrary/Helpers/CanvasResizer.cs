using ConsoleDrawingLibrary.Models.Base;
using System.Runtime.InteropServices.Marshalling;

namespace ConsoleDrawingLibrary.Helpers
{
    public class CanvasResizer
    {
        private readonly IConsoleCanvasBase _canvas;
        private readonly CanvasBoundsDetector _boundsDetector;


        public CanvasResizer(IConsoleCanvasBase canvas)
        {
            _canvas = canvas;
            _boundsDetector = new CanvasBoundsDetector(_canvas);
        }


        public void ResizeToFitDrawings()
        {
            var bounds = _boundsDetector.FindCanvasBounds();


            _canvas.Length = bounds.Y;
            _canvas.Width = bounds.X;
        }
    }
}
