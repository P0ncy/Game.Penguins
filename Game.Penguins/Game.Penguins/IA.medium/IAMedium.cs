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
            _movMag = new MoVerif(MainBoard);
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
            Log.Error("no cell found");
            return null;
        }

        public Coordinates FinalDestcase(int posX, int posY)
        {
            var poscase = _movMang.Wpossiblemove((Cell)MainBoard.Board[posX, posY]);
            if (poscase.Any())
            {
                var choscase = (Cell)poscase[new Random().Next(poscase.Count)];
                return new Coordinates()
                {
                    X = choscase.XPos,
                    Y = choscase.YPos;
                };
            }
            else
            {
                return null;
            }
        }

    public class Coordinates
    {

    }
}
