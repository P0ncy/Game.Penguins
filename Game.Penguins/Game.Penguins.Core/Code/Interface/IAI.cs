using System;
using System.Collections.Generic;
using Game.Penguins.Core.Interfaces.Game.GameBoard;
using System.Text;

namespace Game.Penguins.Core.Code.Interface
{
    public interface IAi
    {
        int PlacementPenguinX { get; set; }

        int PlacementPenguinY { get; set; }
        IBoard MainBoard { get; }

        /*public IAEasy(IBoard plateauParam)
        {
            MainBoard = plateauParam;
            _movementManager = new MovementVerificationHelper(MainBoard);
        }*/

  
    }
}
