using SnakeGame.Inerfaces;
using SnakeGame.Interfaces;
using SnakeGame.Models;

namespace SnakeGame;

public class SnakePixelDrawer : IDrawble<Snake>
{
    public void Clear(Snake snake, PixelDrawer pixelClearer)
    {
        pixelClearer.Clear(snake.Head);

        foreach (var bodyPixel in snake.Body)
        {
            pixelClearer.Clear(bodyPixel);
        }
    }

    public void Draw(Snake snake, PixelDrawer pixelDrawer)
    {
        pixelDrawer.Draw(snake.Head);

        foreach (var bodyPixel in snake.Body)
        {
            pixelDrawer.Draw(bodyPixel);
        }
    }
}


