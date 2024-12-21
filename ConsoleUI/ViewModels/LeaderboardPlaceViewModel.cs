using ConsoleUI.Models;
using MancalaLibrary.Models;

namespace ConsoleUI.ViewModels
{
    public class LeaderboardPlaceViewModel
    {
        public int Place { get; set; }
        public List<PlayerViewModel> PlacedPlayers { get; set; } = new List<PlayerViewModel>();
        public int WinCount { get; set; }

        public string DisplayText => GetDisplayText();

        public override string ToString() => DisplayText;


        private string GetDisplayText()
        {
            if (PlacedPlayers.Any() == true)
            {
                string playerNames = "";

                foreach (var player in PlacedPlayers)
                {
                    playerNames += $", {player.PlayerName}";
                }

                playerNames = playerNames.Substring(2);

                return $"#{Place}: {playerNames} - {WinCount} win(s)";
            }
            else
            {
                return $"#{Place}: No Players";
            }
        }
    }
}
