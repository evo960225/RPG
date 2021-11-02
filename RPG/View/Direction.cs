
namespace hoshi_lib.View {
    public enum Direction {
        Left = 1 << 0,
        Up = 1 << 1,
        Down = 1 << 2,
        Right = 1 << 3,
        Front = 1 << 4,
        Back = 1 << 5,
        LeftUp = Left | Up,
        LeftDown = Left | Down,
        RightUp = Right | Up,
        RightDown = Right | Down
    }
}
