﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoshi_lib.Game {
    interface IObeserve<beObserve> {
        void Observe(beObserve view);
    }
}
