using hoshi_lib.Game._2D.RPG;
using hoshi_lib.Game.RPG;
using hoshi_lib.View;

namespace hoshi_lib.Game.TestView {
    /// <summary>
    /// ItemDescripionPanel.xaml 的互動邏輯
    /// </summary>
    public partial class ItemDescripionPanel : HControlCollection {
        public ItemDescripionPanel() {
            InitializeComponent();
        }
        public void SetDescription(IGameItem item) {
            HName.Text = item.Name;
            HDescription.Text = item.Description;
            HValue.Text = item.ToString();
        }
    }
}
