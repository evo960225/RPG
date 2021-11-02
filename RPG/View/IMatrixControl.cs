using hoshi_lib.HLib;
using System;
namespace hoshi_lib.View {
    public interface IMatrixControl:IHControlCollection {
        IHControl[,] Controls { get; set; }
        string[,] Description { get; set; }
        MatrixSize MatrixSize { get; }
        IHControl PopupView { get; set; }

        IHControl GetItem(int number);
        void SetColor(System.Windows.Media.Brush brush, Func<int, int, bool> equation = null);
        void SetDescription(params string[] text);
        void SetDescription(string text, Func<int, int, bool> equation = null);
        void SetDoing(Action<IHControl> doing, Func<int, int, bool> equation = null);
        void SetImage(System.Windows.Media.Imaging.BitmapImage bmp, Func<int, int, bool> equation = null);
        void SetText(params string[] text);
        void SetText(string text, Func<int, int, bool> equation = null);
    }
    public interface IMatrixControl<T> :IHControlCollection where T : IHoshiView {
        T[,] Controls { get; set; }
        string[,] Description { get; set; }
        MatrixSize MatrixSize { get; }
        IHControl PopupView { get; set; }

        T GetItem(int number);
        void SetColor(System.Windows.Media.Brush brush, Func<int, int, bool> equation = null);
        void SetDescription(params string[] text);
        void SetDescription(string text, Func<int, int, bool> equation = null);
        void SetDoing(Action<T> doing, Func<int, int, bool> equation = null);
        void SetImage(System.Windows.Media.Imaging.BitmapImage bmp, Func<int, int, bool> equation = null);
   
    }
}
