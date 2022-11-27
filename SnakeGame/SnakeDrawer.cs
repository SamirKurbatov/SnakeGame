using SnakeGame.Models;

namespace SnakeGame;

public class SnakePixelDrawer : BaseDrawer<Snake, PixelDrawer>
{
    public override void Draw(Snake snake, PixelDrawer pixelDrawer)
    {
        pixelDrawer.Draw(snake.Head);

        foreach (var bodyPixel in snake.Body)
        {
            pixelDrawer.Draw(bodyPixel);
        }
    }
}
