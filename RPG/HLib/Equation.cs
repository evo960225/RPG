using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoshi_lib {
    public delegate bool Equation2<in numType>(numType x,numType y );
    public delegate bool Equation3<in numType>(numType x, numType y, numType z);
    
}
