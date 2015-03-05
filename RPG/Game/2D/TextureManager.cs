using System.Collections.Generic;
using System.Linq;
using hoshi_lib.Data;
using System.Windows.Media.Imaging;

namespace hoshi_lib.Game._2D {

    public class MapTextureManager : ImageManager {

        IEnumerable<BlockData> blockData;

        public MapTextureManager(MapDataController mapDataController, string imageDirectory):base(){
            blockData = mapDataController.GetBlockInfo();
            base.AddImage(imageDirectory, GetNames(),GetKeys());
        }

        public BitmapImage GetImage(string key) {
            return this.Images[key];
        }
        public IEnumerable<string> GetNames() {
            return blockData.Select((x) => x.Name.ToString());
        }
        public IEnumerator<string> GetKeys() {
            return blockData.Select((x) => x.ID.ToString()).GetEnumerator();
        }
    }



}
