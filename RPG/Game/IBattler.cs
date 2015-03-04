using System;
using System.Collections.Generic;
using System.Windows;
using hoshi_lib.Game.Texture2D;

namespace hoshi_lib.Game {
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
