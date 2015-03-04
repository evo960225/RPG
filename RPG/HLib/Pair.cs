using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoshi_lib {

    public struct Pair {

        public int X;
        public int Y;

        public Pair(int x, int y) {
            this.X = x;
            this.Y = y;
        }

        public static Pair operator +(Pair location1, Pair location2) {
            return new Pair(location1.X + location2.X, location1.Y + location2.Y);
        }
        public static Pair operator +(Pair location, int value) {
            return new Pair(location.X + value, location.Y + value);
        }
        public static Pair operator -(Pair location1, Pair location2) {
            return new Pair(location1.X - location2.X, location1.Y - location2.Y);
        }
        public static Pair operator -(Pair location, int value) {
            return new Pair(location.X - value, location.Y - value);
        }
        public static Pair operator *(Pair location, int value) {
            return new Pair(location.X * value, location.Y * value);
        }
        public static Pair operator /(Pair location, int value) {
            return new Pair(location.X / value, location.Y / value);
        }
        public static bool operator ==(Pair location1, Pair location2) {
            if (location1.X == location2.X && location1.Y == location2.Y)
                return true;
            else
                return false;
        }
        public static bool operator !=(Pair location1, Pair location2) {
            if (location1.X == location2.X && location1.Y == location2.Y)
                return false;
            else
                return true;
        }

        public Pair AddX(int x) {
            return new Pair(this.X + x, this.Y);
        }
        public Pair AddY(int y) {
            return new Pair(this.X, this.Y + y);
        }
        public Pair SetX(int x) {
            return new Pair(x, this.Y);
        }
        public Pair SetY(int y) {
            return new Pair(this.X, y);
        }

    }
}

