using ConsoleLibrary.Common.Models;
using MancalaLibrary.Models;

namespace ConsoleUI.Models
{
    public class CupViewModel
    {
        public CupType CupType { get; set; }
        public DynamicText SeedCount { get; set; } = null!;
        public bool IsHighlighted { get; set; }
    }
}
