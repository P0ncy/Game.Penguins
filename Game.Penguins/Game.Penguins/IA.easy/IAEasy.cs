using System;
using System.Collections.Generic;
using Game.Penguins.Core.Interfaces.Game.GameBoard;
using Game.Penguins.Core.Interfaces.Game.Actions;
using Game.Penguins.Core.Code.Interface;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Penguins.IA.easy
{
    class IAEasy : IAi
    {
        public int PlacementPenguinX { get; set; }

        public int PlacementPenguinY { get; set; }

        public IBoard MainBoard { get; }

    }
}
