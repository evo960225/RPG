using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using hoshi_lib.Input;

namespace hoshi_lib.View {

    public class HButton : HControl {

        private Brush _LeaveBrush;
        private Brush _EnterBrush;
        private Brush _ClickBrush;
        public Brush LeaveBrush {
            get { return _LeaveBrush; }
            set {
                _LeaveBrush = value;
                this.RemoveMouseEvent(MouseEevent.MouseLeave, DefaultLeaveEvent);
                this.AddMouseEvent(MouseEevent.MouseLeave, DefaultLeaveEvent);
                this.BackColor = _LeaveBrush;
            }
        }
        public Brush EnterBrush {
            get { return _EnterBrush; }
            set {
                _EnterBrush = value;
                this.RemoveMouseEvent(MouseEevent.MouseEnter, DefaultEnterEvent);
                this.AddMouseEvent(MouseEevent.MouseEnter, DefaultEnterEvent);
                this.RemoveMouseEvent(MouseButtomEevent.MouseUp, DefaultEnterEvent);
                this.AddMouseEvent(MouseButtomEevent.MouseUp, DefaultEnterEvent);
            }
        }
        public Brush ClickBrush {
            get { return _ClickBrush; }
            set {
                _ClickBrush = value;
                this.RemoveMouseEvent(MouseButtomEevent.MouseDown, DefaultClickEvent);
                this.AddMouseEvent(MouseButtomEevent.MouseDown, DefaultClickEvent);
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
            this.AddMouseEvent(MouseEevent.MouseLeave, eh);
        }
        public void AddEnterEvent(MouseEventHandler eh) {
            this.AddMouseEvent(MouseEevent.MouseEnter, eh);
            this.AddMouseEvent(MouseButtomEevent.MouseUp, new MouseButtonEventHandler(eh));
        }
        public void AddClickEvent(MouseButtonEventHandler eh) {
            this.AddMouseEvent(MouseButtomEevent.MouseDown, eh);
        }

        public void InitStateEvent() {
            this.AddMouseEvent(MouseButtomEevent.MouseDown, DefaultLeaveEvent);
            this.AddMouseEvent(MouseButtomEevent.MouseDown, DefaultEnterEvent);
            this.AddMouseEvent(MouseButtomEevent.MouseDown, DefaultClickEvent);
        }
        public void InitBrush(Brush brush = null) {

            if (brush == null) {
                brush = this.BackColor;
            } else {
                this.BackColor = brush;
            }
            LeaveBrush = brush;
            EnterBrush = brush;
            ClickBrush = brush;
        }

        private void DefaultLeaveEvent(object sender, RoutedEventArgs args) {
            this.BackColor = LeaveBrush;
        }
        private void DefaultEnterEvent(object sender, RoutedEventArgs args) {
            this.BackColor = EnterBrush;
        }
        private void DefaultClickEvent(object sender, RoutedEventArgs args) {
            this.BackColor = ClickBrush;
        }
    }
}



