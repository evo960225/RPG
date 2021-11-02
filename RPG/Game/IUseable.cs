
using hoshi_lib.Game._2D;
namespace hoshi_lib.Game {
    public delegate void UsedEventH(bool isused);
    public interface IUsed {
        void Used(Bio bio);
        event UsedEventH UsedEvent;
    }
}
