using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoshi_lib.Data {


    public class MapDataController {

        enum map_blockColName {
            ID,
            name,
            data
        }

        private MapDataSet DS;
        private MapDataSetTableAdapters.map_blockTableAdapter map_blockTA;
        //private RoleDataDataSetTableAdapters.role_numericalTableAdapter RoleNumericalTA;

        List<BlockData> blockData;

        public MapDataController() {
            DS = new MapDataSet();
            map_blockTA = new MapDataSetTableAdapters.map_blockTableAdapter();
        }

        public IEnumerable<BlockData> GetBlockInfo() {
            var data = map_blockTA.GetData();
            var blockData = data.Select((x)
                => new BlockData(int.Parse(x[(int)map_blockColName.ID].ToString()),
                    x[(int)map_blockColName.name].ToString(),
                    int.Parse(x[(int)map_blockColName.data].ToString())));
            return blockData;
        }
        
    }

    public struct BlockData {
        public int ID;
        public string Name;
        public int Type;

        public BlockData(int ID,string name,int type) {
            this.ID = ID;
            this.Name = name;
            this.Type = type;
        }
    }
}
