using System.IO;
using System.Collections.Generic;

namespace hoshi_lib.Game.Texture2D {
    public class MapData {
        
        public int[,] MatrixID;
        public List<BattleBioValues> BioValues;

        public Pair MatrixSize { get; private set; }
        public string LocalPath { get; private set; }

        public MapData(string path) {
            this.LocalPath = path;
            LoadFromText(path);
            BioValues = new List<BattleBioValues>(100);
        }
        public void LoadFromText(string path) {

            if (File.Exists(path)) {
                StreamReader SR = new StreamReader(path);
                var size = SR.ReadLine().Split();
                this.MatrixSize = new Pair(int.Parse(size[0]), int.Parse(size[1]));

                int w = MatrixSize.X;
                int h = MatrixSize.Y;
                this.MatrixID = new int[h, w];
                for (int i = 0; i < h; ++i) {
                    var info = SR.ReadLine().Split();
                    for (int j = 0; j < w; ++j) {
                        MatrixID[i, j] = int.Parse(info[j]);
                    }
                }
            }

        }
        public void AddBio(BattleBioValues bio) {
            BioValues.Add(bio);
        }    
        public bool IsInMap(Pair MatrixLocation) {
            return MatrixLocation.X < 0 && MatrixLocation.Y < 0 &&
                MatrixLocation.X >= MatrixSize.X && MatrixLocation.Y >= MatrixSize.Y;
        }
        public WalkableType GetWalkableType(Pair MatrixLocation) {
            WalkableType type;
            if (IsInMap(MatrixLocation)) return WalkableType.Unwalkable;

            if (MatrixID[MatrixLocation.Y, MatrixLocation.X] == 1) {
                type = WalkableType.Walkable;
            } else {
                type = WalkableType.Unwalkable;
            }
            var findindex = BioValues.BinarySearch(new BattleBioValues() { MatrixLocation = MatrixLocation }, new BattleBioValuesComparer());
            if (findindex >= 0) {
                type = WalkableType.Unwalkable;
            }
            return type;
        }
    }
    class BattleBioValuesComparer : IComparer<BattleBioValues> {
        public int Compare(BattleBioValues x, BattleBioValues y) {
            return x.MatrixLocation == y.MatrixLocation ? 0 : -1;
        }
    }
}
