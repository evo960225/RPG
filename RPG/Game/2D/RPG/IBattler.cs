using hoshi_lib.Game.RPG;
using System;
using System.Collections.Generic;
using System.Windows;

namespace hoshi_lib.Game._2D.RPG {
    public interface IBattler {
        PointCapacity Hp { get; set; }
        PointCapacity Sp { get; set; }
        int Atk { get; set; }
        int Def { get; set; }

        Pair MatrixLocation { get; set; }
        Direction Direction { get; set; }

        void HpFill(double percentage);
        void SpFill(double percentage);
    }
}
