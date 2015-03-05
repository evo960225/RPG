using System;
using System.ComponentModel;
using System.Threading;

namespace hoshi_lib.Threading {
    public class BGWorker {

        private BackgroundWorker bg;
        public Action Start;
        public Action Loop;
        public Func<bool> Condition;
        public Action End;
        public bool Enable { 
            get { return bg.IsBusy; }
            set { if (!value)bg.CancelAsync(); }
        }

        public int MilsecTimeSpan;
        protected int times;
        protected int severalTimes;
        protected bool condition;

        public BGWorker(Action start=null,Action loop=null,Action end=null,Func<bool> condition=null,int timeSpan=1000) {
            bg = new BackgroundWorker();
            bg.DoWork += bg_DoWork;
            bg.ProgressChanged += bg_ProgressChanged;
            bg.RunWorkerCompleted += bg_RunWorkerCompleted;
            Start = start;
            Loop = loop;
            End = end;
            Condition = condition;
            MilsecTimeSpan = timeSpan;
        }

        public void Run() {
            severalTimes = 0;
            if(!bg.IsBusy)
                bg.RunWorkerAsync(this);
        }

        private void bg_DoWork(object sender, DoWorkEventArgs e) {
            if (Start != null) Start();
            bg.WorkerReportsProgress = true;
            condition = true;
            while (condition) {
                if (bg.WorkerReportsProgress)
                    bg.ReportProgress(0);
                Thread.Sleep(MilsecTimeSpan);
            }
            bg.WorkerReportsProgress = false;
        }
        private void bg_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            if (Condition()) {
                condition = true;
                Loop();
            } else {
                condition = false;
            }
        }
        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (End != null) End();
        }
    }
}
