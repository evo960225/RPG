using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Threading.Tasks;
using hoshi_lib.View;
using System.Threading;

namespace hoshi_lib.Threading {

    public class Timer {

        private BackgroundWorker bgWorker;
        private Action toDO;
        public int MilsecSpeed;
        public bool Enable{get; set;}


        public Timer(Action action, int milsecSpeed = 1000) {
            this.MilsecSpeed = milsecSpeed;
            bgWorker = new BackgroundWorker();
            bgWorker.DoWork += bgwoker_DoWork;
            bgWorker.ProgressChanged += bgwoker_ProgressChanged;
        }
        public void Start() {
            bgWorker.RunWorkerAsync();
        }
        public void SetAction(Action toDO) {
            this.toDO = toDO;
        }
        public void AddAction(Action toDO) {
            this.toDO += toDO;
        }
        

        void bgwoker_DoWork(object sender, DoWorkEventArgs e) {
            bgWorker.WorkerReportsProgress = true;
            while (Enable) {
                if (bgWorker.WorkerReportsProgress)
                    bgWorker.ReportProgress(0);
                System.Threading.Thread.Sleep(MilsecSpeed);
            }
            bgWorker.WorkerReportsProgress = false;
        }
        void bgwoker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            toDO();
        }
    }

    public class SleepAfterDo{

        private BackgroundWorker bgWorker;
        private Action toDO;
        public int MilsecSpeed;

        public SleepAfterDo(int milsecSpeed, Action action,bool start=false) {
            this.MilsecSpeed = milsecSpeed;
            this.toDO = action;
            bgWorker = new BackgroundWorker();
            bgWorker.DoWork += bgwoker_DoWork;
            if (start) {
                Start();
            }
        }
        public void Start() {
            bgWorker.RunWorkerAsync();
        }
        public void SetAction(Action toDO) {
            this.toDO = toDO;
        }
        public void AddAction(Action toDO) {
            this.toDO += toDO;
        }

        void bgwoker_DoWork(object sender, DoWorkEventArgs e) {
            Thread.Sleep(MilsecSpeed);
            toDO();
        }

    }

}
