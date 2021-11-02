using System;
namespace hoshi_lib.View {
    interface ITitleScreen : IScreen {
        void AddButtonClickEvent(int index, System.Windows.Input.MouseButtonEventHandler eventHandler);
        IHButton[] Buttons { get; }
        void CreateButtons(int count, params string[] names);
        void CreateTitle(string text);
        void SetStandardSytle();
        IHControl title { get; }
    }
}
