using System.Collections;

namespace SnakeGame;

public class Snake : IEnumerable<Pixel>
{
    private List<Pixel> _parts = new();

    private PixelDrawer _pixelDrawer = new();

    public Snake(int initialX, int initialY, ConsoleColor headColor, ConsoleColor bodyColor, int bodyLength = 3)
    {
        InitialX = initialX;
        InitialY = initialY;
        HeadColor = headColor;
        BodyColor = bodyColor;
        BodyLength = bodyLength;

        
        _pixelDrawer.Draw(Head);
    }

    public Snake()
    {

    }

    public ConsoleColor HeadColor { get; private set; }

    public ConsoleColor BodyColor { get; private set; }

    public int BodyLength { get; private set; }

    public int InitialX { get; private set; }

    public int InitialY { get; private set; }

    public Pixel Head { get; set; }

    public Queue<Pixel> Body { get; } = new();

    //public void Move(Direction direction, bool eat = false)
    //{
    //    Clear();

    //    Body.Enqueue(new Pixel(Head.X, Head.Y, _bodyColor));
    //    if (eat == false)
    //    {
    //        Body.Dequeue();
    //    }

    //    Head = direction switch
    //    {
    //        Direction.Right => new Pixel(Head.X + 1, Head.Y, _headColor),
    //        Direction.Left => new Pixel(Head.X - 1, Head.Y, _headColor),
    //        Direction.Up => new Pixel(Head.X, Head.Y - 1, _headColor),
    //        Direction.Down => new Pixel(Head.X, Head.Y + 1, _headColor),
    //        _ => Head
    //    };

    //    Draw();
    //}



    //public void Clear()
    //{
    //    Head.Clear();

    //    foreach (var pixel in Body)
    //    {
    //        pixel.Clear();
    //    }
    //}

    public void Add(Pixel part)
    {
        _parts.Add(part);
    }

    public IEnumerator<Pixel> GetEnumerator()
    {
        foreach (var part in _parts)
        {
            yield return part;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
