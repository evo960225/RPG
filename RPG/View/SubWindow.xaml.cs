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
    /// SubWindow.xaml 的互動邏輯
    /// </summary>
    public partial class SubWindow : HControlCollection {
        private IHControlCollection panel;
        private HTimer mouseLoop = new HTimer(15);

        public SubWindow() {
            InitializeComponent();
            Panel.SetZIndex(this, 100);
        }
        public SubWindow(IHControlCollection panel) {
            InitializeComponent();
            this.panel = panel;
            this.AddHControl(panel);
            Panel.SetZIndex(this, 100);
            AutoSize();
            mouseLoop.Tick += MouseLoopTick;
        }
        public SubWindow(HControlCollection panel) {
            InitializeComponent();
            this.panel = panel;
            this.AddHControl(panel);
            Panel.SetZIndex(this, 100);
            AutoSize();
            mouseLoop.Tick += MouseLoopTick;
        }
        public void SetTitle(string text) {
            Title.Text = text;
            
        }
        public void Show() {
            this.Visibility = Visibility.Visible;
        }
        public void Hide() {
            this.Visibility = Visibility.Collapsed;
        }
        private void AutoSize() {
            panel.Location = new Point(0, Title.Size.Height);
            this.Size = new Size(panel.Size.Width, panel.Size.Height + Title.Size.Height);
        }
        private void HbutExit_MouseDown(object sender, MouseButtonEventArgs e) {
            Hide();
        }

        private bool mouseDown = false;
        private bool next = false;

        Point mouseDownPos;
        Point downCtrlPos;
        private void Title_MouseDown(object sender, MouseButtonEventArgs e) {
            downCtrlPos = this.Location;
            if (Parent is UIElement) {
                var pos = e.GetPosition(Parent as UIElement);
                mouseDownPos = new Point(pos.X, pos.Y);
                mouseLoop.Start();
            }
        }

        private Size ogainSize;
        private void HbutHide_MouseDown(object sender, MouseButtonEventArgs e) {
            if (this.Size != Title.Size) {
                ogainSize = this.Size;
                this.Size = Title.Size;
            } else {
                this.Size=ogainSize;
            }
        }
        private void MouseLoopTick(object sen, EventArgs e) {
            if (Mouse.LeftButton == MouseButtonState.Pressed) {
                if (Parent is UIElement) {
                    var pos = Mouse.GetPosition(Parent as UIElement);
                    var curMousePos = new Point(pos.X, pos.Y);
                    var s = curMousePos - mouseDownPos;
                    var ToLoc = downCtrlPos + s;
                    this.Location = ToLoc;
                }
            } else {
                mouseLoop.Stop();
            }
        }
    }
}
