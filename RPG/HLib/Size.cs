
namespace hoshi_lib {
    public struct Size {

        public double Height;
        public double Width;

        public Size(double width, double height) {
            this.Height = height;
            this.Width = width;
        }

        public static Size operator +(Size size1, Size size2) {
            return new Size(size1.Width + size2.Width, size1.Height + size2.Height);
        }
        public static Size operator +(Size size, Location location) {
            return new Size(location.X + size.Width, location.Y + size.Height);
        }
        public static Size operator +(Size size, int value) {
            return new Size(size.Width + value, size.Height + value);
        }
        public static Size operator -(Size size, Location location) {
            return new Size(size.Width - location.X, size.Height - location.Y);
        }
        public static Size operator -(Size size1,Size size2) {
            return new Size(size1.Width - size2.Width, size1.Height - size2.Height);
        }
        public static Size operator -(Size size, int value) {
            return new Size(size.Width - value, size.Height - value);
        }
        public static Size operator *(Size size, int value) {
            return new Size(size.Width * value, size.Height * value);
        }
        public static Size operator *(Size size, Pair value) {
            return new Size(size.Width * value.X, size.Height * value.Y);
        } 
        public static Size operator /(Size size, int value) {
            return new Size(size.Width / value, size.Height / value);
        }
        public static Size operator /(Size size, Pair value) {
            return new Size(size.Width / value.X, size.Height / value.Y);
        }

        public Location ToLocation() {
            return new Location(this.Width, this.Height);
        }

        public Location GetCenter() {
            return new Location(Width / 2, Height / 2);
        }
        public Location GetCenter(Size size) {
            return new Location((this.Width - size.Width) / 2.0, (this.Height - size.Height) / 2.0);
        }
        public Location GetHorizontalCenter() {
            return new Location(Width / 2, 0);
        }
        public Location GetHorizontalCenter(Size size) {
            return new Location((this.Width - size.Width) / 2.0, 0);
        }
        public Location GetVerticalCenter() {
            return new Location(0, Height / 2);
        }
        public Location GetVerticalCenter(Size size) {
            return new Location(0, (this.Height - size.Height) / 2.0);
        }
    }
}
