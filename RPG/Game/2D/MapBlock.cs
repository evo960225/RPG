using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hoshi_lib.View;

namespace hoshi_lib.Game.Texture2D {

    class MapBlockView : HControl {


        private MapBlockView() {
        }

        public MapBlockView(Location location, Size size) {
            this.Location = location;
            this.Size = size;
        }

    }
}
