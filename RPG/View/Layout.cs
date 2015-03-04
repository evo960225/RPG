using System.Collections.Generic;

namespace hoshi_lib.View {
    
    public class ScreenLayout {
        public enum Align {
            Horizontal,
            Vertical
        }
        public Size BaseSize;

        public ScreenLayout(Size baseSize) {
            this.BaseSize = baseSize;
        }

        public void HCenterVMargin(IEnumerable<HControl> contorls, double vMagin = 0, double locationY = 100) {
            foreach (var ctrl in contorls) {
                Location loc;
                loc = BaseSize.GetHorizontalCenter(ctrl.Size);
                loc.Y = locationY;
                ctrl.Location = loc;
                locationY += ctrl.Size.Height + vMagin;
            }
        }
        
        static public void ControlHCenter(Size baseSize, HControl control, double locationY = 50) {
            Location loc;
            loc = baseSize.GetCenter(control.Size);
            loc.Y = locationY;
            control.Location = loc;
        }
        static public void ControlHCenterVMargin(Size baseSize, IEnumerable<HControl> contorls, double vMagin = 0, double locationY = 100) {
            if (contorls == null) return;
            foreach (var ctrl in contorls) {
                Location loc;
                loc = baseSize.GetHorizontalCenter(ctrl.Size);
                loc.Y = locationY;
                ctrl.Location = loc;
                locationY += ctrl.Size.Height + vMagin;
            }
        }
        static public void ControlVCenter(Size baseSize, HControl control, double locationX = 50) {
            Location loc;
            loc = baseSize.GetCenter(control.Size);
            loc.X = locationX;
            control.Location = loc;
        }
        static public void ControlHMarginVCenter(Size baseSize, IEnumerable<HControl> contorls, double hMagin = 0, double locationX = 50) {
            if (contorls == null) return;
            foreach (var ctrl in contorls) {
                Location loc;
                loc = baseSize.GetVerticalCenter(ctrl.Size);
                loc.X = locationX;
                ctrl.Location = loc;
                locationX += ctrl.Size.Width + hMagin;
            }
        }

    }
}
