using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Reflection;
using System.Windows.Media.Imaging;
namespace hoshi_lib.View {
    public class AnimateControl : HControl, IAnimateControl {
        public bool IsWorking { get { return timer.IsEnabled; } }

        private HTimer timer;
        protected int timespan = 15;
        protected int fps { get { return 1000 / timespan; } }

        private EventHandler moveAction;
        private EventHandler deformAction;
        private EventHandler opacityAction;
        private EventHandler imageAction;


        public AnimateControl() {
            timer = new ConditionTimer();
            timer.Interval = TimeSpan.FromMilliseconds(timespan);
        }
        public AnimateControl(HTimer timer) {
            this.timer = timer;
            timespan = timer.Interval.Milliseconds;
        }

        public void Start() {
            timer.Start();
        }
        public void Stop() {
            timer.Stop();
        }

        public void StartMove(Point end, double sec) {
            if (timer.IsEnabled) {
                timer.Stop();
                timer.TickClear();
            }
            SetMove(end, sec);
            timer.Start();
        }
        public void StartResize(Size end, double sec) {
            if (timer.IsEnabled) {
                timer.Stop();
                timer.TickClear();
            }
            SetResize(end, sec);
            timer.Start();
        }
        public void StartOpacity(double end, double sec) {
            if (timer.IsEnabled) {
                timer.Stop();
                timer.TickClear();
            }
            SetOpacity(end, sec);
            timer.Start();
        }
        public void StartImage(IEnumerable<BitmapImage> images, double sec) {
            if (timer.IsEnabled) {
                timer.Stop();
                timer.TickClear();
            }
            SetImage(images, sec);
            timer.Start();
        }

        public void StartPlusMove(Point plus, double sec) {
            if (timer.IsEnabled) {
                timer.Stop();
                timer.TickClear();
            }
            this.SetPlusMove(plus, sec);
            timer.Start();
        }
        public void StartPlusSize(Size plus, double sec) {
            if (timer.IsEnabled) {
                timer.Stop();
                timer.TickClear();
            }
            this.SetPlusSize(plus, sec);
            timer.Start();
        }
        public void StartPlusOpacity(double plus, double sec) {
            if (timer.IsEnabled) {
                timer.Stop();
                timer.TickClear();
            }
            this.SetPlusOpacity(plus, sec);
            timer.Start();
        }

        public void SetMove(Point end, double sec) {
            SetPlusMove(end - this.Location, sec);
        }
        public void SetResize( Size end, double sec) {
            SetPlusSize(end - this.Size, sec);
        }
        public void SetOpacity( double end, double sec) {
            SetPlusOpacity(end - this.Opacity, sec);
        }
        public void SetImage(IEnumerable<BitmapImage> images, double sec) {
            if (images == null) return;
            int imageCount = images.Count();
            int switchCount = imageCount - 1;
            int frameCount = (int)(sec * fps);
            int imageIndex = 1;
            double subplus = switchCount * 1.0 / frameCount;
            double start = 0;
            this.Image = images.ElementAt(0);
            imageAction += delegate {
                if (frameCount <= 0) {
                    this.Image = images.ElementAt(imageCount - 1);
                    timer.Tick -= imageAction;
                    imageAction = null;
                    this.Stop();
                    return;
                }
                if ((int)start >= imageIndex && imageIndex != imageCount - 1) {
                    this.Image = images.ElementAt(imageIndex);
                    ++imageIndex;
                }
                start += subplus;
                --frameCount;
            };
        }
        public void SetPlusMove(Point plus, double sec) {
            Point end = this.Location + plus;
            int frameCount = (int)(sec * fps);
            double dx = plus.X * 1.0 / frameCount;
            double dy = plus.Y * 1.0 / frameCount;
            double curx = this.Location.X;
            double cury = this.Location.Y;
            
            moveAction += delegate {
                if (frameCount == 0) {
                    this.Location = end;
                    timer.Tick -= moveAction;
                    moveAction = null;
                    this.Stop();
                    return;
                }
                curx += dx; cury += dy;
                this.Location = new Point((int)curx, (int)cury);
                --frameCount;
            };
            timer.Tick += moveAction;
        }
        public void SetPlusSize(Size plus, double sec) {
            Size end = this.Size + plus;
            int frameCount = (int)(sec * fps);
            double dw = plus.Width * 1.0 / frameCount;
            double dh = plus.Height * 1.0 / frameCount;
            double curw = this.Size.Width;
            double curh = this.Size.Height;
            
            deformAction += delegate {
                if (frameCount <= 0) {
                    this.Size = end;
                    timer.Tick -= deformAction;
                    deformAction = null;
                    this.Stop();
                    return;
                }
                curw += dw;
                curh += dh;
                this.Size = new Size((int)curw, (int)curh);
                --frameCount;
            };
            timer.Tick += deformAction;
        }
        public void SetPlusOpacity(double plus, double sec) {
            int frameCount = (int)(sec * fps);
            double end = this.Opacity + plus;
            double sub = plus / frameCount;

            opacityAction += delegate {
                if (frameCount <= 0) {
                    this.Opacity = end;
                    timer.Tick -= opacityAction;
                    opacityAction = null;
                    this.Stop();
                    return;
                }
                this.Opacity += sub;
                --frameCount;
            };
            timer.Tick += opacityAction;
        }

    }
}
