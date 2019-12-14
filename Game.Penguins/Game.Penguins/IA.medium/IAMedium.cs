using System;
using System.Collections.Generic;
using Game.Penguins.Core.Interfaces.Game.GameBoard;
using Game.Penguins.Core.Interfaces.Game.Actions;
using Game.Penguins.Core.Code.Interface;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Game.Penguins.AI.Medium.Code
{
    public class IAMedium : IAi
    {
        #region Definitions

        private readonly ILog Log = LogManager.GetLogger(typeof(IAMedium));

        public int PlacementPenguinX { get; set; }
        public int PlacementPenguinY { get; set; }

        public IBoard MainBoard { get; }
        public IPenguin Penguin { get; }
        public static object LogMag { get; private set; }

        private readonly int[] _tabDirection = new int[6];
        private readonly MoVerif _movMag;

        public IAMedium(IBoard plateauParam)
        {
            MainBoard = plateauParam;
            _movementManager = new MoVerif(MainBoard);
        }

        public IAMedium()
        {
            
        }

        #endregion Definitions


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

        public Coordinates FinalDestCell(int posX, int posY)
        {
            var posCells = _movementManager.Wpossiblemove((Cell)MainBoard.Board[posX, posY]);
            if (posCells.Any())
            {
                var chosCell = (Cell)posCells[new Random().Next(posCells.Count)];
                return new Coordinates()
                {
                    X = chosCell.XPos,
                    Y = chosCell.YPos;
                };
            }
            else
            {
                return null;
            }
        }

    public class MoVerif
    {
        private IBoard mainBoard;

        public MoVerif(IBoard mainBoard)
        {
            this.mainBoard = mainBoard;
        }
    }

    public class Coordinates
    {
        public int X { get; internal set; }
        public int Y { get; internal set; }
    }
}
