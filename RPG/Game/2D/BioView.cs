using hoshi_lib.Game.RPG;
using hoshi_lib.Game.TestView;
using hoshi_lib.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;
namespace hoshi_lib.Game._2D {
    public partial class BioView : Bio,IView {

        private EventHandler moveAction;
        private EventHandler imageAction;
        public Size Size {
            get { return View.Size; }
            set { View.Size = value; }
        }
        public Point Location {
            get { return View.Location; }
            set { View.Location = value; }
        }
        public int MoveTimeSpan { get; set; }

        private List<BitmapImage> MoveLeftImage;
        private List<BitmapImage> MoveUpImage;
        private List<BitmapImage> MoveDownImage;
        private List<BitmapImage> MoveRightImage;

        public BioCapacity View { get; protected set; }

        public BioView(Size Size, string name, BattleValue values)
            : base(name, values) {
                View = new BioCapacity(this);
            IsMoveing = false;
            this.Size = Size;
            
            MoveTimeSpan = 200;
            LoadImage();
        }
        private void LoadImage() {
            SetDirectionImage(out MoveLeftImage, fileLeftName);
            SetDirectionImage(out MoveUpImage, fileUpName);
            SetDirectionImage(out MoveDownImage, fileDownName);
            SetDirectionImage(out MoveRightImage, fileRightName);
            if (MoveDownImage.Count > 0) {
                View.Image = MoveDownImage[0];
                View.Size = new Size(MoveDownImage[0].Width, MoveDownImage[0].Height);
            }
            
        }
       

        public void SetMoveImage(Direction direction, List<BitmapImage> images) {
            switch (direction) {
                case Direction.Left:
                    MoveLeftImage = images;
                    break;
                case Direction.Up:
                    MoveUpImage = images;
                    break;
                case Direction.Down:
                    MoveDownImage = images;
                    View.Image = MoveDownImage[0];
                    break;
                case Direction.Right:
                    MoveRightImage = images;
                    break;
            }
            
        }
        public void SetMoveImage(Direction direction, IEnumerable<String> relativePaths) {
            List<BitmapImage> images = new List<BitmapImage>();
            foreach (var path in relativePaths) {
                images.Add(new BitmapImage(new Uri(path, UriKind.Relative)));
            }
            SetMoveImage(direction, images);
        }
        public void SetMoveImage(Direction direction, params string[] relativePaths) {
            List<BitmapImage> images = new List<BitmapImage>();
            foreach (var path in relativePaths) {
                images.Add(new BitmapImage(new Uri(path, UriKind.Relative)));
            }
            SetMoveImage(direction, images);
        }

        public void PutInControl(IHControlCollection ctrl) {
            ctrl.AddHControl(View);
        }
        public new void MoveCommand(Direction direction) {
            if (World == null) return;
            base.MoveCommand(direction);
            if (!IsMoveing)
            switch (direction) {
                case Direction.Left:
                    View.Image = MoveLeftImage[0];
                    break;
                case Direction.Up:
                    View.Image = MoveUpImage[0];
                    break;
                case Direction.Down:
                    View.Image = MoveDownImage[0];
                    break;
                case Direction.Right:
                    View.Image = MoveRightImage[0];
                    break;
            }
        }
        public new void Moved(Direction direction) {
            base.Moved(direction);
            var size = World.MapView.MatrixSize.BlockSize;
            switch (direction) {
                case Direction.Left:
                    StartPlusMove(new Point(-size.Width, 0), MoveTimeSpan / 1000.0);
                    StartChangeImage(MoveLeftImage, MoveTimeSpan / 1000.0);
                    break;
                case Direction.Up:
                    StartPlusMove(new Point(0, -size.Height), MoveTimeSpan / 1000.0);
                    StartChangeImage(MoveUpImage, MoveTimeSpan / 1000.0);
                    break;
                case Direction.Down:
                    StartPlusMove(new Point(0, size.Height), MoveTimeSpan / 1000.0);
                    StartChangeImage(MoveDownImage, MoveTimeSpan / 1000.0);
                    break;
                case Direction.Right:
                    StartPlusMove(new Point(size.Width, 0), MoveTimeSpan / 1000.0);
                    StartChangeImage(MoveRightImage, MoveTimeSpan / 1000.0);
                    break;
            }
        }
        public new void AttackCommand() {
            base.AttackCommand();
        }
        public new void Attacked(int value) {
            base.Attacked(value);
            View.Update();
        }
        public new void Gived(IStuff stuff) {
            base.Gived(stuff);
        }
        private void StartPlusMove(Point plus, double sec) {
            double dx = plus.X / (sec * MainTimer.FPS);
            double dy = plus.Y / (sec * MainTimer.FPS);
            double curx = this.Location.X;
            double cury = this.Location.Y;
            int count = (int)(sec * MainTimer.FPS);
            Point end = this.Location + plus;
                
                moveAction += delegate {
                    if (count == 0) {
                        this.Location = end;
                        MainTimer.Tick -= moveAction;
                        moveAction = null;
                        IsMoveing = false;
                        return;
                    }
                    curx += dx; cury += dy;
                    this.Location = new Point((int)curx, (int)cury);
                    --count;
                };
                MainTimer.Tick += moveAction;
            
        }
        private void StartChangeImage(IEnumerable<BitmapImage> images, double sec) {
            if (images == null) return;
            int imageCount = images.Count();
            int switchCount = imageCount - 1;
            int timerCount = (int)(sec * MainTimer.FPS);
            int imageIndex = 1;
            double subplus = switchCount * 1.0 / timerCount;
            double start = 0;
            View.Image = images.ElementAt(0);
            imageAction += delegate {
                if (timerCount <= 0) {
                    View.Image = images.ElementAt(imageCount - 1);
                    MainTimer.Tick -= imageAction;
                    imageAction = null;
                    return;
                }
                if ((int)start >= imageIndex && imageIndex != imageCount - 1) {
                    View.Image = images.ElementAt(imageIndex);
                    ++imageIndex;
                }
                start += subplus;
                --timerCount;
            };
            MainTimer.Tick += imageAction;
        }
    }

    public partial class BioView {
        /// <summary>
        /// Image格式化路徑字串，{0}為ID、{1}為Name、{2}為Direction、{3}為編號
        /// </summary>
        static public string RelatDirectoryFormat {
            get { return relatDirectoryFormat; }
            set { relatDirectoryFormat = value; }
        }
        static private string relatDirectoryFormat = "";
        /// <summary>
        /// 左移動圖檔代號
        /// </summary>
        static public string FileLeftName {
            get { return fileLeftName; }
            set { fileLeftName = value; }
        }
        static private string fileLeftName = "L";
        /// <summary>
        /// 上移動圖檔代號
        /// </summary>
        static public string FileUpName {
            get { return fileUpName; }
            set { fileUpName = value; }
        }
        static private string fileUpName = "U";
        /// <summary>
        /// 下移動圖檔代號
        /// </summary>
        static public string FileDownName {
            get { return fileDownName; }
            set { fileDownName = value; }
        }
        static private string fileDownName = "D";
        /// <summary>
        /// 右移動圖檔代號
        /// </summary>
        static public string FileRightName {
            get { return fileRightName; }
            set { fileRightName = value; }
        }
        static private string fileRightName = "R";
        static public int SingleDirectionCount { get; set; }
        private void SetDirectionImage(out List<BitmapImage> images, string directionName) {
            string filename;
            int i = 0;
            images = new List<BitmapImage>();
            filename = string.Format(RelatDirectoryFormat, ID, Name, directionName, i);
            while (i < SingleDirectionCount && System.IO.File.Exists(filename)) {
                images.Add(new BitmapImage(new Uri(filename, UriKind.Relative)));
                ++i;
                filename = string.Format(RelatDirectoryFormat, ID, Name, directionName, i);

            
            }
            if (i > 0) {
                filename = string.Format(RelatDirectoryFormat, ID, Name, directionName, 0);
                images.Add(new BitmapImage(new Uri(filename, UriKind.Relative)));
            }
        }
    }
}
