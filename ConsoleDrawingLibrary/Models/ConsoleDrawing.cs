using CommonLibrary.Extensions;
using ConsoleLibrary.Common.Models;
using ConsoleDrawingLibrary.Renderers;
using ConsoleDrawingLibrary.Models.Base;

namespace ConsoleDrawingLibrary.Models
{
    public class ConsoleDrawing : IConsoleDrawing
    {
        public DynamicChar[,] CharGrid { get; set; }


        private int _length;
        public int Length
        {
            get
            {
                return CharGrid?.GetLength(0) ?? _length;
            }
            set
            {
                _length = value;
            }
        }

        private int _width;
        public int Width
        {
            get
            {
                return CharGrid?.GetLength(1) ?? _width;
            }
            set
            {
                _width = value;

            }
        }


        public List<DynamicChar> ReplacementChars { get; } = [];
        public Dictionary<DynamicChar, ConsoleCoordinates> ReplacementCharCoordinates { get; } = [];


        public List<DynamicText> DisplayTexts { get; } = [];
        public Dictionary<DynamicText, ConsoleOrientation> DisplayTextOrientations { get; } = [];
        public Dictionary<DynamicText, ConsoleCoordinates> DisplayTextCoordinates { get; } = [];



        public event EventHandler ElementsChanged;



        public IConsoleDrawing AddDisplayText(DynamicText displayText, ConsoleCoordinates coordinates, ConsoleOrientation orientation = ConsoleOrientation.Horizontal)
        {
            DisplayTexts.Add(displayText);
            DisplayTextOrientations.Add(displayText, orientation);
            DisplayTextCoordinates.Add(displayText, coordinates);


            OnElementsChanged();


            return this;
        }
        public IConsoleDrawing RemoveDisplayText(DynamicText displayText)
        {
            DisplayTexts.Remove(displayText);
            DisplayTextOrientations.Remove(displayText);
            DisplayTextCoordinates.Remove(displayText);


            OnElementsChanged();


            return this;
        }


        public IConsoleDrawing AddReplacementChar(DynamicChar replacementChar, ConsoleCoordinates coordinates)
        {
            ReplacementChars.Add(replacementChar);
            ReplacementCharCoordinates.Add(replacementChar, coordinates);


            OnElementsChanged();


            return this;
        }
        public IConsoleDrawing RemoveReplacementChar(DynamicChar replacementChar)
        {
            ReplacementChars.Remove(replacementChar);
            ReplacementCharCoordinates.Remove(replacementChar);


            OnElementsChanged();


            return this;
        }



        public virtual void Render()
        {
            RenderEmptyGrid();

            var drawingRenderer = new ConsoleDrawingRenderer(this);
            drawingRenderer.Render();
        }

        public void Draw()
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write(CharGrid[i, j]);
                }

                Console.WriteLine();
            }
        }



        protected void RenderEmptyGrid() => CharGrid = new DynamicChar[_length, _width].Populate(new DynamicChar());



        protected void OnElementsChanged() => ElementsChanged?.Invoke(this, EventArgs.Empty);
    }
}
