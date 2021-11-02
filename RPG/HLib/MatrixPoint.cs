using System;

namespace hoshi_lib.HLib {
    public class MatrixPoint {

        public int X { get { return pair.X; } set { pair.X = value; } }
        public int Y { get { return pair.Y; } set { pair.Y = value; } }

        protected Pair pair;

        public MatrixPoint(Point point) {
            pair.X = point.X;
            pair.Y = point.Y;
        }
        public MatrixPoint(int x, int y) {
            pair.X = x;
            pair.Y = y;
        }
        public MatrixPoint(MatrixPoint point) {
            this.X = point.X;
            this.Y = point.Y;
        }
        public Point GetBlockPoint(Size size) {
            return new Point(size.Width * X, size.Height * Y);
        }
        public int GetDistance(MatrixPoint point) {
            if (point == null) return -1;
            return Math.Abs(X - point.X) + Math.Abs(Y - point.Y);
        }

        static public bool  operator ==(MatrixPoint point, MatrixPoint point2) {
            return !(point != point2);
        }
        static public bool operator !=(MatrixPoint point, MatrixPoint point2) {
            object p1 = point;
            object p2 = point2;
            return p1 != null && p2 == null || p1 == null && p2 != null || (p1 != null && p2 != null && point.pair != point2.pair);
            
        }
    }

}
