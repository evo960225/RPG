using System;
using System.Threading.Tasks;
using System.Threading;
using hoshi_lib.Game.Texture2D;
using System.ComponentModel;

namespace hoshi_lib.Game {

    public class AIBio : BattleBio {
        public int spantime = 500;
        private BackgroundWorker bgWorker;
        private Random randomDirection = new Random();
        public Location LocationInGrid;

        public AIBio(BattleBioValues values, BioView view)
            : base(values, view) {
            this.bgWorker = new BackgroundWorker();
            this.bgWorker.DoWork += bgWorker_DoWork;
            this.bgWorker.ProgressChanged += bgWorker_ProgressChanged;
            this.bgWorker.RunWorkerCompleted += bgWorker_RunWorkerCompleted;
            this.bgWorker.RunWorkerAsync();
        }
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e) {
            bgWorker.WorkerReportsProgress = true;
            for (; ; ) {
                bgWorker.ReportProgress(0);
                Thread.Sleep(spantime);
            }
        }
        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            switch (randomDirection.Next(4)) {
                case 0: this.MoveLeft(); break;
                case 1: this.MoveUp(); break;
                case 2: this.MoveDown(); break;
                case 3: this.MoveRight(); break;
            }
        }
        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {

        }

        public void StartRandomMove() {
            bgWorker.DoWork += bgWorker_DoWork;
            bgWorker.ProgressChanged += bgWorker_ProgressChanged;
            bgWorker.RunWorkerAsync();
        }
    }
}
