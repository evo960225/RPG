using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hoshi_lib.View;
using hoshi_lib.HLib;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using hoshi_lib.Game.RPG;
using System.Windows.Controls;
namespace hoshi_lib.Game._2D {
    public class MapView : Map, IView {
        
        public Size Size {
            get { return View.Size; }
            set { View.Size = value; }
        }
        public Point Location {
            get { return View.Location; }
            set { View.Location = value; }
        }

        internal protected IMatrixControl View { get; protected set; }
        private List<IAnimateControl> animateControls = new List<IAnimateControl>(110);
        private Dictionary<int, BioView> Bios = new Dictionary<int, BioView>(30);
        private Dictionary<int, IHControl> Stuffs = new Dictionary<int, IHControl>(50);
        private int aniCtrlIndex = 0;


        public MapView(string fileAddress, string imagePath, TerrainManager textureManager, Size blockSize)
            : base(fileAddress, textureManager) {
            this.MatrixSize.BlockSize = blockSize;
            View = new MatrixControl(MatrixSize);

            CreateMap(imagePath);
        }
        public void AddBio(int id ,BioView bioView, MatrixPoint location) {
            base.AddBio(id, location);
            Bios.Add(id, bioView);
            View.AddHControl(bioView.View);
            Panel.SetZIndex(bioView.View, 10);
            bioView.Location = MatrixSize.GetBlockPoint(location);
        }
        public new void RemoveBio(int id) {
            base.RemoveBio(id);
            View.RemoveHControl(Bios[id].View);
            Bios.Remove(id);
        }

        public void Puted(IHControlCollection ctrl) {
            ctrl.AddHControl(View);
            View.BackColor = Brushes.Bisque;
        }
        public void CreateMap(string imagePath) {
            if (!Directory.Exists(imagePath)) return;
            for (int i = 0; i < base.MatrixSize.Y; ++i) {
                for (int j = 0; j < base.MatrixSize.X; ++j) {
                    View.Controls[i, j].Image = new BitmapImage(new Uri(imagePath +MapBlock[i, j].Name + ".png", UriKind.Relative));
                }
            }
        }
        public void ShowControl( Action<IAnimateControl> action) {
            IAnimateControl ctrl;
            if (animateControls.Count == 0)
                ctrl =AddAnimateControl();
            else
                ctrl = animateControls[aniCtrlIndex];

            if (!ctrl.IsWorking) {
                if (aniCtrlIndex + 1 != animateControls.Count)
                    ++aniCtrlIndex;
                else
                    aniCtrlIndex = 0;
            } else {
                if (animateControls.Count > 100) {
                    ctrl.Stop();
                    ctrl.Opacity = 0;
                } else {
                    ctrl = AddAnimateControl();
                }
            }
            action(ctrl);
        }
       
        public new bool MoveElement(int id, Direction direction) {
            return base.MoveElement(id, direction);
        }
        public void ThorwStuff(int id, BitmapImage image, MatrixPoint loc) {
            base.ThorwStuff(id,loc);
            IHControl stuffimage = new HControl();
            Stuffs.Add(id, stuffimage);
            stuffimage.Image = image;
            stuffimage.Size = new Size((int)image.PixelWidth, (int)image.PixelHeight);
            ThrowShow(stuffimage, MatrixSize.GetBlockPoint(loc));
        }
        public new IEnumerable<int> GetStuff(int bioID) {
            var ids = base.GetStuff(bioID);
            foreach (var it in ids) {
                View.RemoveHControl(Stuffs[it]);
            }
            return ids;
        }
        public new IEnumerable<int> GetStuff(MatrixPoint location) {
            var ids = base.GetStuff(location);
            foreach (var it in ids) {
                View.RemoveHControl(Stuffs[it]);
            }
            return ids;
        }

        private AnimateControl AddAnimateControl() {
            var ctrl = new AnimateControl();
            Panel.SetZIndex(ctrl, 50);
            animateControls.Add(ctrl);
            View.AddHControl(ctrl);
            return ctrl;
        }
        private void ThrowShow(IHControl ctrl,Point loc) {
            View.AddHControl(ctrl);
            ctrl.Location = loc;
            ConditionTimer timer = new ConditionTimer();
            timer.Interval = TimeSpan.FromMilliseconds(25);

            Point ogloc = ctrl.Location + new Point(0, 10);
            double x = 0;
            int tcount = 10;
            int center = 5;
            ogloc.Y -= center * center/2 ;
            Point ogloc2 = ctrl.Location;
            int tcount2 = tcount + 6 ;
            int center2 = tcount + 3;
            ogloc2.Y -= 3 * 3 / 2;

            timer.Tick += delegate {
                x += 1;
                if(x<tcount)
                    ctrl.Location = new Point(ogloc.X + x, (x - center) * (x - center) / 2 + ogloc.Y);
                else
                    ctrl.Location = new Point(ogloc.X + x, (x - center2) * (x - center2) / 2 + ogloc2.Y);
            };
            timer.TickUntil = () => x >  tcount2;
            timer.Start();
        }
    }
}
