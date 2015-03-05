using hoshi_lib.View;
using hoshi_lib;
namespace hoshi_lib.Game._2D.RPG {
    public class BioView : HControl, I4DirectMovement {

        private int imageIndex = 0;
        private Location titleMoveValue {
            get { return (this.Size / LittleMoveTimes).ToLocation(); }
        }
        private Location toLocation;
        private ImageManager imageManager;
        private int moveImageCount;
        public Location MoveValue {
            get { return this.Size.ToLocation(); }
        }
        public int InTimes { get; protected set; }
        public int LittleMoveTimes {
            get { return (int)(MoveSpendMilsec / 1000.0 * FPS); }
        }

        public Direction LookAt { get;  set; }
        public int MoveSpendMilsec { get; set; }
        public int FPS { get; private set; }
        

        public BioView(string imageDirectory, Size size, int singleMoveFrameCount)
            : base() {
            PostInit();
            this.Size = size;
            this.moveImageCount = singleMoveFrameCount;
            LoadImage(imageDirectory);
            PreInit();
        }
        private void PostInit() {
            FPS = 35;
            if (MoveSpendMilsec == 0) {
                MoveSpendMilsec = 200;
            }
            imageManager = new ImageManager();
        }
        private void PreInit() {
            SetDefaultImageInView();
            var oneFrameTime = MoveSpendMilsec / LittleMoveTimes;
        }
        private void LoadImage(string imageDirectory) {
            for (int i = 0; i < moveImageCount; ++i) {
                imageManager.AddImage(Direction.Left.ToString() + i, imageDirectory + "L" + i);
                imageManager.AddImage(Direction.Up.ToString() + i, imageDirectory + "U" + i);
                imageManager.AddImage(Direction.Down.ToString() + i, imageDirectory + "D" + i);
                imageManager.AddImage(Direction.Right.ToString() + i, imageDirectory + "R" + i);
            }
        }
        private void SetDefaultImageInView() {
            this.Image = imageManager.Images[Direction.Right.ToString() + imageIndex];
        }
 

        public void NextImage() {
            ++imageIndex;
            if (imageIndex >= moveImageCount) imageIndex = 0;
            this.Image = imageManager.Images[LookAt.ToString() + imageIndex];
        }

        public void MoveLeft() {
                LookAt = Direction.Left;
                this.Location += new Location(-this.Size.Width, 0);
        }
        public void MoveUp() {
                LookAt = Direction.Up;
                this.Location += new Location(0, -this.Size.Height);
        }
        public void MoveDown() {
            LookAt = Direction.Down;
            this.Location += new Location(0, this.Size.Height);
        }
        public void MoveRight() {
            LookAt = Direction.Right;
            this.Location += new Location(this.Size.Width, 0);
        }
        public void MoveLeft(int val) {
            LookAt = Direction.Left;
            this.Location += new Location(-val, 0);

        }
        public void MoveUp(int val) {
            LookAt = Direction.Up;
            this.Location += new Location(0, -val);
        }
        public void MoveDown(int val) {
            LookAt = Direction.Down;
            this.Location += new Location(0, val);
        }
        public void MoveRight(int val) {
            LookAt = Direction.Right;
            this.Location += new Location(val, 0);
        }
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

        Location val = new Location();
        public Direction MoveingDirection { get; private set; }
        public void LittleMove(Direction direction) {
                   
            if (InTimes == 0) {
                LookAt = direction;
                switch (LookAt) {
                    case Direction.Left:
                        val = MoveLeftValue(); break;
                    case Direction.Up:
                        val = MoveUpValue(); break;
                    case Direction.Down:
                        val = MoveDownValue(); break;
                    case Direction.Right:
                        val = MoveRightValue(); break;
                }
                toLocation = this.Location + val;
            }
            if (LookAt == direction)
                this.Location += LittleMoveValue(LookAt);
            if (++InTimes == LittleMoveTimes) {
                this.Location = toLocation;
                InTimes = 0;
            }
        }

        public Location MoveLeftValue() {
            return new Location(-MoveValue.X, 0);
        }
        public Location MoveUpValue() {
            return new Location(0, -MoveValue.Y);
        }
        public Location MoveDownValue() {
            return new Location(0, MoveValue.Y);
        }
        public Location MoveRightValue() {
            return new Location(MoveValue.X, 0);
        }
        public Location LittleMoveValue(Direction direction) {
            switch (direction) {
                case Direction.Left:
                    return LittleMoveLeftValue();
                case Direction.Up:
                    return LittleMoveUpValue();
                case Direction.Down:
                    return LittleMoveDownValue();
                case Direction.Right:
                    return LittleMoveRightValue();
                default:
                    return new Location();
            }
        }
        public Location LittleMoveLeftValue() {
            return new Location(-MoveValue.X, 0) / LittleMoveTimes;
        }
        public Location LittleMoveUpValue() {
            return new Location(0, -MoveValue.Y) / LittleMoveTimes;
        }
        public Location LittleMoveDownValue() {
            return new Location(0, MoveValue.Y) / LittleMoveTimes;
        }
        public Location LittleMoveRightValue() {
            return new Location(MoveValue.X, 0) / LittleMoveTimes;
        }
    }
}
