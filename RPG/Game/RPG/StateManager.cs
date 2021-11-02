using hoshi_lib.Game._2D;
using hoshi_lib.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoshi_lib.Game.RPG {
    public class StateManager {
        int sec;
        int times;
        BattleValue BattleValues;
        Dictionary<BioStateType, BioState> States = new Dictionary<BioStateType, BioState>();
        public StateManager() {

        }
        public void Add(BioState state) {
            States.Add(state.Type,state);
        }
    }
    public class BioState {
        public BioStateType Type { get; set; }
    }
    public enum BioStateType {
        A,
        B
    }
    public class BioStateController {
        public string Name { get; set; }
        public BioStateType Type { get; set; }
        private HTimer timer = new HTimer(1000);
        private Bio bio;
        private Action<Bio> action;
        private Action<Bio> disarm;
        private int sec;

        public BioStateController(Bio bio, Action<Bio> action, int sec, Action<Bio> disarm) {
            this.bio = bio;
            this.action = action;
            this.sec = sec;
            this.disarm = disarm;

            timer.Tick += delegate {
                if (sec == 0) {
                    End();
                }
                action(bio);
                --sec;
            };
        }
        public void Start(){
            timer.Start();
        }
        public void Stop() {
            timer.Stop();
        }
        public void End() {
            timer.Stop();
            if (disarm != null)
                disarm(bio);
        }
    }
}
