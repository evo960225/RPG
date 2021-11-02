using hoshi_lib.HLib;
using System;
using System.Windows;


namespace hoshi_lib {

    public struct Point {

        public int X { get { return pair.X; } set { pair.X = value; } }
        public int Y { get { return pair.Y; } set { pair.Y = value; } }
        private Pair pair;

        public Point(Pair pair) {
            this.pair = pair;
        }
        public Point(int x, int y) {
            pair.X = x;
            pair.Y = y;
        }
        public Point(double x, double y) {
            pair.X = (int)x;
            pair.Y = (int)y;
        }
        public static Point operator +(Point point ,Size size) {
            return new Point(point.X + size.Width, point.Y + size.Height);
        }
        public static Point operator +(Point point ,int value) {
            return new Point(point.X + value, point.Y + value);
        }
        public static Point operator +(Point point, Point point2) {
            return new Point(point.X + point2.X, point.Y + point2.Y);
        }
        public static Point operator -(Point point, Size size) {
            return new Point(point.X - size.Width, point.Y - size.Height);
        }
        public static Point operator -(Point point ,int value) {
            return new Point(point.X - value, point.Y - value);
        }
        public static Point operator -(Point point, Point point2) {
            return new Point(point.X - point2.X, point.Y - point2.Y);
        }
        public static Point operator *(Point point, int value) {
            return new Point(point.X * value, point.Y * value);
        }
        public static Point operator *(Point point, double value) {
            return new Point(point.X * (int)value, point.Y * (int)value);
        }
        public static Point operator *(Point point, Size size) {
            return new Point(point.X * size.Width, point.Y * size.Height);
        }
        public static Point operator /(Point point ,int value) {
            return new Point(point.X / value, point.Y / value);
        }
        public static Point operator /(Point point ,double value) {
            return new Point(point.X / (int)value, point.Y / (int)value);
        }
        public static Point operator /(Point point, Size size) {
            return new Point(point.X / size.Width, point.Y / size.Height);
        }
        public static Point operator -(Point point) {
            return new Point(-point.X, -point.Y);
        }
        public static bool operator >(Point point, Point point2) {
            if (point.X > point2.X && point.Y > point2.Y)
                return true;
            else
                return false;
        }
        public static bool operator >(Point point, Size size) {
            if (point.X > size.Width && point.Y > size.Height)
                return true;
            else
                return false;
        }
        public static bool operator <(Point point, Point point2) {
            if (point.X < point2.X && point.Y < point2.Y)
                return true;
            else
                return false;
        }
        public static bool operator <(Point point, Size size) {
            if (point.X < size.Width && point.Y < size.Height)
                return true;
            else
                return false;
        }
        public static bool operator >=(Point point, Point point2) {
            if (point.X >= point2.X && point.Y >= point2.Y)
                return true;
            else
                return false;
        }
        public static bool operator <=(Point point, Point point2) {
            if (point.X <= point2.X && point.Y <= point2.Y)
                return true;
            else
                return false;
        }
        public static implicit operator MatrixPoint(Point point) {
            return new MatrixPoint(point);
        }
        public static implicit operator Size(Point point) {
            return new Size(point.pair);
        }

        public void Add(Point point) {
            this.X += point.X;
            this.Y += point.Y;
        }
        public void Sub(Point point) {
            this.X -= point.X;
            this.Y -= point.Y;
        }
        public Point AddX(int x) {
            return new Point(this.X += x, this.Y);
        }
        public Point AddY(int y) {
            return new Point(this.X, this.Y += y);
        }
        public void SetX(int x) {
            this.X = x;
        }
        public void SetY(int y) {
            this.Y = y;
        }
        public Size ToSize() {
            return new Size(pair);
        }
        public Thickness GetThickness() {
            return new Thickness(this.X, this.Y, 0, 0);
        }
        public override string ToString() {
            return "Point(" + X + "," + Y + ")";
        }
    }


}
