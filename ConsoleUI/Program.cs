using ConsoleUI.Menus;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new MainMenu().Run();


            Console.WriteLine("End of Program");
            Console.ReadLine();
        }
    }
}
