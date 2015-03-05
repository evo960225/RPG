using System.Windows;
using System;
using hoshi_lib.Game.RPG;
namespace hoshi_lib.Game._2D.RPG {

    public partial class BattleBioValues {

        public int Level { get; set; }
        public PointCapacity exp { get; set; }
        public string Name { get; set; }
        private PointCapacity hp;
        private PointCapacity sp;
        private int atk;
        private int def;
        private Pair matrixLocation;
        private Direction direction;

        public BattleBioValues() {

        }

    }

    public partial class BattleBioValues : IBattler {

        public PointCapacity Hp {
            get { return this.hp; }
            set { this.hp = value; }
        }
        public PointCapacity Sp {
            get { return this.sp; }
            set { this.sp = value; }
        }
        public int Atk {
            get { return this.atk; }
            set { this.atk = value; }
        }
        public int Def {
            get { return this.def; }
            set { this.def = value; }
        }
        public Pair MatrixLocation {
            get { return this.matrixLocation; }
            set { this.matrixLocation = value; }
        }
        public Direction Direction {
            get { return this.direction; }
            set { this.direction = value; }
        }
        //public int CRT;//爆擊
        //public int EVD;//迴避
        //public int STR;//力量
        //public int DEX;//熟練、靈巧
        //public int AGI;//敏捷
        //public int INT;//智慧
        //public int VIT;//體質
        //public int LUK;//幸運
        //public int MEN;//精神


        public void HpFill(double percentage) {
            hp.Point += (int)Math.Round(Hp.Max * percentage);
        }
        public void SpFill(double percentage) {
            sp.Point += (int)Math.Round(Sp.Max * percentage);
        }

    }
    public partial class BattleBioValues : I4DirectMovement {
        public void Move(Direction direction) {
            switch (direction) {
                case Direction.Left:
                    MoveLeft(); break;
                case Direction.Up:
                    MoveUp(); break;
                case Direction.Down:
                    MoveDown(); break;
                case Direction.Right:
                    MoveRight(); break;
            }
        }
        public void MoveLeft() {
            MatrixLocation = MatrixLocation.AddX(-1);
            Direction = Direction.Left;
        }
        public void MoveUp() {
            MatrixLocation = MatrixLocation.AddY(-1);
            Direction = Direction.Up;
        }
        public void MoveDown() {
            MatrixLocation = MatrixLocation.AddY(1);
            Direction = Direction.Down;
        }
        public void MoveRight() {
            MatrixLocation = MatrixLocation.AddX(1);
            Direction = Direction.Right;
        }
    }
    public partial class BattleBioValues {

    }

}
