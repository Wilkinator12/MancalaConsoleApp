namespace ConsoleUI.Models
{
    public class GamePlayerViewModel
    {
        public int Id { get; set; }
        public PlayerViewModel PlayerInfo { get; set; } = null!;
        public CupViewModel Store { get; set; } = null!;
        public List<CupViewModel> Pits { get; set; } = new List<CupViewModel>();

        public override string ToString() => PlayerInfo.ToString();
    }
}
