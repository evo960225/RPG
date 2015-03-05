using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoshi_lib.Game._2D.RPG.Data {
    interface IRoleDataControl {
        void CreateRole(string name,BattleBioValues val);
        BattleBioValues LoadRole(int id);
    }
}
