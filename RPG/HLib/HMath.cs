using System;
using System.Windows;

namespace hoshi_lib {
    static public class HMath {
        static public int ValueInRange(int value, int min, int max) {
            if (min > max) {
                MessageBox.Show("RangeError");
                throw new Exception("RangeError");
            } else if (value < min) {
                return min;
            } else if (value > max) {
                return max;
            } else {
                return value;
            }
        }
    }
}
