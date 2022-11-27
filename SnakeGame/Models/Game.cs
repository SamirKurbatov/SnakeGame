using SnakeGame.Inerfaces;
using System.Diagnostics;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;

namespace SnakeGame.Models;

internal class Game
{
    private const int FrameMs = 200;

    private readonly SnakeCreator _snakeCreator = new();
    private readonly PixelDrawer _pixelDrawer = new();
    private readonly SnakePixelClearer _snakePixelClearer = new();
    private readonly PixelClearer _pixelClearer = new();
    private readonly GameBoardDrawer _gameBoardDrawer = new();
    private readonly GameBoard _gameBoard = new();

    public void Start()
    {
        var score = 0;
        var isContiniue = true;
        var currentMovement = Direction.Right;
        _gameBoardDrawer.Draw(_gameBoard, _pixelDrawer);
        var snake = _snakeCreator.Create();
        var food = FoodGenerator.Generate(snake, _gameBoard);
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

            if (snake.Head.X == food.X && snake.Head.Y == food.Y)
            {
                snake.Move(currentMovement, true);
                food = FoodGenerator.Generate(snake, _gameBoard);
                _pixelDrawer.Draw(food);
                score++;
            }
            else
            {
                snake.Move(currentMovement);
            }

            if (GameOver(snake, _gameBoard))
            {
                break;
            }
        }
        _snakePixelClearer.Clear(snake, _pixelClearer);
        Console.SetCursorPosition(_gameBoard.ScreenWidth / 3, _gameBoard.ScreenHeight / 3);
        Console.Write($"Game over! Ваши очки {score}");
        Console.ReadKey();
    }

    private bool GameOver(Snake snake, GameBoard gameBoard)
    {
        bool isSnakeHeadXOverGameBoard = snake.Head.X == 0 || snake.Head.X == gameBoard.BoardWidth - 1;
        bool isSnakeHeadYOverGameBoard = snake.Head.Y == 0 || snake.Head.Y == gameBoard.BoardWidth - 1;
        bool isSnakeBodyOverGameBoard = snake.Body.Any(b => b.X == snake.Head.X && b.Y == snake.Head.Y);

        if ((isSnakeBodyOverGameBoard || isSnakeHeadYOverGameBoard || isSnakeHeadXOverGameBoard) == false)
        {
            return false;
        }
        Console.Clear();
        return true;
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
