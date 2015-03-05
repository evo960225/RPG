using System;
namespace hoshi_lib.Game._2D.RPG {

    static public class BattleSystem {

        public delegate int DamageFunc(IBattler atkBio, IBattler defBio);
        public delegate bool ScaleFunc(IBattler atkBio, IBattler defBio);
        public static void Attack(this IBattler bio, Map map, ScaleFunc scaleFunc, DamageFunc damageFunc) {
            var location = bio.MatrixLocation;

            foreach (var it in map.Data.BioValues) {
                if (scaleFunc(bio, it)) {
                    var damage = damageFunc(bio, it);
                    it.Hp-=damage;
                    map.ShowDamageView(damage.ToString(), it.MatrixLocation);
                }
            }
        }
    }
}
