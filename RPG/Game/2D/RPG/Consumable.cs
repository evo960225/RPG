using hoshi_lib.Game.RPG;
using hoshi_lib.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoshi_lib.Game._2D.RPG {
    public class Consumable : Stuff, ICoolDown, IUsed {

        public double CD { get; set; }
        public bool IsCD {
            get { return timer.IsEnabled; }
        }
        public event UsedEventH UsedEvent {
            add { usedEvent += value; }
            remove { usedEvent -= value; }
        }

        private HTimer timer = new HTimer(15);
        private double cdSec = 0;
        private UsedEventH usedEvent;

        public Consumable(int id, string name, Bio user)
            : base(id, name) {
                InitEvent();
        }
        private void InitEvent() {
            timer.Tick += delegate {
                --cdSec;
                if (cdSec <= 0) {
                    timer.Stop();
                }
            };
        }

        public void Used(Bio bio) {
            var isok = !IsCD && Count>0;
            if (isok) {
                --Count;
                cdSec = CD * 64;
                timer.Start();
                bio.World.UsedCommand(bio, this);
            }
            if (usedEvent != null) usedEvent(isok);
        }

    }
}
