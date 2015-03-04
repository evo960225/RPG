using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace hoshi_lib.View {
    public class Screen : HControlCollection {


        public WindowController winCtrl { get; private set; }
        
        private Screen() {
            
        }
        public Screen(WindowController winCtrl, string title = "Window") {
            this.winCtrl = winCtrl;
            winCtrl.SetTitle(title);
            winCtrl.SetScreen(this);
        }

    }
}
