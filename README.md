# The Mancala Console App

This is a Console application that simulates the board game "Mancala". It uses a SQLite database to track players, their number of wins, and active games that they are currently in. Games that are active are automatically saved after each turn and can be reloaded when the program restarts.


## What is Mancala?

Mancala is a board game that predates chess. It may even be as old as agriculture itself. Each player has six "cups" each that start with four seeds in them and their own "home cup" which starts with zero seeds. The goal is to get more seeds in your home cup than the other player.

For a detailed set of rules, please follow this link: https://www.scholastic.com/content/dam/teachers/blogs/alycia-zimmerman/migrated-files/mancala_rules.pdf


## Current Features:
- Add and remove players
- Check out the leaderboard to see which players have the most wins
- Play through games on the same computer
- Games are automatically saved once created and after each turn so they can be reloaded each time the program starts


## ConsoleDrawingLibrary Explanation
A library for drawing to the console was created for this project. It uses a ConsoleDrawing class to create rectangular, text-based "drawings" to the console. A ConsoleCanvas class is also used so that multiple ConsoleDrawing objects can be layered and positioned in a larger drawing space.


## Local Dependencies
### CommonLibrary
This is a library that I use for various, common C# needs. Most specifically, for this project, it provides DynamicChar and DynamicText classes that allow char and string types to be dynamically generated at runtime based on a delegate method. These classes are helpful for ConsoleDrawing needs as the characters that are drawn to the screen often change throughout the game. This library is provided with the repository as "CommonLibrary.dll".

### ConsoleLibrary
This is a library that I use for generating menus and prompts to the console easily. This library is provided with the repository as "ConsoleLibrary.dll".
