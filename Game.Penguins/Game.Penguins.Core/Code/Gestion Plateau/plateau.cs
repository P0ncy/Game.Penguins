using Game.Penguins.Core.Interfaces.Game.GameBoard;
using System;
using System.Collections.Generic;
using System.Text;


namespace Game.Penguins.Core.Code.Gestion_Plateau
{
   class Plateau : IBoard
   {
        private int Nb1Fish = 34;
        private int Nb2Fish = 20;
        private int Nb3Fish = 10;
        private readonly List<Cell> Cells = new List<Cell>();
        private readonly List<Cell> CellsRandom = new List<Cell>();

        public ICell[,] Board { get; }

        public Plateau(ICell[,] board)
        {
            Board = board;
        }

        
    }
}
