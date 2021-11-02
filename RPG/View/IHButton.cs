using System;
namespace hoshi_lib.View {
    public interface IHButton:IHControl {
        void AddClickEvent(System.Windows.Input.MouseButtonEventHandler eh);
        void AddEnterEvent(System.Windows.Input.MouseEventHandler eh);
        void AddLeaveEvent(System.Windows.Input.MouseEventHandler eh);
        System.Windows.Media.Brush ClickBrush { get; set; }
        System.Windows.Media.Brush EnterBrush { get; set; }
        void InitBrush(System.Windows.Media.Brush brush = null);
        void InitStateEvent();
        System.Windows.Media.Brush LeaveBrush { get; set; }
    }
}
