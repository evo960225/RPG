
namespace hoshi_lib.Game.RPG {

    public interface IHp {
        CapacityPoint HP { get; }
    }
    public interface ISp {
        CapacityPoint SP { get; }
    }
    public interface IAtk {
        BasePlus ATK { get; }
    }
    public interface IDef {
        BasePlus DEF { get; }
    }
    public partial interface IBattleBaseValue : IHp, ISp, IAtk, IDef {

    }

    public partial class BattleValue : IBattleBaseValue {
        public CapacityPoint HP { get { return hp; }  }
        public CapacityPoint SP { get { return sp; } }
        public BasePlus ATK { get { return atk; } }
        public BasePlus DEF { get { return def; } }

        private CapacityPoint hp;
        private CapacityPoint sp;
        private BasePlus atk;
        private BasePlus def;

        public BattleValue() {
        }
        public BattleValue(BattleBaseValue value) {
            this.atk = new BasePlus(value.ATK);
            this.def = new BasePlus(value.DEF);
            this.hp = new CapacityPoint(value.HP, new BasePlus(value.HP));
            this.sp = new CapacityPoint(value.SP, new BasePlus(value.SP));
        }
        public BattleValue(int atk, int def, int maxhp, int maxsp, int? hp = null, int? sp = null) {
            this.atk = new BasePlus(atk);
            this.def = new BasePlus(def);
            this.hp = new CapacityPoint(hp ?? maxhp, new BasePlus(maxhp));
            this.sp = new CapacityPoint(sp ?? maxsp, new BasePlus(maxsp));
        }
        public BattleValue(int atk, int def, CapacityPoint hp, CapacityPoint sp) {
            this.atk = new BasePlus(atk);
            this.def = new BasePlus(def);
            this.hp = hp;
            this.sp = sp;
        }
        public BattleValue(BasePlus atk, BasePlus def, CapacityPoint hp, CapacityPoint sp) {
            this.atk = atk;
            this.def = def;
            this.hp = hp;
            this.sp = sp;
        }

        public void SetBase(BattleBaseValue val) {
            var hpmax = hp.Max;
            hpmax.Base = val.HP;
            var spmax = sp.Max;
            spmax.Base = val.SP;
            atk.Base = val.ATK;
            def.Base = val.DEF;
        }
        public void AddBase(BattleBaseValue val) {
            var hpmax = hp.Max;
            hpmax.Base += val.HP;
            var spmax = sp.Max;
            spmax.Base += val.SP;
            atk.Base += val.ATK;
            def.Base += val.DEF;
        }
        public void SetPlus(IBattleBaseValue value) {
            var hpmax = hp.Max;
            hpmax.Plus = value.HP.Max;
            hp.Max = hpmax;
            var spmax = sp.Max;
            spmax.Plus= value.SP.Max;
            sp.Max = spmax;
            atk.Plus = value.ATK;
            def.Plus = value.DEF;
        }
        public void AddPlus(IBattleBaseValue value) {
            var hpmax = hp.Max;
            hpmax.Plus += value.HP.Max;
            var spmax = sp.Max;
            spmax.Plus += value.SP.Max;
            sp.Max = spmax;
            atk.Plus += value.ATK;
            def.Plus += value.DEF;
        }
        public void SubPlus(IBattleBaseValue value) {
            var hpmax = hp.Max;
            hpmax.Plus -= value.HP.Max;
            var spmax = sp.Max;
            spmax.Plus -= value.SP.Max;
            sp.Max = spmax;
            atk.Plus -= value.ATK;
            def.Plus -= value.DEF;
        }
        public void HPIncrease(int val) {
            hp.Increase(val);
        }
        public void HPDecrease(int val) {
            hp.Decrease(val);
        }
        public void SPIncrease(int val) {
            sp.Increase(val);
        }
        public void SPDecrease(int val) {
            sp.Decrease(val);
        }
        static public BattleValue operator +(BattleValue val, BattleValue val2) {
            var atk = val.ATK + val2.ATK;
            var def = val.DEF + val2.DEF;
            var hp = val.HP + val2.HP;
            var sp = val.SP + val2.SP;
            return new BattleValue(atk, def, hp, sp);
        }
        static public BattleValue operator -(BattleValue val, BattleValue val2) {
            var atk = val.ATK - val2.ATK;
            var def = val.DEF - val2.DEF;
            var hp = val.HP - val2.HP;
            var sp = val.SP - val2.SP;
            return new BattleValue(atk, def, hp, sp);
        }
        static public BattleValue operator *(BattleValue val, int val2) {
            var atk = val.ATK * val2;
            var def = val.DEF * val2;
            var hp = val.HP * val2;
            var sp = val.SP * val2;
            return new BattleValue(atk, def, hp, sp);
        }
        static public BattleValue operator /(BattleValue val, int val2) {
            var atk = val.ATK / val2;
            var def = val.DEF / val2;
            var hp = val.HP / val2;
            var sp = val.SP / val2;
            return new BattleValue(atk, def, hp, sp);
        }

        override public string ToString() {
            return "HP:\t" + hp.ToString() + "\nSP:\t" + sp.ToString() + "\nATK:\t" + atk.ToString() + "\nDEF:\t" + def.ToString() + "\n";
        }
    }

    public struct BattleBaseValue {
        public int HP { 
            get { return hp; }
            set { hp = value; }
        }
        public int SP {
            get { return sp; }
            set { sp = value; }
        }
        public int ATK {
            get { return atk; }
            set { atk = value; }
        }
        public int DEF {
            get { return def; }
            set { def = value; }
        }

        private int hp;
        private int sp;
        private int atk;
        private int def;

        public BattleBaseValue(int atk, int def, int hp, int sp) {
            this.atk = atk;
            this.def = def;
            this.hp = hp;
            this.sp = sp;
        }

        static public BattleBaseValue operator +(BattleBaseValue val, BattleBaseValue val2) {
            var atk = val.ATK + val2.ATK;
            var def = val.DEF + val2.DEF;
            var hp = val.HP + val2.HP;
            var sp = val.SP + val2.SP;
            return new BattleBaseValue(atk, def, hp, sp);
        }
        static public BattleBaseValue operator -(BattleBaseValue val, BattleBaseValue val2) {
            var atk = val.ATK - val2.ATK;
            var def = val.DEF - val2.DEF;
            var hp = val.HP - val2.HP;
            var sp = val.SP - val2.SP;
            return new BattleBaseValue(atk, def, hp, sp);
        }
        static public BattleBaseValue operator *(BattleBaseValue val, int val2) {
            var atk = val.ATK * val2;
            var def = val.DEF * val2;
            var hp = val.HP * val2;
            var sp = val.SP * val2;
            return new BattleBaseValue(atk, def, hp, sp);
        }
        static public BattleBaseValue operator /(BattleBaseValue val, int val2) {
            var atk = val.ATK / val2;
            var def = val.DEF / val2;
            var hp = val.HP / val2;
            var sp = val.SP / val2;
            return new BattleBaseValue(atk, def, hp, sp);
        }

        override public string ToString() {
            return "HP:\t" + HP.ToString() + "\nSP:\t" + SP.ToString() + "\nATK:\t" + ATK.ToString() + "\nDEF:\t" + DEF.ToString() + "\n";
        }
    }
}
