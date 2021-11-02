using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace hoshi_lib.View {
    public class TitleScreen : Screen, hoshi_lib.View.ITitleScreen {

        public IHControl title { get; private set; }
        public IHButton[] Buttons { get; private set; }
  
        public TitleScreen(Size size,string title= null)
            :base( size ){
            
            CreateTitle(title);
        }
        HControl ti;
        public void AddButtonClickEvent(int index, MouseButtonEventHandler eventHandler) {
            Buttons[index].AddClickEvent(eventHandler);
        }
        public void CreateButtons(int count,params string[] names) {
            
            if (count == 0) return;
            
            Buttons = new HButton[count];
            for (int i = 0; i < count; ++i) {
                Buttons[i] = new HButton();
                if (i < names.Length)
                    Buttons[i].Text = names[i];
                AddHControl(Buttons[i]);
            }
        }
        public void CreateTitle(string text) {
             
            ti = new HControl() { Size = new Size(100, 100) };
            title=ti;
            title.Text = text;
            AddHControl(title);
        }
        public void SetStandardSytle() {
            title.Size = new Size(300, 40);
            title.Font = new FontFamily("微軟正黑體");
            title.FontSize = 24.0;
            title.BackColor = Brushes.Aqua;
            ControlAligner.HAlignMiddle(Size, title);
            title.Location = new Point(title.Location.X, 100);
            if (Buttons != null) {
                Array.ForEach(Buttons, x => x.Size = new Size(200, 40));
                ControlAligner.VAlignSpan(Buttons, 300, 30);
                ControlAligner.HAlignMiddle(Size,Buttons);
            }
           
        }

     
    }

}
