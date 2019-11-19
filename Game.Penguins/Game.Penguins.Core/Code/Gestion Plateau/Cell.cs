using Game.Penguins.Core.Interfaces.Game.GameBoard;
using System;
using System.Collections.Generic;
using System.Text;


namespace Game.Penguins.Core.Code.Gestion_Plateau
{

    public class Cell : ICell
    {
        private CellType cell;

        public event EventHandler StateChanged;

        public CellType CellType
        {
            get => cell;
            set
            {
                cell = value; //value = access the object created by set
                StateChanged?.Invoke(this, null);
            }
        }

        public Cell() { }

        public int FishCount { get; set; }

        public IPenguin CurrentPenguin => throw new NotImplementedException();
    }
}

