using System.Collections.Generic;
using System.Windows.Controls;

namespace hoshi_lib.View {
    //靜動雙
    public class ControlAligner {

        private Size parentSize;
        private ICollection<IHoshiView> ctrls;

        private ControlAligner() { }
        public ControlAligner(Size parentSize, ICollection<IHoshiView> ctrls) {
            this.parentSize = parentSize;
            this.ctrls = ctrls;
        }

        //水平(同y)
        static public void HAlignMiddle(Size parentSize, IHoshiView ctrl) {
            Point loc = parentSize.GetHCenter(ctrl.Size);
            ctrl.Location = new Point(loc.X, ctrl.Location.Y);
        }
        static public void HAlignMiddle(Size parentSize, ICollection<IHoshiView> ctrls) {
            foreach (var it in ctrls) {
                Point loc = parentSize.GetHCenter(it.Size);
                it.Location = new Point(loc.X, it.Location.Y);
            }
        }
        static public void HAlignLeft(IHoshiView ctrl, int borderWidth = 0) {
                ctrl.Location = new Point(borderWidth, ctrl.Location.Y);
        }
        static public void HAlignLeft(ICollection<IHoshiView> ctrls, int borderWidth = 0) {
            foreach (var it in ctrls) {
                it.Location = new Point(borderWidth, it.Location.Y);
            }
        }
        static public void HAlignRight(Size parentSize, IHoshiView ctrls, int borderWidth = 0) {
            ctrls.Location = new Point(parentSize.Width - ctrls.Size.Width - borderWidth, ctrls.Location.Y);
        }
        static public void HAlignRight(Size parentSize, ICollection<IHoshiView> ctrls, int borderWidth = 0) {
            foreach (var it in ctrls) {
                it.Location = new Point(parentSize.Width - it.Size.Width - borderWidth, it.Location.Y);
            }
        }
        static public void HAlignJustify(ICollection<IHoshiView> ctrls, int startLocX, int endLocX) {
            int inLocX = startLocX;
            int widthTatal = 0;
            foreach (var it in ctrls) {
                widthTatal += it.Size.Width;
            }
            int span = (endLocX - startLocX - widthTatal) / ctrls.Count;
            foreach (var it in ctrls) {
                it.Location = new Point(inLocX, it.Location.Y);
                inLocX += it.Size.Width + span;
            }
        }
        static public void HAlignSpan(ICollection<IHoshiView> ctrls, int startLocX, int hSpan = 0) {
            int inLocX = startLocX;
            foreach (var it in ctrls) {
                it.Location = new Point(inLocX, it.Location.Y);
                inLocX += it.Size.Width + hSpan;
            }
        }
   
        //垂直(同x)
        static public void VAlignMiddle(Size parentSize, IHoshiView ctrl) {
            Point loc = parentSize.GetVCenter(ctrl.Size);
            ctrl.Location = new Point(ctrl.Location.X,loc.Y);
        }
        static public void VAlignMiddle(Size parentSize, ICollection<IHoshiView> ctrls) {
            foreach (var it in ctrls) {
                Point loc = parentSize.GetVCenter(it.Size);
                it.Location = new Point(it.Location.X, loc.Y);
            }
        }
        static public void VAlignTop(IHoshiView ctrl, int borderHeight = 0) {
            ctrl.Location = new Point(ctrl.Location.X, borderHeight);
        }
        static public void VAlignTop(ICollection<IHoshiView> ctrls, int borderHeight = 0) {
            foreach (var it in ctrls) {
                it.Location = new Point(it.Location.X, borderHeight);
            }
        }
        static public void VAlignBottom(Size parentSize, IHoshiView ctrl, int borderHeight = 0) {
            ctrl.Location = new Point(ctrl.Location.X, parentSize.Height - ctrl.Size.Height - borderHeight);
        }
        static public void VAlignBottom(Size parentSize, ICollection<IHoshiView> ctrls, int borderHeight = 0) {
            foreach (var it in ctrls) {
                it.Location = new Point(it.Location.X, parentSize.Height - it.Size.Height - borderHeight);
            }
        }
        static public void VAlignJustify(ICollection<IHoshiView> ctrls, int startLocY, int endLocY) {
            int inLocY = startLocY;
            int heightTatal = 0;
            foreach (var it in ctrls) {
                heightTatal += it.Size.Height;
            }
            int span = (endLocY - startLocY - heightTatal) / ctrls.Count;
            foreach (var it in ctrls) {
                it.Location = new Point(it.Location.X, inLocY);
                inLocY += it.Size.Height + span;
            }
        }
        static public void VAlignSpan(ICollection<IHoshiView> ctrls, int startLocY, int vSpan = 0) {
            int inLocY = startLocY;
            foreach (var it in ctrls) {
                it.Location = new Point(it.Location.X, inLocY);
                inLocY += it.Size.Height + vSpan;
            }
        }

        //水平(同y)
        public void HAlignMiddle() {
            foreach (var it in ctrls) {
                Point loc = parentSize.GetHCenter(it.Size);
                it.Location = new Point(loc.X, it.Location.Y);
            }
        }
        public void HAlignLeft(int borderWidth = 0) {
            foreach (var it in ctrls) {
                it.Location = new Point(borderWidth, it.Location.Y);
            }
        }
        public void HAlignRight(int borderWidth = 0) {
            foreach (var it in ctrls) {
                it.Location = new Point(parentSize.Width - it.Size.Width - borderWidth, it.Location.Y);
            }
        }
        public void HAlignJustify(int startLocX, int endLocX, int count) {
            int inLocX = startLocX;
            int widthTatal = 0;
            foreach (var it in ctrls) {
                widthTatal += it.Size.Width;
            }
            int span = (endLocX - startLocX - widthTatal) / ctrls.Count;
            foreach (var it in ctrls) {
                it.Location = new Point(inLocX, it.Location.Y);
                inLocX += it.Size.Width + span;
            }
        }
        public void HAlignSpan(int startLocX, int hSpan = 0) {
            int inLocX = startLocX;
            foreach (var it in ctrls) {
                it.Location = new Point(inLocX, it.Location.Y);
                inLocX += it.Size.Width + hSpan;
            }
        }
        //垂直(同x)
        public void VAlignMiddle() {
            foreach (var it in ctrls) {
                Point loc = parentSize.GetVCenter(it.Size);
                it.Location = new Point(it.Location.X, loc.Y);
            }
        }
        public void VAlignTop(int borderHeight = 0) {
            foreach (var it in ctrls) {
                it.Location = new Point(it.Location.X, borderHeight);
            }
        }
        public void VAlignBottom(int borderHeight = 0) {
            foreach (var it in ctrls) {
                it.Location = new Point(it.Location.X, parentSize.Height - it.Size.Height - borderHeight);
            }
        }
        public void VAlignJustify(int startLocY, int endLocY) {
            int inLocY = startLocY;
            int heightTatal = 0;
            foreach (var it in ctrls) {
                heightTatal += it.Size.Height;
            }
            int span = (endLocY - startLocY - heightTatal) / ctrls.Count;
            foreach (var it in ctrls) {
                it.Location = new Point(it.Location.X, inLocY);
                inLocY += it.Size.Height + span;
            }
        }
        public void VAlignSpan(int startLocY, int vSpan = 0) {
            int inLocY = startLocY;
            foreach (var it in ctrls) {
                it.Location = new Point(it.Location.X, inLocY);
                inLocY += it.Size.Height + vSpan;
            }
        }
    }
}
