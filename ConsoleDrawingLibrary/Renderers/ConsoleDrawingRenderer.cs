using ConsoleDrawingLibrary.Models;
using ConsoleDrawingLibrary.Models.Base;
using ConsoleDrawingLibrary.Extensions;

namespace ConsoleDrawingLibrary.Renderers
{
    public class ConsoleDrawingRenderer
    {
        private readonly IConsoleDrawing _drawing;


        public ConsoleDrawingRenderer(IConsoleDrawing drawing)
        {
            _drawing = drawing;
        }


        public void Render()
        {
            AddDisplayTexts_ToReplacementChars();
            RenderReplacementChars();
        }


        private void RenderReplacementChars()
        {
            if (_drawing.ReplacementChars.Any() == false) return;


            foreach (var replacementChar in _drawing.ReplacementChars)
            {
                var coordinates = _drawing.ReplacementCharCoordinates[replacementChar];

                if (CoordinatesAreOutsideDrawingBounds(coordinates))
                {
                    continue;
                }

                _drawing.CharGrid[coordinates.Y, coordinates.X] = replacementChar;
            }
        }

        private void AddDisplayTexts_ToReplacementChars()
        {
            if (_drawing.DisplayTexts.Any() == false) return;


            foreach (var displayText in _drawing.DisplayTexts)
            {
                var displayTextOrientation = _drawing.DisplayTextOrientations[displayText];
                var displayTextCoordinates = _drawing.DisplayTextCoordinates[displayText];


                if (CoordinatesAreOutsideDrawingBounds(displayTextCoordinates)) continue;


                int charIndex = 0;

                foreach (var character in displayText.ToString())
                {
                    var charCoordinates = GetDisplayTextCharCoordinates(displayTextCoordinates, displayTextOrientation, charIndex);

                    _drawing.AddReplacementChar(character, charCoordinates);

                    charIndex++;
                }
            }
        }


        private bool CoordinatesAreOutsideDrawingBounds(ConsoleCoordinates coordinates)
        {
            return coordinates.X >= _drawing.Width || coordinates.Y >= _drawing.Length;
        }

        private ConsoleCoordinates GetDisplayTextCharCoordinates(ConsoleCoordinates displayTextCoordinates, ConsoleOrientation orientation, int charIndex)
        {
            var output = new ConsoleCoordinates()
            {
                X = displayTextCoordinates.X,
                Y = displayTextCoordinates.Y
            };

            switch (orientation)
            {
                case ConsoleOrientation.Horizontal:
                    output.X += charIndex;
                    break;

                case ConsoleOrientation.Vertical:
                    output.Y += charIndex;
                    break;

                default:
                    throw new NotImplementedException();
            }

            return output;
        }
    }
}
