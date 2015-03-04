using hoshi_lib.Data;
using hoshi_lib.View;

namespace hoshi_lib.Game.Texture2D {
    
    public class Map {

        public Pair MatrixSize {
            get { return Data.MatrixSize; } }

        public MapData Data { get; private set; }
        public MapView View { get; private set; }

        public Map(MapData mapData, MapView mapView) {
            this.Data = mapData;
            this.View = mapView;
            this.View.CreateView(this.Data.MatrixSize, this.Data.MatrixID);
        }

        public void RegisterBio(Bio bio) {
            View.AddHControl(bio.view);
        }
        public void RegisterBattleBio(BattleBio battleBio,Pair Location) {
            battleBio.values.MatrixLocation = Location;
            Data.AddBio(battleBio.values);
            battleBio.SetViewLoactionByData();
            View.AddHControl(battleBio.view);
            battleBio.LoadMapData(Data);
        }
        public void ShowDamageView(string msg, Pair MatrixLocation) {
            View.ShowDamageView(msg, MatrixLocation);
        }
        
    }


   
}
