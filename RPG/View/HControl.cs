using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace hoshi_lib.View {

    public class HControl : IH<UserControl> {

        protected UserControl control;
        private BitmapImage image;

        public Brush BackColor {
            get { return control.Background; }
            set { control.Background = value; }
        }
        public FontFamily Font {
            get { return control.FontFamily; }
            set { control.FontFamily = value; }
        }
        public double FontSize {
            get { return control.FontSize; }
            set { control.FontSize = value; }
        }
        public Brush FontColor {
            get { return control.Foreground; }
            set { control.Foreground = value; }
        }
        public string Name {
            get { return control.Name; }
            set { control.Name = value; }
        }
        public object Tag {
            get { return control.Tag; }
            set { control.Tag = value; }
        }
        public Size Size {
            get { return new Size(control.Width, control.Height); }
            set { control.Width = value.Width; control.Height = value.Height; }
        }
        public Location Location {
            get { return new Location(control.Margin.Left, control.Margin.Top); }
            set { control.Margin = value.GetThickness(); }
        }
        public string Text {
            get { return control.Content.ToString(); }
            set { control.Content = value; }
        }
        public BitmapImage Image {
            get { return image; }
            set {
                image = value;
                control.Background = new ImageBrush(value);
            }
        }
        public Dispatcher Dispatcher { get { return control.Dispatcher; } }


        public HControl() {
            control = new UserControl() { Background = Brushes.White };
            Size = new Size(100, 100);
            Location = new Location(0, 0);
            postInit();
        }
        public HControl(UserControl control) {
            this.control = control;
            postInit();
        }
        private void postInit() {
            SetAbsoluteLoaction();
        }

        protected void SetAbsoluteLoaction() {
            control.HorizontalAlignment = HorizontalAlignment.Left;
            control.VerticalAlignment = VerticalAlignment.Top;
            control.HorizontalContentAlignment = HorizontalAlignment.Center;
            control.VerticalContentAlignment = VerticalAlignment.Center;
        }

        public void AddMouseEvent(RoutedEvent routeEvent, MouseButtonEventHandler mbEventHanler) {
            control.AddHandler(routeEvent, mbEventHanler);
        }
        public void AddMouseEvent(MouseEevent mEvent, MouseEventHandler addEventHandler) {
            switch (mEvent) {
                case MouseEevent.MouseEnter:
                    control.MouseEnter += addEventHandler; break;
                case MouseEevent.MouseLeave:
                    control.MouseLeave += addEventHandler; break;
                case MouseEevent.MouseMove:
                    control.MouseMove += addEventHandler; break;
            }
        }
        public void AddMouseEvent(MouseButtomEevent mbEvent, MouseButtonEventHandler addEventHandler) {
            switch (mbEvent) {
                case MouseButtomEevent.MouseDown:
                    control.MouseDown += addEventHandler; break;
                case MouseButtomEevent.MouseUp:
                    control.MouseUp += addEventHandler; break;
                case MouseButtomEevent.MouseLeftButtonDown:
                    control.MouseLeftButtonDown += addEventHandler; break;
                case MouseButtomEevent.MouseLeftButtonUp:
                    control.MouseLeftButtonUp += addEventHandler; break;
                case MouseButtomEevent.MouseRightButtonDown:
                    control.MouseRightButtonDown += addEventHandler; break;
                case MouseButtomEevent.MouseRightButtonUp:
                    control.MouseRightButtonUp += addEventHandler; break;
            }
        }
        public void RemoveMouseEvent(MouseEevent mEvent, MouseEventHandler removeEventHandler) {
            try {
                switch (mEvent) {
                    case MouseEevent.MouseEnter:
                        control.MouseEnter -= removeEventHandler;
                        break;
                    case MouseEevent.MouseLeave:
                        control.MouseLeave -= removeEventHandler;
                        break;
                    case MouseEevent.MouseMove:
                        control.MouseMove -= removeEventHandler;
                        break;
                }
            } catch { }
        }
        public void RemoveMouseEvent(MouseButtomEevent mbEvent, MouseButtonEventHandler removeEventHandler) {
            try {
                switch (mbEvent) {
                    case MouseButtomEevent.MouseDown:
                        control.MouseDown -= removeEventHandler;
                        break;
                    case MouseButtomEevent.MouseLeftButtonDown:
                        control.MouseLeftButtonDown -= removeEventHandler;
                        break;
                    case MouseButtomEevent.MouseLeftButtonUp:
                        control.MouseLeftButtonUp -= removeEventHandler;
                        break;
                    case MouseButtomEevent.MouseRightButtonDown:
                        control.MouseRightButtonDown -= removeEventHandler;
                        break;
                    case MouseButtomEevent.MouseRightButtonUp:
                        control.MouseRightButtonUp -= removeEventHandler;
                        break;
                }
            } catch { }
        }

        public UserControl ToNET() {
            return control;
        }
    }

}
