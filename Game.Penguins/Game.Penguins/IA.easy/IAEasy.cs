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

namespace Game.Penguins.AI.Easy.Code
{
    public class AiEasy : IAi//, ILog
    {
        private readonly ILog Log = LogManager.GetLogger(typeof(AiEasy));

        //coordinates for placement in the first turn
        public int PlacementPenguinX { get; set; }

        public int PlacementPenguinY { get; set; }

        //board
        public IBoard MainBoard { get; }

        //penguins
        public IPenguin Penguin { get; }

        private readonly int[] _tabDirection = new int[6];

        private readonly MoveVerif _movMag;

        public AiEasy(IBoard plateauParam)
        {
            MainBoard = plateauParam;
            _movMag = new MoveVerif(MainBoard);
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
            var poscase = _movMang.WpossibleMove((Case)MainBoard.Board[posX, posY]);
            if (poscase.Any())
            {
                while (true)
                {
                    Case choscase = (Case)poscase[new Random().Next(poscase.Count)];
                    if (choscase.CaseType == caseType.Fish)
                    {
                        return new Coordinates()
                        {
                            X = choscase.XPos,
                            Y = choscase.YPos
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
    }

    public class Coordinates
    {
        public int X { get; internal set; }
        public int Y { get; internal set; }
    }
}