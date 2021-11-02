using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoshi_lib.View {
    public class ConditionTimer : HTimer {
        private Action endTiming;
        public event EventHandler Tick {
            add {
                base.Tick += value;
            }
            remove {
                base.Tick -= value;
            }
        }
        public event Action EndTiming {
            add { endTiming += value; }
            remove { endTiming -= value; }
        }
        public Func<bool> TickUntil { get; set; }

        public new void Start() {
            base.Tick += ConditionEvent;
            base.Start();
        }
        public new void Stop() {
            base.Stop();
        }
        public void End() {
            base.Stop();
            if(endTiming!=null)endTiming();
            base.Tick -= ConditionEvent;
        }
        private void ConditionEvent(object sender, EventArgs e) {
            if (TickUntil == null) return;
            if (TickUntil()) End();
        }
    }
}
