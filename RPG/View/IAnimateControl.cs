using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using hoshi_lib;
namespace hoshi_lib.View {
    public interface IAnimateControl:IHControl {
        bool IsWorking { get; }
        void SetImage(IEnumerable<BitmapImage> images, double sec);
        void SetMove(Point end, double sec);
        void SetOpacity(double end, double sec);
        void SetPlusMove(Point plus, double sec);
        void SetPlusOpacity(double plus, double sec);
        void SetPlusSize(Size plus, double sec);
        void SetResize(Size end, double sec);
        void Start();
        void StartImage(IEnumerable<BitmapImage> images, double sec);
        void StartMove(Point end, double sec);
        void StartOpacity(double end, double sec);
        void StartPlusMove(Point plus, double sec);
        void StartPlusOpacity(double plus, double sec);
        void StartPlusSize(Size plus, double sec);
        void StartResize(Size end, double sec);
        void Stop();
    }
}
