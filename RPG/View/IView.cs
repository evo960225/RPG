using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoshi_lib.View {
    public interface IView {
        Size Size { get; set; }
        Point Location { get; set; }
    }
}
