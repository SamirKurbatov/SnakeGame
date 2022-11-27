namespace SnakeGame.Models;

public class GameBoard
{
    public GameBoard()
    {
        new GameBoardConfigurator().Configure(this);
    }

    private const ConsoleColor _borderColor = ConsoleColor.Gray;
    public ConsoleColor BorderColor => _borderColor;

    private const int _boardWidth = 30;
    public int BoardWidth => _boardWidth;

    private const int _boardHeight = 20;
    public int BoardHeight => _boardHeight;

    private const int _screenWidth = _boardWidth * 3;
    public int ScreenWidth => _screenWidth;

    private const int _screenHeight = _boardHeight * 3;
    public int ScreenHeight => _screenHeight;

}
