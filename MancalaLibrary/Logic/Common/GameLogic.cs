using MancalaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Linq;

namespace MancalaLibrary.Logic.Common
{
    public class GameLogic
    {
        public static bool CupBelongsToActivePlayer(GameModel game, CupModel cup)
        {
            bool output = false;


            var activePlayer = GetActivePlayer(game);

            if (activePlayer.Store == cup)
            {
                output = true;
            }

            foreach (var pit in activePlayer.Pits)
            {
                if (pit == cup)
                {
                    output = true;
                }
            }


            return output;
        }

        public static bool IsOpponentStore(GameModel game, CupModel cup) => (cup.CupType == CupType.Store) && (cup != game.ActivePlayer.Store);

        public static GamePlayerModel GetActivePlayer(GameModel game)
        {
            return game.GamePlayers[game.CurrentPlayerTurnIndex]; 
        }
    }
}
