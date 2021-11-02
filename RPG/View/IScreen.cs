using System;
namespace hoshi_lib.View {
    public interface IScreen:IHControlCollection {
        void NextScreen(Screen screen);
    }
}
