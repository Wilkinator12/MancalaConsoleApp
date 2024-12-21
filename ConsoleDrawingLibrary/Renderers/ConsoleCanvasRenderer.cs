using ConsoleDrawingLibrary.Models;
using ConsoleDrawingLibrary.Models.Base;

namespace ConsoleDrawingLibrary.Renderers
{
    public class ConsoleCanvasRenderer
    {
        private readonly IConsoleCanvasBase _canvas;
        private readonly IConsoleDrawing _drawing;


        private readonly ConsoleCoordinates StartCanvasCoordinates;
        private readonly ConsoleCoordinates CurrentCanvasCoordinates;
        private readonly ConsoleCoordinates CurrentDrawingCoordinates;


        public bool RenderCompleted { get; private set; } = false;


        public ConsoleCanvasRenderer(IConsoleCanvasBase canvas, IConsoleDrawing drawing)
        {
            _canvas = canvas;
            _drawing = drawing;

            StartCanvasCoordinates = _canvas.DrawingCoordinates[_drawing];
            CurrentCanvasCoordinates = new ConsoleCoordinates { X = StartCanvasCoordinates.X, Y = StartCanvasCoordinates.Y };
            CurrentDrawingCoordinates = new ConsoleCoordinates();
        }


        public void RenderDrawingToCanvas()
        {
            if (StartCanvasCoordinates.X >= _canvas.Width || StartCanvasCoordinates.Y >= _canvas.Length)
            {
                RenderCompleted = true;
                return;
            }

            while (RenderCompleted == false)
            {
                _canvas.CharGrid[CurrentCanvasCoordinates.Y, CurrentCanvasCoordinates.X] = _drawing.CharGrid[CurrentDrawingCoordinates.Y, CurrentDrawingCoordinates.X];

                MoveToNextCoordinate();
            }
        }

        private void MoveToNextCoordinate()
        {
            CurrentDrawingCoordinates.X++;
            CurrentCanvasCoordinates.X++;

            if (CurrentDrawingCoordinates.X >= _drawing.Width || CurrentCanvasCoordinates.X >= _canvas.Width)
            {
                CurrentDrawingCoordinates.X = 0;
                CurrentCanvasCoordinates.X = StartCanvasCoordinates.X;

                CurrentDrawingCoordinates.Y++;
                CurrentCanvasCoordinates.Y++;

                if (CurrentDrawingCoordinates.Y >= _drawing.Length || CurrentCanvasCoordinates.Y >= _canvas.Length)
                {
                    RenderCompleted = true;
                }
            }
        }
    }
}
