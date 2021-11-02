using hoshi_lib.HLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoshi_lib.Game._2D {
    static class RegionMaker {
        static public Func<MatrixPoint, MatrixPoint, bool> Cross1() {
            return (p1, p2) => ((p1.Y == p2.Y && (p1.X == p2.X + 1 || p1.X == p2.X - 1)) || (p1.X == p2.X && (p1.Y == p2.Y + 1 || p1.Y == p2.Y - 1)));
        }
        static public Func<MatrixPoint, MatrixPoint, bool> Square1() {
            return delegate(MatrixPoint p1, MatrixPoint p2) {
                var x = p1.X - p2.X;
                var y = p1.Y - p2.Y;
                return x<=1 && x>=-1 && y<=1 && y>=-1 && !(x==0 && y==0);
            };
        }
    }
}
