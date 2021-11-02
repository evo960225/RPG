using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
//using hoshi_lib.Input;

namespace hoshi_lib.View {

    public class HButton : HControl, IHButton {
        

        private Brush _LeaveBrush;
        private Brush _EnterBrush;
        private Brush _ClickBrush;
        public Brush LeaveBrush {
            get { return _LeaveBrush; }
            set {
                _LeaveBrush = value;
                this.RemoveMouseEvent(MouseEvent.Leave, DefaultLeaveEvent);
                this.AddMouseEvent(MouseEvent.Leave, DefaultLeaveEvent);
                this.BackColor = _LeaveBrush;
            }
        }
        public Brush EnterBrush {
            get { return _EnterBrush; }
            set {
                _EnterBrush = value;
                this.RemoveMouseEvent(MouseEvent.Enter, DefaultEnterEvent);
                this.AddMouseEvent(MouseEvent.Enter, DefaultEnterEvent);
                this.RemoveMouseEvent(MouseButtomEvent.Up, DefaultEnterEvent);
                this.AddMouseEvent(MouseButtomEvent.Up, DefaultEnterEvent);
            }
        }
        public Brush ClickBrush {
            get { return _ClickBrush; }
            set {
                _ClickBrush = value;
                this.RemoveMouseEvent(MouseButtomEvent.Down, DefaultClickEvent);
                this.AddMouseEvent(MouseButtomEvent.Down, DefaultClickEvent);
            }
        }
        public Brush BackColor {
            get { return base.BackColor; }
            set {
                base.BackColor = value;
                _LeaveBrush = _EnterBrush = _ClickBrush = value;
            }
        }
        public ImageSource LeaveImage;
        public ImageSource EnterImage;
        public ImageSource ClickImage;

        public HButton() {
            InitBrush();
            InitStateEvent();
        }

        public void AddLeaveEvent(MouseEventHandler eh) {
            this.AddMouseEvent(MouseEvent.Leave, eh);
        }
        public void AddEnterEvent(MouseEventHandler eh) {
            this.AddMouseEvent(MouseEvent.Enter, eh);
            this.AddMouseEvent(MouseButtomEvent.Up, new MouseButtonEventHandler(eh));
        }
        public void AddClickEvent(MouseButtonEventHandler eh) {
            this.AddMouseEvent(MouseButtomEvent.Down, eh);
        }

        public void InitStateEvent() {
            this.AddMouseEvent(MouseButtomEvent.Down, DefaultLeaveEvent);
            this.AddMouseEvent(MouseButtomEvent.Down, DefaultEnterEvent);
            this.AddMouseEvent(MouseButtomEvent.Down, DefaultClickEvent);
        }
        public void InitBrush(Brush brush = null) {

            if (brush == null) {
                brush = Brushes.LightGray;
            } else {
                this.BackColor = brush;
            }
            LeaveBrush = brush;
            EnterBrush = brush;
            ClickBrush = brush;
        }

        private void DefaultLeaveEvent(object sender, RoutedEventArgs args) {
            this.Background = LeaveBrush;
        }
        private void DefaultEnterEvent(object sender, RoutedEventArgs args) {
            this.Background = EnterBrush;
        }
        private void DefaultClickEvent(object sender, RoutedEventArgs args) {
            this.Background = ClickBrush;
        }
    }
}



