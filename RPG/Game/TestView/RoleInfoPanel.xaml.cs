using hoshi_lib.Game._2D;
using hoshi_lib.Game.RPG;
using hoshi_lib.View;
using System.Windows.Controls;

namespace hoshi_lib.Game.TestView {
    /// <summary>
    /// RoleInfoPanel.xaml 的互動邏輯
    /// </summary>
    public partial class RoleInfoPanel : HControlCollection {

        public string Name {
            get { return name; }
            set { 
                name = value;
                HRoleName.Text = value;
            }
        }
        public int  Lv {
            get { return lv; }
            set { 
                lv = value;
                HLv.Text = value.ToString();
            }
        }
        public BattleValue Values{
            get { return values; }
            set { 
                values = value;
                HHp.Text = value.HP.ToString();
                HSp.Text = value.SP.ToString();
                HAtk.Text = value.ATK.ToString();
                HDef.Text = value.DEF.ToString();
            }
        }

        private string name;
        private int lv;
        private BattleValue values;
        private Bio bio;

        public RoleInfoPanel(Bio bio) {
            InitializeComponent();
            Panel.SetZIndex(this, 100);
            this.bio = bio;
            Update();
        }
        public void Update() {
            this.Name = bio.Name;
            this.Values = bio.BattleValue;
            this.Lv = bio.Lv;
        }
    }
}
