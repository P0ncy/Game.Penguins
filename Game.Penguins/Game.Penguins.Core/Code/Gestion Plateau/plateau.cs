using Game.Penguins.Core.Interfaces.Game.GameBoard;
using System;
using System.Collections.Generic;
using System.Text;


namespace Game.Penguins.Core.Code.Gestion_Plateau
{
   class Plateau : IBoard
   {
        private readonly int Nb1Fish = 34;
        private readonly int Nb2Fish = 20;
        private readonly int Nb3Fish = 10;
        private readonly List<Cell> Cells = new List<Cell>();
        private readonly List<Cell> CellsRandom = new List<Cell>();

        public ICell[,] Board { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sizeX"></param>
        /// <param name="sizeY"></param>
        public Plateau(int sizeX, int sizeY)
        {
            Board = new ICell[sizeX, sizeY];

            Melange();

            // place les celulle mélangé sur le plateau
            var n = 0;
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    Board[i, j] = CellsRandom[n];
                    CellsRandom[n].XPos = i;
                    CellsRandom[n].YPos = j;
                    n++;
                }
            }
        }

        public Plateau(ICell[,] board)
        {
            Board = board;
        }

        public void Melange()
        {
            for (int i = 0; i < Nb1Fish; i++)
            {
                Cells.Add(new Cell(CellType.Fish, 1));
            }
            for (int o = 0; o < Nb2Fish; o++)
            {
                Cells.Add(new Cell(CellType.Fish, 2));
            }
            for (int p = 0; p < Nb3Fish; p++)
            {
                Cells.Add(new Cell(CellType.Fish, 3));
            }

           

            //Random des poissons
            Random r = new Random();
            while (Cells.Count > 0)
            {
                var randomIndex = r.Next(0, Cells.Count);
                CellsRandom.Add(Cells[randomIndex]);
                Cells.RemoveAt(randomIndex);
            }

        }

    }
}
