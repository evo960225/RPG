using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoshi_lib.Game.Card {
    public class Card {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ATK { get; set; }
        public int DEF { get; set; }
        public int Type { get; set; }
        public int Count { get; set; }
        public Card() { }
    }
}
