using System.Collections;
using hoshi_lib.View;
using hoshi_lib.HLib;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System;
using System.Linq;
namespace hoshi_lib.Game._2D {
    
    public class Map : IGameObject{

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public MatrixSize MatrixSize { get; protected set; }
        public Dictionary<int, MatrixPoint> BiosLocation { get { return biosLocation; } }
        public Dictionary<int, MatrixPoint> StuffsLocation { get { return stuffsLocation; } }
        public List<InNearMap> NearMap { get; protected set; } 
        public MapBlock[,] MapBlock { get; protected set; }
        public bool[,] BioOn { get; protected set; }
        public WorldCommand World { get; set; }

        private Dictionary<int, MatrixPoint> biosLocation;
        private Dictionary<int, MatrixPoint> stuffsLocation;

        private void Init(){
            biosLocation = new Dictionary<int, MatrixPoint>(30);
            stuffsLocation = new Dictionary<int, MatrixPoint>(50);
            NearMap = new List<InNearMap>(5);
        }
        public Map(string fileAddress,TerrainManager textureManager) {
            Init();
            LoadMap(fileAddress, textureManager);
            BioOn = new bool[MatrixSize.Y, MatrixSize.X];
        }

        protected void AddBio(int id, MatrixPoint location) {
            biosLocation.Add(id, location);
            BioOn[location.Y, location.X] = true;
        }
        protected void RemoveBio(int id) {
            var loc = biosLocation[id];
            BioOn[loc.Y, loc.X] = false;
            BiosLocation.Remove(id);
        }
        protected bool MoveElement(int id, Direction direction) {
            object sync = new object();
            var loc = biosLocation[id];
            var preX = loc.X;
            var preY = loc.Y;

            var TransBio = (this as MapView).TransmissBioCommand(id, direction, loc);
            if (TransBio) return false;
            lock (sync) {
                switch (direction) {
                    case Direction.Left:
                        if (loc.X == 0) return false;
                        if (MapBlock[loc.Y, loc.X - 1].Type == TerrainType.Walkable) {
                            if (BioOn[loc.Y, loc.X - 1]) return false;
                            loc.X -= 1;
                        } else {
                            return false;
                        }
                        break;
                    case Direction.Up:
                        if (loc.Y == 0) return false;
                        if (MapBlock[loc.Y - 1, loc.X].Type == TerrainType.Walkable) {
                            if (BioOn[loc.Y - 1, loc.X]) return false;
                            loc.Y -= 1;
                        } else {
                            return false;
                        }
                        break;
                    case Direction.Down:
                        if (loc.Y >= MatrixSize.Y - 1) return false;
                        if (MapBlock[loc.Y + 1, loc.X].Type == TerrainType.Walkable) {
                            if (BioOn[loc.Y + 1, loc.X]) return false;
                            loc.Y += 1;
                        } else {
                            return false;
                        }
                        break;
                    case Direction.Right:
                        if (loc.X >= MatrixSize.X - 1) return false;
                        if (MapBlock[loc.Y, loc.X + 1].Type == TerrainType.Walkable) {
                            if (BioOn[loc.Y, loc.X + 1]) return false;
                            loc.X += 1;
                        } else {
                            return false;
                        }
                        break;
                }
                BioOn[loc.Y, loc.X] = true;
                BioOn[preY, preX] = false;
            }
            return true;

        }
        protected void ThorwStuff(int id, MatrixPoint location) {
            StuffsLocation.Add(id, new MatrixPoint(location));
        }

        protected IEnumerable<int> GetStuff(int bioID) {
            var loc = BiosLocation[bioID];
            return GetStuff(loc);
        }
        protected IEnumerable<int> GetStuff(MatrixPoint location) {
            var getloc = stuffsLocation.Where((x) => x.Value == location).Select((x)=>x.Key).ToList();
            foreach (var it in getloc) {
                stuffsLocation.Remove(it);
            }
            return getloc;
        }

        protected void LoadMap(string mapFileAdr, TerrainManager textureManager) {
            if (File.Exists(mapFileAdr)) {
                StreamReader SR = new StreamReader(mapFileAdr);
                var size = SR.ReadLine().Split();
                this.MatrixSize = new MatrixSize(int.Parse(size[0]), int.Parse(size[1]));

                int w = MatrixSize.X;
                int h = MatrixSize.Y;
                MapBlock = new MapBlock[h, w];
                for (int i = 0; i < h; ++i) {
                    var info = SR.ReadLine().Split();
                    for (int j = 0; j < w; ++j) {
                        int id= int.Parse(info[j]);
                        MapBlock[i, j] = textureManager[id];
                    }
                }
            }
        }
        public List<int> FindElement(int id, Func<MatrixPoint, MatrixPoint, bool> func) {
            List<int> list = new List<int>();
            var cmdBio =biosLocation[id];
            foreach (var it in biosLocation) {
                if (func(cmdBio, it.Value)) {
                    list.Add(it.Key);
                }
            }
            return list;
        }
        public void SetTransmiss(MapView map,Direction direction,Func<MatrixPoint,MatrixPoint> WhereInWhereOut) {
            NearMap.Add(new InNearMap(map, direction, WhereInWhereOut));
        }
        public bool TransmissBioCommand(int id,Direction direction ,MatrixPoint loc) {
            if (World == null) return false;
            foreach (var it in NearMap) {
                if (it.Direction == direction) {
                    var toLoc = it.LocationFunc(loc);
                    if (toLoc != null) {
                        World.MapChangeCommand(it.Map as MapView, id, toLoc);
                        return true;
                    }
                }
            }
            return false;
        }
        
        public struct InNearMap {
            public MapView Map;
            public Direction Direction;
            public Func<MatrixPoint, MatrixPoint> LocationFunc;
            public InNearMap(MapView map, Direction direction, Func<MatrixPoint, MatrixPoint> func) {
                Map = map;
                Direction = direction;
                LocationFunc = func;
            }
        }

       
    }

   
}
