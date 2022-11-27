namespace SnakeGame.Models;

public class FoodGenerator
{
    public FoodGenerator(int boardWidth, int boardHeight, ConsoleColor foodColor = ConsoleColor.Red)
    {
        _boardWidth = boardWidth - _gapMargin;
        _boardHeight = boardHeight - _gapMargin;
        _foodColor = foodColor;
    }

    public FoodGenerator(GameBoard gameBoard, ConsoleColor foodColor = ConsoleColor.Red)
        : this(gameBoard.BoardWidth, gameBoard.BoardHeight, foodColor) { }

    private int _boardWidth;
    private int _boardHeight;
    private const int _gapMargin = 2;
    private readonly Random Random = new();
    private ConsoleColor _foodColor;
    public ConsoleColor FoodColor { get => _foodColor; set => _foodColor = value; }

    public Pixel Generate(Snake snake)
    {
        Pixel food;

        do
        {
            food = new Pixel(Random.Next(1, _boardWidth), Random.Next(1, _boardHeight), _foodColor);
        } while (snake.Head.X == food.X && snake.Head.Y == food.Y
        || snake.Body.Any(b => b.X == food.X && b.Y == food.Y));

        return food;
    }

    public Pixel Generate(Queue<Pixel> usedPixels)
    {
        Pixel food;

        do
        {
            food = new Pixel(Random.Next(1, _boardWidth), Random.Next(1, _boardHeight), _foodColor);
        } while (usedPixels.Any(b => b.X == food.X && b.Y == food.Y));

        return food;
    }
}
