using hoshi_lib.View;
using System.Windows.Controls.Primitives;
using hoshi_lib.Game.RPG;
using System.Linq;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;
using System;
namespace hoshi_lib.Game.TestView {
    /// <summary>
    /// AccoutermentPanel.xaml 的互動邏輯
    /// </summary>
    public partial class AccoutermentPanel : HControlCollection,IGamePanel {

        private EquipmentManager manager;
        private MousePicked picked = new MousePicked();

        public AccoutermentPanel(EquipmentManager manager) {
            InitializeComponent();
            this.manager = manager;
            initManager();
            initStuffEvent();
            this.AddMouseEvent(MouseButtomEvent.LeftButtonUp, delegate {
                if (picked.IsOpen) {
                    picked.Close();
                    picked.Open();
                }
            });
        }
        private void initManager() {
            UpdateImage(HArm, EquipmentType.Arm);
            UpdateImage(HClothes, EquipmentType.Clothes);
            UpdateImage(HEarring, EquipmentType.Earring);
            UpdateImage(HHead, EquipmentType.Head);
            UpdateImage(HLeg, EquipmentType.Leg);
            UpdateImage(HNecklace, EquipmentType.Necklace);
            UpdateImage(HShoes, EquipmentType.Shoes);
            UpdateImage(HWeapon, EquipmentType.Weapon);
        }
        private void UpdateImage(FunctionalSquare ctrl, EquipmentType Type) {
            var acc = manager.Accouterments.Where((x) => x.Key == Type);
            if (acc.Count() == 0) return;
            ctrl.SetContent(acc.ElementAt(0).Value);
            ctrl.Image = acc.ElementAt(0).Value.ItemImage;
        }
    
        private void initStuffEvent() {
            SetStuffPickedEvent(HArm, EquipmentType.Arm);
            SetStuffPickedEvent(HClothes, EquipmentType.Clothes);
            SetStuffPickedEvent(HEarring, EquipmentType.Earring);
            SetStuffPickedEvent(HHead, EquipmentType.Head);
            SetStuffPickedEvent(HLeg, EquipmentType.Leg);
            SetStuffPickedEvent(HNecklace, EquipmentType.Necklace);
            SetStuffPickedEvent(HShoes, EquipmentType.Shoes);
            SetStuffPickedEvent(HWeapon, EquipmentType.Weapon);
            
        }
        private void SetStuffPickedEvent(FunctionalSquare ctrl, EquipmentType type) {
            //pick
            ctrl.AddMouseEvent(MouseButtomEvent.LeftButtonDown, delegate {
                var accs = manager.Accouterments.Where((x) => x.Key == type);
                if (accs.Count() == 0) return;
                var acc = accs.ElementAt(0);
                picked.CopyFrom(ctrl);
                picked.Picked=acc.Value;
                picked.Open();
                manager.Remove(acc.Value);
                ctrl.SetContent(null as Stuff);
                ctrl.Image = null;
            });
            //put or change
            ctrl.AddMouseEvent(MouseButtomEvent.LeftButtonUp, delegate(object sen,MouseButtonEventArgs e) {
                var pickStuff = picked.Picked;
                if (pickStuff == null) return;
                if (pickStuff is Equipment) {
                    var pickAcc = (Equipment)pickStuff;
                    if (pickAcc.Type != type) { return; }

                    Equipment tmp = manager.Change(pickAcc);
                    picked.Picked = tmp;
                    if (tmp == null) {
                        picked.Close();
                    } else {
                        picked.Close();
                        picked.CopyFrom(ctrl);
                        picked.Open();
                    }
                    UpdateImage(ctrl, type);
                } 
            });
          
        }

    }
}
