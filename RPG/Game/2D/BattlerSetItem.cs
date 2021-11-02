using hoshi_lib.Game.RPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoshi_lib.Game._2D {
    public struct BattlerSetItem : IBattlerLevelUpItem {
        public BattleBaseValue BattleValue { get; set; }
        public double AttackCD { get; set; }
        public int MaxExp { get; set; }

        public void LevelUp(Bio bio) {
            bio.BattleValue.SetBase(BattleValue);
            bio.AttackCD = AttackCD;
            ++bio.Lv;
        }
    }
}
