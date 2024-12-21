using System;
using System.Collections.Generic;
using System.Text;

namespace MancalaLibrary.DataAccess.Models
{
    public class GamesTableModel
    {
        public int Id { get; set; }
        public int CurrentPlayerTurnIndex { get; set; }
        public string StartDate { get; set; }
    }
}
