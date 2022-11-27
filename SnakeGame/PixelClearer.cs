using SnakeGame.Models;

namespace SnakeGame;

public class PixelClearer : ISpecificClearable
{
    public void Clear(Pixel pixel)
    {
        for (int x = 0; x < pixel.Size; x++)
        {
            for (int y = 0; y < pixel.Size; y++)
            {
                Console.SetCursorPosition(pixel.X * pixel.Size + x, pixel.Y * pixel.Size + y);
                Console.Write(' ');
            }
        }
    }
}


