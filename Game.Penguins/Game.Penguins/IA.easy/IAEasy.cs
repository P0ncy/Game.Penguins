using System;
using System.Collections.Generic;
using Game.Penguins.Core.Interfaces.Game.GameBoard;
using Game.Penguins.Core.Interfaces.Game.Actions;
using Game.Penguins.Core.Code.Interface;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Game.Penguins.AI.Medium.Code;
using Game.Penguins.Core.Code.Gestion_Plateau;



namespace Game.Penguins.AI.Easy.Code
{
    public class AiEasy : IAi//,ICell, ILog
    {
        private readonly ILog Log = LogManager.GetLogger(typeof(AiEasy));

        //coordinates for placement in the first turn
        public int PlacementPenguinX { get; set; }

        public int PlacementPenguinY { get; set; }

        //board
        public IBoard MainBoard { get; }

        private MoveVerif _movementManager;

        //penguins
        public IPenguin Penguin { get; }

        private readonly int[] _tabDirection = new int[6];

        private readonly MoveVerif _movementManger;

        public AiEasy(IBoard plateauParam)
        {
            MainBoard = plateauParam;
            _movementManager = new MoveVerif(MainBoard);
        }


        public Coordinates PlacementPenguin()
        {
            Random rnd = new Random();

            while (true)
            {
                Log.Debug("Searching for a suitable case");
                PlacementPenguinX = rnd.Next(8);
                PlacementPenguinY = rnd.Next(8);
                ICell c = MainBoard.Board[PlacementPenguinX, PlacementPenguinY];

                if (c.CellType == CellType.Fish && c.FishCount == 1 && c.CurrentPenguin == null)
                {
                    Log.Debug("IA will move to x: " + PlacementPenguinX + " , y: " + PlacementPenguinY);
                    return new Coordinates()
                    {
                        X = PlacementPenguinX,
                        Y = PlacementPenguinY
                    };
                }
            }
        }


        public Coordinates FinalDestcase(int posX, int posY)
        {
            var posCells = _movementManager.WpossibleMove((Cell)MainBoard.Board[posX, posY]);
            if (posCells.Any())
            {
                while (true)
                {
                    Cell chosenCell = (Cell)posCells[new Random().Next(posCells.Count)];
                    if (chosenCell.CellType == CellType.Fish)
                    {
                        return new Coordinates()
                        {
                            X = chosenCell.XPos,
                            Y = chosenCell.YPos
                        };
                    }
                }
            }
            else
            {
                return null;
            }
        }
    }

    public class MoveVerif
    {
        private IBoard mainBoard;

        public MoveVerif(IBoard mainBoard)
        {
            this.mainBoard = mainBoard;
        }

        internal object WpossibleMove(Cell cell)
        {
            throw new NotImplementedException();
        }
    }

    public class Coordinates
    {
        public int X { get; internal set; }
        public int Y { get; internal set; }
    }
}