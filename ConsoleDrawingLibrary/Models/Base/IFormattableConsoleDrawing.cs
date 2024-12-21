using ConsoleLibrary.Common.Models;

namespace ConsoleDrawingLibrary.Models.Base
{
    public interface IFormattableConsoleDrawing : IConsoleDrawing
    {
        DynamicChar TopBorderChar { get; set; }
        DynamicChar RightBorderChar { get; set; }
        DynamicChar BottomBorderChar { get; set; }
        DynamicChar LeftBorderChar { get; set; }

        DynamicChar FillChar { get; set; }
    }
}
