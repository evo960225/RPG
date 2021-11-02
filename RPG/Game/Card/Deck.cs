using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Card.Data;
namespace hoshi_lib.Game.Card {
    public class Deck : List<Card> {

        Random rand = new Random();

        public Deck() {
        }
        public Deck(int capacity):base(capacity) {
        }
        public void Shuffle() {
            for (int i = this.Count; i > 0; --i) {
                var index = rand.Next(0, i);
                var it = this[index];
                this.RemoveAt(index);
                this.Add(it);
            }
        }
        public Card Draw(int index = 0) {
            if (index < this.Count) {
                var card = this[index];
                this.RemoveAt(index);
                return card;
            }
            return null;
        }
        public void LoadData() {
            var deck = CardDataController.GetSelectedCard(1, 1).ToList();
            foreach (var it in deck) {
                int i = it.Count;
                for (it.Count = 1; i > 0; i--) {
                    this.Add(it);
                }
            }
        }

        public override string ToString() {
            StringWriter SW = new StringWriter();
            for (int i = 0; i < this.Count; ++i) {
                SW.WriteLine(this[i].Name);
            }
            return SW.ToString();
        } 
    }
}
