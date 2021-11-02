using hoshi_lib.Game._2D.RPG;
using hoshi_lib.View;
using System;
using System.Windows.Controls;

namespace hoshi_lib.Game.TestView {
    /// <summary>
    /// SkillPanel.xaml 的互動邏輯
    /// </summary>
    public partial class SkillPanel : HControlCollection {

        private SkillManager manager;
        private MousePicked picked = new MousePicked();

        public SkillPanel(SkillManager manager) {
            InitializeComponent();
            this.manager = manager;
            Scroll.Lock(SkillItems, 50);

            LoadManager();
        }

        private void LoadManager() {
            foreach (var it in manager.Skills) {
                var item = new SkillItem(MouseButtomEvent.RightButtonDown) {
                    Skill = it,
                    PlusEnable = false
                };
                SkillItems.Children.Add(item);
                SkillItems.Height += item.Height;
                Scroll.Max++;
                SetEvent(item);
            }
        }
        private void SetEvent(SkillItem item) {
            item.HImage.AddMouseEvent(MouseButtomEvent.LeftButtonDown, delegate {
                picked.Picked = item.Skill;
                picked.CopyFrom(item.HImage);
                picked.Open();
            });
        }
    }
}
