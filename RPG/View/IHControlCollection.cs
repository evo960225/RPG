using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace hoshi_lib.View {
    public interface IHControlCollection : IHoshiView<Grid> {

        
        bool Visible { get; set; }
        
        void AddControl(UIElement control);
        void AddHControl(IHoshiView control);
        void AddHControl(IHControl control);
        void AddHControl(IHControlCollection collection);

        void RemoveControl(UIElement control);
        void RemoveHControl(IHoshiView control);
        void RemoveHControl(IHControl control);
        void RemoveHControl(IHControlCollection collection);


    }
}
