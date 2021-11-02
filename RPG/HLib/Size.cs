
using hoshi_lib.HLib;
namespace hoshi_lib {
    public struct Size {

        public int Width { get { return Pair.X; } set { pair.X = value; } }
        public int Height { get { return Pair.Y; } set { pair.Y = value; } }
        public Pair Pair { get { return pair; } set { pair = value; } }
        private Pair pair;

        public Size(Pair pair) {
            this.pair = pair;
        }
        public Size(int x, int y) {
            pair.X = x;
            pair.Y = y;
        }
        public Size(double x, double y) {
            pair.X = (int)x;
            pair.Y = (int)y;
        }

        public static Size operator +(Size pair, Pair pair2) {
            return new Size(pair.Width + pair2.X, pair.Height + pair2.Y);
        }
        public static Size operator +(Size pair, int value) {
            return new Size(pair.Width + value, pair.Height + value);
        }
        public static Size operator +(Size pair, Size pair2) {
            return new Size(pair.Width + pair2.Width, pair.Height + pair2.Height);
        }
        public static Size operator +(Size pair, Point point) {
            return new Size(pair.Width + point.X, pair.Height + point.Y);
        }
        public static Size operator -(Size pair1, Pair pair2) {
            return new Size(pair1.Width - pair2.X, pair1.Height - pair2.Y);
        }
        public static Size operator -(Size pair, int value) {
            return new Size(pair.Width - value, pair.Height - value);
        }
        public static Size operator -(Size pair, Size pair2) {
            return new Size(pair.Width - pair2.Width, pair.Height - pair2.Height);
        }
        public static Size operator -(Size pair, Point point) {
            return new Size(pair.Width - point.X, pair.Height - point.Y);
        }
        public static Size operator *(Size pair, int value) {
            return new Size(pair.Width * value, pair.Height * value);
        }
        public static Size operator *(Size pair, Pair value) {
            return new Size(pair.Width * value.X, pair.Height * value.Y);
        }
        public static Size operator /(Size pair, int value) {
            return new Size(pair.Width / value, pair.Height / value);
        }
        public static Size operator /(Size pair, Pair value) {
            return new Size(pair.Width / value.X, pair.Height / value.Y);
        }
        public static bool operator ==(Size pair, Size value) {
            return pair.Width == value.Width && pair.Height == value.Height;
        }
        public static bool operator !=(Size pair, Size value) {
            return pair.Width != value.Width || pair.Height != value.Height;
        }
        public static implicit operator Point(Size size) {
            return new Point(size.pair);
        }
        public Point ToPoint() {
            return new Point(this.Width, this.Height);
        }

        public Point GetCenter() {
            return new Point(Width / 2, Height / 2);
        }
        public Point GetCenter(Size size) {
            return new Point((this.Width - size.Width) / 2, (this.Height - size.Height) / 2);
        }
        public Point GetHCenter() {
            return new Point(Width / 2, 0);
        }
        public Point GetHCenter(Size size) {
            return new Point((this.Width - size.Width) / 2, 0);
        }
        public Point GetVCenter() {
            return new Point(0, Height / 2);
        }
        public Point GetVCenter(Size size) {
            return new Point(0, (this.Height - size.Height) / 2);
        }

    }
}
