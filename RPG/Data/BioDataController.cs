using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using hoshi_lib.Game;
using Database = RPG.Data;
using BioTA = RPG.Data.BioDataDataSetTableAdapters;
using hoshi_lib.Game._2D.RPG;
using hoshi_lib.Game._2D.RPG.Data;
using hoshi_lib.Game.RPG;
namespace hoshi_lib.Data {
    public class BioDataController:IRoleDataControl,IMonsterDataControl {

        private Database.BioDataDataSet DS = new Database.BioDataDataSet();
        private BioTA.role_nameTableAdapter roleName=new BioTA.role_nameTableAdapter();
        private BioTA.role_numericalTableAdapter roleNum=new BioTA.role_numericalTableAdapter();
        private BioTA.role_inventoryTableAdapter roleInventroy=new BioTA.role_inventoryTableAdapter();
 

        public BioDataController() {
        }

        public void CreateRole(string name,BattleBioValues val) {
            //RoleNameTA.Insert(name,DateTime.Now);
            //RoleNumericalTA.Insert(1, val.point.Hp.Point, val.point.Sp.Point, val.point.Hp.MaxLimit, val.point.Sp.MaxLimit, val.battleValue.ATK, val.battleValue.DEF); 
        }

        public BattleBioValues LoadRole(int id) {
            roleNum.Fill(DS.role_numerical);
            roleName.Fill(DS.role_name);
            var name=DS.role_name.Where((x)=>x.ID==id).ElementAt(0).rname;
            var table = DS.role_numerical.Where((x) => x.ID == id);
            if (table.Count() != 0) {
                var role = table.ElementAt(0);
                BattleBioValues val = new BattleBioValues() {
                    Name=name,
                    Level = role.Lv,
                    Hp = new PointCapacity(role.HP, role.MaxHP),
                    Sp = new PointCapacity(role.SP, role.MaxSP),
                    Atk = role.ATK,
                    Def = role.DEF,
                    MatrixLocation=new Pair(role.LocationX,role.LocationY)
                };

                return val;
            }
            throw new Exception("該角色不存在!");
        }

        public AIBio LoadMonster(int id) {
            /*var table= DS.monster.Where((x)=>x.ID==id);

            if (table != null) {
                var monster = table.ElementAt(0);
                BattleValuesOrdinary v = new BattleValuesOrdinary(monster.ATK, monster.DEF);
                PointOrdinary p = new PointOrdinary(monster.HP, monster.SP);
                BattleBioValues value = new BattleBioValues(v, p);
                return new Monster(value);
            }*/
            throw new Exception("該monster不存在!");
            
        }
    }
}
