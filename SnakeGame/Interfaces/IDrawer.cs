namespace SnakeGame.Interfaces
{
    internal interface IDrawer<T>
    {
        void Draw(T pixel);
        void Clear(T pixel);
    }
}
