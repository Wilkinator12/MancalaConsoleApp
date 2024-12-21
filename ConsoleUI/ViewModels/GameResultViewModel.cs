using ConsoleUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.ViewModels
{
    public class GameResultViewModel
    {
        public List<GamePlayerViewModel> Winners { get; set; } = new List<GamePlayerViewModel>();
    }
}
