using System.Windows.Controls;
using hoshi_lib.View;
using hoshi_lib.Game.RPG;
using hoshi_lib.Game._2D;
namespace hoshi_lib.Game.TestView {
    /// <summary>
    /// PointCapacityControl.xaml 的互動邏輯
    /// </summary>
    public partial class PointCapacityPanel : UserControl {

        public string Name {
            get { return name; }
            set {
                name = value;
                CRoleName.Text = value;
            }
        }
        public int LV {
            get { return lv; }
            set {
                lv = value;
                CLv.Text = "LV " + value.ToString();
            }
        }
        public BattleValue Values {
            get { return values; }
            set {
                values = value;
                BarHp.Value = value.HP.Point;
                BarHp.Maximum = value.HP.Max.Value;
                BarSp.Value = value.SP.Point;
                BarSp.Maximum = value.SP.Max.Value;
            }
        }
        private string name;
        private int lv;
        private BattleValue values;
        private Bio bio;

        public PointCapacityPanel(Bio bio) {
            InitializeComponent();
            Panel.SetZIndex(this, 100);
            this.bio = bio;
            Update();
        }
        public void Update() {
            this.Name = bio.Name;
            this.Values = bio.BattleValue;
            this.LV = bio.Lv;
        }
    }


}
