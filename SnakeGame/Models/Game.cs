using SnakeGame.Inerfaces;
using System.Diagnostics;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;

namespace SnakeGame.Models;

internal class Game
{
    public Game()
    {
        _foodGenerator = new(_gameBoard);
        ICreate<Snake> creator = new SnakeCreatorByConsole();
        _snake = creator.Create();
    }

    private const int FrameMs = 200;

    private readonly PixelDrawer _pixelDrawer = new();
    private readonly SnakePixelDrawer _snakePixelClearer = new();
    private readonly GameBoardDrawer _gameBoardDrawer = new();
    private readonly Snake _snake;
    private readonly GameBoard _gameBoard = new();
    private readonly FoodGenerator _foodGenerator;

    public void Start()
    {
        var score = 0;
        var isContiniue = true;
        var currentMovement = Direction.Right;
        _gameBoardDrawer.Draw(_gameBoard, _pixelDrawer);
        var food = _foodGenerator.Generate(_snake);
        _pixelDrawer.Draw(food);
        Stopwatch stopwatch = new();
        while (isContiniue)
        {
            stopwatch.Restart();
            var oldMovement = currentMovement;

            while (stopwatch.ElapsedMilliseconds <= FrameMs)
            {
                if (currentMovement == oldMovement)
                {
                    currentMovement = ReadMovement(currentMovement);
                }
            }

            if (_snake.Head.X == food.X && _snake.Head.Y == food.Y)
            {
                _snake.Move(currentMovement, true);
                food = _foodGenerator.Generate(_snake);
                _pixelDrawer.Draw(food);
                score++;
            }
            else
            {
                _snake.Move(currentMovement);
            }

            if (Collision())
            {
                break;
            }
        }
        _snakePixelClearer.Clear(_snake, _pixelDrawer);
        Console.SetCursorPosition(_gameBoard.ScreenWidth / 3, _gameBoard.ScreenHeight / 3);
        Console.Write($"Game over! Ваши очки {score}");
        Console.ReadKey();
    }

    private bool Collision()
    {
        bool isSnakeHeadXOverGameBoard = _snake.Head.X == 0 || _snake.Head.X == _gameBoard.BoardWidth - 1;
        if (isSnakeHeadXOverGameBoard) return true;
        bool isSnakeHeadYOverGameBoard = _snake.Head.Y == 0 || _snake.Head.Y == _gameBoard.BoardHeight - 1;
        if (isSnakeHeadYOverGameBoard) return true;
        bool isSnakeBodyOverGameBoard = _snake.Body.Any(b => b.X == _snake.Head.X && b.Y == _snake.Head.Y);
        if (isSnakeBodyOverGameBoard) return true;

        return false;
    }

    private static Direction ReadMovement(Direction currentDirection)
    {
        if (Console.KeyAvailable == false)
        {
            return currentDirection;
        }
        ConsoleKey key = Console.ReadKey(true).Key;

        currentDirection = key switch
        {
            ConsoleKey.UpArrow when currentDirection != Direction.Down => Direction.Up,
            ConsoleKey.DownArrow when currentDirection != Direction.Up => Direction.Down,
            ConsoleKey.LeftArrow when currentDirection != Direction.Right => Direction.Left,
            ConsoleKey.RightArrow when currentDirection != Direction.Left => Direction.Right,
            _ => currentDirection
        };

        return currentDirection;
    }
}
