using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoshi_lib.Game.RPG {
    public struct CapacityPoint {
   
        public int Point {
            get { return point; }
            set { point = HMath.ValueInRange(value, 0, Max); }
        }
        public BasePlus Max {
            get { return max; }
            set{
                if (value >= 0) max = value;
            }
        }

        private BasePlus max;
        private int point;

        public CapacityPoint(int point, BasePlus limit) {

            this.point = HMath.ValueInRange(point, 0, limit.Value);
            max = limit;

        }
        public void Increase(int val) {
            Point += val;
        }
        public void Decrease(int val) {
            Point -= val;
        }
        public void IncreaseOverMax(int val) {
            point += val;
        }
        static public int operator +(CapacityPoint val, int val2) {
            return val.point + val2;
        }
        static public CapacityPoint operator +(CapacityPoint val, CapacityPoint val2) {
            return new CapacityPoint(val.point + val2.point, val.Max + val2.Max);
        }
        static public int operator -(CapacityPoint val, int val2) {
            return val.point - val2;
        }
        static public CapacityPoint operator -(CapacityPoint val, CapacityPoint val2) {
            return new CapacityPoint(val.point - val2.point, val.Max - val2.Max);
        }
        static public int operator *(CapacityPoint val, int val2) {
            return val.point * val2;
        }
        static public int operator /(CapacityPoint val, int val2) {
            return val.point / val2;
        }
        static public bool operator >(CapacityPoint val, int val2) {
            return val.point > val2;
        }
        static public bool operator >(CapacityPoint val, CapacityPoint val2) {
            return val.point > val2.point;
        }
        static public bool operator <(CapacityPoint val, int val2) {
            return val.point < val2;
        }
        static public bool operator <(CapacityPoint val, CapacityPoint val2) {
            return val.point < val2.point;
        }

        override public string ToString() {
            return Max.Base.ToString()+" + " + Max.Plus + " = " + Point.ToString() + " / " + Max.Value.ToString();
        }
    }
}
