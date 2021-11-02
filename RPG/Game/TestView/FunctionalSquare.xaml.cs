using hoshi_lib.Game._2D.RPG;
using hoshi_lib.Game.RPG;
using hoshi_lib.View;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace hoshi_lib.Game.TestView {
    /// <summary>
    /// SkillPanel.xaml 的互動邏輯
    /// </summary>
    public partial class FunctionalSquare : HControlCollection {
        
        
        private readonly double TwoSqrt = Math.Sqrt(2);
        private const double timerMSec = 15.49;

        public static Action<IGameItem> ButtonRightFunc { get; set; }
        public Size Size {
            get { return base.Size; }
            set {
                base.Size = value;
                var width = Size.Width;
              
            }
        }
        public double Height {
            get { return base.Height; }
            set { Size =new Size(value,value); }
        }
        public double Width {
            get { return base.Width; }
            set { Size = new Size(value, value); }
        }
        public Brush MarkColor {
            get { return P1.Fill; }
            set { P1.Fill = P2.Fill = P3.Fill = P4.Fill = value; }
        }
        public double MarkOpacity {
            get { return P1.Opacity; }
            set { P1.Opacity = P2.Opacity = P3.Opacity = P4.Opacity = value; }
        }
        public double CircleRunTime {
            get { return sec; }
            set { 
                sec = value;
                unit = 2 * Math.PI / (sec * 1000 / timerMSec);
            }
        }
   
        public int? Num {
            get { return num; }
            set {
                num = value;
                HNum.Text = value.ToString();
            }
        }
        public bool Enable {
            get { return enable; }
            set { 
                enable = value;
                if (value) {
                    UnMark();
                } else {
                    Mark();
                }
            }
        }
        public IGameItem Content { get; protected set; }
        public ItemDescripionPanel PopupView { get; set; }
        public bool PopupOpen{
            get { return popupOpen; }
            set {
                if (popupOpen == value) return;
                popupOpen = value;
                if (value)
                    AddPopupEvent();
                else
                    RemovePopupEvent();
            }
        }

        private Popup popup = new Popup();
        private bool enable = true;
        private double half { get { return Size.Width / 2; } }
        private double sec = 0;
        private HTimer timer = new HTimer(timerMSec);
        private bool popupOpen;
        private int? num = null;

        public FunctionalSquare() {
            InitializeComponent();
            InitView();
            InitEvent();
            InitPopup();
        }
        private void InitEvent() {
            timer.Tick += delegate {
                RunCircle();
            };
            this.AddMouseEvent(MouseButtomEvent.RightButtonDown, 
                delegate {
                    Use();
                });
        }
        private void InitView() {
            if (Content is Skill) {
                (Content as Skill).UsedEvent -= skillUsed;
            } else if (Content is Consumable) {
                (Content as Consumable).UsedEvent -= skillUsed;
            }
            if (timer.IsEnabled) timer.Stop();
            if (enable) { UnMark(); } else { Mark(); }
            Content = null;
            Image = null;
            CircleRunTime = -1;
            HNum.Text = "";
        }

        MouseEventHandler open;
        MouseEventHandler close;
        private void InitPopup() {
            PopupView = new ItemDescripionPanel();
            popup.Child = PopupView.Net;
            popup.Placement = PlacementMode.Mouse;
            popup.AllowsTransparency = true;

            open = new MouseEventHandler((s, e) => popup.IsOpen = true && Content != null);
            close = new MouseEventHandler((s,e)=>popup.IsOpen=false);
            PopupOpen = true;
        }
        private void AddPopupEvent() {
            this.AddMouseEvent(MouseEvent.Enter, open);
            this.AddMouseEvent(MouseEvent.Leave, close);
        }
        private void RemovePopupEvent() {
            this.RemoveMouseEvent(MouseEvent.Enter, open);
            this.RemoveMouseEvent(MouseEvent.Leave, close);
        }

        public void Use() {
            if (!timer.IsEnabled && Enable) {
                if (ButtonRightFunc != null) ButtonRightFunc(Content);
                //TODO:
                if (Content is Consumable) Num = (Content as Consumable).Count;
                Run();
            }
        }
        public void Run() {
           
            if (sec <= 0) return;
            Mark();
            r = Width * TwoSqrt / 2;
            loc = Width / 2 - r;
            timer.Start();
        }
        public void UnMark() {
            InitCircle();
            P1.Points[0] = new System.Windows.Point(Width, half);
            P2.Points[0] = new System.Windows.Point(half, Width);
            P3.Points[0] = new System.Windows.Point(0, half);
            P4.Points[0] = new System.Windows.Point(half, 0);
        }
        public void Mark() {
            InitCircle();
            P1.Points[0] = new System.Windows.Point(half, 0);
            P2.Points[0] = new System.Windows.Point(Width, half);
            P3.Points[0] = new System.Windows.Point(half, Width);
            P4.Points[0] = new System.Windows.Point(0, half);
        }
        public void SetContent(IGameItem item) {
            InitView();
            Content = item;
            if (item == null) {
                return;
            }
            Image = item.ItemImage;
            if (item is ICoolDown) {
                CircleRunTime = (item as ICoolDown).CD;
            }
            if (item is ICountable) {
                var cur = item as ICountable;
                if (cur.IsCountable)
                    Num = cur.Count;
            }
            PopupView.SetDescription(item);
        }
        public void SetContent(Skill skill) {
            InitView();
            Content = skill;
            if (skill == null) {
                return;
            }
            skill.UsedEvent += skillUsed;
            Image = skill.ItemImage;
            CircleRunTime = skill.CD;
            PopupView.SetDescription(skill);
        }
        public void SetContent(Consumable item) {
            InitView();
            Content = item;
            if (item == null) {
                return;
            }
            item.UsedEvent += skillUsed;
            CircleRunTime = item.CD;
            Image = item.ItemImage;
            if (item.IsCountable)
                Num = item.Count;
            PopupView.SetDescription(item);
        }

        private void InitCircle() {
            P1.Points[0] = new System.Windows.Point(Width, half);
            P1.Points[1] = new System.Windows.Point(Width, 0);
            P1.Points[2] = new System.Windows.Point(Width, half);
            P1.Points[3] = new System.Windows.Point(half, half);

            P2.Points[0] = new System.Windows.Point(half, Width);
            P2.Points[1] = new System.Windows.Point(Width, Width);
            P2.Points[2] = new System.Windows.Point(half, Width);
            P2.Points[3] = new System.Windows.Point(half, half);

            P3.Points[0] = new System.Windows.Point(0, half);
            P3.Points[1] = new System.Windows.Point(0, Width);
            P3.Points[2] = new System.Windows.Point(0, half);
            P3.Points[3] = new System.Windows.Point(half, half);

            P4.Points[0] = new System.Windows.Point(half, 0);
            P4.Points[1] = new System.Windows.Point(0, 0);
            P4.Points[2] = new System.Windows.Point(half, 0);
            P4.Points[3] = new System.Windows.Point(half, half);
        }
        private void skillUsed(bool isok) {
            if (isok) {
                Use();
            }
        }

        private double angle = 0;
        private double unit = 2 * Math.PI;
        private double r;
        private double loc;
        private void RunCircle() {
            angle -= unit;
        
            if (angle < -Math.PI * 2) {
                P4.Points[0] = new System.Windows.Point(Width / 2, 0);
                angle = 0;
                timer.Stop();
                return;
            }
            var w = r - r * Math.Sin(angle) + loc;
            var h = r - r * Math.Cos(angle) + loc;

            if (angle >= -Math.PI / 2){
                w = w > Width ? Width : w;
                h = h < 0 ? 0 : h;
                P1.Points[0] = new System.Windows.Point(w, h);
            }else if(angle > -Math.PI ) {
                P1.Points[0] = new System.Windows.Point(Width, Width/2);
                w = w > Width ? Width : w;
                h = h > Width ? Width : h;
                P2.Points[0] = new System.Windows.Point(w, h);
            } else if (angle >= -Math.PI / 2 * 3) {
                P2.Points[0] = new System.Windows.Point(Width/2, Width);
                w = w < 0 ? 0 : w;
                h = h > Width ? Width : h;
                P3.Points[0] = new System.Windows.Point(w, h);
            } else {
                P3.Points[0] = new System.Windows.Point(0, Width/2);
                w = w < 0 ? 0 : w;
                h = h < 0 ? 0 : h;
                P4.Points[0] = new System.Windows.Point(w, h);
            }
            Log.Write(w + " , " + h);
        }
       
    }
}
