using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Threading;
using System.ComponentModel;

namespace hoshi_lib.View {
    public class DynamicControl : HControl/*, IDynamicObject*/ {
        
        protected BackgroundWorker bgWorker { get; set; }
        private Action bgloop;
        private Func<bool> bgCondition;
        private Action bgEnd;

        protected int bgTimeSpan;
        protected int times;
        protected int severalTimes;
        protected bool condition;

        public DynamicControl() {
            InitBGWorker();
        }
        private void InitBGWorker() {
            bgWorker = new BackgroundWorker();
            bgWorker.DoWork += bgWorker_DoWork;
            bgWorker.ProgressChanged += bgWorker_ProgressChanged;
            bgWorker.RunWorkerCompleted += bgWorker_RunWorkerCompleted;
        }

        public void AddBGAction(Action loop, Func<bool> condition = null, Action end = null, int? timeSpan = null) {
            bgloop += loop;
            if (condition != null)
                bgCondition += condition;
            if (end != null)
                bgEnd += end;

            this.bgTimeSpan = timeSpan ?? this.bgTimeSpan;
        }
        public void BackgroundLoop(Action loop, Func<bool> condition, int timeSpan, bool endDelete = false) {
            if (!bgWorker.IsBusy) {
                this.bgloop = loop;
                this.bgCondition = condition;
                this.bgTimeSpan = timeSpan;
                bgWorker.RunWorkerAsync(this);
            }
            if (endDelete) {
                bgEnd=(()=>this.control.Visibility=0.0);
            }
        }
        public void BackgroundLoop(Action loop, Func<bool> condition, Action end, int timeSpan) {
            if (!bgWorker.IsBusy) {
                this.bgloop = loop;
                this.bgCondition = condition;
                this.bgEnd = end;
                this.bgTimeSpan = timeSpan;
                bgWorker.RunWorkerAsync(this);
            }
        }
        public void BackgroundLoop(Action loop, int times, int timeSpan, bool endDelete = false) {
            if (!bgWorker.IsBusy) {
                this.bgloop = loop;
                this.times = times;
                this.bgCondition = (() => ++severalTimes <= times);
                this.bgTimeSpan = timeSpan;
                bgWorker.RunWorkerAsync(this);
            }
            if (endDelete) {
                bgEnd = (() => this.control.Visibility = Visibility.Hidden);
            }
        }
        public void BackgroundLoop(Action loop, int times, Action end, int timeSpan) {
            if (!bgWorker.IsBusy) {
                this.bgloop = loop;
                this.times = times;
                this.bgCondition = (() => ++severalTimes <= times);
                this.bgEnd = end;
                this.bgTimeSpan = timeSpan;
                bgWorker.RunWorkerAsync(this);
            }
        }

        public void Run() {
            severalTimes = 0;
            bgWorker.RunWorkerAsync(this);
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e) {

            bgWorker.WorkerReportsProgress = true;
            condition = true;
            while (condition) {
                if (bgWorker.WorkerReportsProgress)
                    bgWorker.ReportProgress(0);
                Thread.Sleep(bgTimeSpan);
            }
            bgWorker.WorkerReportsProgress = false;
        }
        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            if (bgCondition()) {
                condition = true;
                bgloop();
            } else {
                condition = false;
            }
        }
        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            bgEnd();
        }
    }
}
