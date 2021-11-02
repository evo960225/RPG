using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace hoshi_lib.Game {
    public static class MainTimer {
        private static DispatcherTimer timer = new DispatcherTimer();
        private static EventHandler tickAction;

        public static bool IsEnabled {
            get { return timer.IsEnabled; }
        }
        public static TimeSpan Interval {
            get { return timer.Interval; }
            set { timer.Interval = value; }
        }
        public static int FPS {
            get { return 64; }
        }
        public static event EventHandler Tick {
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

        static MainTimer() {
            Interval = TimeSpan.FromMilliseconds(15);
            
        }

        public static void TickClear() {
            timer.Tick -= tickAction;
            tickAction = null;
        }
        public static void Start() {
            timer.Start();
        }
        public static void Stop() {
            timer.Stop();
        }
    }
}
