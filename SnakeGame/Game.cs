using ConsoleApp1;
using System.Diagnostics;

namespace Zmeika2;

internal class Game
{
    private const int FrameMs = 200;


    public static void Start()
    {
        var gameBoard = GameBoard.Initialize();
        var score = 0;
        gameBoard.DrawBoard();
        var currentMovement = Direction.Right;
        var snake = SnakeCreator.Create();
        var food = FoodGenerator.Generate(snake, gameBoard);
        food.Draw();
        Stopwatch sw = new();
        while (true)
        {
            sw.Restart();
            var oldMovement = currentMovement;

            while (sw.ElapsedMilliseconds <= FrameMs)
            {
                if (currentMovement == oldMovement)
                {
                    currentMovement = ReadMovement(currentMovement);
                }
            }

            if (snake.Head.X == food.X && snake.Head.Y == food.Y)
            {
                snake.Move(currentMovement, true);
                food = FoodGenerator.Generate(snake, gameBoard);
                food.Draw();
                score++;
            }
            else
            {
                snake.Move(currentMovement);
            }

            if (snake.Head.X == 0
            || snake.Head.X == gameBoard.GetBoardWidth() - 1
            || snake.Head.Y == 0
            || snake.Head.Y == gameBoard.GetBoardHeight() - 1
            || snake.Body.Any(b => b.X == snake.Head.X && b.Y == snake.Head.Y))
            {
                break;
            }
        }

        snake.Clear();

        Console.SetCursorPosition(gameBoard.GetScreenWidth() / 3, gameBoard.GetScreenHeight() / 3);
        Console.Write("Game over! ");
        Console.ReadKey();
    }


    static Direction ReadMovement(Direction currentDirection)
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
