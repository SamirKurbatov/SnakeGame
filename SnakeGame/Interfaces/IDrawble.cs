namespace SnakeGame.Inerfaces
{
    internal interface IDrawble<T, K>
    {
        void Draw(T firstValue, K pixelDrawer);
        void Clear(T firstValue, K pixelDrawer);
    }
}