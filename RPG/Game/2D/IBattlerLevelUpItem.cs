
using hoshi_lib.Game.RPG;
namespace hoshi_lib.Game._2D {
    public interface IBattlerLevelUpItem {
        BattleBaseValue BattleValue { get; set; }
        double AttackCD { get; set; }
        int MaxExp { get; set; }
        void LevelUp(Bio bio);
    }
}
