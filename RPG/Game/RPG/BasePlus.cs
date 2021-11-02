using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoshi_lib.Game.RPG {
    public struct BasePlus {
        public int Base { 
            get { return _base; }
            set { _base = value; }
        }
        public int Plus {
            get { return plus; }
            set { plus = value; }
        }
        public int Value { get { return Base + Plus; } }

        private int _base;
        private int plus;

        public BasePlus(int _base) {
            this._base = _base;
            this.plus = 0;
        }
  
        static public int operator +(BasePlus val, int val2) {
            return val.Value + val2;
        }
        static public int operator +(int val, BasePlus val2) {
            return val + val2.Value;
        }
        static public BasePlus operator +(BasePlus val, BasePlus val2) {
            var tmp = new BasePlus(val.Base + val2.Base);
            tmp.Plus = val.Plus + val2.Plus;
            return  tmp;
        }
        static public int operator -(BasePlus val, int val2) {
            return val.Value - val2;
        }
        static public int operator -(int val, BasePlus val2) {
            return val - val2.Value;
        }
        static public BasePlus operator -(BasePlus val, BasePlus val2) {
            var tmp = new BasePlus(val.Base - val2.Base);
            tmp.Plus = val.Plus - val2.Plus;
            return tmp;
        }
        static public int operator *(BasePlus val, int val2) {
            return val.Value * val2;
        }
        static public int operator /(BasePlus val, int val2) {
            return val.Value / val2;
        }
        static public bool operator >(BasePlus val, int val2) {
            return val.Value > val2;
        }
        static public bool operator >(BasePlus val, BasePlus val2) {
            return val.Value > val2.Value;
        }
        static public bool operator <(BasePlus val, int val2) {
            return val.Value < val2;
        }
        static public bool operator <(BasePlus val, BasePlus val2) {
            return val.Value < val2.Value;
        }

        static public implicit operator int(BasePlus val) {
            return val.Value;
        }
        override public string ToString() {
            return Base + " + " + Plus + " = " + Value;
        }
    }
}
