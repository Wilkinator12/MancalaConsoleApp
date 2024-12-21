using CommonLibrary.Extensions;
using ConsoleLibrary.Common.Models;
using ConsoleDrawingLibrary.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleDrawingLibrary.Helpers;

namespace ConsoleDrawingLibrary.Models
{
    public class ConsoleCanvas : ConsoleCanvasBase, IConsoleCanvas
    {
        public bool ResizeToFit { get; set; } = true;
        public CanvasResizer Resizing { get; set; }

        public ConsoleCanvas()
        {
            Resizing = new CanvasResizer(this);

            ElementsChanged += ResizeCanvas_OnElementsChanged;
        }



        public void AddDrawing(IConsoleDrawing drawing, ConsoleCoordinates coordinates)
        {
            Drawings.Add(drawing);
            DrawingCoordinates.Add(drawing, coordinates);


            OnElementsChanged();
        }

        public void RemoveDrawing(IConsoleDrawing drawing)
        {
            Drawings.Remove(drawing);
            DrawingCoordinates.Remove(drawing);


            OnElementsChanged();
        }



        private void ResizeCanvas_OnElementsChanged(object? sender, EventArgs args) => Resizing.ResizeToFitDrawings();



        public override void Render()
        {



            base.Render();
        }
    }
}
