using hoshi_lib.Data;
using hoshi_lib.View;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace hoshi_lib.Game.TestView {
    /// <summary>
    /// LoadData.xaml 的互動邏輯
    /// </summary>
    public partial class CreateRoleSimple : UserControl {

        HControl HName = new HControl();
        
        
        public CreateRoleSimple() {
            InitializeComponent();
           
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e) {
            BioDataController rdController = new BioDataController();
            //rdController.CreateRole(this.TxtName.Text, new BattleBioValues(new BattleValues(this.NumAtk.GetValue(), this.NumDef.GetValue()), new Point(this.NumHP.GetValue(), this.NumSP.GetValue())));
        }

        private void butCreate_MouseEnter(object sender, MouseEventArgs e) {
            butCreate.Background = Brushes.Pink;
        }

        private void butCreate_MouseLeave(object sender, MouseEventArgs e) {
            butCreate.Background = new SolidColorBrush(Color.FromRgb(0xBF, 0x38, 0x38));
        }
    }
}
