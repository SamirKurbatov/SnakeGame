using SnakeGame.Interfaces;
using SnakeGame.Models;

namespace SnakeGame;

public class SnakePixelClearer : IClearable<Snake, PixelClearer>
{
    public void Clear(Snake snake, PixelClearer pixelClearer)
    {
        pixelClearer.Clear(snake.Head);

        foreach (var bodyPixel in snake.Body)
        {
            pixelClearer.Clear(bodyPixel);
        }
    }
}


