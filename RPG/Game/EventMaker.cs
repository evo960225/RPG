using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoshi_lib.Game {
    public class EventMaker {
        private struct Event {
            private Action action;
            private Func<bool> condition;
            public IList<int> DirectTo;
            public Event(Func<bool> condition, Action action) {
                DirectTo = new List<int>();
                this.condition = condition;
                this.action = action;
            }
            public bool Check() {
                if (condition()) {
                    action();
                    return true;
                }
                return false;
            }
        }
        private Dictionary<int, Event> events = new Dictionary<int, Event>();
        public List<int> crrentEvent { get; protected set; }

        public EventMaker() {
            crrentEvent = new List<int>();
        }
        public void AddEvent(int number, Func<bool> condition, Action action) {
            var eve = new Event(condition,action);
            events.Add(number, eve);
        }
        public void AddEvent(int number, Func<bool> condition, Action action, IList<int> directTo) {
            var eve = new Event(condition,action);
            eve.DirectTo = directTo;
            events.Add(number, eve);
        }
        public void AddEvent(int number, Func<bool> condition, Action action, params int[] directTo) {
            var eve = new Event(condition, action);
            eve.DirectTo = directTo;
            events.Add(number, eve);
        }
        public void StartEvent(params int[] directTo) {
            crrentEvent.AddRange(directTo);
        }
        public void StartEvent(IList<int> directTo) {
            crrentEvent.AddRange(directTo);
        }
        public void CheckEvent() {
            int happen = 0;
            int len = crrentEvent.Count;
            for (int i = 0; i < len - happen; ++i) {
                var _event = events[crrentEvent[i]];
                if (_event.Check()) {
                    crrentEvent.AddRange(_event.DirectTo);
                    crrentEvent.RemoveAt(i);
                    ++happen;
                    --i;
                    System.Threading.Thread.Sleep(1);
                }
            }
        }
    }

}
