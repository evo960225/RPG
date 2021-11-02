
namespace hoshi_lib.HLib {

    public class MatrixSize : MatrixPoint {

        public int SpanX { get; set; }
        public int SpanY { get; set; }
        public Point Point {
            get { return new Point(BlockSize.Width * X + SpanX * (X + 1), BlockSize.Height * Y + SpanY * (Y + 1)); }
        }
        public Size BlockSize { get; set; }

        public MatrixSize(Point point)
            : base(point) {
        }
        public MatrixSize(int x, int y)
            : base(x, y) {
        }
        public MatrixSize(MatrixSize size)
            : base(size) {
            this.BlockSize = size.BlockSize;
        }
        public Point GetBlockPoint(int x, int y) {
            return new Point(BlockSize.Width * x + SpanX * (x + 1), BlockSize.Height * y + SpanY * (y + 1));
        }
        public Point GetBlockPoint(MatrixPoint matrixPoint) {
            return GetBlockPoint(matrixPoint.X, matrixPoint.Y);
        }

        static public bool operator ==(MatrixSize point, MatrixSize point2) {
            return point.pair == point2.pair;
        }
        static public bool operator !=(MatrixSize point, MatrixSize point2) {
            return point.pair != point2.pair;
        }
    }
}