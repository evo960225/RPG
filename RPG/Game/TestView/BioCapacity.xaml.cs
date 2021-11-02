using hoshi_lib.Game._2D;
using hoshi_lib.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace hoshi_lib.Game.TestView {
    /// <summary>
    /// BioCapacity.xaml 的互動邏輯
    /// </summary>
    public partial class BioCapacity : HControlCollection {
        public string BioName {
            get { return HBioName.Content.ToString(); }
            set { HBioName.Content = value; }
        }
        public Size Size {
            get { return HBioImage.Size; }
            set { HBioImage.Size = value; }
        }
        public BitmapImage Image {
            get { return HBioImage.Image; }
            set { HBioImage.Image = value; }
        }
        public int BarValue {
            get { return barvalue;}
            set {
                if (value >= 0)
                    if (value <= barMax) {
                        barvalue = value;
                    } else {
                        barvalue = barMax;
                    }
                HBarValue.Width = 1.0 * barvalue / barMax * HBar.Width;
            }
        }
        public int BarMax {
            get { return barMax; }
            set { if(value>=0)barMax = value; }
        }

        private int barMax;
        private int barvalue;
        private Bio bio;

        public BioCapacity(Bio bio) {
            InitializeComponent();
            this.bio = bio;
            BioName = bio.Name;
            Update();
        }
        public void Update() {
            BarMax = bio.BattleValue.HP.Max;
            BarValue = bio.BattleValue.HP.Point;
        }
    }
}

