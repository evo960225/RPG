using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace hoshi_lib.View {


    public class Menu : HControlCollection {

        HControl[] Buttons; 

        public Menu(int buttonsCount) {
            CreateButtons(buttonsCount);   
            this.Size = new Size(400, 500);
            Array.ForEach(Buttons, x => x.Size = new Size(100, 30));

            ScreenLayout.ControlHCenterVMargin(Size, Buttons, 25, 150);
        }

        private void CreateButtons(int count, params string[] names) {
            Buttons = new HControl[count];
            try {
                for (int i = 0; i < count; ++i) {
                    Buttons[i] = new HControl();
                    if (names.Length!=0)
                        Buttons[i].Text = names[i];
                    AddHControl(Buttons[i]);
                }
            } catch {
                MessageBox.Show("Err:HControl.Create");
            }

        }
       
        
    }
}
