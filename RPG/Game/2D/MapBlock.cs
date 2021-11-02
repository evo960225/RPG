using System.Windows.Media.Imaging;
using hoshi_lib.HLib;

namespace hoshi_lib.Game._2D {

    public struct MapBlock : IGameObject {
        public int ID;
        public string Name;
        public string Description;

        int IGameObject.ID {
            get { return ID; }
            set { ID = value; }
        }
        string IGameObject.Name {
            get { return Name; }
            set { Name = value; }
        }
        string IGameObject.Description {
            get { return Description; }
            set { Description = value; }
        }

        public TerrainType Type;

        public MapBlock(int id,string name,TerrainType type) {
            this.ID = id;
            this.Name = name;
            this.Type = type;
            Description = "";
        }



       
    }
}
