using System.Windows;
using System.Windows.Media;

namespace hoshi_lib.View {
    public static class WindowController {
        static public Window Window {
            get { return window; }
            set { 
                window = value;
                AutoSize = SizeToContent.WidthAndHeight;
            }
        }
        static public IScreen Screen {
            get { return screen; }
            set {
                screen = value;
                Window.Content = screen.This;
            }
        }
        static public Brush BackColor {
            get { return Window.Background; }
            set { Window.Background = value; }
        }
        static public Size Size {
            get { return new Size((int)Window.Width, (int)Window.Height); }
            set { Window.Width = value.Width; Window.Height = value.Height; }
        }
        static public Point Location {
            get {
                return new Point((int)Window.Left, (int)Window.Top);
            }
            set {
                Window.Left = value.X;
                Window.Top = value.Y;
            }
        }
        static public SizeToContent AutoSize {
            get { return Window.SizeToContent; }
            set { Window.SizeToContent = value; }
        }

        static private IScreen screen;
        static private Window window;

        static public void Close() {
            Window.Close();
        }
        static public void SetTitle(string name) {
            Window.Title = name;
        }
        static public void UpdataLayout() {
            Window.UpdateLayout();
        }

        static public Point PointToScreen(IHoshiView ctrl) {
            var a = ctrl.Net.PointToScreen(new System.Windows.Point(0, 0));
            var b = window.PointToScreen(new System.Windows.Point(Screen.Location.X, Screen.Location.Y));
            var c = a - b;
            return new Point((int)c.X, (int)c.Y);
        }
        static public Point PointToScreen(IHControl ctrl) {
            var a = ctrl.This.PointToScreen(new System.Windows.Point(0, 0));
            var b = window.PointToScreen(new System.Windows.Point(Screen.Location.X, Screen.Location.Y));
            var c=a-b;
            return new Point((int)c.X, (int)c.Y);
        }
        static public Point PointToScreen(IHControlCollection ctrl) {
            var a = ctrl.This.PointToScreen(new System.Windows.Point(0, 0));
            var b = window.PointToScreen(new System.Windows.Point(Screen.Location.X, Screen.Location.Y));
            var c = a-b;
            return new Point((int)c.X, (int)c.Y);
        }
    }

}
