using hoshi_lib.Game.RPG;
using hoshi_lib.HLib;
using hoshi_lib.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoshi_lib.Game._2D {
    public class AITest: BioView{
        public List<IStuff> ThrowStuff {
            get { return throwStuff; }
            set { throwStuff = value; }
        }

        private List<IStuff> throwStuff = new List<IStuff>(10);
        private HTimer timer;
        private Random MoveRand = new Random();
        
        public AITest(Size size,string name,BattleValue val)
            : base(size,name,val) {
                IDGroup = IDGroupType.Antagonism;
            timer = new HTimer(330);
            timer.Tick += delegate {
                if (BattleValue.HP.Point == 0) {
                    timer.Stop();
                    return;
                }

                int distance = 1000;
                MatrixPoint userloc = new MatrixPoint(0,0);
                MatrixPoint thisloc = new MatrixPoint(0,0);
                if (World != null) {
                    userloc = World.FindUserLocation();
                    thisloc = World.GetLocation(this);
                    if (userloc != null)
                        distance = userloc.GetDistance(thisloc);
                }

                if (distance == 1) AttackCommand();
                if (distance > 8) {
                    switch (MoveRand.Next(4)) {
                        case 0:
                            this.MoveCommand(Direction.Left); break;
                        case 1:
                            this.MoveCommand(Direction.Up); break;
                        case 2:
                            this.MoveCommand(Direction.Down); break;
                        case 3:
                            this.MoveCommand(Direction.Right); break;
                    }
                } else {
                    if (thisloc.X > userloc.X) {
                        this.MoveCommand(Direction.Left);
                    } else if (thisloc.Y > userloc.Y) {
                        this.MoveCommand(Direction.Up);
                    } else if (thisloc.X < userloc.X) {
                        this.MoveCommand(Direction.Right);
                    } else if (thisloc.Y < userloc.Y) {
                        this.MoveCommand(Direction.Down);
                    }
                }
   
               
            };
            timer.Start();
        }
        public new void Attacked(int val) {
            if (BattleValue.HP.Point <= 0) {
                ThrowSomeing();
            }
            base.Attacked(val);
        }
        private void ThrowSomeing() {
            foreach (var it in ThrowStuff) {
                World.ThrowCommand(this, it);
            }
        }
    }
}
