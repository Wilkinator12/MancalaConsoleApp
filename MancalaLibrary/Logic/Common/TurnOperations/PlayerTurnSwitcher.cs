using CommonLibrary.ListServices;
using MancalaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MancalaLibrary.Logic.Common.TurnOperations
{
    public class PlayerTurnSwitcher
    {
        private readonly GameModel _game;


        private readonly ListCycler<GamePlayerModel> _playerCycler;


        public PlayerTurnSwitcher(GameModel game)
        {
            _game = game;
            _playerCycler = new ListCycler<GamePlayerModel>(game.GamePlayers);

            _playerCycler.SetCurrentItem(game.CurrentPlayerTurnIndex);
        }


        public void SwitchToNextPlayer()
        {
            _playerCycler.CycleNext();
            _game.CurrentPlayerTurnIndex = _playerCycler.CurrentIndex;
        }
    }
}
