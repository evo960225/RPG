using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hoshi_lib.Game;
using hoshi_lib;

namespace Test {
    interface IBioValue : I4DirectMovement {
        void MoveLeft();
        void MoveUp();
        void MoveDown();
        void MoveRight();
    }
}
