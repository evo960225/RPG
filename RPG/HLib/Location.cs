using System;
using System.Windows;

namespace hoshi_lib {

    public struct Location {

        public double X;
        public double Y;

        public Location(double x, double y) {
            this.X = x;
            this.Y = y;
        }

        public static Location operator +(Location location1, Location location2) {
            return new Location(location1.X + location2.X, location1.Y + location2.Y);
        }
        public static Location operator +(Location location, Size size) {
            return new Location(location.X + size.Width, location.Y + size.Height);
        }
        public static Location operator +(Location location, int value) {
            return new Location(location.X + value, location.Y + value);
        }
        public static Location operator -(Location location1, Location location2) {
            return new Location(location1.X - location2.X, location1.Y - location2.Y);
        }
        public static Location operator -(Location location, Size size) {
            return new Location(location.X - size.Width, location.Y - size.Height);
        }
        public static Location operator -(Location location, int value) {
            return new Location(location.X - value, location.Y - value);
        }
        public static Location operator *(Location location, int value) {
            return new Location(location.X * value, location.Y * value);
        }
        public static Location operator *(Location location, double value) {
            return new Location(location.X * value, location.Y * value);
        }
        public static Location operator *(Location location1, Location location2) {
            return new Location(location1.X * location2.X, location1.Y * location2.Y);
        }
        public static Location operator /(Location location, int value) {
            return new Location(location.X / value, location.Y / value);
        }
        public static Location operator /(Location location, double value) {
            return new Location(location.X / value, location.Y / value);
        }
        public static Location operator /(Location location1, Location location2) {
            return new Location(location1.X / location2.X, location1.Y / location2.Y);
        }
        public static Location operator -(Location location) {
            return new Location(-location.X, -location.Y);
        }
        public static bool operator ==(Location location1, Location location2) {
            if (location1.X == location2.X && location1.Y == location2.Y)
                return true;
            else
                return false;
        }
        public static bool operator !=(Location location1, Location location2) {
            if (location1.X == location2.X && location1.Y == location2.Y)
                return false;
            else
                return true;
        }



        public Location AddX(double x) {
            return new Location(this.X += x, this.Y);
        }
        public Location AddY(double y) {
            return new Location(this.X, this.Y += y);
        }
        public Location SetX(double x) {
            return new Location(x, this.Y);
        }
        public Location SetY(double y) {
            return new Location(this.X, y);
        }

        public Thickness GetThickness() {
            return new Thickness(this.X, this.Y, 0, 0);
        }
        public Location ToFloor() {
            return new Location(Math.Floor(this.X), Math.Floor(this.Y));
        }
        public Location ToRound() {
            return new Location(Math.Round(this.X), Math.Round(this.Y));
        }

    }
}
