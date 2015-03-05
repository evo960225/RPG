using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoshi_lib.Game.RPG {

    public class Equipage : Stuff {




    }

    public class Stuff {

        public string Name;
        public int Count;
        public string Description;

        protected Stuff() {
        }
        public Stuff(string name, int count) {

        }
    }

    public class Supplements : Stuff {
        
    }

    public class Card : Stuff {

    }

    public class Addenda : Stuff {

    }
}
