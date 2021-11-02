using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace hoshi_lib.View {
    public class HTimer {
        private DispatcherTimer timer;
        private EventHandler tickAction;

        public bool IsEnabled {
            get { return timer.IsEnabled; }
        }
        public TimeSpan Interval {
            get { return timer.Interval; }
            set { timer.Interval = value; }
        }
        public event EventHandler Tick {
            add {
                timer.Tick -= tickAction;
                tickAction += value; 
                timer.Tick += tickAction;
            }
            remove {
                timer.Tick -= tickAction;
                tickAction -= value;
                timer.Tick += tickAction;
            }
        }

        public HTimer() {
            timer = new DispatcherTimer();
        }
        public HTimer(double intervalMillisec) {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(intervalMillisec);
        }
        public void TickClear(){
            timer.Tick -= tickAction;
            tickAction = null;
        }
        public void Start() {
            timer.Start();
        }
        public void Stop() {
            timer.Stop();
        }
    }

}
