using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hoshi_lib.View;
using System.Threading;

namespace hoshi_lib.Input {
    public class KeyDelegate {
        public const int TimerSpan = 25;

        private Window win;
        private Screen screen;
        private HTimer checkKeyTimer = new HTimer();

        public delegate void KeyProcess();
        public delegate void KeyProcessArg(object obj);
        private KeyProcess[] keyProcess = new KeyProcess[(int)Key.DeadCharProcessed];
        private KeyProcess[] keyUp = new KeyProcess[(int)Key.DeadCharProcessed];
        private KeyProcess currentPressEvent = delegate { return; };
        private KeyProcess prePressEvent = delegate { return; };
        private bool[] pressed = new bool[(int)Key.DeadCharProcessed];
        private int pressedCount;

        public KeyDelegate(Window win) {
            this.win = win;
            checkKeyTimer.Interval = TimeSpan.FromMilliseconds(TimerSpan);
            checkKeyTimer.Tick += delegate {
                if (pressedCount <= 0) {
                    checkKeyTimer.Stop();
                    pressedCount = 0;
                }
                currentPressEvent();
            };
            
            KeyEventHandler KeyEH = Process;
            Keyboard.AddKeyDownHandler(win,KeyEH);
            Keyboard.AddKeyUpHandler(win, KeyUp);
            win.Deactivated += delegate {
                ClearPressed();
            };
        }
       
        public void AddEvent(Key key,KeyProcess keyProcessEventHandler) {
            keyProcess[(int)key] += keyProcessEventHandler;
        }                      
        public void AddPressEvent(Key key, KeyProcess keyProcessEventHandler) {
            
            keyProcess[(int)key] += delegate {
                if (!pressed[(int)key] && pressedCount<2) {
                    prePressEvent += keyProcessEventHandler;
                    currentPressEvent = keyProcessEventHandler;
                    pressed[(int)key] = true;
                    ++pressedCount;
                    checkKeyTimer.Start();
                }
                
            };
            keyUp[(int)key] += delegate {
                if (pressed[(int)key]) {
                    prePressEvent -= keyProcessEventHandler;
                    currentPressEvent = prePressEvent;
                    pressed[(int)key] = false;
                    pressedCount--;
                }
            };
                
        }

        public void RemoveEvent(Key key, KeyProcess keyProcessEventHandler) {
            try {
                keyProcess[(int)key] -= keyProcessEventHandler;
            }catch{
                MessageBox.Show(keyProcess.ToString());
            }
        }
        private void Process(object sender, KeyEventArgs e) {
            if (keyProcess[(int)e.Key] != null) {
                keyProcess[(int)e.Key]();
            }
        }
        private void KeyUp(object sender, KeyEventArgs e) {
            if (keyUp[(int)e.Key] != null) {
                keyUp[(int)e.Key]();
            }
        }
        private void ClearPressed() {
            pressedCount = 0;
            for (int i = 0; i < pressed.Length; ++i) {
                pressed[i] = false;
            }
        }
    }
}
