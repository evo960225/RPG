using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hoshi_lib.View;

namespace hoshi_lib.Game._2D {
    public class Camera{
        public IView BGView { get; set; }
        private IView screen;
        private Point limitLocation {
            get {
                return screen.Size - BGView.Size;
            }
        }

        public Camera(IView screen, IView bgview) {
            BGView = bgview;
            this.screen = screen;
        }
        public void Lock(BioView view) {
            MainTimer.Tick += delegate {
                var point=-view.Location + (screen.Size / 2 - view.Size / 2).ToPoint();
                if (point.X > 0) point.SetX(0);
                if (point.Y > 0) point.SetY(0);
                if (point.X < limitLocation.X) point.SetX(limitLocation.X);
                if (point.Y < limitLocation.Y) point.SetY(limitLocation.Y);
                BGView.Location = point;
            };
        }
    
    }
}
