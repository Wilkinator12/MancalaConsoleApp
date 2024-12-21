using ConsoleDrawingLibrary.Models;
using ConsoleDrawingLibrary.Models.Base;

namespace ConsoleDrawingLibrary.Helpers
{
    public class CanvasCenteringCalculator
    {
        public IConsoleCanvas Canvas { get; set; }

        public CanvasCenteringCalculator(IConsoleCanvas canvas)
        {
            Canvas = canvas;
        }

        public int GetHorizontalCenter(int widthOfElement) => (Canvas.Width - widthOfElement) / 2;
        public int GetVerticalCenter(int lengthOfElement) => (Canvas.Length - lengthOfElement) / 2;
    }
}
