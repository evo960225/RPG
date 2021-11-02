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
    /// StorePanel.xaml 的互動邏輯
    /// </summary>
    public partial class StorePanel : HControlCollection {

        public int Cost {
            get { return int.Parse(HCost.Text); }
            set { HCost.Text = value.ToString(); }
        }

        private IMatrixControl<FunctionalSquare> matrixControl;
        private MatrixSize matrixSize = new MatrixSize(10, 5);
        private StoreManager manager;

        public StorePanel(StoreManager manager, IMoney money, StuffManager stuffmanager) {
            InitializeComponent();
            this.manager = manager;
            MakeMatrixControl();
            InitButtonEvent(money, stuffmanager);
            LoadManager();
            LinkManager();
        }
        private void MakeMatrixControl() {
            matrixSize.SpanX = 2;
            matrixSize.SpanY = 2;
            matrixSize.BlockSize = new hoshi_lib.Size(32, 32);

            matrixControl = new MatrixControl<FunctionalSquare>(matrixSize);
            matrixControl.SetColor(Brushes.LightCyan);

            int i = 0;
            foreach (var it in matrixControl.Controls) {
                var index = i;
                it.Enable = false;
                it.MarkColor = Brushes.Linen;
                it.MarkOpacity = 0;
                it.AddMouseEvent(MouseButtomEvent.LeftButtonDown, delegate {
                    
                    var stuff=it.Content as IStuff;
                    if (stuff == null) return;
                    if (it.MarkOpacity == 0) {
                        manager.Select(stuff);
                        it.MarkOpacity = 0.5;
                    } else {
                        manager.Unselect(stuff);
                        it.MarkOpacity = 0;
                    }
                });
                ++i;
            }

            AddHControl(matrixControl);
            matrixControl.Location = new Point(20, 20);
            this.Size = matrixSize.Point + new Point(40, 60);
        }
        private void InitButtonEvent( IMoney money, StuffManager stuffmanager) {
            HBuy.AddClickEvent((s, e) => manager.Buy(money, stuffmanager));
        }
        private void LoadManager() {
            int index = 0;
            foreach(var it in manager.Stuffs){
                if (index < matrixControl.Controls.Length) {
                    var control = matrixControl.GetItem(index);
                    control.SetContent(it);
                    ++index;
                } else {
                    break;
                }
            }
        }
        private void LinkManager() {
            manager.BuyedEvent += BuyedUpdate;
            manager.SelectedEvent += PriceUpdate;
            manager.UnselectedEvent += PriceUpdate;
        }
        private void BuyedUpdate(List<IStuff> stuffs) {
            foreach (var it in matrixControl.Controls) {
                if (it.MarkOpacity == 0.5) {
                    it.SetContent(null as IStuff);
                }
            }
            PriceUpdate();
        }
        private void PriceUpdate() {
            Cost = manager.Price;
        }
        private void PriceUpdate(IStuff stuff) {
            PriceUpdate();
        }
    }
}
