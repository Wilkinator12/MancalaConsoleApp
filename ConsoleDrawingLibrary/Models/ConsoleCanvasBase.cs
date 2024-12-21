using ConsoleDrawingLibrary.Renderers;
using ConsoleDrawingLibrary.Models.Base;

namespace ConsoleDrawingLibrary.Models
{
    public class ConsoleCanvasBase : FormattableConsoleDrawing, IConsoleCanvasBase
    {
        public List<IConsoleDrawing> Drawings { get; } = new List<IConsoleDrawing>();
        public Dictionary<IConsoleDrawing, ConsoleCoordinates> DrawingCoordinates { get; } = new Dictionary<IConsoleDrawing, ConsoleCoordinates>();


        public override void Render()
        {
            base.Render();


            foreach (var drawing in Drawings)
            {
                drawing.Render();

                var canvasRenderer = new ConsoleCanvasRenderer(this, drawing);
                canvasRenderer.RenderDrawingToCanvas();
            }
        }
    }
}
