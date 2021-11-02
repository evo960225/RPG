using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace hoshi_lib.View {
    public interface IHoshiView<T> : IHoshiView {
        T This { get; }
    }
    public interface IHoshiView : IView {
        string Name { get; set; }
        FrameworkElement Net { get; }
        Brush BackColor { get; set; }
        BitmapImage Image { get; set; }
        Dispatcher Dispatcher { get; }
        double Opacity { get; set; }
        object Tag { get; set; }

        void AddRoutedEvent(RoutedEvent routeEvent, MouseButtonEventHandler mbEventHanler);
        void RemoveRoutedEvent(RoutedEvent routeEvent, MouseButtonEventHandler mbEventHanler);
        void AddMouseEvent(MouseEvent mEvent, MouseEventHandler addEventHandler);
        void AddMouseEvent(MouseButtomEvent mbEvent, MouseButtonEventHandler addEventHandler);
        void RemoveMouseEvent(MouseEvent mEvent, MouseEventHandler removeEventHandler);
        void RemoveMouseEvent(MouseButtomEvent mbEvent, MouseButtonEventHandler removeEventHandler);
    }
}
 