using System.Windows;
using System.Windows.Media;

namespace hoshi_lib.View {
    public class WindowController {
        private Window win;

        private Screen screen;
        public Brush BgBrush {
            get { return win.Background; }
            set { win.Background = value; }
        }
        public Size Size {
            get { return new Size(win.Width, win.Height); }
            set { win.Width = value.Width; win.Height = value.Height; }
        }
        public SizeToContent AutoSize { 
            get { return win.SizeToContent; }
            set { win.SizeToContent = value; }
        }
        
        public WindowController(Window win) {
            this.win = win;
        }

        public void SetTitle(string name) {
            win.Title = name;
        }
        public void SetScreen(Screen screen) {
            this.screen = screen;
            this.Size = screen.Size;
            win.Content = screen.ToNET();
        }
        public void UpdataLayout() {
            win.UpdateLayout();
        }
        public Size GetSize() {
            return new Size(win.Width, win.Height);
        }
        public Window GetWindow() {
            return this.win;
        }
    }
}
