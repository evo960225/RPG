using hoshi_lib.Game.RPG;
using System.Linq;
using TA = hoshi_lib.Data.UserDataDataSetTableAdapters;

namespace hoshi_lib.Data {
    public class StuffLoader {
        UserDataDataSet ds = new UserDataDataSet();
        TA.StuffTableAdapter StuffTA = new TA.StuffTableAdapter();

        public StuffLoader() {
            StuffTA.Fill(ds.Stuff);
        }
        public IStuff LoadStuff(int id) {
            var load = ds.Stuff.Where((x) => x.ID == id).ElementAtOrDefault(0);
            IStuff stuff = new Stuff(load.ID, load._Name) {
                Description = load.Description,
                Price = load.Price
            };
            if (load.Type == 1) {
                stuff.IsCountable = true;
                stuff.Count = 1;
            } else {
                stuff.IsCountable = false;
            }
            return stuff;
        }
    }
}
