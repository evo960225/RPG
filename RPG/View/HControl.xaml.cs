using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace hoshi_lib.View {

    public partial class HControl : UserControl, IHControl {

        private BitmapImage image;

        public Brush BackColor {
            get { return base.Background; }
            set { base.Background = value; }
        }
        public FontFamily Font {
            get { return base.FontFamily; }
            set { base.FontFamily = value; }
        }
        public Brush FontColor {
            get { return base.Foreground; }
            set { base.Foreground = value; }
        }
        public Size Size {
            get { return new Size((int)base.Width, (int)base.Height); }
            set { base.Width = value.Width; this.Height = value.Height; }
        }
        public Point Location {
            get { return new Point((int)base.Margin.Left, (int)base.Margin.Top); }
            set { base.Margin = value.GetThickness(); }
        }
        public string Text {
            get {
                if (this.Content != null)
                    return base.Content.ToString();
                else
                    return "";
            }
            set { base.Content = value; }
        }
        public BitmapImage Image {
            get { return image; }
            set {
                image = value;
                base.Background = new ImageBrush(value);
            }
        }
        public Dispatcher Dispatcher { get { return base.Dispatcher; } }
        public UserControl This { get { return this; } }
        public double Opacity {
            get { return base.Opacity; }
            set { base.Opacity = value; }
        }
        public FrameworkElement Net {
            get { return this; }
        }

        public HControl() {
            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.VerticalAlignment = VerticalAlignment.Top;
            Background = Brushes.White;
          
            Size = new Size(100, 100);
            Location = new Point(0, 0);
            postInit();
        }

        private void postInit() {
            SetAbsoluteLoaction();
        }
        private void SetAbsoluteLoaction() {
            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.VerticalAlignment = VerticalAlignment.Top;
            this.HorizontalContentAlignment = HorizontalAlignment.Center;
            this.VerticalContentAlignment = VerticalAlignment.Center;
        }

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