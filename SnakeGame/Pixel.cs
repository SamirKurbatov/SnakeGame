namespace SnakeGame;

public readonly struct Pixel
{
    private const char _pixelImage = '█';
    public char PixelImage => _pixelImage;

    public Pixel(int x, int y, ConsoleColor color, int size = 3)
    {
        X = x;
        Y = y;
        Color = color;
        Size = size;
    }

    public int X { get; }

    public int Y { get; }

    public ConsoleColor Color { get; }

    public int Size { get; }

}
