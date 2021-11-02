using System.Collections.Generic;
using System.Linq;

namespace hoshi_lib.Game.RPG {
    public class StuffManager {
        public delegate void StuffManagerEvent(int index, IStuff add);

        public IStuff this[int index]{
            get { return stuffs[index]; }
        }
        public IEnumerable<IStuff> Stuffs { get { return stuffs; } }
        public event StuffManagerEvent AddEvent {
            add { addedEvent += value; }
            remove { addedEvent -= value; }
        }
        public event StuffManagerEvent ChangedEvent {
            add { changedEvent += value; }
            remove { changedEvent -= value; }
        }
        public event StuffManagerEvent RemovedEvent {
            add { removedEvent += value; }
            remove { removedEvent -= value; }
        }

        private StuffManagerEvent addedEvent;
        private StuffManagerEvent changedEvent;
        private StuffManagerEvent removedEvent;
        private List<IStuff> stuffs;

        public StuffManager() {
            stuffs = new List<IStuff>();
        }
        public void Add(IStuff stuff) {
            int index;
            var _stuff = stuffs.Where(x => x!=null && x.Name == stuff.Name);
            if (_stuff.Count() == 1 && stuff.IsCountable) {
                _stuff.ElementAt(0).Count += stuff.Count;
                index = stuffs.IndexOf(_stuff.ElementAt(0));
            } else {
                index = 0;
                foreach (var it in stuffs) {
                    if (it == null) {
                        stuffs[index] = stuff;
                        break;
                    }
                    ++index;
                }
                stuffs.Add(stuff);
            }
            if (addedEvent != null) addedEvent(index, stuff);
        }
        public void Add(int index, IStuff stuff) {
            if (index >= stuffs.Count) {
                while (index > stuffs.Count) { stuffs.Add(null); }
                stuffs.Add(stuff);
            } else {
                var _stuff = stuffs[index];
                if (_stuff == null) {
                    stuffs[index] = stuff;
                } else if (stuff.IsCountable) {
                    _stuff.Count += stuff.Count;
                }
            }
            if (addedEvent != null) addedEvent(index, stuff);
        }
        public IStuff Change(int index, IStuff stuff) {
            IStuff _return = null;
            if (index < stuffs.Count) {
                Remove(index, stuff);
            }
            Add(index, stuff);
            if (changedEvent != null) changedEvent(index, stuff);
            return _return;
        }
        public void Remove(int index, IStuff stuff) {
            if (stuffs[index] != null) {
                stuffs[index] = null;
            }
            if (removedEvent != null) removedEvent(index, stuff);
        }
        public int Count() {
            int sum=0;
            foreach (var it in stuffs) {
                sum += it.Count;
            }
            return sum;
        }
    }
}
