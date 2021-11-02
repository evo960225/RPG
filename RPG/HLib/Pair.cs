using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoshi_lib.HLib {
    public struct Pair {

        public int X;
        public int Y;

        public Pair(int x, int y) {
            X = x;
            Y = y;
        }
        public void Add(Pair pair) {
            this.X += pair.X;
            this.Y += pair.Y;
        }
        public void Sub(Pair pair) {
            this.X -= pair.X;
            this.Y -= pair.Y;
        }
        public Point AddX(int x) {
            return new Point(this.X += x, this.Y);
        }
        public Point AddY(int y) {
            return new Point(this.X, this.Y += y);
        }
        public Point SetX(int x) {
            return new Point(x, this.Y);
        }
        public Point SetY(int y) {
            return new Point(this.X, y);
        }

        public static Pair operator +(Pair pair, Pair pair2) {
            return new Pair(pair.X + pair2.X, pair.Y + pair2.Y);
        }
        public static Pair operator +(Pair pair, int value) {
            return new Pair(pair.X + value, pair.Y + value);
        }
        public static Pair operator -(Pair pair1, Pair pair2) {
            return new Pair(pair1.X - pair2.X, pair1.Y - pair2.Y);
        }
        public static Pair operator -(Pair pair, int value) {
            return new Pair(pair.X - value, pair.Y - value);
        }
        public static Pair operator *(Pair pair, int value) {
            return new Pair(pair.X * value, pair.Y * value);
        }
        public static Pair operator *(Pair pair, Pair value) {
            return new Pair(pair.X * value.X, pair.Y * value.Y);
        }
        public static Pair operator /(Pair pair, int value) {
            return new Pair(pair.X / value, pair.Y / value);
        }
        public static Pair operator /(Pair pair, Pair value) {
            return new Pair(pair.X / value.X, pair.Y / value.Y);
        }
        public static bool operator ==(Pair pair, Pair value) {
            return pair.X == value.X && pair.Y == value.Y;
        }
        public static bool operator !=(Pair pair, Pair value) {
            return pair.X != value.X || pair.Y != value.Y;
        }
        public override string ToString() {
            return this.GetType().ToString() + ":(" + X + "," + Y + ")";
        }
    }
}
