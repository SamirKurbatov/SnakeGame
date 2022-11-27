namespace SnakeGame.Inerfaces
{
    internal interface IDrawble<T,K>
    {
        void Draw(T firstValue, K secondValue);
    }
}