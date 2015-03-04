using System;
using System.Threading.Tasks;
using System.Threading;
using hoshi_lib.Game.Texture2D;
using System.ComponentModel;

namespace hoshi_lib.Game {

    public class BattleBio : Bio, I4DirectMovement {
        
        public BattleBioValues values;
        public int Speed {
            get { return view.MoveSpendMilsec; }
            set { view.MoveSpendMilsec = value; }
        }
        public BGWorker bgWorker { get; protected set; }
        private MapData mapData;

        public Direction direction;
        public int bgTimes;
        public BattleBio(BattleBioValues values, BioView view) {
            bgWorker = new BGWorker();
            this.values = values;
            this.view = view;

            bgWorker = new BGWorker(condition: () => bgTimes++ < view.LittleMoveTimes);
            bgWorker.MilsecTimeSpan = view.MoveSpendMilsec / view.LittleMoveTimes;
            bgWorker.Start += () => bgTimes = 0;
            bgWorker.Loop += () => this.Move(direction);    
        }
        public void LoadMapData(MapData mapData) {
            this.mapData = mapData;
        }
        public void MoveLeft() {
            if (!bgWorker.Enable) {
                var loc = values.MatrixLocation;
                loc = loc.AddX(-1);
                if (mapData.GetWalkableType(loc) == WalkableType.Walkable) {
                    direction = Direction.Left;
                    bgWorker.Run();
                }
            }
        }
        public void MoveUp() {
            if (!bgWorker.Enable) {
                var loc = values.MatrixLocation;
                loc = loc.AddY(-1);
                if (mapData.GetWalkableType(loc) == WalkableType.Walkable) {
                    direction = Direction.Up;
                    bgWorker.Run();
                }
            }
        }
        public void MoveDown() {
            if (!bgWorker.Enable) {
                var loc = values.MatrixLocation;
                loc = loc.AddY(1);
                if (mapData.GetWalkableType(loc) == WalkableType.Walkable) {
                    direction = Direction.Down;
                    bgWorker.Run();
                }
            }
        }
        public void MoveRight() {
            if (!bgWorker.Enable) {
                var loc = values.MatrixLocation;
                loc = loc.AddX(1);
                if (mapData.GetWalkableType(loc) == WalkableType.Walkable) {
                    direction = Direction.Right;
                    bgWorker.Run();
                }
            }
        }
        public void Move(Direction direction) {
            view.LittleMove(direction);
            if (view.InTimes == view.LittleMoveTimes / 2)
                values.Move(direction);
        }

        public void SetViewLoactionByData() {
            view.Location = view.MoveValue * new Location(values.MatrixLocation.X, values.MatrixLocation.Y);
        }
    }
}
