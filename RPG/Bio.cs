using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hoshi_lib.Game;
using hoshi_lib.Game.Texture2D;
using hoshi_lib.Image;
using hoshi_lib.View;
using hoshi_lib;

namespace Test {

    public partial class BattleBio : Bio,IBio {

        private Direction direction;

        public int MilsecSpeed;
        public void MoveUp() {
            (this as IBioValue).MoveUp();
            (this as IBioView).MoveUp();
        }
        public void MoveDown() {
            (this as IBioValue).MoveUp();
            (this as IBioView).MoveUp();
        }
        public void MoveLeft() {
            (this as IBioValue).MoveUp();
            (this as IBioView).MoveUp();
        }
        public void MoveRight() {
            (this as IBioValue).MoveUp();
            (this as IBioView).MoveUp();
        }
        void IBioView.MoveUp() {
            (this as IBioValue).MoveUp();
            (this as IBioView).MoveUp();
            var a = (this as IBioView) as I4DirectMovement;
        }/*
        void IBio.MoveDown() {
            (this as IBioValue).MoveUp();
            (this as IBioView).MoveUp();
        }
        void IBio.MoveLeft() {
            (this as IBioValue).MoveUp();
            (this as IBioView).MoveUp();
        }
        void IBio.MoveRight() {
            (this as IBioValue).MoveUp();
            (this as IBioView).MoveUp();
        }*/
    }


    public partial class BattleBio : IBioValue {

        /*void I4DirectMovement.MoveUp() {
            (this as IBioValue).MoveUp();
            (this as IBioView).MoveUp();
        }
        void IBioValue.MoveDown() {
            (this as IBioValue).MoveUp();
            (this as IBioView).MoveUp();
        }
        void IBioValue.MoveLeft() {
            (this as IBioValue).MoveUp();
            (this as IBioView).MoveUp();
        }
        void IBioValue.MoveRight() {
            (this as IBioValue).MoveUp();
            (this as IBioView).MoveUp();
        }*/
    }

    public partial class BattleBio : IBioView {

        private ImageManager imageManager;
        private Location directionValue;
        private Location fromLocation;
        private Location toLocation;

        private int moveTimes {
            get { return (int)(MilsecSpeed / 1000.0 * FPS); }
        }
        private int singleMoveImageCount;
        public int FPS { get; private set; }


/*void IBioView.MoveUp() {
            (this as IBioValue).MoveUp();
            (this as IBioView).MoveUp();
        }
        void IBioView.MoveDown() {
            (this as IBioValue).MoveUp();
            (this as IBioView).MoveUp();
        }
        void IBioView.MoveLeft() {
            (this as IBioValue).MoveUp();
            (this as IBioView).MoveUp();
        }
        void IBioView.MoveRight() {
            (this as IBioValue).MoveUp();
            (this as IBioView).MoveUp();
        }*/
    }
}
