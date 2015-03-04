using hoshi_lib.View;
using System.Windows.Media;
namespace hoshi_lib.Game.Texture2D {

    public class MapView : HControlCollection {
        
        private MapBlockView[,] block;
        private MapTextureManager mapTexture;

        public Pair MatrixSize { get; private set; }
        public Size BlockSize { get; private set; }

        /// <summary>
        /// 無需MapData相關資訊當參數，以Map做封裝處理
        /// </summary>
        public MapView(MapTextureManager mapTexture, Size BlockSize) {
            this.BlockSize = BlockSize;
            this.mapTexture = mapTexture;
            this.block = new MapBlockView[MatrixSize.Y, MatrixSize.X];
        }
        /// <summary>
        /// 若不依靠Map類別，可用此建構
        /// </summary>
        public MapView(Pair MatrixSize, Size BlockSize, MapTextureManager mapTexture, int[,] mapID) {
            this.BlockSize = BlockSize;
            this.mapTexture = mapTexture;
            this.MatrixSize = MatrixSize;
            this.block = new MapBlockView[MatrixSize.Y, MatrixSize.X];
            this.Size = new Size(MatrixSize.X * BlockSize.Width, MatrixSize.Y * BlockSize.Height); 
            this.CreateView(mapID);
        }

        public void CreateView(Pair MatrixSize, int[,] mapID) {
            this.MatrixSize = MatrixSize;
            this.block = new MapBlockView[MatrixSize.Y, MatrixSize.X];
            this.Size = new Size(MatrixSize.X * BlockSize.Width, MatrixSize.Y * BlockSize.Height);
            this.CreateView(mapID);
        }
        private void CreateView(int[,] mapBlockID) {

            for (int i = 0; i < mapBlockID.GetLength(0); ++i) {
                for (int j = 0; j < mapBlockID.GetLength(1); ++j) {
                    Location loc = new Location(j * BlockSize.Width, i * BlockSize.Height);
                    block[i, j] = new MapBlockView(loc, BlockSize);
                    block[i, j].Image = mapTexture.GetImage(mapBlockID[i, j].ToString());
                    this.AddHControl(block[i, j]);
                }
            }
        }

        public void ShowDamageView(string msg, Pair MatrixLocation) {
            DynamicControl dyctrl = new DynamicControl();
            dyctrl.BackColor = null;
            dyctrl.Size = new hoshi_lib.Size(BlockSize.Width, BlockSize.Height);
            dyctrl.FontColor = Brushes.Red;
            dyctrl.FontSize = 16;
            dyctrl.Text = msg;
            this.AddHControl(dyctrl);
            dyctrl.Location = new Location(MatrixLocation.X * BlockSize.Width, MatrixLocation.Y * BlockSize.Height - BlockSize.Height / 2);
            dyctrl.BackgroundLoop(()=>dyctrl.Location -= new Location(0, 1), 15, 100, true);
        }

        public void MoveToLeft(int value) {
            this.Location = this.Location.AddX(-value);
        }
        public void MoveToLeftBlockWidth() {
            this.Location = this.Location.AddX(-BlockSize.Width);
        }
        public void MoveToUp(int value) {
            this.Location = this.Location.AddY(-value);
        }
        public void MoveToUpBlockHeight() {
            this.Location = this.Location.AddY(-BlockSize.Height);
        }
        public void MoveToDown(int value) {
            this.Location = this.Location.AddY(value);
        }
        public void MoveToDownBlockHeight() {
            this.Location = this.Location.AddY(BlockSize.Height);
        }
        public void MoveToRight(int value) {
            this.Location = this.Location.AddX(value);
        }
        public void MoveToRightBlockWidth() {
            this.Location = this.Location.AddX(BlockSize.Width);
        }

        public Location LeftBlockLocation() {
            return this.Location.AddX(-BlockSize.Width); 
        }
        public Location UpBlockLocation() {
            return this.Location.AddY(-BlockSize.Height);
        }
        public Location DownBlockLocation() {
            return this.Location.AddY(BlockSize.Height);
        }
        public Location RightBlockLocation() {
            return this.Location.AddX(BlockSize.Width);
        }
    }
}
