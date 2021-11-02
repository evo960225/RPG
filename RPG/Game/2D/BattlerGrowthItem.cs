
using hoshi_lib.Game.RPG;
namespace hoshi_lib.Game._2D {
    public struct BattlerGrowthItem : IBattlerLevelUpItem {
        public BattleBaseValue BattleValue { get; set; }
        public double AttackCD { get; set; }
        public int MaxExp { get; set; }
        public void LevelUp(Bio bio) {
            bio.BattleValue.AddBase(BattleValue);
            bio.AttackCD += AttackCD;
            bio.MaxExp += MaxExp;
            ++bio.Lv;
        }
    }
}
