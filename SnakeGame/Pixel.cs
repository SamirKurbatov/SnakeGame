namespace Zmeika2;

public readonly struct Pixel
{
    private const char PixelImage = '█';

    public Pixel(int x, int y, ConsoleColor pixelColor, int pixelSize = 3)
    {
        X = x;
        Y = y;
        PixelColor = pixelColor;
        PixelSize = pixelSize;
    }
    public int X { get; }

    public int Y { get; }

    public ConsoleColor PixelColor { get; }

    public int PixelSize { get; }

    public void Draw()
    {
        Console.ForegroundColor = PixelColor;
        for (int x = 0; x < PixelSize; x++)
        {
            for (int y = 0; y < PixelSize; y++)
            {
                Console.SetCursorPosition(X * PixelSize + x, Y * PixelSize + y);
                Console.Write(PixelImage);
            }
        }
    }

    public void Clear()
    {

        for (int x = 0; x < PixelSize; x++)
        {
            for (int y = 0; y < PixelSize; y++)
            {
                Console.SetCursorPosition(X * PixelSize + x, Y * PixelSize + y);
                Console.Write(' ');
            }
        }
    }
}
