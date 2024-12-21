namespace ConsoleUI.Models
{
    public class PlayerViewModel
    {
        public int Id { get; set; }
        public string PlayerName { get; set; } = null!;
        public int WinCount { get; set; }

        public override string ToString() => PlayerName;
    }
}
