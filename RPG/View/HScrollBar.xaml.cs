using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace hoshi_lib.View {
    /// <summary>
    /// HScrollBar.xaml 的互動邏輯
    /// </summary>
    public partial class HScrollBar : HControlCollection {
        public int Max {
            get { return max; }
            set { 
                max = value;
                SetLocation();
                SetSize();
            }
        }
        public int Value {
            get { return _value; }
            set {
                _value = value;
                SetLocation();
            }
        }
        public int ShowLarge {
            get { return large; }
            set {
                large = value < 1 ? 1 : value;
                SetLocation();
                SetSize();
            }
        }
        public Size Size {
            get { return base.Size; }
            set { 
                base.Size = value;
                Line.Location = new Point(Width / 2, 0);
            }
        }

        private int max;
        private int _value;
        private int large = 1;


        private HTimer mouseLoop;

        public HScrollBar() {
            InitializeComponent();
     
            mouseLoop = new HTimer(15);
            mouseLoop.Tick += MouseLoopTick;
        }

        Point mouseDownPos;
        Point downButtonPos;
        private void HButton_MouseDown(object sender, MouseButtonEventArgs e) {
            
            downButtonPos = Button.Location;
            var pos = e.GetPosition(this);
            mouseDownPos = new Point(pos.X, pos.Y);
            mouseLoop.Start();
        }
        private void SetLocation() {
            if (max > large)
                Button.Location = new Point(Button.Location.X, large / max * Height * _value > max - large ? max - large : _value);
            else
                Button.Location = new Point(Button.Location.X, 0);
        }
        private void SetSize() {
            if (max > large)
                Button.Size = new Size(Button.Size.Width, large * 1.0 / max * Height);
            else
                Button.Size = new Size(Button.Size.Width, Height);
        }
        private void MouseLoopTick(object sen,EventArgs e) {
            if (Mouse.LeftButton == MouseButtonState.Pressed) {
                var pos = Mouse.GetPosition(this);
                var curMousePos = new Point(pos.X, pos.Y);
                var s = curMousePos - mouseDownPos;
                var ToLocY = downButtonPos.Y + s.Y;
                if (ToLocY + Button.Height > this.Height) {
                    Button.Location = new Point(downButtonPos.X, this.Height - Button.Height);
                } else if (ToLocY < 0) {
                    Button.Location = new Point(downButtonPos.X, 0);
                } else {
                    Button.Location = new Point(downButtonPos.X, ToLocY);
                }
                _value = (int)(Button.Location.Y / (Height - Button.Height)*(max-large));
                lockView.Location = new Point(0, -unitHeight * _value);
            } else {
                mouseLoop.Stop();
            }
        }

        private IView lockView;
        private int unitHeight;
        public void Lock(IView view, int unitHeight) {
            lockView = view;
            this.unitHeight = unitHeight;
        }
    }
}
