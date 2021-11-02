using hoshi_lib.Game._2D.RPG;
using hoshi_lib.Game.RPG;
using hoshi_lib.HLib;
using hoshi_lib.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace hoshi_lib.Game._2D {
    public class WorldCommand {

        public MapView MapView { get; protected set; }
        public EventMaker EventTree { get; protected set; }
        public Camera Camera { get; protected set; }

        private Dictionary<int, BioView> Bios;
        private Dictionary<int, IStuff> Stuffs;
        private IScreen screen;

        public WorldCommand(IScreen screen, MapView map, EventMaker eventTree) {
            this.screen = screen;
            screen.AddHControl(map.View);
            this.MapView = map;
            MapView.World = this;
            this.EventTree = eventTree;
            this.Camera = new Camera(screen, MapView);
            Bios = new Dictionary<int, BioView>(30);
            Stuffs = new Dictionary<int, IStuff>(50);
        }
        public void AddBio(BioView bio, MatrixPoint location) {
            Bios.Add(bio.GetHashCode(), bio);
            MapView.AddBio(bio.GetHashCode(), bio, location);
            bio.World = this;
        }
        public void RemoveBio(BioView bio) {
            bio.World = null;
            Bios.Remove(bio.GetHashCode());
            MapView.RemoveBio(bio.GetHashCode());
        }
        public void RemoveALLBio() {
            var removeE = Bios.ToList();
            foreach (var it in removeE) {
                RemoveBio(it.Value);
            }
        }

        public void MoveCommand(Bio bio, Direction direction) {
            var bioID=bio.GetHashCode();
            if (MapView.MoveElement(bioID, direction)) {
                (bio as BioView).Moved(direction);
                var stuffid = MapView.GetStuff(bioID);
                Picked(bio as BioView, stuffid);
            }
           

            EventTree.CheckEvent();
        }
        public void AttackCommand(Bio bio) {
            var locs = MapView.FindElement(bio.GetHashCode(), RegionMaker.Cross1());
            var atk = bio.BattleValue.ATK;
            foreach (var it in locs) {
                var atkedbio = Bios[it];

                if (!CanAttack(bio, atkedbio)) return;
                var damage = atk.Value - atkedbio.BattleValue.DEF.Value;
                if (damage < 0) damage = 0;
                atkedbio.Attacked(damage);

                ShowDamage(damage, atkedbio);
                if (atkedbio.BattleValue.HP.Point <= 0) {
                    bio.Exp += atkedbio.OfferExp;
                }
            }
            EventTree.CheckEvent();
        }
        public void AttackCommand(Bio bio,Skill skill) {
            var locs = MapView.FindElement(bio.GetHashCode(), skill.EffectRegion);
            var atk = skill.GetDamage(bio.BattleValue);
            foreach (var it in locs) {
                var atkedbio = Bios[it];
                var damage = atk - atkedbio.BattleValue.DEF;
                if (damage < 0) damage = 0;
                atkedbio.Attacked(damage);
                ShowDamage(damage, atkedbio);
                if (atkedbio.BattleValue.HP.Point <= 0) {
                    bio.Exp += atkedbio.OfferExp;
                }
                ShowSkill(Bios[bio.GetHashCode()], skill);
            }
            EventTree.CheckEvent();
        }
        public void UsedCommand(Bio bio, IUsed use) {
            use.Used(bio);
            EventTree.CheckEvent();
        }
        public void ThrowCommand(Bio bio,IStuff stuff) {
            var loc = MapView.BiosLocation[bio.GetHashCode()];
            var stuffId = stuff.GetHashCode();
            Stuffs.Add(stuffId, stuff);
            MapView.ThorwStuff(stuffId, stuff.ItemImage, loc);

            EventTree.CheckEvent();
        }
        public void MapChangeCommand(MapView map,int bioId,MatrixPoint location) {
            var bio = Bios[bioId];
            if (MapView != null) {
                RemoveBio(bio);
                screen.RemoveHControl(MapView.View);
                RemoveALLBio();
            }
            screen.AddHControl(map.View);
            this.MapView = map;
            map.World = this;
            AddBio(bio, location);
            Camera.BGView = map.View;

            EventTree.CheckEvent();
        }
        public void ShowDamage(string text,BioView bio) {
            MapView.ShowControl( delegate(IAnimateControl ctrl) {
                ctrl.Size = new Size(50, 25);
                ctrl.Location = bio.Location - new Point(0, 25);
                ctrl.Text = text;
                ctrl.Opacity = 1;
                ctrl.FontColor = Brushes.LightPink;
                ctrl.BackColor = null;
                ctrl.SetPlusMove(new Point(0, -50), 1.5);
                ctrl.SetPlusOpacity(-1, 1.5);
                ctrl.Start();
            });
        }
        public void ShowDamage(int num, BioView bio) {
            ShowDamage(num.ToString(), bio);
        }
        public void ShowSkill(BioView bio,Skill skill) {
            var locs = MapView.FindElement(bio.GetHashCode(), skill.EffectRegion);
            foreach (var it in locs) {
                MapView.ShowControl(delegate(IAnimateControl ctrl) {
                    ctrl.Size = new Size(32, 32);
                    ctrl.Location = Bios[it].Location + new Point(8, 8);
                    ctrl.Opacity = 1;
                    ctrl.Image = skill.ItemImage;
                    ctrl.SetOpacity(0, 0.5);
                    ctrl.Start();
                });
            }
        }
        protected void Picked(BioView bio, IEnumerable<int> stuffIds) {
           foreach(var it in stuffIds){
               bio.Gived(Stuffs[it]);
           }
        }
        private bool CanAttack(Bio bio1, Bio bio2) {
            if ((((int)bio1.IDGroup)| ((int)bio2.IDGroup))== 3) {
                return true;
            }
            return false;
        }
        public MatrixPoint FindUserLocation() {
            //TODO:
            MatrixPoint point;
            var bio = Bios.Where((x) => x.Value.Name == "maid").ElementAtOrDefault(0);
            if (bio.Value == null) return new MatrixPoint(0, 0);
            MapView.BiosLocation.TryGetValue(bio.Value.GetHashCode(), out point);
            return point;
        }
        public MatrixPoint GetLocation(BioView bio) {
            MatrixPoint loc;
            MapView.BiosLocation.TryGetValue(bio.GetHashCode(),out loc);
            return loc;
        }
    }
    
}
