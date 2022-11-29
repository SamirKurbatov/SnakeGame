namespace SnakeGame.Inerfaces;

internal interface IDrawble<T>
{
    void Draw(T abstraction, PixelDrawer abstractionDrawer);
    void Clear(T abstraction, PixelDrawer abstractionDrawer);
}