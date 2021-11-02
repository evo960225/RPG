
using hoshi_lib.HLib;
using hoshi_lib.View;
using hoshi_lib.Game.RPG;
using hoshi_lib.Game._2D.RPG;
using System.Collections.Generic;
namespace hoshi_lib.Game._2D {
    public partial class Bio : IGameObject {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
    public partial class Bio : IMoney {

        public IDGroupType IDGroup { get; set; }
        public int Money { get; set; }

        public WorldCommand World { get; set; }

        public bool IsMoveing { get; protected set; }
        public BattleValue BattleValue { get; protected set; }
        public bool IsAttacking { get { return attackTimer.IsEnabled; } }
        public double AttackCD { get; set; }

        //public EquipmentManager EquipmentManager { get; set; }
        public StuffManager StuffManager { get; set; }

        private HTimer attackTimer;
        public Bio(string name, BattleValue values) {
            this.Name = name;
            this.BattleValue = values;
            IDGroup = IDGroupType.User;
            InitAttackTimer();
        }

        protected void MoveCommand(Direction direction) {
            if (IsMoveing) return;
            if (World == null) return;
            World.MoveCommand(this, direction);
        }
        protected void Moved(Direction direction) {
            IsMoveing = true;
        }
        protected void AttackCommand() {
            if (IsAttacking) return;
            if (World == null) return;
            World.AttackCommand(this);
            atkTimes = (int)(AttackCD * onesecTimes);
            attackTimer.Start();
        }
        protected void Attacked(int value) {
            BattleValue.HPDecrease(value);
            if (BattleValue.HP.Point <= 0) {
                World.RemoveBio(this as BioView);
            }
        }
        protected void LevelUpCommand() {

        }

        public void Gived(IStuff stuff) {
            if (StuffManager == null) return;
            StuffManager.Add(stuff);
        }

        int atkTimes;
        int onesecTimes = 64;
        private void InitAttackTimer() {
            attackTimer = new HTimer(15);
            attackTimer.Tick += delegate {
                --atkTimes;
                if (atkTimes <= 0) {
                    attackTimer.Stop();
                }
            };
        }

    }
 
    public partial class Bio {
        public int Lv { get; set; }
        public int Exp {
            get { return exp; }
            set { 
                exp = value;
                CanLevelUp();
            }
        }
        public int MaxExp { get; set; }
        public int OfferExp { get; set; }

        private int exp;
        public List<IBattlerLevelUpItem> LevelItem = new List<IBattlerLevelUpItem>(100);
        public void CanLevelUp() {
            if (exp >= MaxExp) { LevelUp(); }
        }
        public void LevelUp() {
            int index = Lv-1;
            if (index < LevelItem.Count && index>=0) {
                LevelItem[index].LevelUp(this);
                exp -= MaxExp;
            }
        }
    }
}
