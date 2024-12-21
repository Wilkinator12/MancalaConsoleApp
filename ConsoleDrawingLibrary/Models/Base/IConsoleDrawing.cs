using ConsoleLibrary.Common.Models;
using ConsoleDrawingLibrary.Models;

namespace ConsoleDrawingLibrary.Models.Base
{
    public interface IConsoleDrawing
    {
        DynamicChar[,] CharGrid { get; }
        int Length { get; set; }
        int Width { get; set; }


        List<DynamicChar> ReplacementChars { get; }
        Dictionary<DynamicChar, ConsoleCoordinates> ReplacementCharCoordinates { get; }

        IConsoleDrawing AddReplacementChar(DynamicChar replacementChar, ConsoleCoordinates coordinates);
        IConsoleDrawing RemoveReplacementChar(DynamicChar replacementChar);


        List<DynamicText> DisplayTexts { get; }
        Dictionary<DynamicText, ConsoleOrientation> DisplayTextOrientations { get; }
        Dictionary<DynamicText, ConsoleCoordinates> DisplayTextCoordinates { get; }

        IConsoleDrawing AddDisplayText(DynamicText displayText, ConsoleCoordinates coordinates, ConsoleOrientation orientation = ConsoleOrientation.Horizontal);
        IConsoleDrawing RemoveDisplayText(DynamicText displayText);



        event EventHandler ElementsChanged;



        void Render();
        void Draw();
    }
}
