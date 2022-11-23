using System;
using System.Xml.Linq;
using SnakeGame.Inerfaces;

namespace SnakeGame;

abstract class BaseDrawer<T> : IDrawble<T>
{
    public abstract void Draw(T value);
}

class PixelDrawer : BaseDrawer<Pixel>
{
    public override void Draw(Pixel pixel)
    {
        for (int x = 0; x < pixel.Size; x++)
        {
            for (int y = 0; y < pixel.Size; y++)
            {
                Console.SetCursorPosition(pixel.X * pixel.Size + x, pixel.Y * pixel.Size + y);
            }
        }
    }
}

class GameBoardDrawer : BaseDrawer<GameBoard>
{
    private PixelDrawer _pixelDrawer = new();

    public override void Draw(GameBoard gameBoard)
    {
        for (int i = 0; i < gameBoard.BoardWidth; i++)
        {
            _pixelDrawer.Draw(new Pixel(i, 0, gameBoard.BorderColor));
            _pixelDrawer.Draw(new Pixel(i, gameBoard.BoardHeight - 1, gameBoard.BorderColor));
        }

        for (int i = 0; i < gameBoard.BoardHeight; i++)
        {
            _pixelDrawer.Draw(new Pixel(0, i, gameBoard.BorderColor));
            _pixelDrawer.Draw(new Pixel(gameBoard.BoardWidth - 1, i, gameBoard.BorderColor));
        }
    }
}

class SnakeDrawer : BaseDrawer<Snake>
{
    private PixelDrawer _pixelDrawer = new();

    public override void Draw(Snake value)
    {
        _pixelDrawer.Draw(value.Head);

        foreach (var bodyPixel in value.Body)
        {
            _pixelDrawer.Draw(bodyPixel);
        }
    }
}

abstract class BaseBuilder<T> : IBuild<T>
{
    public abstract void FirstBuild();
    public abstract void SecondBuild();
    public abstract T GetResult();
}


public class SnakeCreator
{
    public static Snake Create()
    {
        var bodyColor = GetRandomColor();
        var headColor = GetRandomColor();
        Console.Write("Введите начальную позицию X змеи: ");
        var initialX = int.Parse(Console.ReadLine());
        Console.Write("Введите конечную позицию Y: ");
        var initialY = int.Parse(Console.ReadLine());
        Console.Write("Введите длиную змеи: ");
        var bodyLenght = int.Parse(Console.ReadLine());
        return new Snake(initialX, initialY, headColor, bodyColor, bodyLenght);
    }

    private static ConsoleColor GetRandomColor()
    {
        var random = new Random();
        var consoleColors = Enum.GetValues(typeof(ConsoleColor));
        return (ConsoleColor)consoleColors.GetValue(random.Next(consoleColors.Length));
    }
}

class SnakeBuilder : BaseBuilder<Snake>
{
    private Snake _snake = SnakeCreator.Create();

    public override void FirstBuild() // Голова собирается
    {
        var head = _snake.Head = new Pixel(_snake.InitialX, _snake.InitialY, _snake.HeadColor);
        _snake.Add(head);
    }

    public override void SecondBuild() // Туловище собирается
    {
        for (int i = _snake.BodyLength; i >= 0; i--)
        {
            _snake.Body.Enqueue(new Pixel(_snake.Head.X - 1 - i, _snake.InitialY, _snake.BodyColor));
        }
    }

    public override Snake GetResult()
    {
        return new Snake(_snake.Head, _snake.Body);
    }
}

record Director(BaseBuilder<Snake> SnakeBuilder)
{
    public void Construct()
    {
        SnakeBuilder.FirstBuild();
        SnakeBuilder.SecondBuild();
    }
}

/*
 *  public void Clear()
    {

        for (int x = 0; x < Size; x++)
        {
            for (int y = 0; y < Size; y++)
            {
                Console.SetCursorPosition(X * Size + x, Y * Size + y);
                Console.Write(' ');
            }
        }
    }
 */
