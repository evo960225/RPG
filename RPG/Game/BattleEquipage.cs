using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoshi_lib.Game {

    /*public class BattleEquipage : Stuff {

        private Point point;
        private BattleValues values;


        public BattleEquipage(string name, Point point, BattleValues values, int count = 1) {
            this.Name = name;
            this.point = point;
            this.values = values;
            this.count = count;
        }

    }*/

    public class Stuff {

        public string Name;
        public string explain;
        protected int count;

        protected Stuff() {
        }
        public Stuff(string name, int count) {

        }

    }
}
