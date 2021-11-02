using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;
using System.IO;
using System.Text;
using System;

namespace hoshi_lib.Game._2D {

    public class TerrainManager : List<MapBlock> {

        public TerrainManager(string texturePath, string terrainTypePath) {
            if (!File.Exists(texturePath)) return;
            StreamReader SR = new StreamReader(texturePath, Encoding.Default);
            while (SR.Peek() > 0) {
                var tmp = SR.ReadLine();
                var args = tmp.Split();
                var id = int.Parse(args[0]);
                var name = args[1];
                var type = (TerrainType)int.Parse(args[2]);
                this.Insert(id, new MapBlock(id, name, type));
            }
            SR.Close();
        }
    }


}
