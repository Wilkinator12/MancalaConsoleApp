using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Board.Constants
{
    public static class BoardConstants
    {
        public static readonly int StandardPitLength = 5;
        public static readonly int StandardPitWidth = 7;

        public static readonly int StandardStoreLength = 11;
        public static readonly int StandardStoreWidth = 9;

        public static readonly int StandardHorizontalCupSpacing = 1;
        public static readonly int StandardVerticalPitRowSpacing = 1;

        public static readonly char StandardStoreIndicatorChar = '|';

        public static readonly char StandardPitBorderChar = '-';
        public static readonly char StandardStoreBorderChar = '*';

        public static readonly char StandardCupHighlightChar = '*';
    }
}
