using System.Windows.Media.Imaging;

namespace hoshi_lib.Game {
    public interface IGameItem : IGameObject {
        BitmapImage ItemImage { get; set; }
    }
}
