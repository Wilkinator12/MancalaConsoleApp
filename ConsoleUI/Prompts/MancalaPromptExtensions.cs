using ConsoleLibrary.Prompts.Base.Extensions;
using ConsoleLibrary.Prompts.CommonPrompts.Models;
using ConsoleUI.Models;
using ConsoleUI.ViewModels;

namespace ConsoleUI.Prompts
{
    public static class MancalaPromptExtensions
    {
        public static PlayerViewModel AsPlayerSelectPrompt(this string message, List<PlayerViewModel> players)
        {
            return new NumberedListConsolePrompt<PlayerViewModel>(players)
                .AddPromptMessage(message)
                .Run();
        }

        public static GameViewModel AsGameSelectPrompt(this string message, List<GameViewModel> games)
        {
            return new NumberedListConsolePrompt<GameViewModel>(games)
                .AddPromptMessage(message)
                .Run();
        }
    }
}
