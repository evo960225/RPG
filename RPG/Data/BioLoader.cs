using hoshi_lib.Game._2D;
using hoshi_lib.Game.RPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA = hoshi_lib.Data.UserDataDataSetTableAdapters;

namespace hoshi_lib.Data {
    public class BioLoader {
        UserDataDataSet ds = new UserDataDataSet();
        TA.BioTableAdapter BioTA = new TA.BioTableAdapter();
        TA.BioDropStuffTableAdapter DropTA = new TA.BioDropStuffTableAdapter();

        public BioLoader() {
            BioTA.Fill(ds.Bio);
            DropTA.Fill(ds.BioDropStuff);
        }
        public AITest LoadBio(int id, Size size) {
            var Bio = ds.Bio.Where((x) => x.ID == id).ElementAt(0);
            //var stuffs = ds.BioDropStuff.Where((x) => x.ID == id).Select((x)=>x.StuffID);
            BattleValue Value = new BattleValue(Bio.ATK, Bio.DEF, Bio.MaxHP, Bio.MaxSP);
            AITest role = new AITest(size, Bio._Name, Value);
            role.OfferExp = Bio.OfferEXP;
            //role.ThrowStuff.AddRange(stuffs);
            return role;
        }
    }

   
}
