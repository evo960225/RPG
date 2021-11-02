using System.Windows.Media;

namespace hoshi_lib.View {
    public interface IFont {
        FontFamily Font { get; set; }
        double FontSize { get; set; }
        Brush FontColor { get; set; }
        string Text { get; set; }
    }
}
