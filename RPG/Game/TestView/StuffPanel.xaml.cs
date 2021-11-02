using hoshi_lib.Game.RPG;
using hoshi_lib.HLib;
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
    /// StuffPanel.xaml 的互動邏輯
    /// </summary>
    public partial class StuffPanel : HControlCollection {
        public MatrixSize MatrixSize {
            get { return matrixSize; }
            set {
                matrixSize = value;
                MakeMatrixControl();
            }
        }

        private IMatrixControl<FunctionalSquare> matrixControl;
        private MatrixSize matrixSize;
        private StuffManager manager;
        private MousePicked picked = new MousePicked();
        
        public StuffPanel(StuffManager manager,MatrixSize size) {
            this.manager = manager;
            InitMouseDownEvent();
           
            manager.AddEvent += UpdateView;
            manager.RemovedEvent += UpdateView;
            MatrixSize = size;
        }
        public void UpdateView(int index,IStuff stuff) {
            var cur = matrixControl.GetItem(index);
            cur.SetContent(manager[index]);
        }
        private void InitMouseDownEvent() {
            this.AddMouseEvent(MouseButtomEvent.LeftButtonUp, delegate {
                if (picked.IsOpen) {
                    picked.Close();
                    picked.Open();
                }
            });
        }
        private void MakeMatrixControl() {
            matrixControl = new MatrixControl<FunctionalSquare>(matrixSize);
            matrixControl.Location = new Point(20, 20);
            this.AddHControl(matrixControl);
            this.Size = MatrixSize.Point + new Point(40, 40);
            matrixControl.SetColor(Brushes.LightSlateGray);
            int i = 0;
            foreach (var it in matrixControl.Controls) {
                SetStuffMoveEvent(it, i++);
            }
        }
        private void LoadStuffManager() {
            int matIndex = 0;
            foreach (var it in manager.Stuffs) {
                if (it != null) {
                    var cur = matrixControl.GetItem(matIndex);
                    cur.Image = it.ItemImage;
                    cur.Num = it.Count;
                }
                ++matIndex;
            }
            for (; matIndex < matrixControl.Controls.Length; ++matIndex) {
                matrixControl.GetItem(matIndex).Image = null;
            }
        }
        private void SetStuffMoveEvent(FunctionalSquare ctrl, int number) {
            //pick
            ctrl.AddMouseEvent(MouseButtomEvent.LeftButtonDown, delegate {
                if (manager.Stuffs.Count() <= number || number < 0) return;
                var acc = manager.Stuffs.ElementAt(number);
                picked.CopyFrom(ctrl);
                picked.Picked = acc;
                picked.Open();
                manager.Remove(number,acc);
                ctrl.SetContent(null as IStuff);
            });
            //put or change
            ctrl.AddMouseEvent(MouseButtomEvent.LeftButtonUp, delegate(object sen, MouseButtonEventArgs e) {
                var pickStuff = picked.Picked;
                if (pickStuff == null || !(pickStuff is IStuff)) return;
                IStuff tmp = manager.Change(number, pickStuff as IStuff);
                picked.Picked = tmp;
                if (tmp == null) {
                    picked.Close();
                } else {
                    picked.Close();
                    picked.CopyFrom(ctrl);
                    picked.Open();
                }
            });
        }
        
    }
}
