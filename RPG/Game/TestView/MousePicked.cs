using hoshi_lib.Game.RPG;
using hoshi_lib.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace hoshi_lib.Game.TestView {
    public partial class MousePicked {
        private const int Hide = -1;
        private const int Show = 999;
        

        public object Picked {
            get { return picked; }
            set { 
                picked = value;
                _checked = true;
            }
        }
        public bool IsOpen {
            get { return showIndex == Show; }
        }
        public IHoshiView PickCtrl {
            get { return ctrl; }
            set {
                WindowController.Screen.RemoveHControl(ctrl);
                ctrl = value;
                WindowController.Screen.AddHControl(ctrl);
            }
        }
        public Action ThrowingEvent {
            get { return throwingEvent; }
            set {
                throwingEvent = value;
            }
        }

        private static object picked;
        private static IHoshiView ctrl = new HControl();
        private static int showIndex = -1;
        private static bool _checked = false;
        private static Action throwingEvent;

        static MousePicked() {
            InitLockMouseEvent();
            InitMouseDownEvent();
            Panel.SetZIndex(ctrl.Net, Hide);
            WindowController.Screen.AddHControl(ctrl);   
        }
        static private void InitLockMouseEvent() {
            var lockMouse = new MouseEventHandler(delegate(object s, MouseEventArgs e) {
                var pos = e.GetPosition(WindowController.Screen.This);
                ctrl.Location = new Point((int)(pos.X - ctrl.Size.Width / 2), (int)(pos.Y - ctrl.Size.Height / 2));
            });
            WindowController.Screen.AddMouseEvent(MouseEvent.Move, lockMouse);
            ctrl.AddMouseEvent(MouseButtomEvent.LeftButtonDown, delegate {
                Panel.SetZIndex(ctrl.Net, Hide);
            });
        }
        static private void InitMouseDownEvent() {
            WindowController.Screen.AddMouseEvent(MouseButtomEvent.LeftButtonUp, delegate(object s, MouseButtonEventArgs e) {
                if (picked!=null && showIndex == Show && _checked==false) {
                    if (throwingEvent != null) throwingEvent();
                } else
                    Panel.SetZIndex(ctrl.Net, showIndex);
                _checked = false;
            });
        }

        public void CopyFrom(IHoshiView ctrl) {
            MousePicked.ctrl.Size = ctrl.Size;
            //MousePicked.ctrl.Text = ctrl.Text;
            MousePicked.ctrl.BackColor = ctrl.BackColor;
            MousePicked.ctrl.Image = ctrl.Image;
            MousePicked.ctrl.Size = ctrl.Size;
            MousePicked.ctrl.Location = WindowController.PointToScreen(ctrl);
        }
        public void CopyTo(IHoshiView ctrl) {
            ctrl.Size = MousePicked.ctrl.Size;
            //MousePicked.ctrl.Text = ctrl.Text;
            ctrl.BackColor = MousePicked.ctrl.BackColor;
            ctrl.Image = MousePicked.ctrl.Image;
            ctrl.Size = MousePicked.ctrl.Size;
            //ctrl.Location = WindowController.PointToScreen(MousePicked.ctrl);
        }
        public void Open() {
            showIndex = Show;
            Panel.SetZIndex(ctrl.Net, showIndex);
            _checked = true;
        }
        public void Close() {
            showIndex = Hide;
            Panel.SetZIndex(ctrl.Net, showIndex);
        }

    }

}
