using System.Windows.Controls;
using hoshi_lib.View;
namespace hoshi_lib.Game.TestView {
    /// <summary>
    /// PointCapacityControl.xaml 的互動邏輯
    /// </summary>
    public partial class PointCapacityControl : UserControl {

        public int MaxHP {
            set { HpBar.Maximum = value; }
        }
        public int MaxSP {
            set { SpBar.Maximum = value; }
        }
        public int HP {
            set { HpBar.Value = value; }
        }
        public int SP {
            set { SpBar.Value = value; }
        }
        public int Lv {
            set { LvTxt.Text = "Lv" + value.ToString(); }
        }
        public string Name {
            set { NameTxt.Text = value; }
        }

        public PointCapacityControl() {
            InitializeComponent();
        }
        
    }


}
