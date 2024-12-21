using MancalaLibrary.Logic.Common.Board.Models;
using MancalaLibrary.Models;
using System;
using System.Collections.Generic;

namespace MancalaLibrary.Logic.Common.CupOperations
{
    public class CupActivator
    {
        private readonly BoardModel _board;


        public CupActivator(BoardModel board)
        {
            _board = board;
        }


        public void Activate(List<CupModel> cups)
        {
            foreach (var cup in cups)
            {
                if (_board.CupPath.Contains(cup))
                {
                    cup.IsActive = true;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("cup did not appear on the board.");
                }
            }
        }

        public void Deactivate(List<CupModel> cups)
        {
            foreach (var cup in cups)
            {
                if (_board.CupPath.Contains(cup))
                {
                    cup.IsActive = false;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("cup did not appear on the board.");
                }
            }
        }

        public void DeactivateAll()
        {
            foreach (var cup in _board.CupPath)
            {
                cup.IsActive = false;
            }
        }

        public void ActivateExclusive(List<CupModel> cups)
        {
            DeactivateAll();

            Activate(cups);
        }
    }
}
