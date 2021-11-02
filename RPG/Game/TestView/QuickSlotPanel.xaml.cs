using hoshi_lib.Game._2D.RPG;
using hoshi_lib.Game.RPG;
using hoshi_lib.Input;
using hoshi_lib.View;
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

namespace hoshi_lib.Game.TestView {
    /// <summary>
    /// QuickSlotPanel.xaml 的互動邏輯
    /// </summary>
    public partial class QuickSlotPanel : HControlCollection {
        
        private MousePicked mousePicked = new MousePicked();
        private FunctionalSquare[] funSquare;

        public QuickSlotPanel(KeyDelegate keyDelegate) {
            InitializeComponent();
            LoadFunctionalSquare();
            InitKeyEvent(keyDelegate);
            Panel.SetZIndex(this, 100);
          
            InitEvent();
        }
        private void LoadFunctionalSquare() {
            funSquare = new FunctionalSquare[10];
            funSquare[0] = I1;
            funSquare[1] = I2;
            funSquare[2] = I3;
            funSquare[3] = I4;
            funSquare[4] = I5;
            funSquare[5] = I6;
            funSquare[6] = I7;
            funSquare[7] = I8;
            funSquare[8] = I9;
            funSquare[9] = I10;
        }
        private void InitKeyEvent(KeyDelegate keyDelegate) {
            keyDelegate.AddEvent(Key.D1, () => funSquare[0].Use());
            keyDelegate.AddEvent(Key.D2, () => funSquare[1].Use());
            keyDelegate.AddEvent(Key.D3, () => funSquare[2].Use());
            keyDelegate.AddEvent(Key.D4, () => funSquare[3].Use());
            keyDelegate.AddEvent(Key.D5, () => funSquare[4].Use());
            keyDelegate.AddEvent(Key.D6, () => funSquare[5].Use());
            keyDelegate.AddEvent(Key.D7, () => funSquare[6].Use());
            keyDelegate.AddEvent(Key.D8, () => funSquare[7].Use());
            keyDelegate.AddEvent(Key.D9, () => funSquare[8].Use());
            keyDelegate.AddEvent(Key.D0, () => funSquare[9].Use());
        }
        private void InitEvent() {
            int i=0;
            foreach (var it in funSquare) {
                int index = i;
                it.AddMouseEvent(MouseButtomEvent.LeftButtonUp, delegate {
                    if (mousePicked.IsOpen) {
                        if (mousePicked.Picked is Skill) {
                            it.SetContent(mousePicked.Picked as Skill);
                        } else if (mousePicked.Picked is Consumable) {
                            it.SetContent(mousePicked.Picked as Consumable);
                        } else if (mousePicked.Picked is IGameItem) {
                            it.SetContent(mousePicked.Picked as IGameItem);
                        }
                        mousePicked.Close();
                    } else {
                        mousePicked.CopyFrom(it);
                        mousePicked.Picked = it.Content;
                        it.SetContent(null as IGameItem);
                        mousePicked.Open();
                        mousePicked.ThrowingEvent = () => mousePicked.Close();
                    }
                });
                ++i;
            }
        }


        private bool mouseDown = false;
        private bool next = false;
        private System.Windows.Point point;
        private void Panel_MouseDown(object sender, MouseButtonEventArgs e) {
            mouseDown = true;
        }
        private void Panel_MouseMove(object sender, MouseEventArgs e) {
            if (mouseDown) {
                if (!next) { point = e.GetPosition(this); next = true; } else {
                    var loc = e.GetPosition(this);
                    var ans = loc - point;
                    this.Location += new Point((int)ans.X / 2, (int)ans.Y / 2);
                }
            }

        }
        private void Panel_MouseUp(object sender, MouseButtonEventArgs e) {
            mouseDown = false;
            next = false;
        }
        private void Panel_MouseLeave(object sender, MouseEventArgs e) {
            if (mouseDown) {
                if (!next) { point = e.GetPosition(this); next = true; } else {
                    var loc = e.GetPosition(this);
                    var ans = loc - point;
                    this.Location += new Point((int)ans.X / 2, (int)ans.Y / 2);
                }
            }
        }

    }
}
