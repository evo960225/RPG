using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoshi_lib.View {
    public interface IDynamicAction {
        void AddBGAction(Action action, Func<bool> condition = null, Action end = null, int? timeSpan = null);
        void BackgroundLoop(Action toDo, Func<bool> condition, Action end, int timeSpan);
        void BackgroundLoop(Action toDo, int times, Action end, int timeSpan);
    }
    public interface IDynamicObject : IDynamicAction {
        void BackgroundLoop(Action toDo, Func<bool> condition, int timeSpan, bool endDelete);
        void BackgroundLoop(Action toDo, int times, int timeSpan, bool endDelete);
    }
}
