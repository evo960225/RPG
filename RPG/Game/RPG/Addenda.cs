using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoshi_lib.Game.RPG {
    public class Addenda : Stuff {

        public BattleValue BattleValues { get; protected set; }

        public Func<BattleValue, BattleValue> PlusFunc { get; protected set; }

        public Addenda(IStuff stuffInfo, BattleValue values, Func<BattleValue, BattleValue> plusFunc):base(stuffInfo.ID,stuffInfo.Name) {
            this.Name = stuffInfo.Name;
            this.Description = stuffInfo.Description;
            this.BattleValues = values;
            this.PlusFunc = plusFunc;
        }
    }
}
