using ConsoleUI.Board.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Board.Models
{
    public class MancalaBoardDrawingProperties
    {
        public int BoardLength { get; set; }
        public int BoardWidth { get; set; }


        public int LengthOfPits { get; set; } = BoardConstants.StandardPitLength;
        public int WidthOfPits { get; set; } = BoardConstants.StandardPitWidth;
        public char PitBorderChar { get; set; } = BoardConstants.StandardPitBorderChar;
        public char PitHighlightChar { get; set; } = BoardConstants.StandardCupHighlightChar;

        public int LengthOfStores { get; set; } = BoardConstants.StandardStoreLength;
        public int WidthOfStores { get; set; } = BoardConstants.StandardStoreWidth;
        public char StoreBorderChar { get; set; } = BoardConstants.StandardStoreBorderChar;
        public char StoreHighlightChar { get; set; } = BoardConstants.StandardCupHighlightChar;


        public int HorizontalCupSpacing { get; set; } = BoardConstants.StandardHorizontalCupSpacing;
        public int VerticalPitRowSpacing { get; set; } = BoardConstants.StandardVerticalPitRowSpacing;

        public char StoreIndicatorChar { get; set; } = BoardConstants.StandardStoreIndicatorChar;
    }
}
