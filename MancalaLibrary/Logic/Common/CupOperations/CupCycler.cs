using CommonLibrary.ListServices;
using MancalaLibrary.Logic.Common.Board.Models;
using MancalaLibrary.Logic.Common.Board.Models.Factories;
using MancalaLibrary.Models;
using System;

namespace MancalaLibrary.Logic.Common.CupOperations
{
    public class CupCycler
    {
        private readonly GameModel _game;
        private readonly BoardModel _board;

        private readonly ListCycler<CupModel> _listCycler;


        public CupModel CurrentCup => _listCycler.CurrentItem;
        public bool SkipOpponentStores { get; set; } = true;


        public CupCycler(GameModel game)
        {
            _game = game;
            _board = BoardFactory.Create(game);

            _listCycler = new ListCycler<CupModel>(_board.CupPath);
        }



        public void SetCurrentCup(CupModel cup) => _listCycler.SetCurrentItem(cup);



        public CupModel CycleNext()
        {
            var output = _listCycler.CycleNext();


            if (SkipOpponentStores)
            {
                while (GameLogic.IsOpponentStore(_game, CurrentCup))
                {
                    output = _listCycler.CycleNext();
                }
            }

            return output;
        }

        public CupModel CyclePrevious()
        {
            var output = _listCycler.CyclePrevious();


            if (SkipOpponentStores)
            {
                while (GameLogic.IsOpponentStore(_game, CurrentCup))
                {
                    output = _listCycler.CyclePrevious();
                }
            }

            return output;
        }
    }
}
