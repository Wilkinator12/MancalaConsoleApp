using ConsoleDrawingLibrary.Models.Base;

namespace ConsoleDrawingLibrary.Renderers
{
    public class FormattableConsoleDrawingRenderer
    {
        private readonly IFormattableConsoleDrawing _drawing;


        public FormattableConsoleDrawingRenderer(IFormattableConsoleDrawing drawing)
        {
            _drawing = drawing;
        }


        public void Render()
        {
            RenderFillChars();
            RenderBorderChars();
        }



        private void RenderFillChars()
        {
            if (_drawing.FillChar.IsEmpty == true) return;


            for (int i = 0; i < _drawing.Length; i++)
            {
                for (int j = 0; j < _drawing.Width; j++)
                {
                    _drawing.CharGrid[i, j] = _drawing.FillChar;
                }
            }
        }

        private void RenderBorderChars()
        {
            // Render Top Border
            if (_drawing.TopBorderChar.IsEmpty == false)
            {
                for (int i = 0; i < _drawing.Width; i++)
                {
                    _drawing.CharGrid[0, i] = _drawing.TopBorderChar;
                } 
            }


            // Render Right Border
            if (_drawing.RightBorderChar.IsEmpty == false)
            {
                for (int i = 1; i < _drawing.Length - 1; i++)
                {
                    _drawing.CharGrid[i, _drawing.Width - 1] = _drawing.RightBorderChar;
                } 
            }


            // Render Bottom Border
            if (_drawing.BottomBorderChar.IsEmpty == false)
            {
                for (int i = 0; i < _drawing.Width; i++)
                {
                    _drawing.CharGrid[_drawing.Length - 1, i] = _drawing.BottomBorderChar;
                } 
            }


            // Render Left Border
            if (_drawing.LeftBorderChar.IsEmpty == false)
            {
                for (int i = 1; i < _drawing.Length - 1; i++)
                {
                    _drawing.CharGrid[i, 0] = _drawing.LeftBorderChar;
                } 
            }
        }
    }
}
