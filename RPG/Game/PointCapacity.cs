using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoshi_lib.Game {
    public struct PointCapacity {

        private int point;
        public int Point {
            get { return point; }
            set { point = closeLimit ? HMath.ValueInRange(value, 0, MaxLimit) : value; }
        }
        public int MaxLimit;
        private bool closeLimit;

        public PointCapacity(int point, int limit, bool closeLimit = false) {

            this.closeLimit = closeLimit;

            try {
                this.point = HMath.ValueInRange(point, 0, limit);
                this.MaxLimit = limit;
            } catch {
                this.point = 0;
                this.MaxLimit = limit;
            }
        }

        static public PointCapacity operator +(PointCapacity self, int value) {
            return new PointCapacity(self.Point + value, self.MaxLimit);
        }
        static public PointCapacity operator -(PointCapacity self, int value) {
            return new PointCapacity(self.Point - value, self.MaxLimit);
        }
        override public string ToString() {
            return Point.ToString() + " / " + MaxLimit.ToString();
        }
    }
}
