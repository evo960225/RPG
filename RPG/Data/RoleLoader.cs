using hoshi_lib.Game._2D;
using hoshi_lib.Game.RPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA = hoshi_lib.Data.UserDataDataSetTableAdapters;
namespace hoshi_lib.Data {

    public class RoleLoader {
        UserDataDataSet ds = new UserDataDataSet();
        TA.RoleTableAdapter RoleTA = new TA.RoleTableAdapter();
        TA.BattleValueTableAdapter BattleValueTA = new TA.BattleValueTableAdapter();

        public RoleLoader() {

        }
        public BioView LoadRole(int id,Size size) {
            RoleTA.Fill(ds.Role);
            BattleValueTA.Fill(ds.BattleValue);
            var tmp = ds.Role.Join(ds.BattleValue, (x) => x.ID, (y) => y.RoleID,
                              (x, y) => new { Role = x, Value = y }).
                              Where((x) => x.Role.ID == id).ElementAt(0);
            var Value=tmp.Value;
            BattleValue  value=new BattleValue(Value.ATK,Value.DEF,Value.MaxHP,Value.MaxSP,Value.HP,Value.SP);
            BioView role = new BioView(size, tmp.Role.RoleName, value);
            role.Lv = Value.Lv;
            return role;
        }
    }
}
