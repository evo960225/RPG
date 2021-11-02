using hoshi_lib.Game._2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoshi_lib.Game.RPG {
    public class Equipment : Stuff {

        public BattleValue BattleValues { get; protected set; }
        public EquipmentType Type { get; protected set; }

        public IEnumerable<Addenda> Addendas { get { return addendas; } }
        public Func<BattleValue, BattleValue> PlusFunc { get; protected set; }

        private List<Addenda> addendas = new List<Addenda>();

        public Equipment(IStuff stuffInfo, BattleValue values, EquipmentType type, Func<BattleValue, BattleValue> plusFunc)
        :base(stuffInfo.ID,stuffInfo.Name){
            this.Name = stuffInfo.Name;
            this.Description = stuffInfo.Description;
            this.BattleValues = values;
            this.Type = type;
            this.PlusFunc = plusFunc;
        }

        public void Add(Addenda addenda) {
            addendas.Add(addenda);
            UpdateValues();
        }
        private void Remove(Addenda addenda) {
            addendas.Remove(addenda);
            UpdateValues();
        }
        private void UpdateValues() {
            BattleValue sum = new BattleValue();
            foreach (var it in addendas) {
                sum += it.BattleValues;
                if (it.PlusFunc!=null)
                    sum += it.PlusFunc(BattleValues);
            }
            BattleValues.SetPlus(sum);
        }

        public override string ToString() {
            return "類型: " + Type.ToString() + "\n" + 
            "數值: \n\n" + BattleValues.ToString() + "\n";
        }

    }
}
