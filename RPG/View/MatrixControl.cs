using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace hoshi_lib.View {
    public class MatrixControl:HControlCollection {
        public HControl[,] Controls { get; private set; }
        public Pair MatrixSize { get; private set; }
        public Size ControlsSize { get; private set; }

        public MatrixControl(Pair matrixSize, Size controlsSize, int heightSpace, int widthSpace) {

            this.ControlsSize = controlsSize;
            this.MatrixSize = matrixSize;
            this.Size = ControlsSize * matrixSize + new Size(matrixSize.X * widthSpace, matrixSize.Y * widthSpace);
            Controls = new HControl[matrixSize.Y, matrixSize.X];
            CreateMatrix(heightSpace, widthSpace);
        }
        private void CreateMatrix(int heightSpace, int widthSpace) {
            int hspace = 0, wspace = 0;
            for (int i = 0; i < MatrixSize.Y; ++i) {
                wspace = 0;
                for (int j = 0; j < MatrixSize.X; ++j) {
                    Controls[i, j] = new HControl();
                    Controls[i, j].Size = ControlsSize;
                    Controls[i, j].Location = new Location(j * ControlsSize.Width + wspace, i * ControlsSize.Height + hspace);
                    this.AddHControl(Controls[i, j]);
                    wspace += widthSpace;
                }
                hspace += heightSpace;
            }
        }
        
        public void SetImage(BitmapImage bmp){
            foreach (var it in this.Controls) {
                it.Image = bmp;
            }
        }
        public void SetColor(Brush brush) {
            foreach (var it in this.Controls) {
                it.BackColor = brush;
            }
        }
    }
}
