using ConsoleLibrary.Common.Models;
using ConsoleDrawingLibrary.Models;
using ConsoleDrawingLibrary.Models.Base;

namespace ConsoleDrawingLibrary.Helpers
{
    public class CanvasBoundsDetector
    {
        private readonly IConsoleCanvasBase _canvas;


        public CanvasBoundsDetector(IConsoleCanvasBase canvas)
        {
            _canvas = canvas;
        }



        // A bound is the coordinate whose X and Y values represent the first coordinates where no more canvas elements
        // will be visible up to infinity.
        public ConsoleCoordinates FindCanvasBounds()
        {
            List<ConsoleCoordinates> allBoundsCoordinates = new List<ConsoleCoordinates>();

            allBoundsCoordinates.AddRange(FindDrawingBounds());
            allBoundsCoordinates.AddRange(FindReplacementCharBounds());
            allBoundsCoordinates.AddRange(FindDisplayTextBounds());



            List<int> xCoordinates = allBoundsCoordinates.Select(c => c.X).ToList();
            List<int> yCoordinates = allBoundsCoordinates.Select(c => c.Y).ToList();



            int greatestXCoordinates = 0;
            int greatestYCoordinates = 0;

            if (xCoordinates.Any() == true) greatestXCoordinates = xCoordinates.Max();
            if (yCoordinates.Any() == true) greatestYCoordinates = yCoordinates.Max();


            return new ConsoleCoordinates { X = greatestXCoordinates, Y = greatestYCoordinates };
        }


        public List<ConsoleCoordinates> FindDrawingBounds() => _canvas.Drawings.Select(FindDrawingBound).ToList();

        public ConsoleCoordinates FindDrawingBound(IConsoleDrawing drawing)
        {
            var drawingCoordinates = _canvas.DrawingCoordinates[drawing];

            return new ConsoleCoordinates()
            {
                X = drawingCoordinates.X + drawing.Width,
                Y = drawingCoordinates.Y + drawing.Length
            };
            
        }



        public List<ConsoleCoordinates> FindReplacementCharBounds() 

            => _canvas.ReplacementChars.Select(FindReplacementCharBound).ToList();

        public ConsoleCoordinates FindReplacementCharBound(DynamicChar replacementChar)
        {
            var replacementCharCoordinates = _canvas.ReplacementCharCoordinates[replacementChar];

            return new ConsoleCoordinates()
            {
                X = replacementCharCoordinates.X + 1,
                Y = replacementCharCoordinates.Y + 1
            };
        }




        public List<ConsoleCoordinates> FindDisplayTextBounds() => _canvas.DisplayTexts.Select(FindDisplayTextBound).ToList();

        public ConsoleCoordinates FindDisplayTextBound(DynamicText displayText)
        {
            var displayTextCoordinates = _canvas.DisplayTextCoordinates[displayText];
            var orientation = _canvas.DisplayTextOrientations[displayText];



            var output = new ConsoleCoordinates()
            {
                X = displayTextCoordinates.X,
                Y = displayTextCoordinates.Y
            };


            switch (orientation)
            {
                case ConsoleOrientation.Horizontal:
                    output.X += displayText.Length;
                    output.Y++;
                    break;

                case ConsoleOrientation.Vertical:
                    output.X++;
                    output.Y += displayText.Length;
                    break;

                default:
                    throw new NotImplementedException();
            }


            return output;
        }
    }
}
