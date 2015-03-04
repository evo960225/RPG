using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace hoshi_lib.View {
    public class TitleScreen : Screen {

        public HControl Title { get; private set; }
        public HButton[] Buttons { get; private set; }
  
        public TitleScreen(WindowController winCtrl ,string title = "Window"):base(winCtrl,title) {
            CreateTitle(title);
        }

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
            Title = new HControl() { Size = new hoshi_lib.Size(100, 100) };
            Title.Text = text;
            AddHControl(Title);
        }

        public void SetStandardSytle() {
            Title.Size = new Size(300, 40);
            Title.Font = new FontFamily("微軟正黑體");
            Title.FontSize = 24;
            Title.BackColor = Brushes.Aqua;
            ScreenLayout.ControlHCenter(Size, Title, 100);
            Array.ForEach(Buttons, x => x.Size = new Size(200, 40));
            ScreenLayout.ControlHCenterVMargin(Size, Buttons, 25, 250);
        }
    }

}
