using ConsoleUI.Board.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Board.Validation
{
    public class CupDrawingValidator
    {
        private readonly int _minCupLength = 4;
        private readonly int _minCupWidth = 3;

        public void ValidateForDrawing(CupDrawingProperties cupProperties)
        {
            ValidateLength(cupProperties.Length);
            ValidateWidth(cupProperties.Width);
        }

        private void ValidateLength(int length)
        {
            if (length < _minCupLength)
            {
                throw new ArgumentException($"The length of a cup must be at least {_minCupLength} to be drawn.");
            }
        }

        private void ValidateWidth(int width)
        {
            if (width < _minCupWidth)
            {
                throw new ArgumentException($"The width of this cup must be at least {_minCupWidth}.");
            }
        }
    }
}
