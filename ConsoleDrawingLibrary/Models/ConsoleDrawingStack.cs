using ConsoleDrawingLibrary.Models.Base;
using ConsoleDrawingLibrary.Helpers;

namespace ConsoleDrawingLibrary.Models
{
    public class ConsoleDrawingStack : ConsoleCanvasBase
    {
        private readonly CanvasResizer _resizer;
        private int _nextCoordinateValue;


        private ConsoleOrientation _orientation;
        public ConsoleOrientation Orientation 
        { 
            get
            {
                return _orientation;
            }
            set
            {
                _orientation = value;
                ReGenerateCoordinates();
            } 
        }

        private int _spacing;
        public int Spacing 
        { 
            get
            {
                return _spacing;
            }
            set
            {
                _spacing = value;
                ReGenerateCoordinates();
            }
        }



        public ConsoleDrawingStack()
        {
            _resizer = new CanvasResizer(this);
        }




        public void AddDrawing(IConsoleDrawing drawing)
        {
            Drawings.Add(drawing);
            DrawingCoordinates.Add(drawing, GetNextCoordinate());

            IncreaseCoordinates(drawing);
        }

        public void RemoveDrawing(IConsoleDrawing drawing)
        {
            Drawings.Remove(drawing);
            DrawingCoordinates.Remove(drawing);

            DecreaseCoordinates(drawing);
        }



        public override void Render()
        {
            _resizer.ResizeToFitDrawings();

            base.Render();
        }



        private void ReGenerateCoordinates()
        {
            DrawingCoordinates.Clear();

            foreach (var drawing in Drawings)
            {
                DrawingCoordinates.Add(drawing, GetNextCoordinate());
                IncreaseCoordinates(drawing);
            }
        }

        private void IncreaseCoordinates(IConsoleDrawing drawing)
        {
            switch (Orientation)
            {
                case ConsoleOrientation.Horizontal:
                    _nextCoordinateValue += drawing.Width + Spacing;
                    break;

                case ConsoleOrientation.Vertical:
                    _nextCoordinateValue += drawing.Length + Spacing;
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        private void DecreaseCoordinates(IConsoleDrawing drawing)
        {
            switch (Orientation)
            {
                case ConsoleOrientation.Horizontal:
                    _nextCoordinateValue -= drawing.Width - Spacing;
                    break;

                case ConsoleOrientation.Vertical:
                    _nextCoordinateValue -= drawing.Length - Spacing;
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        private ConsoleCoordinates GetNextCoordinate()
        {
            switch (Orientation)
            {
                case ConsoleOrientation.Horizontal:
                    return new ConsoleCoordinates { X = _nextCoordinateValue };

                case ConsoleOrientation.Vertical:
                    return new ConsoleCoordinates { Y = _nextCoordinateValue };

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
