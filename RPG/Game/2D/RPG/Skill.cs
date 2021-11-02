using hoshi_lib.Game.RPG;
using hoshi_lib.HLib;
using hoshi_lib.View;
using System;
using System.Windows.Media.Imaging;
using hoshi_lib.Game;
namespace hoshi_lib.Game._2D.RPG {
    public class Skill : ICoolDown, IUsed, IGameItem {

        /// <summary>
        /// Image格式化路徑字串，{0}為ID、{1}為Name
        /// </summary>
        static public string RelatDirectoryFormat {
            get { return relatDirectoryFormat; }
            set { relatDirectoryFormat = value; }
        }
        static public string relatDirectoryFormat = "";

        
        public event UsedEventH UsedEvent {
            add { usedEvent += value; }
            remove { usedEvent -= value; }
        }
        
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public BitmapImage ItemImage { get; set; }

        public int Lv { get; set; }
        public int CostSp { get; set; }
        public double CD { get; set; }
        public bool IsCD {
            get { return timer.IsEnabled; }
        }

        public Func<MatrixPoint, MatrixPoint, bool> EffectRegion { get; set; }

        private HTimer timer = new HTimer(15);
     
        private double cdSec = 0;
        private Func<Skill, BattleValue, int> function;
        private UsedEventH usedEvent;

        public int GetDamage(BattleValue vaule) {
            return function(this, vaule);
        }
        public Skill(int id, string name, Bio user, Func<Skill, BattleValue, int> func) {
            this.ID = id;
            this.Name = name;
            this.function = func;

            timer.Tick += delegate {
                --cdSec;
                if (cdSec <= 0) {
                    timer.Stop();
                }
            };
            LoadImage();
        }
        public void Used(Bio bio) {
            var isok = !IsCD && bio.BattleValue.SP.Point >= CostSp;
            if (isok) {
                bio.BattleValue.SPDecrease(CostSp);
                cdSec = CD * 64;
                timer.Start();
                bio.World.AttackCommand(bio, this);
            }
            if (usedEvent != null) usedEvent(isok);
        }
        public override string ToString() {
            return "消耗SP:" + CostSp + "\n" +
                   "冷卻時間:" + CD.ToString() + "\n";
        }
        private void LoadImage() {
            string filename;
            filename = string.Format(RelatDirectoryFormat, ID, Name);
            if (System.IO.File.Exists(filename))
                ItemImage = new BitmapImage(new Uri(filename, UriKind.Relative));
        }
    }

  

   
   
}
