using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Input;

namespace hoshi_lib.View {
    public class StackControl : StackPanel, IHoshiView<StackPanel> {

        public StackPanel This {
            get { return this; }
        }
        public FrameworkElement Net {
            get { return this; }
        }
        public Size Size {
            get {
                return new Size(Width, Width);
            }
            set {
                Width = value.Width;
                Height = value.Height;
            }
        }
        public Point Location {
            get {
                return new Point(Margin.Left, Margin.Top);
            }
            set {
                Margin = new Thickness(value.X, value.Y, 0, 0);
            }
        }
        public Brush BackColor {
            get { return base.Background; }
            set { base.Background = value; }
        }
        public BitmapImage Image {
            get { return image; }
            set {
                image = value;
                base.Background = new ImageBrush(value);
            }
        }
        private BitmapImage image;


        public void AddRoutedEvent(RoutedEvent routeEvent, MouseButtonEventHandler mbEventHanler) {
            this.AddHandler(routeEvent, mbEventHanler);
        }
        public void RemoveRoutedEvent(RoutedEvent routeEvent, MouseButtonEventHandler mbEventHanler) {
            this.RemoveHandler(routeEvent, mbEventHanler);
        }
        public void AddMouseEvent(MouseEvent mEvent, MouseEventHandler addEventHandler) {
            switch (mEvent) {
                case MouseEvent.Enter:
                    this.MouseEnter += addEventHandler; break;
                case MouseEvent.Leave:
                    this.MouseLeave += addEventHandler; break;
                case MouseEvent.Move:
                    this.MouseMove += addEventHandler; break;
            }
        }
        public void AddMouseEvent(MouseButtomEvent mbEvent, MouseButtonEventHandler addEventHandler) {
            switch (mbEvent) {
                case MouseButtomEvent.Down:
                    this.MouseDown += addEventHandler; break;
                case MouseButtomEvent.Up:
                    this.MouseUp += addEventHandler; break;
                case MouseButtomEvent.LeftButtonDown:
                    this.MouseLeftButtonDown += addEventHandler; break;
                case MouseButtomEvent.LeftButtonUp:
                    this.MouseLeftButtonUp += addEventHandler; break;
                case MouseButtomEvent.RightButtonDown:
                    this.MouseRightButtonDown += addEventHandler; break;
                case MouseButtomEvent.RightButtonUp:
                    this.MouseRightButtonUp += addEventHandler; break;
            }
        }
        public void RemoveMouseEvent(MouseEvent mEvent, MouseEventHandler removeEventHandler) {
            try {
                switch (mEvent) {
                    case MouseEvent.Enter:
                        this.MouseEnter -= removeEventHandler;
                        break;
                    case MouseEvent.Leave:
                        this.MouseLeave -= removeEventHandler;
                        break;
                    case MouseEvent.Move:
                        this.MouseMove -= removeEventHandler;
                        break;
                }
            } catch { }
        }
        public void RemoveMouseEvent(MouseButtomEvent mbEvent, MouseButtonEventHandler removeEventHandler) {
            try {
                switch (mbEvent) {
                    case MouseButtomEvent.Down:
                        this.MouseDown -= removeEventHandler;
                        break;
                    case MouseButtomEvent.LeftButtonDown:
                        this.MouseLeftButtonDown -= removeEventHandler;
                        break;
                    case MouseButtomEvent.LeftButtonUp:
                        this.MouseLeftButtonUp -= removeEventHandler;
                        break;
                    case MouseButtomEvent.RightButtonDown:
                        this.MouseRightButtonDown -= removeEventHandler;
                        break;
                    case MouseButtomEvent.RightButtonUp:
                        this.MouseRightButtonUp -= removeEventHandler;
                        break;
                }
            } catch { }
        }
    }
}
