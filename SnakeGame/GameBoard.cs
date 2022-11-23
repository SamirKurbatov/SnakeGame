namespace SnakeGame;

public sealed class GameBoard
{
    private static GameBoard _initalize;

    private GameBoard() { }

    private static GameBoardDrawer _gameBoardDrawer = new(); 
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

    public static void ConfigureBoard()
    {
        Console.SetWindowSize(_screenWidth, _screenHeight);
        Console.SetBufferSize(_screenWidth, _screenHeight);
        Console.CursorVisible = false;
    }

    public static GameBoard Initialize()
    {
        if (_initalize == null)
        {
            return new GameBoard();
        }
        return _initalize;
    }
}
