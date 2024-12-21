using ConsoleLibrary.Common.Extensions;
using ConsoleDrawingLibrary.Models.Base;
using MancalaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Displays
{
    public class GameDisplay
    {
        public string Title { get; set; } = null!;
        public string TurnMessage { get; set; } = null!;
        public IConsoleDrawing Board { get; set; } = null!;
        public string EventMessage { get; set; } = null!;


        public void Print()
        {
            Title.PrintAsTitle();
            Console.WriteLine(TurnMessage);
            Console.WriteLine();

            Board.Render();
            Board.Draw();
            Console.WriteLine();

            Console.WriteLine(EventMessage);
        }
    }
}
