using SnakeGame.Inerfaces;

namespace SnakeGame;

internal abstract class BaseConfigurator<T> : IConfigure<T>
{
    public abstract void Configure(T abstraction);
}
