using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace hoshi_lib.Game.RPG {
    public class Stuff : IStuff {
        /// <summary>
        /// 格式化路徑字串，{0}為ID、{1}為Name
        /// </summary>
        static public string RelatDirectoryFormat {
            get { return relatDirectoryFormat; }
            set { relatDirectoryFormat = value; }
        }
        static public string relatDirectoryFormat = "";

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public BitmapImage ItemImage { get; set; }

        public bool IsProduct { get; set; }
        public int Price { get; set; }
        public bool IsCountable { get; set; }
        public int Count { get; set; }
       
        public Stuff(int id, string name) {
            this.ID = id;
            this.Name = name;
            LoadImage();
        }
        private void LoadImage() {
            string filename;
            filename = string.Format(RelatDirectoryFormat, ID, Name);
            if (System.IO.File.Exists(filename))
                ItemImage = new BitmapImage(new Uri(filename, UriKind.Relative));
        }
        public override string ToString() {
            return "";
        }
       
    }
    

    
}
