using Zmeika2;

namespace ConsoleApp1;

public class FoodGenerator
{
    private static readonly Random Random = new Random();
    private static readonly ConsoleColor FoodColor = ConsoleColor.Blue;

    public static Pixel Generate(Snake snake, GameBoard gameBoard)
    {
        Pixel food;

        do
        {
            food = new Pixel(Random.Next(1, gameBoard.GetBoardWidth() - 2), Random.Next(1, gameBoard.GetBoardHeight() - 2), FoodColor);
        } while (snake.Head.X == food.X && snake.Head.Y == food.Y
        || snake.Body.Any(b => b.X == food.X && b.Y == food.Y));

        return food;
    }
}
