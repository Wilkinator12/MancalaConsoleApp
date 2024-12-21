using ConsoleLibrary.Common.Models;
using ConsoleDrawingLibrary.Models.Base;
using ConsoleDrawingLibrary.Renderers;

namespace ConsoleDrawingLibrary.Models
{
    public class FormattableConsoleDrawing : ConsoleDrawing, IFormattableConsoleDrawing
    {
        public DynamicChar TopBorderChar { get; set; } = new DynamicChar();
        public DynamicChar RightBorderChar { get; set; } = new DynamicChar();
        public DynamicChar BottomBorderChar { get; set; } = new DynamicChar();
        public DynamicChar LeftBorderChar { get; set; } = new DynamicChar();


        public DynamicChar FillChar { get; set; } = new DynamicChar();

        public override void Render()
        {
            RenderEmptyGrid();
            new FormattableConsoleDrawingRenderer(this).Render();
            new ConsoleDrawingRenderer(this).Render();
        }
    }
}
