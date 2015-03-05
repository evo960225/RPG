using System.Windows;
using System.Windows.Input;
using hoshi_lib.View;

namespace hoshi_lib.Input {
    public class KeyDelegate {

        private WindowController win;
        private Screen screen;

        public delegate void KeyProcess();
        public delegate void KeyProcessArg(object obj);
        private KeyProcess[] keyProcess = new KeyProcess[(int)Key.DeadCharProcessed];

        public KeyDelegate(WindowController win) {
            this.win = win;
            KeyEventHandler KeyEH = Process;
            Keyboard.AddKeyDownHandler(win.GetWindow(), KeyEH);
        }

        public void AddEvent(Key key,KeyProcess keyProcessEventHandler) {
            keyProcess[(int)key] += keyProcessEventHandler;
        }
        public void RemoveEvent(Key key, KeyProcess keyProcessEventHandler) {
            try {
                keyProcess[(int)key] -= keyProcessEventHandler;
            }catch{
                MessageBox.Show(keyProcess.ToString());
            }
        }
        public void Process(object sender, KeyEventArgs e) {
            if (keyProcess[(int)e.Key] != null) {
                keyProcess[(int)e.Key]();
            }
        }
        
    }
}
