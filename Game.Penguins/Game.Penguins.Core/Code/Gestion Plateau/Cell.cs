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

        public int XPos; //X position de la cellule
        public int YPos; //Y position de la cellule

        public CellType CellType
        {
            get => cell;
            set
            {
                cell = value; //value = access the object created by set
                StateChanged?.Invoke(this, null);
            }
        }

       

        public int FishCount { get; set; }

        public IPenguin CurrentPenguin => throw new NotImplementedException();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="numberOfFish"></param>
        public Cell(CellType type, int numberOfFish)
        {
            CellType = type;
            if (type != CellType.Fish)
            {
                throw new Exception();
            }
            else
            {
                if (numberOfFish < 0 || numberOfFish > 3)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    FishCount = numberOfFish;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="numberOfFish"></param>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        public Cell(CellType type, int numberOfFish, int posX, int posY)
        {
            CellType = type;
            XPos = posX;
            YPos = posY;
        }   
            
        public Cell() { }

        public void DeleteCell()
        {
            //CurrentPenguin = null;
            FishCount = 0;
            CellType = CellType.Water;
        }
    }

}

