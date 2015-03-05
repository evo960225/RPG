using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hoshi_lib.View;
using hoshi_lib.Game._2D.RPG;

namespace hoshi_lib.Game._2D {
    public class Camera : I4DirectMovement{

        private MapView mapView;
        private Size screenSize;

        private void postInit(){
           
        }
        public Camera(Size screenSize,MapView mapView) {
            this.screenSize = screenSize;
            this.mapView = mapView;
        }

        public void MoveLeft() {
            if (mapView.LeftBlockLocation().X >= (screenSize - mapView.Size).Width)
                mapView.MoveToLeftBlockWidth();
            else
                mapView.Location.SetX(this.screenSize.Width - mapView.Size.Width);
        }
        public void MoveUp() {
            if (mapView.UpBlockLocation().Y >= (screenSize - mapView.Size).Height)
                mapView.MoveToUpBlockHeight();
            else
                mapView.Location.SetY(this.screenSize.Height - mapView.Size.Height);

        }
        public void MoveDown() {
            if (mapView.DownBlockLocation().Y <= 0)
                mapView.MoveToDownBlockHeight();
            else
                mapView.Location.SetY(0);
        }
        public void MoveRight() {
            if (mapView.RightBlockLocation().X <= 0)
                mapView.MoveToRightBlockWidth();
            else
                mapView.Location.SetX(0);
        }

        BattleBio battleBio;
        public void Observe(BattleBio battleBio) {
            this.battleBio = battleBio;
            battleBio.bgWorker.Loop += Move;
            battleBio.bgWorker.End += MoveCompleted;
            this.Move();
        }

        private void Move() {
            mapView.Location = -battleBio.view.Location + screenSize / 2 - battleBio.view.Size / 2; 
        }
        private void MoveCompleted() {
            mapView.Location = mapView.Location.ToRound();
        }
    }
}
