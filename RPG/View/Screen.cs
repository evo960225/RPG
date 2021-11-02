using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace hoshi_lib.View {
    public class Screen : HControlCollection, IScreen {

        public Screen(Size size) {
            this.Size = size;
        }
        public void NextScreen(Screen screen){
            
        }

    }
}
