namespace SnakeGame;

public abstract class BaseSpecificDrawer<T> : ISpecificDrawble<T>
{
    public abstract void Draw(T pixel);
}
