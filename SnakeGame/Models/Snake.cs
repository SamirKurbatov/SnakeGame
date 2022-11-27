using SnakeGame.Inerfaces;
using System.Collections;
using System.Xml.Linq;

namespace SnakeGame.Models;

public class Snake
{
    private readonly PixelDrawer _pixelDrawer = new();
    private readonly SnakePixelDrawer _snakePixelDrawer = new();

    public Snake(int initialX, int initialY, ConsoleColor headColor, ConsoleColor bodyColor, int bodyLength = 3)
    {
        InitialX = initialX;
        InitialY = initialY;
        HeadColor = headColor;
        BodyColor = bodyColor;
        BodyLength = bodyLength;

        Head = new Pixel(initialX, initialY, headColor);

        for (int i = bodyLength; i >= 0; i--)
        {
            Body.Enqueue(new Pixel(Head.X - 1 - i, initialY, bodyColor));
        }
     
        _pixelDrawer.Draw(Head);
    }

    public ConsoleColor HeadColor { get; private set; }

    public ConsoleColor BodyColor { get; private set; }

    public int BodyLength { get; private set; }

    public int InitialX { get; private set; }

    public int InitialY { get; private set; }

    public Pixel Head { get; private set; }

    public Queue<Pixel> Body { get; } = new();

    public void Move(Direction direction, bool eat = false)
    {
        _snakePixelDrawer.Clear(this, _pixelDrawer); // исправить

        Body.Enqueue(new Pixel(Head.X, Head.Y, BodyColor));
        if (eat == false)
        {
            Body.Dequeue();
        }

        Head = direction switch
        {
            Direction.Right => new Pixel(Head.X + 1, Head.Y, HeadColor),
            Direction.Left => new Pixel(Head.X - 1, Head.Y, HeadColor),
            Direction.Up => new Pixel(Head.X, Head.Y - 1, HeadColor),
            Direction.Down => new Pixel(Head.X, Head.Y + 1, HeadColor),
            _ => Head
        };
        _snakePixelDrawer.Draw(this, _pixelDrawer);
    }
}



